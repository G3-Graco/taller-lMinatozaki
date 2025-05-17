using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Core.Interfaces.Services;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces;
using System.Security.Cryptography;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Login(User userX)
        {
            Console.WriteLine($"Validandoooo {userX.UserName}, {userX.Password}");
            var userLog = await _unitOfWork.UserRepository.GetUser(userX.UserName, null);

            if (userLog == null || !VerifyPassword(userX.Password, userLog.Password))
            {
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("6f4d75aab32aef76b24c058d1bf7b979");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userLog.UserName),
                    new Claim("id", userLog.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }

        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                var enteredPasswordHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return enteredPasswordHash == storedPasswordHash;
            }
        }

        public async Task<bool> ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("6f4d75aab32aef76b24c058d1bf7b979");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> CreateUser(User newUser)
        {
            var existingUser = await _unitOfWork.UserRepository.GetByIdAsync(newUser.Id);
            if (existingUser != null)
            {
                throw new InvalidOperationException($"El ID {newUser.Id} ya está en uso");
            }

            var userByName = await _unitOfWork.UserRepository.GetUser(newUser.UserName, null);
            if (userByName != null)
            {
                throw new InvalidOperationException($"El nombre de usuario '{newUser.UserName}' ya está en uso");
            }

            newUser.Password = HashPassword(newUser.Password);

            await _unitOfWork.UserRepository.AddAsync(newUser);
            await _unitOfWork.CommitAsync();

            return newUser;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public void Logout(string token)
        {
            Console.WriteLine("deberia ir aqui XD");
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task<User> UpdateUser(int userId, User updateUser)
        {
            var existingUser = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"Usuario con ID {userId} no encontrado");
            }

            if (existingUser.UserName != updateUser.UserName)
            {
                var userByName = await _unitOfWork.UserRepository.GetUser(updateUser.UserName, null);
                if (userByName != null)
                {
                    throw new InvalidOperationException($"El nombre de usuario '{updateUser.UserName}' ya esta en uso :/");
                }
            }

            existingUser.UserName = updateUser.UserName;

            if (!string.IsNullOrEmpty(updateUser.Password) && updateUser.Password != existingUser.Password)
            {
                existingUser.Password = HashPassword(updateUser.Password);
            }

            await _unitOfWork.CommitAsync();
            return existingUser;
        }
    }
}
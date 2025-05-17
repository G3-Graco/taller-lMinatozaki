using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> Login(User user);
        Task<User> CreateUser(User newUser);
        Task<bool> ValidateToken(string token);
        void Logout(string token);
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int userId, User updateUser);
    }
}
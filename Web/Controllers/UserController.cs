using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(User user)
        {
            Console.WriteLine($"Usuario recibido: {user.UserName}, Contraseña: {user.Password}");
            var token = await _service.Login(user);
            if (token == null || token == string.Empty)
            {
                return BadRequest(new { message = "Username or Password is incorrect" });
            }
            return Ok(token);
        }

        public class TokenRequest
        {
            public string Token { get; set; }
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateTokenAsync([FromBody] TokenRequest request)
        {
            if (string.IsNullOrEmpty(request.Token) || await _service.ValidateToken(request.Token) == false)
            {
                return Unauthorized(new { message = "token invalido" });
            }
            return Ok(new { message = "Si funciona dios mio" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                var newUser = await _service.CreateUser(user);
                return CreatedAtAction(nameof(Register), newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", detail = ex.Message });
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout(TokenRequest request)
        {
            if (string.IsNullOrEmpty(request.Token))
            {
                return BadRequest(new { message = "Token is required" });
            }
            _service.Logout(request.Token);
            return Ok(new { message = "Logged out successfully!!!" });
        }


        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _service.GetUserById(id);

            if (user == null)
            {
                return NotFound(new { message = "User not found :/" });
            }

            return Ok(user);
        }
        
        [HttpPut("user/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updateUser)
        {
            try
            {
                if (id != updateUser.Id)
                {
                    return BadRequest(new { message = "ID ingresado no coincide con el ID del usuario" });
                }

                var updatedUser = await _service.UpdateUser(id, updateUser);
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", detail = ex.Message });
            }
        }
    }
}

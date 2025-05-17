using AppBlazor.Data.Models;
using Core.Entities;
using AppBlazor.Data.Auth;
using Newtonsoft.Json;

namespace AppBlazor.Data.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly TokenContainer _tokenContainer;

        public AuthService(IHttpClientFactory clientFactory, TokenContainer tokenContainer)
        {
            _http = clientFactory.CreateClient("API");
            _tokenContainer = tokenContainer;
        }

        public async Task<Response<string>> Login(UserDTO usuario)
        {
            var response = await _http.PostAsJsonAsync("api/auth/Login", usuario);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return new Response<string> { Ok = false, Message = content };

            await _tokenContainer.AsignarToken(content);
            Console.WriteLine(content);
            return new Response<string> { Ok = true, Data = content };
        }

        public async Task<Response<UserDTO>> GetUserById(int userId)
        {
            try
            {
                var response = await _http.GetAsync($"api/auth/user/{userId}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return new Response<UserDTO> { Ok = false, Message = content };

                return new Response<UserDTO>
                {
                    Ok = true,
                    Data = JsonConvert.DeserializeObject<UserDTO>(content)
                };
            }
            catch (Exception ex)
            {
                return new Response<UserDTO>
                {
                    Ok = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<string>> Register(RegisterDTO user)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", new
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password
            });

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new Response<string>
                {
                    Ok = false,
                    Message = content
                };
            }

            return new Response<string>
            {
                Ok = true,
                Message = $"Usuario registrado exitosamente con ID {user.Id}"
            };
        }
        
        public async Task<Response<UserDTO>> UpdateUser(int userId, UserDTO userData)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/auth/user/{userId}", userData);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<UserDTO> 
                    { 
                        Ok = false, 
                        Message = content 
                    };
                }

                return new Response<UserDTO> 
                { 
                    Ok = true, 
                    Data = JsonConvert.DeserializeObject<UserDTO>(content) 
                };
            }
            catch (Exception ex)
            {
                return new Response<UserDTO> 
                { 
                    Ok = false, 
                    Message = $"Error de conexión: {ex.Message}" 
                };
            }
        }
    }
}
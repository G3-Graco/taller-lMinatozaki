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
            return new Response<string> { Ok = true, Data = content };
        }
    }
}
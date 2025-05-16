using Blazored.LocalStorage;
using AppBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AppBlazor.Data.Auth
{
    public class TokenContainer
    {
        private readonly ILocalStorageService _localStorage;

        public TokenContainer(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public string? token { get; private set; }

        public async Task AsignarToken(string newToken)
        {
            token = newToken;
            await _localStorage.SetItemAsync("jwt_token", token);
        }

        public async Task CargarToken()
        {
            token = await _localStorage.GetItemAsStringAsync("jwt_token");
        }

        public async Task LimpiarToken()
        {
            token = null;
            await _localStorage.RemoveItemAsync("jwt_token");
        }
    }
}
using AppBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AppBlazor.Data.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly TokenContainer _tokenContainer;

        public CustomAuthenticationStateProvider(TokenContainer tokenContainer)
        {
            _tokenContainer = tokenContainer;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await _tokenContainer.CargarToken();
            var token = _tokenContainer.token;

            if (string.IsNullOrEmpty(token))
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public void NotifyAuthStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RolePlayManager.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Options;
using ToDoApp.Core.Services;
using ToDoApp.Data.Entities;

namespace ToDoApp.Infrastracture.Services
{
    public class TokenService : ITokenService
    {
        private TokenOptions _tokenOptions { get; }
        private ICrudService<RefreshToken> _tokens { get; }

        public TokenService(
            IOptions<TokenOptions> tokenOptions,
            ICrudService<RefreshToken> tokens)
        {
            _tokenOptions = tokenOptions.Value;
            _tokens = tokens;
        }

        public string CreateAccessToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("sub", user.Id),
                new Claim("jti", Guid.NewGuid().ToString())
            };

            var jwt = new JwtSecurityToken(
                _tokenOptions.ValidIssuer,
                _tokenOptions.ValidAudience,
                claims,
                DateTime.UtcNow.Add(_tokenOptions.AccessTokenNotBefore),
                DateTime.UtcNow.Add(_tokenOptions.AccessTokenValidFor),
                _tokenOptions.SigningCredentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;
        }

        public async Task<string> CreateRefreshToken(User user)
        {
            var token = new RefreshToken
            {
                User = user,
                Token = Guid.NewGuid().ToString("N"),
                ValidUntil = DateTime.UtcNow.Add(_tokenOptions.RefreshTokenValidFor)
            };
            await _tokens.CreateAsync(token);
            return token.Token;
        }

        public async Task<bool> UseRefreshTokenAsync(User user, string token)
        {
            var databaseToken = await _tokens.GetEntities.SingleOrDefaultAsync(e => e.User == user && e.Token == token && DateTime.UtcNow < e.ValidUntil);

            if (databaseToken != null)
            {
                //await _tokens.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

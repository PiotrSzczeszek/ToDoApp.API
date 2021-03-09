using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Services;
using ToDoApp.Data.Entities;

namespace ToDoApp.Infrastracture.Services
{
    public class AuthService : IAuthService
    {
        private ITokenService _tokenService { get; }
        private IBCryptService _passwordService { get; }
        private ICrudService<User> _users { get; }

        public AuthService(
            ITokenService tokenService,
            IBCryptService passwordService,
            ICrudService<User> users)
        {
            _tokenService = tokenService;
            _passwordService = passwordService;
            _users = users;
        }

        public bool VerifyPassword(User user, string password) => _passwordService.Verify(password, user.Password);

        public async Task<TokenResult> LogInWithPasswordAsync(string userName, string password)
        {
            var user = await _users.GetEntities.SingleOrDefaultAsync(e => e.Username == userName);
            if (user == null)
                return null;
            if (VerifyPassword(user, password))
            {
                var tokens = await GenerateNewTokensAsync(user);
                return tokens;
            }
            else
                return null;
        }

        public async Task<TokenResult> LogInWithTokenAsync(string userName, string token)
        {
            var user = await _users.GetEntities.SingleOrDefaultAsync(e => e.Username == userName);
            if (user == null)
                return null;
            if (await _tokenService.UseRefreshTokenAsync(user, token))
            {
                var tokens = await GenerateNewTokensAsync(user);
                return tokens;
            }
            else
                return null;
        }

        private async Task<TokenResult> GenerateNewTokensAsync(User user)
        {
            return new TokenResult
            {
                AccessToken = _tokenService.CreateAccessToken(user),
                RefreshToken = await _tokenService.CreateRefreshToken(user)
            };
        }
    }
}

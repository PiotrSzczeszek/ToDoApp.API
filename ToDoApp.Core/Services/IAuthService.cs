using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Entities;

namespace ToDoApp.Core.Services
{
    public interface IAuthService
    {

        Task<TokenResult> LogInWithPasswordAsync(string userName, string password);

        Task<TokenResult> LogInWithTokenAsync(string userName, string token);

        bool VerifyPassword(User user, string password);
    }

    public class TokenResult
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

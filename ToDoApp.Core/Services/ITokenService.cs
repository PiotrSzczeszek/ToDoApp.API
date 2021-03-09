using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Entities;

namespace ToDoApp.Core.Services
{
    public interface ITokenService
    {
        string CreateAccessToken(User user);
        Task<string> CreateRefreshToken(User user);
        Task<bool> UseRefreshTokenAsync(User user, string token);
    }
}

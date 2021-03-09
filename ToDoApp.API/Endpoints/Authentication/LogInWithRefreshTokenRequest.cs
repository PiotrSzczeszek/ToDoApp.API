using System.ComponentModel.DataAnnotations;

namespace RolePlayManager.Api.App.Features.Core.Auth
{
    public class LogInWithRefreshTokenRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Token { get; set; }
    }
}

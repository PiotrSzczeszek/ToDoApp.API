using System.ComponentModel.DataAnnotations;

namespace RolePlayManager.Api.App.Features.Core.Auth
{
    public class LogInWithPasswordRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

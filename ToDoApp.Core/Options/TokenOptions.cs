using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Core.Options
{
    public class TokenOptions
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }

        public int AccessTokenNotBeforeSeconds { get; set; }
        public TimeSpan AccessTokenNotBefore => TimeSpan.FromSeconds(AccessTokenNotBeforeSeconds);

        public int AccessTokenValidForSeconds { get; set; }
        public TimeSpan AccessTokenValidFor => TimeSpan.FromSeconds(AccessTokenValidForSeconds);

        public int RefreshTokenValidForMinutes { get; set; }
        public TimeSpan RefreshTokenValidFor => TimeSpan.FromMinutes(RefreshTokenValidForMinutes);

        public string SecretKey { get; set; }
        public SymmetricSecurityKey SecurityKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public SigningCredentials SigningCredentials => new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature);
    }
}

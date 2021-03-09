using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RolePlayManager.Api.App.Features.Core.Auth;
using ToDoApp.Core.Services;

namespace ToDoApp.API.Endpoints.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILogger<AuthController> _logger { get; }
        private IAuthService _authService { get; }

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

       
        [Authorize]
        [HttpPost("check")]
        public IActionResult Check() => NoContent();

        
        [HttpPost("password")]
        public async Task<ActionResult<TokenResponse>> LogInWithPasswordAsync(LogInWithPasswordRequest request)
        {
            var tokens = await _authService.LogInWithPasswordAsync(request.UserName, request.Password);
            if (tokens == null)
                return BadRequest();
            else
            {
                _logger.LogInformation($"User \"{request.UserName}\" has successfully logged in with password.");
                return Ok(tokens);
            }
        }

        
        [HttpPost("token")]
        public async Task<ActionResult<TokenResponse>> LogInWithTokenAsync(LogInWithRefreshTokenRequest request)
        {
            var tokens = await _authService.LogInWithTokenAsync(request.UserName, request.Token);
            if (tokens == null)
                _logger.LogInformation("its bad");
            else
            {
                _logger.LogInformation($"User \"{request.UserName}\" has successfully exchanged refresh token.");
                return Ok(tokens);
            }

            return BadRequest();
        }
    }
}

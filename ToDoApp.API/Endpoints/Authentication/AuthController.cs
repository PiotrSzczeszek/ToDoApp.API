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

        /// <summary>
        /// Checks if the session is still valid
        /// </summary>
        /// <returns>No content</returns>
        /// <response code="204">Session still valid</response>
        /// <response code="401">Unauthorized - session is not valid anymore</response>
        [Authorize]
        [HttpPost("check")]
        public IActionResult Check() => NoContent();

        /// <summary>
        /// Logs in the user using password
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST /api/auth/password
        ///     {
        ///         "UserName" : "admin"
        ///         "Password" : "admin"
        ///     }
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="200">Returns tokens</response>
        /// <response code="400">Bad credentials</response>
        /// <returns>Token response - Access token with refresh token</returns>
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

        /// <summary>
        /// Logs in the user using refresh token
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST /api/auth/token
        ///     {
        ///         "UserName" : "admin"
        ///         "Token" : "5ae5b8644a04498cab84bcd8fc649d6f"
        ///     }
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="200">Returns tokens</response>
        /// <response code="400">Invalid credentials</response>
        /// <returns>Token response - Access token with refresh token</returns>
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

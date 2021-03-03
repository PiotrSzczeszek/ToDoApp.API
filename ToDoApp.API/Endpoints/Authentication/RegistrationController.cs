using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoApp.API.Endpoints.Authentication;
using ToDoApp.Core.Services;
using ToDoApp.Data.Entities;

namespace ToDoApp.API.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ILogger<RegistrationController> _logger;
        readonly IRegistrationService _registrationService;

        public RegistrationController(IMapper mapper, ILogger<RegistrationController> logger, IRegistrationService registrationService)
        {
            _mapper = mapper;
            _logger = logger;
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Register(RegistrationRequest registrationRequest)
        {
            try
            {
                User user = _mapper.Map<User>(registrationRequest);


                bool a = await _registrationService.AddUserAsync(user);

                _logger.LogInformation($"Added user with username: {user.Username} and email: {user.Email}");
                

            }catch(Exception e)
            {
                _logger.LogError($"Exception: {e}");
            }

            return Ok(true);
        }
    }
}

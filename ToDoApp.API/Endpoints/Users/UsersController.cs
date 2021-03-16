using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Services;
using ToDoApp.Data.Entities;

namespace ToDoApp.API.Endpoints.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// Gets all registered users
        /// </summary>
        /// <returns>List of every user in database</returns>
        /// <response code="200">List of all users</response>
        /// <response code="401">Unauthorized - user not logged in</response>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ICollection<User>>> GetUsersAsync()
        {
            ICollection<User> users;

            users = await _usersService.GetUsersAsync(); 

            return Ok(users);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Services;
using ToDoApp.Data.Entities;

namespace ToDoApp.API.Endpoints.Todo
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        private readonly string currentUserId;
        public TodoController(ITodoService todoService, IUsersService usersService, IMapper mapper)
        {
            _todoService = todoService;
            _usersService = usersService;
            _mapper = mapper;

            //currentUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        }

        [HttpGet]
        public string xd()
        {
            return "XD";
        }

        [HttpGet("all")]
        [Authorize]
        public async Task<ActionResult<ICollection<ToDo>>> GetAllTodosAsync()
        {
            var todos = await _todoService.GetToDosAsync();

            return Ok(todos);
        }

        [HttpGet("my")]
        [Authorize]
        public async Task<ActionResult<ICollection<ToDo>>> GetUsersTodosAsync()
        {
            var user = await _usersService.GetCurrentUserAsync();
            var todos = await _todoService.GetUsersTodosAsync(user);

            return Ok(todos);

        }

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<bool>> AddTodo(TodoRequest todoRequest)
        {

            ToDo todo = _mapper.Map<ToDo>(todoRequest);

            todo.CreatedAt = DateTime.Now;
            todo.Tasks = new List<Data.Entities.Task>();
            todo.User = await _usersService.GetCurrentUserAsync();
            todo.UserId = todo.User.Id;

            if (await _todoService.AddTodoAsync(todo))
                return NoContent();

            return BadRequest();
        }
    }
}

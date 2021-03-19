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
        private readonly ITaskService _taskService;
        public TodoController(ITodoService todoService, IUsersService usersService, IMapper mapper, ITaskService taskService)
        {
            _todoService = todoService;
            _usersService = usersService;
            _mapper = mapper;
            _taskService = taskService;
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("{id}/xd")]
        public string xd(int id)
        {
            return $"id to: {id} XD";
        }


        /// <summary>
        /// Returns all todos in database
        /// </summary>
        /// <returns>All todods inside db</returns>
        [HttpGet("all")]
        [Authorize]
        public async Task<ActionResult<ICollection<ToDo>>> GetAllTodosAsync()
        {
            var todos = await _todoService.GetToDosAsync();

            return Ok(todos);
        }

        /// <summary>
        /// Gets current user's todos
        /// </summary>
        /// <returns>List of todos of a current user</returns>
        [HttpGet("my")]
        [Authorize]
        public async Task<ActionResult<ICollection<ToDo>>> GetUsersTodosAsync()
        {
            var user = await _usersService.GetCurrentUserAsync();
            var todos = await _todoService.GetUsersTodosAsync(user);

            return Ok(todos);

        }

        /// <summary>
        /// Adds a new Todo as current user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///         "Title": "sample title",
        ///         "DueDate": "2020-01-09 12:03:00"
        ///     }
        /// </remarks>
        /// <param name="todoRequest"></param>
        /// <returns>No content</returns>
        /// <response code="204">Todo added successfully</response>
        /// <response code="400">Bad request - incomplete info</response>
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Services;

namespace ToDoApp.API.Endpoints.Todo.Task
{
    [Route("api/Todo/{ToDoID}/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {


        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        private readonly ITodoService _todoService;
        public TaskController(ITaskService taskService, IMapper mapper, ITodoService todoSerive)
        {
            _taskService = taskService;
            _mapper = mapper;
            _todoService = todoSerive;
        }

        /// <summary>
        /// Returns all tasks associated with Todo with specific ID
        /// </summary>
        /// <param name="ToDoID"></param>
        /// <returns>
        ///     Tasks associated with Todo 
        /// </returns>
        /// <response code="200">Tasks</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("all")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ToDoApp.Data.Entities.Task>>> GetTasks(string ToDoID)
        {
            var tasks = await _taskService.GetTasks(ToDoID);


            return Ok(tasks);
        }

        /// <summary>
        /// Adds new task to existing todo
        /// </summary>
        /// <param name="ToDoID"></param>
        /// <param name="task"></param>
        /// <returns>
        ///     No content
        /// </returns>
        /// <remarks>
        ///     Sample request:
        ///     
        ///     {
        ///         "TaskContent": "Send invitations"
        ///     }
        /// </remarks>
        /// <response code="204">Task added succesfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthorized</response>

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<bool>> AddTask(string ToDoID, TaskRequest task)
        {
            try
            {
                Data.Entities.Task t = _mapper.Map<Data.Entities.Task>(task);

                t.ToDo = await _todoService.GetToDoAsync(ToDoID);
                t.ToDoId = t.ToDo.Id;
                t.IsFinished = false;

                await _taskService.AddTask(t);

                return NoContent();
            }catch
            {
                return BadRequest();
            }

        }

        [HttpPost("addMany")]
        [Authorize]
        public async Task<ActionResult<bool>> AddTasks(string ToDoID, MultipleTasksRequest multipleTasks)
        {
            try
            {
                foreach (var taskContent in multipleTasks.TasksContents)
                {
                    Data.Entities.Task t = new Data.Entities.Task();
                    t.TaskContent = taskContent;

                    t.ToDo = await _todoService.GetToDoAsync(ToDoID);
                    t.ToDoId = t.ToDo.Id;
                    t.IsFinished = false;
                    await _taskService.AddTask(t);
                }


                return NoContent();
            }
            catch(Exception e)
            {
                
                return BadRequest();
            }
        }




    }


}


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Services;
using ToDoApp.Data.Entities;

namespace ToDoApp.Infrastracture.Services
{
    public class TodoService : ITodoService
    {

        private readonly ICrudService<ToDo> _crudService;

        public TodoService(ICrudService<ToDo> crudService)
        {
            _crudService = crudService;
        }

        public async Task<bool> AddTodoAsync(ToDo todo)
        {
            return await _crudService.CreateAsync(todo);
        }

        public Task<ToDo> GetToDoAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ToDo>> GetToDosAsync()
        {
            return await _crudService.GetEntities.ToListAsync();
        }

        public async Task<ICollection<ToDo>> GetUsersTodosAsync(User user)
        {
            return await _crudService.GetEntities.Where(x => x.User == user).ToListAsync();

        }

        public Task<bool> RemoveTodoAsync(ToDo todo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTodoAsync(ToDo todo)
        {
            throw new NotImplementedException();
        }
    }
}

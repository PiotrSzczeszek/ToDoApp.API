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

        public async Task<ToDo> GetToDoAsync(string id)
        {
            return await _crudService.GetEntities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<ToDo>> GetToDosAsync()
        {
            return await _crudService.GetEntities.ToListAsync();
        }

        public async Task<ICollection<ToDo>> GetUsersTodosAsync(User user)
        {
            return await _crudService.GetEntities.Where(x => x.User == user).ToListAsync();

        }

        public async Task<bool> RemoveTodoAsync(ToDo todo)
        {
            return await _crudService.DeleteAsync(todo);
        }

        public async Task<bool> UpdateTodoAsync(ToDo todo)
        {
            return await _crudService.UpdateAsync(todo);
        }
    }
}

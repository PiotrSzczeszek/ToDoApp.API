using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Entities;

namespace ToDoApp.Core.Services
{
    public interface ITodoService
    {
        public Task<bool> AddTodoAsync(ToDo todo);
        public Task<bool> RemoveTodoAsync(ToDo todo);
        public Task<ToDo> GetToDoAsync(string id);
        public Task<ICollection<ToDo>> GetToDosAsync();
        public Task<ICollection<ToDo>> GetUsersTodosAsync(User user);
        public Task<bool> UpdateTodoAsync(ToDo todo);

    }
}

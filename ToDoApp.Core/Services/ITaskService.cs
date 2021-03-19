using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Core.Services
{
    public interface ITaskService
    {
        public Task<Data.Entities.Task> GetTask(string ID);
        public Task<IEnumerable<Data.Entities.Task>> GetTasks(string ToDoID);
        public Task<bool> RemoveTask(string ID);
        public Task<bool> AddTask(Data.Entities.Task task);
        public Task<bool> UpdateTask(string ID, Data.Entities.Task updatedTask);

    }
}

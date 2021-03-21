using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Services;

namespace ToDoApp.Infrastracture.Services
{
    public class TaskService : ITaskService
    {

        private readonly ICrudService<Data.Entities.Task> _crudService;

        public TaskService(ICrudService<Data.Entities.Task> crudService)
        {
            _crudService = crudService;
        }


        public async Task<bool> AddTask(Data.Entities.Task task)
        {
            task.CreatedAt = DateTime.Now;
            return await _crudService.CreateAsync(task);
        }

        public async Task<Data.Entities.Task> GetTask(string ID)
        {
            return await _crudService.GetEntities.FirstAsync(x => x.Id == ID);
        }

        public async Task<IEnumerable<Data.Entities.Task>> GetTasks(string ToDoID)
        {
            return await _crudService.GetEntities.Where(x => x.ToDoId == ToDoID).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<bool> RemoveTask(string ID)
        {
            Data.Entities.Task t = _crudService.GetEntities.First(x => x.Id == ID);
            return await _crudService.DeleteAsync(t);
        }

        public async Task<bool> UpdateTask(string ID, Data.Entities.Task updatedTask)
        {
            Data.Entities.Task t = _crudService.GetEntities.First(x => x.Id == ID);
            t = updatedTask;
            return await _crudService.UpdateAsync(t);
        }
    }
}

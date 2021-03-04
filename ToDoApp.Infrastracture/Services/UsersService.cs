using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Services;
using ToDoApp.Data;
using ToDoApp.Data.Entities;

namespace ToDoApp.Infrastracture.Services
{
    public class UsersService : IUsersService
    {

        readonly ICrudService<User> _crudService;

        public UsersService(ICrudService<User> crudService)
        {
            _crudService = crudService;
        }


        public async Task<bool> AddUserAsync(User user)
        {
            return await _crudService.CreateAsync(user);
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await System.Threading.Tasks.Task.FromResult(_crudService.GetEntities.FirstOrDefault(x => x.Id == id));
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await System.Threading.Tasks.Task.FromResult(_crudService.GetEntities.ToList());
        }

        public Task<bool> RemoveUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(string id, User user)
        {
            throw new NotImplementedException();
        }
    }
}

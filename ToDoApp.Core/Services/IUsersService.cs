using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Entities;

namespace ToDoApp.Core.Services
{
    public interface IUsersService
    {
        public Task<User> GetUserAsync(string id);
        public Task<ICollection<User>> GetUsersAsync();
        public Task<bool> AddUserAsync(User user);
        public Task<bool> RemoveUserAsync(string id);
        public Task<bool> UpdateUserAsync(string id, User user);
        public Task<User> GetCurrentUserAsync();

    }
}

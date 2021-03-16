using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        readonly IHttpContextAccessor _httpContextAccessor;
        public UsersService(ICrudService<User> crudService, IHttpContextAccessor httpContextAccessor)
        {
            _crudService = crudService;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<bool> AddUserAsync(User user)
        {
            return await _crudService.CreateAsync(user);
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await _crudService.GetEntities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await _crudService.GetEntities.ToListAsync();
        }

        public async Task<bool> RemoveUserAsync(string id)
        {
            User user = _crudService.GetEntities.FirstOrDefault(x => x.Id == id);

            return await _crudService.DeleteAsync(user);
        }

        public async Task<bool> UpdateUserAsync(string id, User user)
        {
            User old = _crudService.GetEntities.FirstOrDefault(x => x.Id == id);
            old = user;

            return await _crudService.UpdateAsync(old);

        }

        public async Task<User> GetCurrentUserAsync()
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await _crudService.GetEntities.FirstAsync(x => x.Id == currentUserId);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Services;
using ToDoApp.Data.Entities;

namespace ToDoApp.Infrastracture.Services
{
    public class RegistrationService2 : IRegistrationService
    {

        public Task<bool> AddUserAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Services;
using ToDoApp.Data.Entities;

namespace ToDoApp.Infrastracture.Services
{
    public class RegistrationService : IRegistrationService
    {

        readonly ICrudService<User> _crudService;
        readonly IBCryptService _bCryptService;
        public RegistrationService(ICrudService<User> crudService, IBCryptService bCryptService)
        {
            _crudService = crudService;
            _bCryptService = bCryptService;
        }

        public Task<bool> AddUserAsync(User user)
        {
            user.Password = _bCryptService.Hash(user.Password);

            return _crudService.CreateAsync(user);
        }
    }
}

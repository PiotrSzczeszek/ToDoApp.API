using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Services;

namespace ToDoApp.Infrastracture.Services
{
    public class BCryptService : IBCryptService
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}

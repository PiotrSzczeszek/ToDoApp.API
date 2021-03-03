using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Core.Services
{
    public interface IBCryptService
    {
        string Hash(string password);
        bool Verify(string password, string hash);
    }
}

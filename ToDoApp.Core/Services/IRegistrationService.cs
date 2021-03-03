using System.Threading.Tasks;
using ToDoApp.Data.Entities;

namespace ToDoApp.Core.Services
{
    public interface IRegistrationService
    {
        Task<bool> AddUserAsync(User user);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> getUserbyUsernameAsync(string username);
        Task addUserAsync(User user);
        Task updateUserAsync(User user);
        Task deleteUserAsync(Guid id);
        Task<IEnumerable<User>> getAllUserAsync();
        Task<User> getUserByIdAsync(Guid id);
        Task saveChangesAsync();
    }
}

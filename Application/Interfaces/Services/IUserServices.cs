using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Interfaces.Services
{
    public interface IUserServices
    {
        Task<User> getUserByUsernameAsync(string username);
        Task<User> RegisterUserAsync(string username, string email, string password);

        Task<User> AuthenticateUserAsync(string username, string password);

    }
}

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
        Task<User> getUserByPhoneNumberAsync(string phoneNumber);
        Task<User> RegisterUserAsync(string phoneNumber, string email, string password);
        Task<User> AuthenticateUserAsync(string phoneNumber, string password);
        Task<User> AuthenticateWithGoogleAsync(string idToken);
        Task<User> AuthenticateWithOTPAsync(string phoneNumber, string otp);
        Task SendOTPAsync(string phoneNumber);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Application.Interfaces.Services;
using System.Security.Cryptography;

namespace Application.Services
{
    public class UserServices: IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {  
            _userRepository = userRepository; 
        }

        public async Task<User> getUserByUsernameAsync(string username)
        {
            return await _userRepository.getUserbyUsernameAsync(username);
        }


        //Register new Customer
        public async Task<User> RegisterUserAsync(string username, string email, string password)
        {
            var existintUser = await _userRepository.getUserbyUsernameAsync(username);

            if (existintUser != null) throw new InvalidOperationException("Username already exists.");

            var passwordHash = HashPassword(password);

            var user = new User
            {
                Username = username,
                Email = email,
                Password = passwordHash
            };

            await _userRepository.addUserAsync(user);
            await _userRepository.saveChangesAsync();

            return user;


        }

        //Login services
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var existingUser = await _userRepository.getUserbyUsernameAsync(username);
            if (existingUser == null) throw new UnauthorizedAccessException("Invalid credentials.");
            if (existingUser.Password != HashPassword(password)) throw new UnauthorizedAccessException("Invalid credentials");

            return existingUser;
        }


        //Hash function raw password
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }


    }
}

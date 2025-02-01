using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyAppDbContext _context;

        public UserRepository(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task addUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task updateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task deleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if( user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> getUserbyPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<IEnumerable<User>> getAllUserAsync()
        {
            return await _context.Users.Include(u => u.Bookings).ToListAsync();
        }

        public async Task<User> getUserByIdAsync(Guid id)
        {
            return await _context.Users.Include(u => u.Bookings).FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task saveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

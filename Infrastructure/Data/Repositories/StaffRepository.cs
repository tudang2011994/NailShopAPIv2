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
    public class StaffRepository : IStaffRepository
    {

        private readonly MyAppDbContext _context;

        public StaffRepository(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task addStaffAsync(Staff staff)
        {
            await _context.Staffs.AddAsync(staff);
        }

        public async Task deleteStaffAsync(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                await _context.SaveChangesAsync();
            }          
        }

        public async Task<IEnumerable<Staff>> getAllStaffAsync()
        {
            //return await _context.Staffs.Include(s => s.StaffServices).ThenInclude(ss => ss.Staff).ToListAsync();
            return await _context.Staffs.ToListAsync();
        }

        public async Task<Staff> getStaffByIdAsync(int id)
        {
            return await _context.Staffs.Include(s => s.StaffServices).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task updateStaffAsync(Staff staff)
        {
            _context.Staffs.Update(staff);
            await _context.SaveChangesAsync();
        }
    }
}

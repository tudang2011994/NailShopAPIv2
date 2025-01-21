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
    public class CheckInWorkRepository : ICheckInWorkRepository
    {
        private readonly MyAppDbContext _context;

        CheckInWorkRepository(MyAppDbContext context)
        {
            _context = context;
        }

        public async Task addCheckInWorkAsync(CheckInWork CheckInWork)
        {
            await _context.CheckInWorks.AddAsync(CheckInWork);    
        }

        public async Task deleteCheckInWorkAsync(Guid id)
        {
            var checkInWork = await _context.CheckInWorks.FindAsync(id);
            if(checkInWork != null)
            {
                _context.CheckInWorks.Remove(checkInWork);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<CheckInWork>> getAllCheckInWorkAsync()
        {
            return await _context.CheckInWorks.Include(cw => cw.Service).Include(cw => cw.Booking).Include(cw => cw.Staff).ToListAsync();
        }

        //public async Task<CheckInWork> getCheckInWorkByIdAsync(Guid id)
        //{
        //    return await _context.CheckInWorks.Include(cw => cw.Service).Include(cw => cw.Booking).Include(cw => cw.Staff).FirstOrDefaultAsync(cw => cw.Id == id);
        //}

        public async Task updateCheckInWorkAsync(CheckInWork CheckInWork)
        {
            _context.CheckInWorks.Update(CheckInWork);
            await _context.SaveChangesAsync();
        }
    }
}

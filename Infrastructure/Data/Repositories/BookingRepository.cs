using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Infrastructure.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MyAppDbContext _context;
        public BookingRepository(MyAppDbContext context) 
        {
            _context = context; 
        }

        public async Task addBookingAsync(ICollection<Booking> booking)
        {
           _context.Bookings.AddRange(booking);

        }

        public async Task deleteBookingAsync(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null) 
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> getAllBookingAsync()
        {
            return await _context.Bookings.Include(b => b.User).Include(b => b.Staff).Include(b => b.Service).ToListAsync();
        }

        public async Task<IEnumerable<Booking>> getAllBookingInDateRangeAsync(DateTime startDate, int days)
        {
            var endDate = startDate.AddDays(days);
            return await _context.Bookings.Where(b => b.BookingTime >= startDate && b.BookingTime <= endDate).ToListAsync();
        }

        public async Task<Booking> getBookingByIdAsync(Guid id)
        {
            return await _context.Bookings.Include(b => b.User).Include(b => b.Staff).Include(b => b.Service).FirstOrDefaultAsync(b => b.Id == id); 
        }

        public async Task saveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task updateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking> getBookingByIdAsync(Guid id);
        Task addAllBookingAsync(ICollection<Booking> booking);
        Task addBookingAsync(Booking booking);
        Task updateBookingAsync(Booking booking);
        Task deleteBookingAsync(Guid id);
        Task<IEnumerable<Booking>> getAllBookingAsync();
        Task saveChangesAsync();
        Task<IEnumerable<Booking>> getAllBookingInDateRangeAsync(DateTime startDate, int days);

    }
}

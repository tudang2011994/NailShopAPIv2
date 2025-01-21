using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IBookingServices
    {
        Task<Booking> getBookingByUserIdAsync(Guid id);
        Task addBookingAsync(Booking booking);

        Task updateBookingAsync(Booking booking);
        Task deleteBookingAsync(Guid id);

    }
}

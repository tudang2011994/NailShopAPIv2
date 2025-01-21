using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Core.Entities;

namespace Application.Interfaces.Services
{
    public interface IBookingServices
    {
        Task<Booking> getBookingByUserIdAsync(Guid id);
        Task<IEnumerable<Booking>> getAllBookingInDateRangeAsync(DateTime startDate, int days);
        Task<ICollection<Booking>> addBookingAsync(List<BookingDTO> booking);

        Task updateBookingAsync(BookingUpdateDTO booking);
        Task deleteBookingAsync(Guid id);

    }
}

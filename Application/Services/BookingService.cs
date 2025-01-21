using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.Data.Repositories;
using Application.Dtos;

namespace Application.Services
{
    public class BookingService : IBookingServices
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<ICollection<Booking>> addBookingAsync(List<BookingDTO> bookingDTOs)
        {
            List<Booking> bookings = new List<Booking>();
            foreach(var bookingDTO in bookingDTOs)
            { 
                Guid tempBookingId = Guid.NewGuid();
                //Map DTO To Entity
                var booking = new Booking
                {
                    Id = tempBookingId,
                    BookingTime = bookingDTO.BookingTime,
                    UserId = bookingDTO.UserId,
                    ServiceId = bookingDTO.ServiceId,
                    StaffId = bookingDTO.StaffId,
                    Status = bookingDTO.Status,
                };
                bookings.Add(booking);
            }
            await _bookingRepository.addBookingAsync(bookings);
            await _bookingRepository.saveChangesAsync();
            return bookings;
        }

        public async Task deleteBookingAsync(Guid id)
        {
            await _bookingRepository.deleteBookingAsync(id);
        }

        public async Task<IEnumerable<Booking>> getAllBookingInDateRangeAsync(DateTime startDate, int days)
        {
            return await _bookingRepository.getAllBookingInDateRangeAsync(startDate, days);
        }

        public async Task<Booking> getBookingByUserIdAsync(Guid id)
        {
            return await _bookingRepository.getBookingByIdAsync(id); 
        }

        public async Task updateBookingAsync(BookingUpdateDTO bookingUpdateDTO)
        {
            var booking = await _bookingRepository.getBookingByIdAsync(bookingUpdateDTO.BookingId);
            if(booking != null)
            {
                //booking.BookingTime = bookingUpdateDTO.BookingTime;

                //foreach ( var cwDTO in bookingUpdateDTO.CheckInWorks)
                //{
                //    var checkInWork = booking.CheckInWorks.FirstOrDefault(cw => cw.CheckInWorkId == cwDTO.CheckInWorkId);

                //    if(checkInWork == null)
                //    {
                //        booking.CheckInWorks.Add(new CheckInWork
                //        {
                //            CheckInWorkId = Guid.NewGuid(),
                //            BookingId = booking.Id,
                //            ServiceId = cwDTO.ServiceId,

                //        });
                //    }
                //    else
                //    {
                //        checkInWork.ServiceId = cwDTO.ServiceId;
                //        checkInWork.StaffId = cwDTO.StaffId;
                //    }
                //}

                ////Remove CheckInWork not present in DTOS
                //var incomingIds = bookingUpdateDTO.CheckInWorks.Select(cw => cw.CheckInWorkId).ToList();
                //var checkInWorkToRemove = booking.CheckInWorks.Where(cw => !incomingIds.Contains(cw.CheckInWorkId)).ToList();

                //foreach( var checkInWork in checkInWorkToRemove)
                //{
                //    booking.CheckInWorks.Remove(checkInWork);
                //};

                await _bookingRepository.updateBookingAsync(booking);                
            }
            
;        }
    }
}

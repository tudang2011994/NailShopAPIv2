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
        private readonly IUserRepository _userRepository;

        public BookingService(IBookingRepository bookingRepository, IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
        }

        public async Task addAllBookingsAsync(List<BookingDTO> bookingDtos)
        {
            foreach (var bookingDto in bookingDtos)
            {

                // Map BookingDTO to Booking entity
                var bookingEntity = new Booking
                {
                    BookingTime = bookingDto.BookingTime,
                    ServiceId = bookingDto.ServiceId,
                    StaffId = bookingDto.StaffId,
                    UserId = bookingDto.UserId,
                };

                // Save each booking to the database
                await _bookingRepository.addBookingAsync(bookingEntity);
            }

            // Commit all changes
            await _bookingRepository.saveChangesAsync();
        }
        public async Task<Booking> createBookingAsync(CreateBookingRequestDTO createBookingRequest)
        {
            // Check if user exists by phone number
            var user = await _userRepository.getUserbyPhoneNumberAsync(createBookingRequest.CustomerInfo.Phone);
            if (user == null)
            {
                // Create new user if not exists
                user = new User
                {
                    Id = Guid.NewGuid(),
                    PhoneNumber = createBookingRequest.CustomerInfo.Phone,
                    Email = createBookingRequest.CustomerInfo.Email,
                    Name = createBookingRequest.CustomerInfo.FullName, // Added to match the full name field
                    isRegisterUser = false
                };
                await _userRepository.addUserAsync(user);
                await _userRepository.saveChangesAsync();
            }

            var bookingDto = new BookingDTO
            {
                UserId = user.Id,
                BookingTime = DateTime.Parse($"{createBookingRequest.Date.ToShortDateString()} {createBookingRequest.Time}"),
                StaffId = 0, // Assuming you need to set this based on some logic
                ServiceId = createBookingRequest.ServiceId,
                Status = BookingStatus.Pending, // Assuming a default status
                SpecialRequest = createBookingRequest.SpecialRequest // Added to match the special request field
            };

            var bookings = await addBookingAsync(new List<BookingDTO> { bookingDto });
            return bookings.FirstOrDefault();
        }

        public async Task<ICollection<Booking>> addBookingAsync(List<BookingDTO> bookingDTOs)
        {
            List<Booking> bookings = new List<Booking>();
            foreach(var bookingDTO in bookingDTOs)
            { 
                Guid tempBookingId = Guid.NewGuid();

                DateTime localTime = bookingDTO.BookingTime.ToLocalTime();
                //Map DTO To Entity
                var booking = new Booking
                {
                    Id = tempBookingId,
                    BookingTime = localTime,
                    UserId = bookingDTO.UserId,
                    ServiceId = bookingDTO.ServiceId,
                    StaffId = bookingDTO.StaffId,
                    Status = bookingDTO.Status,
                };
                bookings.Add(booking);
            }
            await _bookingRepository.addAllBookingAsync(bookings);
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

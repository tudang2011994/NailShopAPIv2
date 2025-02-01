using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Dtos
{
    public class BookingDTO
    {
        public Guid UserId { get; set; }
        public DateTime BookingTime { get; set; }
        public int StaffId { get; set; }
        public int ServiceId { get; set; }
        public BookingStatus Status { get; set; }
        public string SpecialRequest { get; set; } // Added to match the special request field
    }
    public class BookingUpdateDTO
    {
        public Guid BookingId { get; set; }
        public DateTime BookingTime { get; set; }
        //public List<CheckInWorkUpdateDTO> CheckInWorks { get; set; } = new List<CheckInWorkUpdateDTO>();

    }
    public class CreateBookingRequestDTO
    {
        public CustomerInfoDTO CustomerInfo { get; set; }
        //public string? Email { get; set; }
        //public string FullName { get; set; }
        //public string Phone { get; set; }
        public DateTime Date { get; set; }
        public int ServiceId { get; set; }
        public string SpecialRequest { get; set; }
        public string Time { get; set; }
    }

    public class CustomerInfoDTO
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
    }

}

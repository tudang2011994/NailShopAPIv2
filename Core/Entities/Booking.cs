using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.JoinEntities;

namespace Core.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime BookingTime { get; set; }
        public Staff Staff { get; set; }
        public Service Service { get; set; }
        public int StaffId { get; set; }
        public int ServiceId { get; set; }
        public BookingStatus Status { get; set; }
        public string SpecialRequest { get; set; } // Added to match the special request field
    }

    public enum BookingStatus
    {
        Pending = 0,
        Confirm =1,
        CheckIn = 2,
        Complete = 3,
        Canceled = 4,
        NoShow = 5
    }
}

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
        public DateTime BookingTime     { get; set; }
        //public ICollection<CheckInWork> CheckInWorks { get; set; } = new List<CheckInWork>();

        public Staff Staff { get; set; }
        public Service Service { get; set; }

        public int StaffId { get; set; }
        public int ServiceId { get; set; }
        public string Status { get; set; }

    }
}

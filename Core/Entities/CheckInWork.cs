using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CheckInWork
    {
        public Guid CheckInWorkId { get; set; }

        public Guid BookingId { get; set; } //Foreign Key for Booking
        public int StaffId { get; set; }    //Foreign Key for Staff    
        public int ServiceId { get; set; } //Foreign Key for Service

        public Service Service { get; set; }
        public Booking Booking { get; set; }
        public Staff Staff { get; set; }

        public bool IsChecked { get; set; }
    }
}

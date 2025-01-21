using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BookingDTO
    {
        public Guid UserId { get; set; }
        public DateTime BookingTime { get; set; }
        //public List<CheckInWorkDTO> CheckInWorks { get; set; } = new List<CheckInWorkDTO>();
        public int StaffId { get; set; }
        public int ServiceId { get; set; }
        public string Status { get; set; }
    }
    public class BookingUpdateDTO
    {
        public Guid BookingId { get; set; }
        public DateTime BookingTime { get; set; }
        //public List<CheckInWorkUpdateDTO> CheckInWorks { get; set; } = new List<CheckInWorkUpdateDTO>();

    }
}

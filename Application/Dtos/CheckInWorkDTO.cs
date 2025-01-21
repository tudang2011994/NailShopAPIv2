using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CheckInWorkDTO
    {
        public int ServiceId { get; set; }
        public int StaffId { get; set; }   
    }
    public class CheckInWorkUpdateDTO
    {
        public Guid CheckInWorkId { get; set; }
        public int ServiceId { get; set; }
        public int StaffId { get; set; }
    }
}

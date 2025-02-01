using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.JoinEntities;

namespace Core.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName {  get; set; }
        public float Amount { get; set; }
        public bool IsValid {  get; set; }
        public float Duration { get; set; }

        //Other Join table
        public ICollection<StaffService> StaffServices { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}

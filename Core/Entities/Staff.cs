using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.JoinEntities;

namespace Core.Entities
{
    public class Staff
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        //Join other table
        public ICollection<StaffService> StaffServices { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}

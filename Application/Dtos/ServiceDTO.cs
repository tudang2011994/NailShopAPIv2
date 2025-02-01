using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ServiceDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount {  get; set; }
    }
    public class ServiceUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

    }

    public class ServiceWithStaffDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public float Duration { get; set; }
        
        public List<StaffDTO> StaffDTOs { get; set; }
    }
}

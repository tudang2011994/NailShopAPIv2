using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities.JoinEntities
{
    public class StaffService
    {
        public int StaffId { get; set; }
        [JsonIgnore] // Prevent recursive serialization
        public Staff Staff { get; set; }
        public int ServiceId {  get; set; }
        [JsonIgnore] // Prevent recursive serialization
        public Service Service {  get; set; }
    }
}

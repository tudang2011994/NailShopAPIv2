﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class StaffDTO
    {
        public int Id { get; set;  }
        public string Name {  get; set; }   
    }

    public class StaffUpdateDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public List<ServiceUpdateDTO> Services { get; set; }

    }
}

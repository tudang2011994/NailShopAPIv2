using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Core.Entities;

namespace Application.Interfaces.Services
{
    public interface IStaffServices
    {
        public Task addStaffAsync(StaffDTO staff);
        public Task deleteStaffAsync(int id);
        public Task updateStaffAsync(StaffUpdateDTO staffDTO);
    }
}

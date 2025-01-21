using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.Data.Repositories;
using Application.Dtos;
using Core.Entities.JoinEntities;

namespace Application.Services
{
    public class StaffServices : IStaffServices
    {
        private readonly IStaffRepository _staffService;

        StaffServices(IStaffRepository staffService)
        {
            _staffService = staffService;
        }

        public async Task addStaffAsync(StaffDTO staffDTO)
        {
            var staff = new Staff
            {
                Name = staffDTO.Name,
            };
            await _staffService.addStaffAsync(staff);
        }

        public async Task deleteStaffAsync(int id)
        {
            await _staffService.deleteStaffAsync(id);
        }

        public async Task updateStaffAsync(StaffUpdateDTO staffDTO)
        {
            var staff = new Staff
            {
                Id = staffDTO.Id,
                Name = staffDTO.Name,
                StaffServices = staffDTO.Services.Select(ss => new StaffService
                {
                    ServiceId = ss.Id,
                }).ToList()
            };
            await _staffService.updateStaffAsync(staff);
        }
    }
}

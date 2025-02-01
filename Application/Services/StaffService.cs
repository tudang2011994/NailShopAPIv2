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
        private readonly IStaffRepository _staffRepository;

        public StaffServices(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task addStaffAsync(StaffDTO staffDTO)
        {
            var staff = new Staff
            {
                Name = staffDTO.Name,
            };
            await _staffRepository.addStaffAsync(staff);
        }

        public async Task deleteStaffAsync(int id)
        {
            await _staffRepository.deleteStaffAsync(id);
        }

        public async Task<IEnumerable<Staff>> getAllStaffsAsync()
        {
            return await _staffRepository.getAllStaffAsync();
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
            await _staffRepository.updateStaffAsync(staff);
        }
    }
}

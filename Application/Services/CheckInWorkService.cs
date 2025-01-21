using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class CheckInWorkService : ICheckInWorkService
    {
        private readonly ICheckInWorkRepository _checkInWorkRepository;

        public CheckInWorkService(ICheckInWorkRepository checkInWorkRepository)
        {
            _checkInWorkRepository = checkInWorkRepository;
        }

        public async Task addCheckInWorkAsync(CheckInWork checkInWork)
        {
            await _checkInWorkRepository.addCheckInWorkAsync(checkInWork);
        }

        public async Task deleteCheckInWorkAsync(Guid id)
        {
            await _checkInWorkRepository.deleteCheckInWorkAsync(id);
        }

        public async Task updateCheckInWorkAsync(CheckInWork checkInWork)
        {
            await _checkInWorkRepository.updateCheckInWorkAsync(checkInWork);
        }
    }
}

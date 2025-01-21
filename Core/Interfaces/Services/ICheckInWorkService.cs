using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface ICheckInWorkService
    {
        public Task addCheckInWorkAsync(CheckInWork checkInWork);
        public Task deleteCheckInWorkAsync(Guid id);
        public Task updateCheckInWorkAsync(CheckInWork checkInWork);
    }
}

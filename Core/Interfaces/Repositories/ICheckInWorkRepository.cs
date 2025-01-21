using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICheckInWorkRepository
    {
        public Task addCheckInWorkAsync(CheckInWork CheckInWork);
        public Task<ICollection<CheckInWork>> getAllCheckInWorkAsync();
        //public Task<CheckInWork> getCheckInWorkByIdAsync(Guid id);
        public Task updateCheckInWorkAsync(CheckInWork CheckInWork);
        public Task deleteCheckInWorkAsync(Guid id);
    }
}

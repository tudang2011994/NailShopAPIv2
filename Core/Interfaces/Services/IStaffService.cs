using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IStaffService
    {
        public Task addStaffAsync(Staff staff);
        public Task deleteStaffAsync(Guid id);
        public Task updateStaffAsync(Staff staff);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        public Task addStaffAsync(Staff staff);
        public Task<IEnumerable<Staff>> getAllStaffAsync();

        public Task<Staff> getStaffByIdAsync(int id);
        public Task updateStaffAsync(Staff staff);
        public Task deleteStaffAsync(int id);
    }
}

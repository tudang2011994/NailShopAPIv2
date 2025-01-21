using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Infrastructure.Data.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly MyAppDbContext _context;
        public ServiceRepository(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task addServiceAsync(Service service)
        {
            await _context.Services.AddAsync(service);
        }

        public async Task deleteServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if(service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<Service>> getAllServiceAsync()
        {
            return await _context.Services.Include(s => s.StaffServices).ThenInclude(ss => ss.Staff).ToListAsync();
        }

        public async Task<Service> getServiceByIdAsync(int id)
        {
            return await _context.Services.Include(s => s.StaffServices).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task updateServiceAsync(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IServiceRepository
    {
        public Task<Service> getServiceByIdAsync(int id);
        public Task<IEnumerable<Service>> getAllServiceAsync();
        public Task addServiceAsync(Service service);
        public Task updateServiceAsync (Service service);
        public Task deleteServiceAsync (int id);
    }
}

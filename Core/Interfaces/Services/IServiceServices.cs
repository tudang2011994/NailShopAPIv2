using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IServiceServices
    {
        public Task addServiceAsync(Service service);
        public Task updateServiceAsync(Service service);
        public Task deleteServiceAsync(Guid id);
    }
}

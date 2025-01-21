using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Core.Entities;

namespace Application.Interfaces.Services
{
    public interface IServiceServices
    {
        public Task addServiceAsync(ServiceDTO serviceDTO);
        public Task updateServiceAsync(ServiceUpdateDTO serviceUpdateDTO);
        public Task deleteServiceAsync(int id);
        Task<IEnumerable<Service>> getAllServicesAsync();

    }
}

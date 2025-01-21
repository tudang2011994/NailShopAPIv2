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
using System.Collections;

namespace Application.Services
{
    public class ServiceService : IServiceServices
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        //public async Task<IEnumerable<Service>> getAllServicesAsync()
        //{
        //    return await _serviceRepository.getAllServiceAsync();
        //}
        public async Task addServiceAsync(ServiceDTO serviceDTO)
        {
            var service = new Service
            {
                ServiceName = serviceDTO.Name,
                Amount = serviceDTO.Amount,
            };
            await _serviceRepository.addServiceAsync(service);
        }

        public async Task deleteServiceAsync(int id)
        {
            await _serviceRepository.deleteServiceAsync(id);
        }

        public async Task updateServiceAsync(ServiceUpdateDTO servicUpdateDTO)
        {
            var service = new Service
            {
                Id = servicUpdateDTO.Id,
                ServiceName = servicUpdateDTO.Name,
                Amount = servicUpdateDTO.Amount,
            };
            await _serviceRepository.updateServiceAsync(service);
        }

        public async Task<IEnumerable<Service>> getAllServicesAsync()
        {
            return await _serviceRepository.getAllServiceAsync();
        }
    }
}

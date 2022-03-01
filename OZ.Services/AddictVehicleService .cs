using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class AddictVehicleService : IAddictVehicleService
    {
        private IAddictVehicleRepository repository;
        public AddictVehicleService(IAddictVehicleRepository userRepository)
        {
            repository = userRepository;
        }

        public AddictVehicleDto Create(AddictVehicle domain)
        {
            return repository.SaveCreate(domain);
        }
        public bool Update(AddictVehicle domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<AddictVehicleDto> GetAll()
        {
            return repository.GetAll();
        }

        public AddictVehicleDto GetByID(Guid id)
        {
            return repository.GetByID(id);
        }

        public IEnumerable<AddictVehicleDto> GetByAddictID(Guid addictID)
        {
            return repository.GetByAddictID(addictID);
        }

        public PagedList<AddictVehicleDto> GetAddictVehicle(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            return repository.GetAddictVehicle(sortName, sortDirection, searchString, pageNumber, pageSize);
        }
    }
}

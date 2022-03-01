using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class AddictManagePlaceService : IAddictManagePlaceService
    {
        private IAddictManagePlaceRepository repository;
        public AddictManagePlaceService(IAddictManagePlaceRepository userRepository)
        {
            repository = userRepository;
        }

        public AddictManagePlaceDto Create(AddictManagePlace domain)
        {
            return repository.SaveCreate(domain);
        }
        public bool Update(AddictManagePlace domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<AddictManagePlaceDto> GetAll()
        {
            return repository.GetAll();
        }

        public AddictManagePlaceDto GetByID(Guid id)
        {
            return repository.GetByID(id);
        }

        public IEnumerable<AddictManagePlaceDto> GetByAddictID(Guid addictID)
        {
            return repository.GetByAddictID(addictID);
        }

        public PagedList<AddictManagePlaceDto> GetAddictPlaces(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            return repository.GetAddictPlaces(sortName, sortDirection, searchString, pageNumber, pageSize);
        }

        public IEnumerable<AddictManagePlaceDto2> GetAddictPlace2()
        {
            return repository.GetAddictPlace2();
        }
    }
}

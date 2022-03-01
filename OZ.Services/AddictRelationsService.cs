using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class AddictRelationsService : IAddictRelationsService
    {
        private IAddictRelationsRepository repository;
        public AddictRelationsService(IAddictRelationsRepository userRepository)
        {
            repository = userRepository;
        }
        public AddictRelationsDto Create(AddictRelations domain)
        {
            return repository.SaveCreate(domain);
        }
        public bool Update(AddictRelations domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<AddictRelationsDto> GetAll()
        {
            return repository.GetAll();
        }

        public AddictRelationsDto GetByID(Guid id)
        {
            return repository.GetByID(id);
        }

        public IEnumerable<AddictRelationsDto> GetByAddictID(Guid addictID)
        {
            return repository.GetByAddictID(addictID);
        }

        public PagedList<AddictRelationsDto> GetAddictRelations(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            return repository.GetAddictRelations(sortName, sortDirection, searchString, pageNumber, pageSize);
        }

        public IEnumerable<AddictRelationsDto2> GetAddictRelations2()
        {
            return repository.GetAddictRelations2();
        }
    }
}

using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class AddictDrugsService : IAddictDrugsService
    {
        private IAddictDrugsRepository repository;
        public AddictDrugsService(IAddictDrugsRepository userRepository)
        {
            repository = userRepository;
        }
        public AddictDrugDto Create(AddictDrugs domain)
        {
            return repository.SaveCreate(domain);
        }
        public bool Update(AddictDrugs domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<AddictDrugDto> GetAll()
        {
            return repository.GetAll();
        }

        public AddictDrugDto GetByID(Guid id)
        {
            return repository.GetByID(id);
        }

        public IEnumerable<AddictDrugDto> GetByAddictID(Guid addictID)
        {
            return repository.GetByAddictID(addictID);
        }

        public PagedList<AddictDrugDto> GetAddictDrugs(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            return repository.GetAddictDrugs(sortName, sortDirection, searchString, pageNumber, pageSize);
        }
    }
}

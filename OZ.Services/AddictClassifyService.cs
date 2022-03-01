using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class AddictClassifyService : IAddictClassifyService
    {
        private IAddictClassifyRepository repository;
        public AddictClassifyService(IAddictClassifyRepository userRepository)
        {
            repository = userRepository;
        }
        public AddictClassifyDto Create(AddictClassify domain)
        {
            return repository.SaveCreate(domain);
        }
        public bool Update(AddictClassify domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<AddictClassifyDto> GetAll()
        {
            return repository.GetAll();
        }

        public AddictClassifyDto GetByID(Guid id)
        {
            return repository.GetByID(id);
        }

        public IEnumerable<AddictClassifyDto> GetByAddictID(Guid addictID)
        {
            return repository.GetByAddictID(addictID);
        }

        public PagedList<AddictClassifyDto> GetAddictClassifys(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            return repository.GetAddictClassifys(sortName, sortDirection, searchString, pageNumber, pageSize);
        }

        
    }
}

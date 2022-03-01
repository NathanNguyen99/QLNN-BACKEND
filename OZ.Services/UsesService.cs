using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class UsesService : IUsesService
    {
        private IUsesRepository repository;
        public UsesService(IUsesRepository userRepository)
        {
            repository = userRepository;
        }
        public Uses Create(Uses domain)
        {
            return repository.Create(domain);
        }
        public bool Update(Uses domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<Uses> GetAll()
        {
            return repository.GetAll();
        }

        public Uses GetByID(int id)
        {
            return repository.GetByID(id);
        }
    }
}

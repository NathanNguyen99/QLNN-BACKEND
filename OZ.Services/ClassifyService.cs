using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class ClassifyService : IClassifyService
    {
        private IClassifyRepository repository;
        public ClassifyService(IClassifyRepository userRepository)
        {
            repository = userRepository;
        }
        public Classify Create(Classify domain)
        {
            return repository.Create(domain);
        }
        public bool Update(Classify domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<Classify> GetAll()
        {
            return repository.GetAll();
        }

        public Classify GetByID(int id)
        {
            return repository.GetByID(id);
        }
    }
}

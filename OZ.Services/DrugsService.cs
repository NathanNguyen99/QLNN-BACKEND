using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class DrugsService : IDrugsService
    {
        private IDrugsRepository repository;
        public DrugsService(IDrugsRepository userRepository)
        {
            repository = userRepository;
        }
        public Drugs Create(Drugs domain)
        {
            return repository.Create(domain);
        }
        public bool Update(Drugs domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<Drugs> GetAll()
        {
            return repository.GetAll();
        }

        public Drugs GetByID(int id)
        {
            return repository.GetByID(id);
        }
    }
}

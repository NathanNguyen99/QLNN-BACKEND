using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class RelationsService : IRelationsService
    {
        private IRelationsRepository repository;
        public RelationsService(IRelationsRepository userRepository)
        {
            repository = userRepository;
        }
        public Relations Create(Relations domain)
        {
            return repository.Create(domain);
        }
        public bool Update(Relations domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<Relations> GetAll()
        {
            return repository.GetAll();
        }

        public Relations GetByID(int id)
        {
            return repository.GetByID(id);
        }
    }
}

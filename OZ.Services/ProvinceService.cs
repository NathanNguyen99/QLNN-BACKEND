using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class ProvinceService : IProvinceService
    {
        private IProvinceRepository repository;
        public ProvinceService(IProvinceRepository userRepository)
        {
            repository = userRepository;
        }
        public Province Create(Province domain)
        {
            return repository.Create(domain);
        }
        public bool Update(Province domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<Province> GetAll()
        {
            return repository.GetAll();
        }

        public Province GetByID(int id)
        {
            return repository.GetByID(id);
        }
    }
}

using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class EducationLevelService : IEducationLevelService
    {
        private IEducationLevelRepository repository;
        public EducationLevelService(IEducationLevelRepository userRepository)
        {
            repository = userRepository;
        }
        public EducationLevel Create(EducationLevel domain)
        {
            return repository.Create(domain);
        }
        public bool Update(EducationLevel domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<EducationLevel> GetAll()
        {
            return repository.GetAll();
        }

        public EducationLevel GetByID(Guid id)
        {
            return repository.GetByID(id);
        }
    }
}

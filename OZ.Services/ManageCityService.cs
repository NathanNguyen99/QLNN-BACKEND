using Microsoft.AspNetCore.Http;
using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class ManageCityService : IManageCityService
    {
        private IManageCityRepository repository;
        public ManageCityService(IManageCityRepository userRepository)
        {
            repository = userRepository;
        }
        
        public IEnumerable<ManageCity> GetAll()
        {
            return repository.GetAll();
        }

        
    }
}



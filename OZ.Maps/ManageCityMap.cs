using Microsoft.AspNetCore.Http;
using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class ManageCityMap : IManageCityMap
    {
        IManageCityService empService;
        public ManageCityMap(IManageCityService service)
        {
            empService = service;
        }
        
        public List<ManageCityViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }

        public ManageCityViewModel DomainToViewModel(ManageCity domain)
        {
            var lst = empService.GetAll();
            ManageCityViewModel model = new ManageCityViewModel();
            model.OID = domain.OID;
            model.CityName = domain.CityName;
            model.CityType = domain.CityType;
            return model;
        }
        public List<ManageCityViewModel> DomainToViewModel(IEnumerable<ManageCity> domain)
        {
            var lst = empService.GetAll();
            List<ManageCityViewModel> model = new List<ManageCityViewModel>();
            foreach (ManageCity of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
    }
}

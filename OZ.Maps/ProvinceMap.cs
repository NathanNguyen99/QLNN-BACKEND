using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class ProvinceMap : IProvinceMap
    {
        IProvinceService empService;
        public ProvinceMap(IProvinceService service)
        {
            empService = service;
        }
        public ProvinceViewModel Create(ProvinceViewModel viewModel)
        {
            Province user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(ProvinceViewModel viewModel)
        {
            Province user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(Guid id)
        {
            return empService.Delete(id);
        }
        public IEnumerable<ProvinceViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public ProvinceViewModel DomainToViewModel(Province domain)
        {
            ProvinceViewModel model = new ProvinceViewModel();            
            model.ProvinceName = domain.ProvinceName;
            model.Seq = domain.Seq;
            model.OID = domain.OID;            
            return model;
        }
        public IEnumerable<ProvinceViewModel> DomainToViewModel(IEnumerable<Province> domain)
        {
            List<ProvinceViewModel> model = new List<ProvinceViewModel>();
            foreach (Province of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public Province ViewModelToDomain(ProvinceViewModel officeViewModel)
        {
            Province domain = new Province();
            domain.ProvinceName = officeViewModel.ProvinceName;
            domain.Seq = officeViewModel.Seq;
            domain.OID = officeViewModel.OID;
            
            return domain;
        }

        public ProvinceViewModel GetByID(int id)
        {
            var objdomain = empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }
    }
}

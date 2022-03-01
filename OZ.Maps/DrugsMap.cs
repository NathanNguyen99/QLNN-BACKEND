using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class DrugsMap : IDrugsMap
    {
        IDrugsService empService;
        public DrugsMap(IDrugsService service)
        {
            empService = service;
        }
        public DrugsViewModel Create(DrugsViewModel viewModel)
        {
            Drugs user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(DrugsViewModel viewModel)
        {
            Drugs user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(int id)
        {
            return empService.Delete(id);
        }
        public IEnumerable<DrugsViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public DrugsViewModel DomainToViewModel(Drugs domain)
        {
            DrugsViewModel model = new DrugsViewModel();            
            model.DrugsName = domain.DrugsName;            
            model.OID = domain.OID;            
            return model;
        }
        public IEnumerable<DrugsViewModel> DomainToViewModel(IEnumerable<Drugs> domain)
        {
            List<DrugsViewModel> model = new List<DrugsViewModel>();
            foreach (Drugs of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public Drugs ViewModelToDomain(DrugsViewModel officeViewModel)
        {
            Drugs domain = new Drugs();
            domain.DrugsName = officeViewModel.DrugsName;           
            domain.OID = officeViewModel.OID;
            
            return domain;
        }

        public DrugsViewModel GetByID(int id)
        {
            var objdomain = empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }
    }
}

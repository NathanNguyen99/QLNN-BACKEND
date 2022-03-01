using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class UsesMap : IUsesMap
    {
        IUsesService empService;
        public UsesMap(IUsesService service)
        {
            empService = service;
        }
        public UsesViewModel Create(UsesViewModel viewModel)
        {
            Uses user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(UsesViewModel viewModel)
        {
            Uses user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(int id)
        {
            return empService.Delete(id);
        }
        public List<UsesViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public UsesViewModel DomainToViewModel(Uses domain)
        {
            UsesViewModel model = new UsesViewModel();            
            model.MethodName = domain.MethodName;            
            model.OID = domain.OID;            
            return model;
        }
        public List<UsesViewModel> DomainToViewModel(IEnumerable<Uses> domain)
        {
            List<UsesViewModel> model = new List<UsesViewModel> ();
            foreach (Uses of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public Uses ViewModelToDomain(UsesViewModel officeViewModel)
        {
            Uses domain = new Uses();
            domain.MethodName = officeViewModel.MethodName;           
            domain.OID = officeViewModel.OID;
            return domain;
        }
        public UsesViewModel GetByID(int id)
        {
            var objdomain = empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }
    }
}

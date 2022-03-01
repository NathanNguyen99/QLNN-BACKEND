using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class RelationsMap : IRelationsMap
    {
        IRelationsService empService;
        public RelationsMap(IRelationsService service)
        {
            empService = service;
        }
        public RelationsViewModel Create(RelationsViewModel viewModel)
        {
            Relations user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(RelationsViewModel viewModel)
        {
            Relations user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(int id)
        {
            return empService.Delete(id);
        }
        public IEnumerable<RelationsViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public RelationsViewModel DomainToViewModel(Relations domain)
        {
            RelationsViewModel model = new RelationsViewModel();            
            model.RelationName = domain.RelationName;            
            model.OID = domain.OID;            
            return model;
        }
        public IEnumerable<RelationsViewModel> DomainToViewModel(IEnumerable<Relations> domain)
        {
            List<RelationsViewModel> model = new List<RelationsViewModel>();
            foreach (Relations of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public Relations ViewModelToDomain(RelationsViewModel officeViewModel)
        {
            Relations domain = new Relations();
            domain.RelationName = officeViewModel.RelationName;           
            domain.OID = officeViewModel.OID;
            
            return domain;
        }

        public RelationsViewModel GetByID(int id)
        {
            var objdomain = empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }
    }
}

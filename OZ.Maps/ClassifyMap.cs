using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class ClassifyMap : IClassifyMap
    {
        IClassifyService empService;
        public ClassifyMap(IClassifyService service)
        {
            empService = service;
        }
        public ClassifyViewModel Create(ClassifyViewModel viewModel)
        {
            Classify user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(ClassifyViewModel viewModel)
        {
            Classify user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(int id)
        {
            return empService.Delete(id);
        }
        public IEnumerable<ClassifyViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public ClassifyViewModel DomainToViewModel(Classify domain)
        {
            ClassifyViewModel model = new ClassifyViewModel();            
            model.ClassifyName = domain.ClassifyName;            
            model.OID = domain.OID;            
            return model;
        }
        public IEnumerable<ClassifyViewModel> DomainToViewModel(IEnumerable<Classify> domain)
        {
            List<ClassifyViewModel> model = new List<ClassifyViewModel>();
            foreach (Classify of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public Classify ViewModelToDomain(ClassifyViewModel officeViewModel)
        {
            Classify domain = new Classify();
            domain.ClassifyName = officeViewModel.ClassifyName;           
            domain.OID = officeViewModel.OID;
            
            return domain;
        }

        public ClassifyViewModel GetByID(int id)
        {
            var objdomain = empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }
    }
}

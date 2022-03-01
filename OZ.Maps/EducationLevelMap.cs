using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class EducationLevelMap : IEducationLevelMap
    {
        IEducationLevelService empService;
        public EducationLevelMap(IEducationLevelService service)
        {
            empService = service;
        }
        public EducationLevelViewModel Create(EducationLevelViewModel viewModel)
        {
            EducationLevel user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(EducationLevelViewModel viewModel)
        {
            EducationLevel user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(Guid id)
        {
            return empService.Delete(id);
        }
        public List<EducationLevelViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public EducationLevelViewModel DomainToViewModel(EducationLevel domain)
        {
            EducationLevelViewModel model = new EducationLevelViewModel();            
            model.EducationName = domain.EducationName;
            model.Seq = domain.Seq;
            model.OID = domain.OID;            
            return model;
        }
        public List<EducationLevelViewModel> DomainToViewModel(IEnumerable<EducationLevel> domain)
        {
            List<EducationLevelViewModel> model = new List<EducationLevelViewModel> ();
            foreach (EducationLevel of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public EducationLevel ViewModelToDomain(EducationLevelViewModel officeViewModel)
        {
            EducationLevel domain = new EducationLevel();
            domain.EducationName = officeViewModel.EducationName;
            domain.Seq = officeViewModel.Seq;
            domain.OID = officeViewModel.OID;
            return domain;
        }
        public EducationLevelViewModel GetByID(Guid id)
        {
            var objdomain = empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }
    }
}

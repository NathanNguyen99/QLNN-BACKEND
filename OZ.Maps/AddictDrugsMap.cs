using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class AddictDrugsMap : IAddictDrugsMap
    {
        IAddictDrugsService empService;
        public AddictDrugsMap(IAddictDrugsService service)
        {
            empService = service;
        }
        public AddictDrugsViewModel Create(AddictDrugsViewModel viewModel)
        {
            AddictDrugs user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(AddictDrugsViewModel viewModel)
        {
            AddictDrugs user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(Guid id)
        {
            return empService.Delete(id);
        }
        public List<AddictDrugsViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public AddictDrugsViewModel DomainToViewModel(AddictDrugDto domain)
        {
            AddictDrugsViewModel model = new AddictDrugsViewModel();
            model.AddictID = domain.AddictID;
            model.AddictCode = domain.AddictCode;
            model.AddictName = domain.AddictName;
            model.DrugsID = domain.DrugsID;
            model.DrugsName = domain.DrugsName;
            model.inUse = domain.inUse;
            model.Remarks = domain.Remarks;
            model.UseID = domain.UseID;
            model.UseName = domain.UseName;
            model.OID = domain.OID;
            
            return model;
        }
        public List<AddictDrugsViewModel> DomainToViewModel(IEnumerable<AddictDrugDto> domain)
        {
            List<AddictDrugsViewModel> model = new List<AddictDrugsViewModel> ();
            foreach (AddictDrugDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public PagedList<AddictDrugsViewModel> DomainToViewModel(PagedList<AddictDrugDto> domain)
        {
            List<AddictDrugsViewModel> model = new List<AddictDrugsViewModel>();
            foreach (AddictDrugDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            PagedList<AddictDrugsViewModel> model2 = new PagedList<AddictDrugsViewModel>(model, domain.TotalCount, domain.CurrentPage, domain.PageSize);
            
            return model2;
        }
        public AddictDrugs ViewModelToDomain(AddictDrugsViewModel officeViewModel)
        {
            AddictDrugs domain = new AddictDrugs();
            domain.AddictID = officeViewModel.AddictID;
            domain.DrugsID = officeViewModel.DrugsID;
            domain.inUse = officeViewModel.inUse;
            domain.Remarks = officeViewModel.Remarks;
            domain.UseID = officeViewModel.UseID;            
            domain.OID = officeViewModel.OID;
            return domain;
        }

        public AddictDrugsViewModel GetByID(Guid id)
        {
            var objdomain =empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }

        public List<AddictDrugsViewModel> GetByAddictID(Guid addictID)
        {
            return DomainToViewModel(empService.GetByAddictID(addictID));
        }

        public PagedList<AddictDrugsViewModel> GetAddictDrugs(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            var lstPlaces = empService.GetAddictDrugs(sortName, sortDirection, searchString, pageNumber, pageSize);

            return DomainToViewModel(lstPlaces);
        }

        
    }
}

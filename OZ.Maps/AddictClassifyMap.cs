using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class AddictClassifyMap : IAddictClassifyMap
    {
        IAddictClassifyService empService;
        public AddictClassifyMap(IAddictClassifyService service)
        {
            empService = service;
        }
        public AddictClassifyViewModel Create(AddictClassifyViewModel viewModel)
        {
            AddictClassify user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(AddictClassifyViewModel viewModel)
        {
            AddictClassify user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(Guid id)
        {
            return empService.Delete(id);
        }
        public List<AddictClassifyViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public AddictClassifyViewModel DomainToViewModel(AddictClassifyDto domain)
        {
            AddictClassifyViewModel model = new AddictClassifyViewModel();
            model.AddictID = domain.AddictID;
            model.AddictCode = domain.AddictCode;
            model.AddictName = domain.AddictName;
            model.ClassifyID = domain.ClassifyID;
            model.ClassifyName = domain.ClassifyName;            
            model.Remarks = domain.Remarks;      
            model.OID = domain.OID;            
            return model;
        }
        public List<AddictClassifyViewModel> DomainToViewModel(IEnumerable<AddictClassifyDto> domain)
        {
            List<AddictClassifyViewModel> model = new List<AddictClassifyViewModel> ();
            foreach (AddictClassifyDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public PagedList<AddictClassifyViewModel> DomainToViewModel(PagedList<AddictClassifyDto> domain)
        {
            List<AddictClassifyViewModel> model = new List<AddictClassifyViewModel>();
            foreach (AddictClassifyDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            PagedList<AddictClassifyViewModel> model2 = new PagedList<AddictClassifyViewModel>(model, domain.TotalCount, domain.CurrentPage, domain.PageSize);
            
            return model2;
        }
        public AddictClassify ViewModelToDomain(AddictClassifyViewModel officeViewModel)
        {
            AddictClassify domain = new AddictClassify();
            domain.AddictID = officeViewModel.AddictID;
            domain.ClassifyID = officeViewModel.ClassifyID;            
            domain.Remarks = officeViewModel.Remarks;                      
            domain.OID = officeViewModel.OID;
            return domain;
        }
        public AddictClassifyViewModel GetByID(Guid id)
        {
            var objdomain =empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }

        public List<AddictClassifyViewModel> GetByAddictID(Guid addictID)
        {
            return DomainToViewModel(empService.GetByAddictID(addictID));
        }

        public PagedList<AddictClassifyViewModel> GetAddictClassify(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            var lstPlaces = empService.GetAddictClassifys(sortName, sortDirection, searchString, pageNumber, pageSize);

            return DomainToViewModel(lstPlaces);
        }

        
    }
}

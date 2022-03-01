using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class AddictRelationsMap : IAddictRelationsMap
    {
        IAddictRelationsService empService;
        public AddictRelationsMap(IAddictRelationsService service)
        {
            empService = service;
        }
        public AddictRelationsViewModel Create(AddictRelationsViewModel viewModel)
        {
            AddictRelations user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(AddictRelationsViewModel viewModel)
        {
            AddictRelations user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(Guid id)
        {
            return empService.Delete(id);
        }
        public List<AddictRelationsViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public AddictRelationsViewModel DomainToViewModel(AddictRelationsDto domain)
        {
            AddictRelationsViewModel model = new AddictRelationsViewModel();
            model.AddictID = domain.AddictID;
            model.AddictCode = domain.AddictCode;
            model.AddictName = domain.AddictName;

            model.Date = domain.Date;
            model.RelationWithID = domain.RelationWithID;
            model.RelationWithName = domain.RelationWithName;

            model.ManagePlaceID = domain.ManagePlaceID;
            model.ManagePlaceName = domain.ManagePlaceName;
            model.BlackList = domain.BlackList;
            model.OtherName = domain.OtherName;
            model.CurrentAddress = domain.CurrentAddress;
            model.DateOfBirth = domain.DateOfBirth;


            model.RelationsID = domain.RelationsID;
            model.RelationsName = domain.RelationsName;         

            model.Remarks = domain.Remarks;

            model.OID = domain.OID;
            
            return model;
        }
        public List<AddictRelationsViewModel> DomainToViewModel(IEnumerable<AddictRelationsDto> domain)
        {
            List<AddictRelationsViewModel> model = new List<AddictRelationsViewModel> ();
            foreach (AddictRelationsDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public PagedList<AddictRelationsViewModel> DomainToViewModel(PagedList<AddictRelationsDto> domain)
        {
            List<AddictRelationsViewModel> model = new List<AddictRelationsViewModel>();
            foreach (AddictRelationsDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            PagedList<AddictRelationsViewModel> model2 = new PagedList<AddictRelationsViewModel>(model, domain.TotalCount, domain.CurrentPage, domain.PageSize);
            
            return model2;
        }

        public AddictRelationsViewModel2 DomainToViewModel(AddictRelationsDto2 domain)
        {
            AddictRelationsViewModel2 model = new AddictRelationsViewModel2();
            model.AddictID = domain.AddictID;
            model.DOB = domain.DOB;
            model.AddictCode = domain.AddictCode;
            model.AddictName = domain.AddictName;

            foreach (var item in domain.ActivityLog)
            {
                model.ActivityLog.Add(DomainToViewModel(item));
            }
            return model;
        }

        public List<AddictRelationsViewModel2> DomainToViewModel2(IEnumerable<AddictRelationsDto2> domain)
        {
            List<AddictRelationsViewModel2> model = new List<AddictRelationsViewModel2>();
            foreach (AddictRelationsDto2 of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            List<AddictRelationsViewModel2> model2 = new List<AddictRelationsViewModel2>(model);
            return model2;
        }
        public AddictRelations ViewModelToDomain(AddictRelationsViewModel officeViewModel)
        {
            AddictRelations domain = new AddictRelations();
            domain.AddictID = officeViewModel.AddictID;
            domain.RelationWithID = officeViewModel.RelationWithID;
            domain.RelationsID = officeViewModel.RelationsID;
            domain.ManagePlaceID = (Guid)officeViewModel.ManagePlaceID;
            domain.BlackList = officeViewModel.BlackList;
            domain.OtherName = officeViewModel.OtherName;
            domain.CurrentAddress = officeViewModel.CurrentAddress;
            domain.Date = officeViewModel.Date;
            domain.DateOfBirth = officeViewModel.DateOfBirth;

            domain.Remarks = officeViewModel.Remarks;
            domain.OID = officeViewModel.OID;
            return domain;
        }

        public AddictRelationsViewModel GetByID(Guid id)
        {
            var objdomain =empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }

        public List<AddictRelationsViewModel> GetByAddictID(Guid addictID)
        {
            return DomainToViewModel(empService.GetByAddictID(addictID));
        }

        public PagedList<AddictRelationsViewModel> GetAddictRelations(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            var lstPlaces = empService.GetAddictRelations(sortName, sortDirection, searchString, pageNumber, pageSize);

            return DomainToViewModel(lstPlaces);
        }

        public List<AddictRelationsViewModel2> GetAddictRelations2()
        {
            var lstPlaces = empService.GetAddictRelations2();

            return DomainToViewModel2(lstPlaces);
        }
    }
}

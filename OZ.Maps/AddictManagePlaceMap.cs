using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Maps
{
    public class AddictManagePlaceMap : IAddictManagePlaceMap
    {
        IAddictManagePlaceService empService;
        IManagePlaceService _mservice;
        public AddictManagePlaceMap(IAddictManagePlaceService service, IManagePlaceService mservice)
        {
            empService = service;
            _mservice = mservice;
        }
        public AddictManagePlaceViewModel Create(AddictManagePlaceViewModel viewModel)
        {
            AddictManagePlace user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(AddictManagePlaceViewModel viewModel)
        {
            AddictManagePlace user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(Guid id)
        {
            return empService.Delete(id);
        }
        public List<AddictManagePlaceViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public AddictManagePlaceViewModel DomainToViewModel(AddictManagePlaceDto domain)
        {
            AddictManagePlaceViewModel model = new AddictManagePlaceViewModel();
            model.AddictID = domain.AddictID;
            model.FromDate = domain.FromDate;
            model.ToDate = domain.ToDate;
            model.ManagePlaceID = domain.ManagePlaceID;
            model.PlaceTypeID = domain.PlaceTypeID;
            model.Remarks = domain.Remarks;
            model.OID = domain.OID;
            model.PlaceName = domain.PlaceName;
            model.PlaceTypeName = domain.PlaceTypeName;
            model.AddictCode = domain.AddictCode;
            model.AddictName = domain.AddictName;
            //model.PlaceTypeName = _mservice.GetPlaceTypeName(domain.PlaceTypeID);
            //var oplace = _mservice.GetByID(domain.ManagePlaceID);
            //if (oplace != null)
            //    model.PlaceName = _mservice.GetByID(domain.ManagePlaceID).PlaceName;
            return model;
        }
        public AddictManagePlaceViewModel2 DomainToViewModel(AddictManagePlaceDto2 domain)
        {
            AddictManagePlaceViewModel2 model = new AddictManagePlaceViewModel2();
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
        public List<AddictManagePlaceViewModel> DomainToViewModel(IEnumerable<AddictManagePlaceDto> domain)
        {
            List<AddictManagePlaceViewModel> model = new List<AddictManagePlaceViewModel>();
            foreach (AddictManagePlaceDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public List<AddictManagePlaceViewModel2> DomainToViewModel2(IEnumerable<AddictManagePlaceDto2> domain)
        {
            List<AddictManagePlaceViewModel2> model = new List<AddictManagePlaceViewModel2>();
            foreach (AddictManagePlaceDto2 of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            List<AddictManagePlaceViewModel2> model2 = new List<AddictManagePlaceViewModel2>(model);
            return model2;
        }
        public PagedList<AddictManagePlaceViewModel> DomainToViewModel(PagedList<AddictManagePlaceDto> domain)
        {
            List<AddictManagePlaceViewModel> model = new List<AddictManagePlaceViewModel>();
            foreach (AddictManagePlaceDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            PagedList<AddictManagePlaceViewModel> model2 = new PagedList<AddictManagePlaceViewModel>(model, domain.TotalCount, domain.CurrentPage, domain.PageSize);
            //return PagedList<AddictManagePlaceViewModel>.ToPagedList(model, domain.CurrentPage, domain.PageSize);
            return model2;
        }
        public AddictManagePlace ViewModelToDomain(AddictManagePlaceViewModel officeViewModel)
        {
            AddictManagePlace domain = new AddictManagePlace();
            domain.AddictID = officeViewModel.AddictID;
            domain.FromDate = officeViewModel.FromDate;
            domain.ToDate = officeViewModel.ToDate;
            domain.ManagePlaceID = officeViewModel.ManagePlaceID;
            domain.PlaceTypeID = officeViewModel.PlaceTypeID;
            domain.Remarks = officeViewModel.Remarks;
            domain.OID = officeViewModel.OID;
            return domain;
        }

        public AddictManagePlaceViewModel GetByID(Guid id)
        {
            var objdomain = empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }

        public List<AddictManagePlaceViewModel> GetByAddictID(Guid addictID)
        {
            return DomainToViewModel(empService.GetByAddictID(addictID));
        }

        public PagedList<AddictManagePlaceViewModel> GetAddictPlaces(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            var lstPlaces = empService.GetAddictPlaces(sortName, sortDirection, searchString, pageNumber, pageSize);

            return DomainToViewModel(lstPlaces);
        }

        public List<AddictManagePlaceViewModel2> GetAddictPlace2()
        {
            var lstPlaces = empService.GetAddictPlace2();

            return DomainToViewModel2(lstPlaces);
        }
    }
}

using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Maps
{
    public class AddictVehicleMap : IAddictVehicleMap
    {
        IAddictVehicleService empService;
        public AddictVehicleMap(IAddictVehicleService service)
        {
            empService = service;
        }
        public AddictVehicleViewModel Create(AddictVehicleViewModel viewModel)
        {
            AddictVehicle user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(AddictVehicleViewModel viewModel)
        {
            AddictVehicle user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(Guid id)
        {
            return empService.Delete(id); 
        }
        public List<AddictVehicleViewModel> GetAll()
        {            
            return DomainToViewModel(empService.GetAll());
        }
        public AddictVehicleViewModel DomainToViewModel(AddictVehicleDto domain)
        {
            AddictVehicleViewModel model = new AddictVehicleViewModel();
            model.AddictID = domain.AddictID;
            model.Remarks = domain.Remarks;            
            model.OID = domain.OID;
            model.nhanHieu = domain.nhanHieu;
            model.kieuXe = domain.kieuXe;
            model.mauXe = domain.mauXe;
            model.bienSo = domain.bienSo;
            model.noiDangKy = domain.noiDangKy;
            model.giayPhep = domain.giayPhep;

            //model.PlaceTypeName = _mservice.GetPlaceTypeName(domain.PlaceTypeID);
            //var oplace = _mservice.GetByID(domain.ManagePlaceID);
            //if (oplace != null)
            //    model.PlaceName = _mservice.GetByID(domain.ManagePlaceID).PlaceName;
            return model;
        }
        public List<AddictVehicleViewModel> DomainToViewModel(IEnumerable<AddictVehicleDto> domain)
        {
            List<AddictVehicleViewModel> model = new List<AddictVehicleViewModel> ();
            foreach (AddictVehicleDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public PagedList<AddictVehicleViewModel> DomainToViewModel(PagedList<AddictVehicleDto> domain)
        {
            List<AddictVehicleViewModel> model = new List<AddictVehicleViewModel>();
            foreach (AddictVehicleDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            PagedList<AddictVehicleViewModel> model2 = new PagedList<AddictVehicleViewModel>(model, domain.TotalCount, domain.CurrentPage, domain.PageSize);
            //return PagedList<AddictManagePlaceViewModel>.ToPagedList(model, domain.CurrentPage, domain.PageSize);
            return model2;
        }
        public AddictVehicle ViewModelToDomain(AddictVehicleViewModel officeViewModel)
        {
            AddictVehicle domain = new AddictVehicle();
            domain.AddictID = officeViewModel.AddictID;

            domain.nhanHieu = officeViewModel.nhanHieu;
            domain.kieuXe = officeViewModel.kieuXe;
            domain.mauXe = officeViewModel.mauXe;
            domain.bienSo = officeViewModel.bienSo;
            domain.noiDangKy = officeViewModel.noiDangKy;
            domain.giayPhep = officeViewModel.giayPhep;   

            domain.Remarks = officeViewModel.Remarks;
            domain.OID = officeViewModel.OID;
            return domain;
        }

        public AddictVehicleViewModel GetByID(Guid id)
        {
            var objdomain = empService.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }

        public List<AddictVehicleViewModel> GetByAddictID(Guid addictID)
        {
            return DomainToViewModel(empService.GetByAddictID(addictID));
        }

        public PagedList<AddictVehicleViewModel> GetAddictVehicle(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            var lstPlaces = empService.GetAddictVehicle(sortName, sortDirection, searchString, pageNumber, pageSize);

            return DomainToViewModel(lstPlaces);
        }
    }
}

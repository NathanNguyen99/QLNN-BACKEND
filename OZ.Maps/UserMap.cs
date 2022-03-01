using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class UserMap : IUserMap
    {
        IUserService empService;
        IManagePlaceService _managePlaceService;
        public UserMap(IUserService service, IManagePlaceService managePlaceService)
        {
            empService = service;
            _managePlaceService = managePlaceService;
        }
        public UserViewModel Create(UserViewModel viewModel)
        {
            User user = ViewModelToDomain(viewModel);
            return DomainToViewModel(empService.Create(user));
        }
        public bool Update(UserViewModel viewModel)
        {
            User user = ViewModelToDomain(viewModel);
            return empService.Update(user);
        }
        public bool Delete(Guid id)
        {
            return empService.Delete(id);
        }
        public IEnumerable<UserViewModel> GetAll()
        {
            return DomainToViewModel(empService.GetAll());
        }
        public UserViewModel DomainToViewModel(UserDto domain)
        {
            UserViewModel model = new UserViewModel();            
            model.UserName = domain.UserName;            
            model.OID = domain.OID;
            model.FullName = domain.FullName;
            model.Active = domain.Active;
            model.Password = domain.Password;
            model.Admin = domain.Admin;
            model.PlaceID = domain.PlaceID;
            model.PlaceName = domain.PlaceName;
            model.ManageCityID = domain.ManageCityID;
            model.ManageCityTypeID = domain.ManageCityTypeID;
            model.ManageCityTypeName = domain.ManageCityTypeName;
            model.ManageCityName = domain.ManageCityName;
            return model;
        }

        public UserViewModel DomainToViewModel2(User domain)
        {
            UserViewModel model = new UserViewModel();
            model.UserName = domain.UserName;
            model.OID = domain.OID;
            model.FullName = domain.FullName;
            model.Active = domain.Active;
            model.Password = domain.Password;
            model.Admin = domain.Admin;
            model.PlaceID = domain.PlaceID;
            model.ManageCityID = domain.ManageCityID;
            model.ManageCityTypeID = domain.ManageCityTypeID;
            

            return model;
        }
        public IEnumerable<UserViewModel> DomainToViewModel(IEnumerable<UserDto> domain)
        {
            List<UserViewModel> model = new List<UserViewModel>();
            foreach (UserDto of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public User ViewModelToDomain(UserViewModel officeViewModel)
        {
            User domain = new User();
            domain.UserName = officeViewModel.UserName;     
            domain.OID = officeViewModel.OID;
            domain.FullName = officeViewModel.FullName;
            domain.Active = officeViewModel.Active;
            domain.Password = officeViewModel.Password;
            domain.Admin = officeViewModel.Admin;
            domain.PlaceID = officeViewModel.PlaceID;
            domain.ManageCityID = officeViewModel.ManageCityID;
            domain.ManageCityTypeID = officeViewModel.ManageCityTypeID;

            return domain;
        }

        public UserViewModel GetByID(Guid id)
        {
            var objdomain = empService.GetByID(id);
            var model = DomainToViewModel2(objdomain);
            return model;
        }

        public UserViewModel CheckLogin(string username, string password)
        {
            var model = empService.CheckLogin(username, password);
            if (model != null)
                return DomainToViewModel(model);
            return null;
        }

        public bool ChangePassword(Guid userid, string oldPassword, string newPassword)
        {
            return empService.ChangePassword(userid, oldPassword, newPassword);
        }
    }
}

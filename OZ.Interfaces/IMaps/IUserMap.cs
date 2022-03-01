using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IUserMap
    {
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetByID(Guid id);
        bool Delete(Guid id);
        bool Update(UserViewModel viewModel);
        UserViewModel Create(UserViewModel viewModel);
        UserViewModel CheckLogin(string username, string password);
        bool ChangePassword(Guid userid, string oldPassword, string newPassword);
    }
}

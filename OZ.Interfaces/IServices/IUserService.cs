using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        User GetByID(Guid id);
        UserDto Create(User domain);
        bool Update(User domain);
        bool Delete(Guid id);
        UserDto CheckLogin(string username, string password);
        bool ChangePassword(Guid userid, string oldPassword, string newPassword);
    }
}

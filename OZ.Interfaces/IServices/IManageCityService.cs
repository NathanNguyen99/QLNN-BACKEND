using Microsoft.AspNetCore.Http;
using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IManageCityService
    {
        IEnumerable<ManageCity> GetAll();
    }
}

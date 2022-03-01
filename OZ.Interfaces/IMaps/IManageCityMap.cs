using Microsoft.AspNetCore.Http;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IManageCityMap
    {
        List<ManageCityViewModel> GetAll();
    }
}

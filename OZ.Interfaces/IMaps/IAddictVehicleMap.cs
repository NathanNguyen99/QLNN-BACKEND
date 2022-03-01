using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IAddictVehicleMap
    {
        List<AddictVehicleViewModel> GetAll();
        List<AddictVehicleViewModel> GetByAddictID(Guid addictID);
        AddictVehicleViewModel GetByID(Guid id);
        bool Delete(Guid id);
        bool Update(AddictVehicleViewModel viewModel);
        AddictVehicleViewModel Create(AddictVehicleViewModel viewModel);
        PagedList<AddictVehicleViewModel> GetAddictVehicle(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
    }
}

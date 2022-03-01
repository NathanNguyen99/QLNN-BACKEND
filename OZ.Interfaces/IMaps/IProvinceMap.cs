using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IProvinceMap
    {
        IEnumerable<ProvinceViewModel> GetAll();
        ProvinceViewModel GetByID(int id);
        bool Delete(Guid id);
        bool Update(ProvinceViewModel viewModel);
        ProvinceViewModel Create(ProvinceViewModel viewModel);
    }
}

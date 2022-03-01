using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IUsesMap
    {
        List<UsesViewModel> GetAll();
        UsesViewModel GetByID(int id);
        bool Delete(int id);
        bool Update(UsesViewModel viewModel);
        UsesViewModel Create(UsesViewModel viewModel);
    }
}

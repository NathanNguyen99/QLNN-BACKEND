using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IDrugsMap
    {
        IEnumerable<DrugsViewModel> GetAll();
        DrugsViewModel GetByID(int id);
        bool Delete(int id);
        bool Update(DrugsViewModel viewModel);
        DrugsViewModel Create(DrugsViewModel viewModel);
    }
}

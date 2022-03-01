using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IClassifyMap
    {
        IEnumerable<ClassifyViewModel> GetAll();
        ClassifyViewModel GetByID(int id);
        bool Delete(int id);
        bool Update(ClassifyViewModel viewModel);
        ClassifyViewModel Create(ClassifyViewModel viewModel);
    }
}

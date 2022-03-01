using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IRelationsMap
    {
        IEnumerable<RelationsViewModel> GetAll();
        RelationsViewModel GetByID(int id);
        bool Delete(int id);
        bool Update(RelationsViewModel viewModel);
        RelationsViewModel Create(RelationsViewModel viewModel);
    }
}

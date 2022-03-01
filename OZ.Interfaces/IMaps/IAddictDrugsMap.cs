using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IAddictDrugsMap
    {
        List<AddictDrugsViewModel> GetAll();
        List<AddictDrugsViewModel> GetByAddictID(Guid addictID);
        AddictDrugsViewModel GetByID(Guid id);
        bool Delete(Guid id);
        bool Update(AddictDrugsViewModel viewModel);
        AddictDrugsViewModel Create(AddictDrugsViewModel viewModel);
        PagedList<AddictDrugsViewModel> GetAddictDrugs(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
    }
}

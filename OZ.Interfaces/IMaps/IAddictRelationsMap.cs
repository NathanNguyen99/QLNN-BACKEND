using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IAddictRelationsMap
    {
        List<AddictRelationsViewModel> GetAll();
        List<AddictRelationsViewModel> GetByAddictID(Guid addictID);
        AddictRelationsViewModel GetByID(Guid id);
        bool Delete(Guid id);
        bool Update(AddictRelationsViewModel viewModel);
        AddictRelationsViewModel Create(AddictRelationsViewModel viewModel);
        PagedList<AddictRelationsViewModel> GetAddictRelations(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
        List<AddictRelationsViewModel2> GetAddictRelations2();

    }
}

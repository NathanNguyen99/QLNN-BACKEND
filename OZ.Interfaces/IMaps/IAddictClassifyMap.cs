using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IAddictClassifyMap
    {
        List<AddictClassifyViewModel> GetAll();
        List<AddictClassifyViewModel> GetByAddictID(Guid addictID);
        AddictClassifyViewModel GetByID(Guid id);
        bool Delete(Guid id);
        bool Update(AddictClassifyViewModel viewModel);
        AddictClassifyViewModel Create(AddictClassifyViewModel viewModel);
        PagedList<AddictClassifyViewModel> GetAddictClassify(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
    }
}

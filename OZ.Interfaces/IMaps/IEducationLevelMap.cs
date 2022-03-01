using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IEducationLevelMap
    {
        List<EducationLevelViewModel> GetAll();
        EducationLevelViewModel GetByID(Guid id);
        bool Delete(Guid id);
        bool Update(EducationLevelViewModel viewModel);
        EducationLevelViewModel Create(EducationLevelViewModel viewModel);
    }
}

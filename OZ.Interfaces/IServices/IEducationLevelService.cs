using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IEducationLevelService
    {
        IEnumerable<EducationLevel> GetAll();
        EducationLevel GetByID(Guid id);
        EducationLevel Create(EducationLevel domain);
        bool Update(EducationLevel domain);
        bool Delete(Guid id);
    }
}

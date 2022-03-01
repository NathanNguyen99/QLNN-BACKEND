using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IAddictRelationsService
    {
        IEnumerable<AddictRelationsDto> GetAll();
        IEnumerable<AddictRelationsDto> GetByAddictID(Guid addictID);
        AddictRelationsDto GetByID(Guid id);
        AddictRelationsDto Create(AddictRelations domain);
        bool Update(AddictRelations domain);
        bool Delete(Guid id);
        public PagedList<AddictRelationsDto> GetAddictRelations(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
        IEnumerable<AddictRelationsDto2> GetAddictRelations2();
    }
}

using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IAddictRelationsRepository
    {
        IEnumerable<AddictRelationsDto> GetAll();
        IEnumerable<AddictRelationsDto> GetByAddictID(Guid addictID);
        AddictRelationsDto GetByID(Guid id);
        AddictRelationsDto SaveCreate(AddictRelations domain);
        bool Update(AddictRelations domain);
        bool Delete(Guid id);
        public PagedList<AddictRelationsDto> GetAddictRelations(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
        IEnumerable<AddictRelationsDto2> GetAddictRelations2(IAddictRepository addictRepository);
    }
}

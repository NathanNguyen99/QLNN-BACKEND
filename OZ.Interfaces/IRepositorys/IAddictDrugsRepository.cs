using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IAddictDrugsRepository
    {
        IEnumerable<AddictDrugDto> GetAll();
        IEnumerable<AddictDrugDto> GetByAddictID(Guid addictID);
        AddictDrugDto GetByID(Guid id);
        AddictDrugDto SaveCreate(AddictDrugs domain);
        bool Update(AddictDrugs domain);
        bool Delete(Guid id);
        public PagedList<AddictDrugDto> GetAddictDrugs(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
    }
}

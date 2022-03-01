using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IAddictClassifyRepository
    {
        IEnumerable<AddictClassifyDto> GetAll();
        IEnumerable<AddictClassifyDto> GetByAddictID(Guid addictID);
        AddictClassifyDto GetByID(Guid id);
        AddictClassifyDto SaveCreate(AddictClassify domain);
        bool Update(AddictClassify domain);
        bool Delete(Guid id);
        public PagedList<AddictClassifyDto> GetAddictClassifys(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
    }
}

using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IAddictVehicleService
    {
        IEnumerable<AddictVehicleDto> GetAll();
        IEnumerable<AddictVehicleDto> GetByAddictID(Guid addictID);
        AddictVehicleDto GetByID(Guid id);
        AddictVehicleDto Create(AddictVehicle domain);
        bool Update(AddictVehicle domain);
        bool Delete(Guid id);
        public PagedList<AddictVehicleDto> GetAddictVehicle(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize);
    }
}

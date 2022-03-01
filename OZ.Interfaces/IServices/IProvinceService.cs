using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IProvinceService
    {
        IEnumerable<Province> GetAll();
        Province GetByID(int id);
        Province Create(Province domain);
        bool Update(Province domain);
        bool Delete(Guid id);
    }
}

using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IRelationsService
    {
        IEnumerable<Relations> GetAll();
        Relations GetByID(int id);
        Relations Create(Relations domain);
        bool Update(Relations domain);
        bool Delete(int id);
    }
}

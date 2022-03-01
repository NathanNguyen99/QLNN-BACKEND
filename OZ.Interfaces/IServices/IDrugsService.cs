using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IDrugsService
    {
        IEnumerable<Drugs> GetAll();
        Drugs GetByID(int id);
        Drugs Create(Drugs domain);
        bool Update(Drugs domain);
        bool Delete(int id);
    }
}

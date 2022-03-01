using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IClassifyService
    {
        IEnumerable<Classify> GetAll();
        Classify GetByID(int id);
        Classify Create(Classify domain);
        bool Update(Classify domain);
        bool Delete(int id);
    }
}

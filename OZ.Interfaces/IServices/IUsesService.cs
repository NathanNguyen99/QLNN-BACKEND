using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IUsesService
    {
        IEnumerable<Uses> GetAll();
        Uses GetByID(int id);
        Uses Create(Uses domain);
        bool Update(Uses domain);
        bool Delete(int id);
        
    }
}

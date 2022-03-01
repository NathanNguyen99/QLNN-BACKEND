using Microsoft.AspNetCore.Http;
using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OZ.Interfaces
{
    public interface IManageCityRepository
    {
        IEnumerable<ManageCity> GetAll();
        
    }
}

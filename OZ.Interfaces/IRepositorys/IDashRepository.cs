using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OZ.Interfaces
{
    public interface IDashRepository
    {
        Task<List<Dash01>> GetDashBoard01();
        Task<List<Dash02>> GetDashBoard02();
        Task<List<Dash03>> GetDashBoard03();
        Task<List<Dash04>> GetDashBoard04();
        Task<List<Dash05>> GetDashBoard05();
        Task<List<DashClassify>> GetDashBoardClassify();
        Task<List<DashAddictType>> GetDashBoardAddictType();
    }
}

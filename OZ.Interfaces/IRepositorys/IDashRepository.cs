using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OZ.Interfaces
{
    public interface IDashRepository
    {
        //Task<List<Dash01>> GetDashBoard01();
        IEnumerable<Dash01> GetDashBoard01(IAddictRepository addictRepository);
        IEnumerable<Dash02> GetDashBoard02(IAddictRepository addictRepository);
        Task<List<Dash03>> GetDashBoard03();
        IEnumerable<Dash04> GetDashBoard04(IAddictRepository addictRepository);
        IEnumerable<Dash05> GetDashBoard05(IAddictRepository addictRepository);
        IEnumerable<DashClassify> GetDashBoardClassify(IAddictClassifyRepository addictClassifyRepository, IAddictRepository addictRepository);
        IEnumerable<DashAddictType> GetDashBoardAddictType();
    }
}

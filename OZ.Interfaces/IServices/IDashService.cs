using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IDashService
    {
        IEnumerable<Dash01> GetDashBoard01();
        IEnumerable<Dash02> GetDashBoard02();
        List<Dash03> GetDashBoard03();
        IEnumerable<Dash04> GetDashBoard04();
        IEnumerable<Dash05> GetDashBoard05();
        IEnumerable<DashClassify> GetDashBoardClassify();
        IEnumerable<DashAddictType> GetDashBoardAddictType();

    }
}

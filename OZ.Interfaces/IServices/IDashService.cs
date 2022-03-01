using OZ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Interfaces
{
    public interface IDashService
    {
        List<Dash01> GetDashBoard01();
        List<Dash02> GetDashBoard02();
        List<Dash03> GetDashBoard03();
        List<Dash04> GetDashBoard04();
        List<Dash05> GetDashBoard05();
        List<DashClassify> GetDashBoardClassify();
        List<DashAddictType> GetDashBoardAddictType();

    }
}

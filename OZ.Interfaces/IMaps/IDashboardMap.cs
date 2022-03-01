using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Interfaces
{
    public interface IDashboardMap
    {
        IEnumerable<DashViewModel01> GetDashBoard01();
        IEnumerable<DashViewModel02> GetDashBoard02();
        IEnumerable<DashViewModel03> GetDashBoard03();
        IEnumerable<DashViewModel04> GetDashBoard04();
        IEnumerable<DashViewModel05> GetDashBoard05();
        IEnumerable<DashViewModelClassify> GetDashBoardClassify();
        IEnumerable<DashViewModelAddictType> GetDashBoardAddictType();

    }
}

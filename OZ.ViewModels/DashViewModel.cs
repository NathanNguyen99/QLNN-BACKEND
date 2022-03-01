using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.ViewModels
{
    public class DashViewModel01 : IBaseViewModel
    {
        public string MonthID { get; set; }
        public int Qty { get; set; }       
    }

    public class DashViewModel02 : IBaseViewModel
    {
        public string Syear { get; set; }
        public int male { get; set; }
        public int female { get; set; }
    }
    public class DashViewModel03 : IBaseViewModel
    {
        public string drugName { get; set; }
        public int Qty { get; set; }
    }
    public class DashViewModel04 : IBaseViewModel
    {
        public string levelName { get; set; }
        public int Qty { get; set; }
    }
    public class DashViewModel05 : IBaseViewModel
    {
        public string AgeRange { get; set; }
        public int curQty { get; set; }
        public int PreQty { get; set; }
    }

    public class DashViewModelClassify : IBaseViewModel
    {
        public string classifyName { get; set; }

        public int Qty { get; set; }
    }

    public class DashViewModelAddictType : IBaseViewModel
    {
        public string PlaceName { get; set; }

        public int Qty { get; set; }
    }
}
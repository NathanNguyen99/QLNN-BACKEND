using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Dash01
    {
        //public string MonthID { get; set; }
        public string MonthID { get; set; }
        public int Qty { get; set; }
    }

    public class Dash02
    {
        public string Syear { get; set; }
        public int male { get; set; }
        public int female { get; set; }
    }
    public class Dash03
    {
        public string drugName { get; set; }
        public int Qty { get; set; }
    }
    public class Dash04
    {
        public string levelName { get; set; }
        public int Qty { get; set; }
    }
    public class Dash05
    {
        public string AgeRange { get; set; }
        public int curQty { get; set; }
        public int PreQty { get; set; }
    }

    public class DashClassify
    {

        public string classifyName { get; set; }

        public int Qty { get; set; }

    }

    public class DashAddictType
    {

        public string PlaceName { get; set; }

        public int Qty { get; set; }

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.ViewModels
{
    public class ManageCityViewModel : IBaseViewModel
    {
        public int OID { get; set; }
        public string CityName { get; set; }
        public int CityType { get; set; }
    }
}

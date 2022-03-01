
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.ViewModels
{
    public class ProvinceViewModel : IBaseViewModel
    {
        public Guid OID { get; set; }
        public int Seq { get; set; }
        public string ProvinceName { get; set; }
    }
}

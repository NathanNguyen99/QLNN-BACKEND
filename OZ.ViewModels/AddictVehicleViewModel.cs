
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.ViewModels
{
    public class AddictVehicleViewModel : IBaseViewModel
    {
        public Guid OID { get; set; }
        public Guid AddictID { get; set; }
        public string nhanHieu { get; set; }
        public string kieuXe { get; set; }
        public string mauXe { get; set; }

        public string bienSo { get; set; }
        public string noiDangKy { get; set; }
        public string giayPhep { get; set; }

        public string Remarks { get; set; }
    }
}

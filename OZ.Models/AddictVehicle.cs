using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.Models
{
    public class AddictVehicle
    {
        [Key]
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

    public class AddictVehicleDto : AddictVehicle
    {
        public string AddictCode { get; set; }
        public string AddictName { get; set; }
        //public string PlaceTypeName { get; set; }
        //public string PlaceName { get; set; }
    }
}

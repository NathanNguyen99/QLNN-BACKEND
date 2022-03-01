using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class ManageCity
    {
        [Key]
        public int OID { get; set; }
        public string CityName { get; set; }
        public int CityType { get; set; }
    }

}

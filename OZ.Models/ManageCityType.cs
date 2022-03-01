using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class ManageCityType
    {
        [Key]
        public int OID { get; set; }        
        public string ManageCityTypeName { get; set; }        
    }
}

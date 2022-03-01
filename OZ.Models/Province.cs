using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Province
    {
        [Key]
        public Guid OID { get; set; }    
        public int Seq { get; set; }
        public string ProvinceName { get; set; }        
    }
}

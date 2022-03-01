using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Ward
    {
        [Key]
        public Guid OID { get; set; }            
        public string WardName { get; set; }       
        public Guid DistrictID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Religion
    {
        [Key]
        public int OID { get; set; }
        public string ReligionName { get; set; }        
    }
}

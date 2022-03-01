using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Drugs
    {
        [Key]
        public int OID { get; set; }
        public string DrugsName { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Marriage
    {
        [Key]
        public int OID { get; set; }
        public string MarriageName { get; set; }        
    }
}

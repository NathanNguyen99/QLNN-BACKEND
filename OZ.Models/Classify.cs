using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Classify
    {
        [Key]
        public int OID { get; set; }
        public string ClassifyName { get; set; }        
    }
}

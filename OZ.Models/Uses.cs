using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Uses
    {
        [Key]
        public int OID { get; set; }            
        public string MethodName { get; set; }        
    }
}

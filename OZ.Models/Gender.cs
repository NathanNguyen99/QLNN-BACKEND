using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Gender
    {
        [Key]
        public int OID { get; set; }
        public string GenderName { get; set; }        
    }
}

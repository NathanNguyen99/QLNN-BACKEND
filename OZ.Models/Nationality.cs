using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Nationality
    {
        [Key]
        public int OID { get; set; }
        public string NationalityName { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class EducationLevel
    {
        [Key]
        public Guid OID { get; set; }
        public int Seq { get; set; }
        public string EducationName { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class Relations
    {
        [Key]
        public int OID { get; set; }
        public string RelationName { get; set; }        
    }
}

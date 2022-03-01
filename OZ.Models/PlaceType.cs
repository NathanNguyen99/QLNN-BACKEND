using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class PlaceType
    {
        [Key]
        public int OID { get; set; }        
        public string PlaceTypeName { get; set; }        
    }
}

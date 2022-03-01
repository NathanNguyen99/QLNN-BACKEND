using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class ManageType
    {
        [Key]
        public int OID { get; set; }        
        public string ManagementType { get; set; }        
    }
}

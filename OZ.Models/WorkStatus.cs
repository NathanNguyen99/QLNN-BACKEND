using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class WorkStatus
    {
        [Key]
        public int OID { get; set; }
        public string WorkStatusName { get; set; }        
    }
}

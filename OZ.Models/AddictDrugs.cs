using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.Models
{
    public class AddictDrugs
    {
        [Key]
        public Guid OID { get; set; }
        public Guid AddictID { get; set; }
        public int DrugsID { get; set; }
        public int UseID { get; set; }
        public bool inUse { get; set; }
        public string Remarks { get; set; }
    }
    public class AddictDrugDto : AddictDrugs
    {
        public string AddictCode { get; set; }
        public string AddictName { get; set; }
        public string DrugsName { get; set; }
        public string UseName { get; set; }
    }
}

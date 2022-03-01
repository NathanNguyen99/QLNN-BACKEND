using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.Models
{
    public class AddictClassify
    {
        [Key]
        public Guid OID { get; set; }
        public Guid AddictID { get; set; }
        public int ClassifyID { get; set; }        
        public string Remarks { get; set; }
    }
    public class AddictClassifyDto : AddictClassify
    {
        public string AddictCode { get; set; }
        public string AddictName { get; set; }
        public string ClassifyName { get; set; }        
    }
}

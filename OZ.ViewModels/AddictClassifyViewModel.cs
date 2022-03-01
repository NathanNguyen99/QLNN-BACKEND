
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.ViewModels
{
    public class AddictClassifyViewModel : IBaseViewModel
    {
        public Guid OID { get; set; }
        public Guid AddictID { get; set; }
        public string AddictCode { get; set; }
        public string AddictName { get; set; }
        public int ClassifyID { get; set; }
        public string ClassifyName { get; set; }        
        public string Remarks { get; set; }
    }
}

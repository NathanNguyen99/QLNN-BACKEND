
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.ViewModels
{
    public class AddictDrugsViewModel : IBaseViewModel
    {
        public Guid OID { get; set; }
        public Guid AddictID { get; set; }
        public string AddictCode { get; set; }
        public string AddictName { get; set; }
        public int DrugsID { get; set; }
        public string DrugsName { get; set; }
        public int UseID { get; set; }
        public string UseName { get; set; }
        public bool inUse { get; set; }
        public string Remarks { get; set; }
    }
}

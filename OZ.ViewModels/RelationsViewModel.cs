
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.ViewModels
{
    public class RelationsViewModel : IBaseViewModel
    {
        public int OID { get; set; }
        public string RelationName { get; set; }
    }
}

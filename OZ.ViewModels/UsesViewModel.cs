
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.ViewModels
{
    public class UsesViewModel : IBaseViewModel
    {
        public int OID { get; set; }
        public string MethodName { get; set; }
    }
}

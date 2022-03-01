using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.ViewModels
{
    public class EducationLevelViewModel: IBaseViewModel
    {
        public Guid OID { get; set; }
        public int Seq { get; set; }
        public string EducationName { get; set; }
    }
}
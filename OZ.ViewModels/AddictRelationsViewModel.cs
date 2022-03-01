
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.ViewModels
{
    public class AddictRelationsViewModel : IBaseViewModel
    {
        public Guid OID { get; set; }
        public Guid AddictID { get; set; }
        public string AddictCode { get; set; }
        public string AddictName { get; set; }

        public Guid RelationWithID { get; set; }
        public string RelationWithName { get; set; }

        public bool BlackList { get; set; }
        public Guid? ManagePlaceID { get; set; }
        public string ManagePlaceName { get; set; }
        public string OtherName { get; set; }
        public string CurrentAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }


        public DateTime? Date { get; set; }

        public int RelationsID { get; set; }
        public string RelationsName { get; set; }

        public string Remarks { get; set; }
    }

    public class AddictRelationsViewModel2 : IBaseViewModel
    {
        public AddictRelationsViewModel2()
        {
            _lstActivities = new List<AddictRelationsViewModel>();
        }
        public Guid AddictID { get; set; }
        public string AddictCode { get; set; }
        public string AddictName { get; set; }
        public DateTime? DOB { get; set; }
        public bool expand { get { return false; } }
        private List<AddictRelationsViewModel> _lstActivities;
        public List<AddictRelationsViewModel> ActivityLog { get { return _lstActivities; } }

    }
}

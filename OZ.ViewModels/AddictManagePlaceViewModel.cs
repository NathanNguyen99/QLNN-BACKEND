
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.ViewModels
{
    public class AddictManagePlaceViewModel : IBaseViewModel
    {
        public Guid OID { get; set; }
        public Guid AddictID { get; set; }
        public string AddictCode { get; set; }
        public string AddictName { get; set; }
        public int PlaceTypeID { get; set; }
        public string PlaceTypeName { get; set; }
        public Guid ManagePlaceID { get; set; }
        public string PlaceName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Remarks { get; set; }
    }

    public class AddictManagePlaceViewModel2 : IBaseViewModel
    {
        public AddictManagePlaceViewModel2()
        {
            _lstActivities = new List<AddictManagePlaceViewModel>();
        }
        public Guid AddictID { get; set; }
        public string AddictCode { get; set; }
        public string AddictName { get; set; }
        public DateTime? DOB { get; set; }
        public bool expand { get { return false; } }
        private List<AddictManagePlaceViewModel> _lstActivities;
        public List<AddictManagePlaceViewModel> ActivityLog { get { return _lstActivities; } }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.ViewModels
{
    public class UserViewModel: IBaseViewModel
    {
        public Guid OID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }     
        public string FullName { get; set; }
        public bool Admin { get; set; }
        public bool Active { get; set; }
        public Guid? PlaceID { get; set; }
        public string PlaceName { get; set; }
        public int ManageCityID { get; set; }
        public int ManageCityTypeID { get; set; }
        public string ManageCityTypeName { get; set; }
        public string ManageCityName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.ViewModels
{
    public class ManagePlaceViewModel : IBaseViewModel
    {
        public Guid OID { get; set; }
        public string PlaceName { get; set; }
        public string? Address { get; set; }
        public int PlaceTypeID { get; set; }
        public string PlaceTypeName { get; set; }
        public int ManageCityID { get; set; }
    }
}

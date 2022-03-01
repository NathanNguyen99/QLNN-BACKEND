using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class ManagePlace
    {
        [Key]
        public Guid OID { get; set; }        
        public string PlaceName { get; set; }   
        public string Address { get; set; }
        public int PlaceTypeID { get; set; }
        public int ManageCityID { get; set; }

        //Extensions
        //public string PlaceTypeName { get; set; }
    }

    public class ManagePlaceDto: ManagePlace
    {        
        //Extensions
        public string PlaceTypeName { get; set; }
    }
}

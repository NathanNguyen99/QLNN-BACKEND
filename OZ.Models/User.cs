using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class User
    {
        [Key]
        public Guid OID { get; set; }    
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; } 
        public bool Admin { get; set; }
        public bool Active { get; set; }
        public Guid? PlaceID { get; set; }
        public int ManageCityID { get; set; }
        public int ManageCityTypeID { get; set; }


    }
    public class UserDto : User
    {
        //Extensions
        public string ManageCityTypeName { get; set; }
        public string ManageCityName { get; set; }

        public string PlaceName { get; set; }
    }
}

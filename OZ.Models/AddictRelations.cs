using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.Models
{
    public class AddictRelations
    {
        [Key]
        public Guid OID { get; set; }
        public Guid AddictID { get; set; }

        public int RelationsID { get; set; }

        public Guid RelationWithID { get; set; }
        public string CurrentAddress { get; set; }
        public string OtherName { get; set; }

        public Guid? ManagePlaceID { get; set; }
        public bool BlackList { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public DateTime? Date { get; set; }

        public string Remarks { get; set; }
    }
    public class AddictRelationsDto : AddictRelations
    {
        public string AddictCode { get; set; }
        public string AddictName { get; set; }

        public string RelationWithName { get; set; }
        public string ManagePlaceName { get; set; }

        public string RelationsName { get; set; }
 
    }

    public class AddictRelationsDto2
    {
        //public AddictManagePlaceDto2()
        //{
        //    _lstActivities = new List<AddictManagePlaceDto>();
        //}
        public Guid AddictID { get; set; }
        public string AddictCode { get; set; }
        public string AddictName { get; set; }
        public DateTime? DOB { get; set; }
        //private List<AddictManagePlaceDto> _lstActivities;
        public List<AddictRelationsDto> ActivityLog { get; set; }
    }
}

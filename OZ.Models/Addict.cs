using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OZ.Models
{
    public class Addict //: IdentityUser
    {
        [Key]
        public Guid OID { get; set; }
        public string AddictCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string OtherName { get; set; }
        public int GenderID { get; set; }
        public Guid? PlaceOfBirthID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? YearOfBirth { get; set; }
        public int? MonthOfBirth { get; set; }
        public int? DayOfBirth { get; set; }
        public string PemanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }
        public string SocialNetworkAccount { get; set; }
        public Guid? EducationLevelID { get; set; }
        public string CitizenID { get; set; }
        public DateTime? IssueDate { get; set; }
        public Guid? IssuePlaceID { get; set; }
        public int? ethnicID { get; set; }
        public int? religionID { get; set; }
        public int? nationalityID { get; set; }
        public int? workStatusID { get; set; }
        public int? ingredientID { get; set; }
        public int? marriageID { get; set; }
        public string CriminalConviction { get; set; }
        public string CriminalRecord { get; set; }
        public bool? Detoxed { get; set; }
        public string FartherName { get; set; }
        public string MotherName { get; set; }
        public string PartnerName { get; set; }
        public string Characteristics { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public int? ManageType { get; set; }
        public bool? Complete { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? CreateUser { get; set; }
        public string ImgLink { get; set; }
        public Guid? ManagePlaceID { get; set; } // de biet thuoc phuong nao quan ly
        public bool? Dead { get; set; }
    }

    public class AddictDto : Addict
    {
        public string GenderName { get; set; }
        public string PlaceOfBirthName { get; set; }
        public string EducationLevelName { get; set; }
        public string IssuePlaceName { get; set; }
        public string EthnicName { get; set; }
        public string ReligionName { get; set; }
        public string NationalityName { get; set; }
        public string WorkStatusName { get; set; }
        public string MarriageName { get; set; }
        public string CreateUserName { get; set; }
        public string ManagePlaceName { get; set; }
    }

    public class AddictBaseDto
    {
        public Guid OID { get; set; }
        public string AddictCode { get; set; }
        public string FullName { get; set; }
    }

    public class Addict2Dto
    {
        public Guid OID { get; set; }
        public string AddictCode { get; set; }
        public string FullName { get; set; }
        //public string LastName { get; set; }
        public int GenderID { get; set; }
        public Guid? PlaceOfBirthID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PemanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }
        public string SocialNetworkAccount { get; set; }
        public Guid? EducationLevelID { get; set; }
        public string CitizenID { get; set; }
        public string CriminalConviction { get; set; }
        public string CriminalRecord { get; set; }
        public string FartherName { get; set; }
        public string MotherName { get; set; }
        public string PartnerName { get; set; }
        public string Characteristics { get; set; }
        public string ImgLink { get; set; }
        public double CorrectRatio { get; set; }
    }
}

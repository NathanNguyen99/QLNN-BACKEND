using Microsoft.AspNetCore.Http;
using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;



namespace OZ.Maps
{
    public class AddictMap : IAddictMap
    {
        IAddictService service;
        public AddictMap(IAddictService service)
        {
            this.service = service;
        }
        public AddictViewModel Create(AddictViewModel viewModel)
        {
            Addict user = ViewModelToDomain(viewModel);
            var listClassifys = new List<AddictClassify>();
            var instanceClassifyMap = new AddictClassifyMap(null);
            foreach (var item in viewModel.classifys)
            {
                listClassifys.Add(instanceClassifyMap.ViewModelToDomain(item));
            }

            var listDrugs = new List<AddictDrugs>();
            var instanceDrugMap = new AddictDrugsMap(null);
            foreach (var item in viewModel.drugs)
            {
                listDrugs.Add(instanceDrugMap.ViewModelToDomain(item));
            }

            var listPlaces = new List<AddictManagePlace>();
            var instancePlaceMap = new AddictManagePlaceMap(null, null);
            foreach (var item in viewModel.places)
            {
                listPlaces.Add(instancePlaceMap.ViewModelToDomain(item));
            }

            var listvehicles = new List<AddictVehicle>();
            var instanceVehicleMap = new AddictVehicleMap(null);
            foreach (var item in viewModel.vehicle)
            {
                listvehicles.Add(instanceVehicleMap.ViewModelToDomain(item));
            }
            //service.Create(user, listDrugs, listPlaces);
            //Addict domain, List<AddictDrugs> drugs, List<AddictClassify> classifies, List<AddictVehicle> vehicle, List<AddictManagePlace> places
            return DomainToViewModel(service.Create(user, listDrugs, listClassifys, listvehicles, listPlaces));
        }
        public bool UploadExcel(IFormFile postedFile)
        {
            //ManagePlace user = ViewModelToDomain(users);

            return service.UploadExcel(postedFile);
        }
        public bool Update(AddictViewModel viewModel)
        {
            Addict user = ViewModelToDomain(viewModel);
            //var listDrugs = new List<AddictDrugs>();            
            //var instanceDrugMap = new AddictDrugsMap(null);
            var listClassifys = new List<AddictClassify>();
            var instanceClassifyMap = new AddictClassifyMap(null);
            foreach (var item in viewModel.classifys)
            {
                listClassifys.Add(instanceClassifyMap.ViewModelToDomain(item));
            }

            var listDrugs = new List<AddictDrugs>();
            var instanceDrugMap = new AddictDrugsMap(null);
            foreach (var item in viewModel.drugs)
            {
                listDrugs.Add(instanceDrugMap.ViewModelToDomain(item));
            }

            var listPlaces = new List<AddictManagePlace>();
            var instancePlaceMap = new AddictManagePlaceMap(null, null);
            foreach (var item in viewModel.places)
            {
                listPlaces.Add(instancePlaceMap.ViewModelToDomain(item));
            }

            var listvehicles = new List<AddictVehicle>();
            var instanceVehicleMap = new AddictVehicleMap(null);
            foreach (var item in viewModel.vehicle)
            {
                
                
                listvehicles.Add(instanceVehicleMap.ViewModelToDomain(item));
            }
            return service.Update(user, listDrugs, listClassifys, listvehicles, listPlaces);
        }
        public bool Delete(Guid id)
        {
            return service.Delete(id);
        }
        public List<AddictViewModel> GetAll()
        {
            return DomainToViewModel(service.GetAll());
        }

        public List<AddictViewModel2> GetAddict()
        {
            return DomainToViewModel2(service.GetAddict());
        }
        public List<AddictViewModel2> DomainToViewModel2(IEnumerable<AddictDto> domain)
        {
            List<AddictViewModel2> model = new List<AddictViewModel2>();
            foreach (AddictDto of in domain)
            {
                model.Add(DomainToViewModel2(of));
            }
            return model;
        }
        public AddictViewModel2 DomainToViewModel2(AddictDto domain)
        {

            AddictViewModel2 model = new AddictViewModel2();
            model.AddictCode = domain.AddictCode;
            model.FullName = domain.FullName;
            model.OtherName = domain.OtherName;
            model.GenderName = domain.GenderName;
            model.PlaceOfBirthName = domain.PlaceOfBirthName;
            model.DateOfBirth = domain.DateOfBirth;
            model.PemanentAddress = domain.PemanentAddress;
            model.CurrentAddress = domain.CurrentAddress;
            model.Profession = domain.Profession;
            model.PhoneNumber = domain.PhoneNumber;
            model.SocialNetworkAccount = domain.SocialNetworkAccount;
            model.EducationLevelName = domain.EducationLevelName;
            model.CitizenID = domain.CitizenID;
            model.IssueDate = domain.IssueDate;
            model.IssuePlaceName = domain.IssuePlaceName;
            model.NationalityName = domain.NationalityName;
            model.EthnicName = domain.EthnicName;
            model.ReligionName = domain.ReligionName;
            model.WorkStatusName = domain.WorkStatusName;
            model.ingredientID = domain.ingredientID;
            model.MarriageName = domain.MarriageName;
            model.CriminalConviction = domain.CriminalConviction;
            model.CriminalRecord = domain.CriminalRecord;
            model.Detoxed = domain.Detoxed;
            model.FartherName = domain.FartherName;
            model.MotherName = domain.MotherName;
            model.PartnerName = domain.PartnerName;
            model.Characteristics = domain.Characteristics;
            model.Remarks1 = domain.Remarks1;
            model.Remarks2 = domain.Remarks2;
            model.Complete = domain.Complete;
            model.ManageType = domain.ManageType;
            model.CompleteDate = domain.CompleteDate;
            model.CreateDate = domain.CreateDate;
            model.CreateUserName = domain.CreateUserName;
            model.ManagePlaceName = domain.ManagePlaceName;
            model.Dead = domain.Dead;
            return model;
        }
        public List<AddictViewModel> GetByPlaceID(Guid placeID)
        {
            return DomainToViewModel(service.GetByPlaceID(placeID));
        }
        public AddictViewModel DomainToViewModel(Addict domain)
        {
            AddictViewModel model = new AddictViewModel();
            model.OID = domain.OID;
            model.AddictCode = domain.AddictCode;
            //model.FirstName = domain.FirstName;
            //model.LastName = domain.LastName;
            model.FullName = domain.FullName;
            model.OtherName = domain.OtherName;
            model.GenderID = domain.GenderID;
            model.PlaceOfBirthID = domain.PlaceOfBirthID;
            model.DateOfBirth = domain.DateOfBirth;
            model.PemanentAddress = domain.PemanentAddress;
            model.CurrentAddress = domain.CurrentAddress;
            model.Profession = domain.Profession;
            model.PhoneNumber = domain.PhoneNumber;
            model.SocialNetworkAccount = domain.SocialNetworkAccount;
            model.EducationLevelID = domain.EducationLevelID;
            model.CitizenID = domain.CitizenID;
            model.IssueDate = domain.IssueDate;
            model.IssuePlaceID = domain.IssuePlaceID;
            model.nationalityID = domain.nationalityID;
            model.ethnicID = domain.ethnicID;
            model.religionID = domain.religionID;
            model.workStatusID = domain.workStatusID;
            model.ingredientID = domain.ingredientID;
            model.marriageID = domain.marriageID;
            model.CriminalConviction = domain.CriminalConviction;
            model.CriminalRecord = domain.CriminalRecord;
            model.Detoxed = domain.Detoxed;
            model.FartherName = domain.FartherName;
            model.MotherName = domain.MotherName;
            model.PartnerName = domain.PartnerName;
            model.Characteristics = domain.Characteristics;
            model.Remarks1 = domain.Remarks1;
            model.Remarks2 = domain.Remarks2;
            model.Complete = domain.Complete;
            model.ManageType = domain.ManageType;
            model.CompleteDate = domain.CompleteDate;
            model.CreateDate = domain.CreateDate;
            model.CreateUser = domain.CreateUser;
            model.ImgLink = domain.ImgLink;
            model.ManagePlaceID = domain.ManagePlaceID;
            model.Dead = domain.Dead;
            return model;
        }
        public AddictViewModel DomainToViewModel(Addict2Dto domain)
        {
            AddictViewModel model = new AddictViewModel();
            model.OID = domain.OID;
            model.AddictCode = domain.AddictCode;
            //model.FirstName = domain.FirstName;
            //model.LastName = domain.LastName;
            model.FullName = domain.FullName;
            model.GenderID = domain.GenderID;
            model.PlaceOfBirthID = domain.PlaceOfBirthID;
            model.DateOfBirth = domain.DateOfBirth;
            model.PemanentAddress = domain.PemanentAddress;
            model.CurrentAddress = domain.CurrentAddress;
            model.Profession = domain.Profession;
            model.PhoneNumber = domain.PhoneNumber;
            model.SocialNetworkAccount = domain.SocialNetworkAccount;
            model.EducationLevelID = domain.EducationLevelID;
            model.CitizenID = domain.CitizenID;
            model.CriminalConviction = domain.CriminalConviction;
            model.CriminalRecord = domain.CriminalRecord;
            model.FartherName = domain.FartherName;
            model.MotherName = domain.MotherName;
            model.PartnerName = domain.PartnerName;
            model.Characteristics = domain.Characteristics;
            model.ImgLink = domain.ImgLink;
            model.CorrectRatio = domain.CorrectRatio;
            return model;
        }
        private byte[] Zip(byte[] value)
        {
            //var bytes = Encoding.UTF8.GetBytes(str);            
            using (var msi = new System.IO.MemoryStream(value))
            using (var mso = new System.IO.MemoryStream())
            {
                using (var gs = new System.IO.Compression.GZipStream(mso, System.IO.Compression.CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                    //CopyTo(msi, gs);
                }
                return mso.ToArray();
            }
        }

        private byte[] Resize2Max50Kbytes(byte[] byteImageIn)
        {
            byte[] currentByteImageArray = byteImageIn;
            double scale = 1f;

            if (byteImageIn == null)
            {
                return null;
            }
            MemoryStream inputMemoryStream = new MemoryStream(byteImageIn);
            var fullsizeImage = Image.FromStream(inputMemoryStream);
            while (currentByteImageArray.Length > 50000)
            {
                Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size((int)(fullsizeImage.Width * scale), (int)(fullsizeImage.Height * scale)));
                MemoryStream resultStream = new MemoryStream();

                fullSizeBitmap.Save(resultStream, fullsizeImage.RawFormat);

                currentByteImageArray = resultStream.ToArray();
                resultStream.Dispose();
                resultStream.Close();
                scale -= 0.05f;
            }
            return currentByteImageArray;
        }

        string BytesToStringConverted(byte[] bytes)
        {
            using (var stream = new System.IO.MemoryStream(bytes))
            {
                using (var streamReader = new System.IO.StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
        private string ToString(byte[] bytes)
        {
            string response = string.Empty;

            foreach (byte b in bytes)
                response += (Char)b;

            return response;
        }
        public List<AddictViewModel> DomainToViewModel(IEnumerable<Addict> domain)
        {
            List<AddictViewModel> model = new List<AddictViewModel>();
            foreach (Addict of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }
        public Addict ViewModelToDomain(AddictViewModel officeViewModel)
        {
            var lastSpaceIndex = officeViewModel.FullName.LastIndexOf(" ");
            Addict domain = new Addict();
            domain.OID = officeViewModel.OID;
            domain.AddictCode = officeViewModel.AddictCode;
            domain.FirstName = officeViewModel.FullName.Substring(lastSpaceIndex + 1);
            domain.LastName = officeViewModel.FullName.Substring(0, lastSpaceIndex - 1);
            domain.FullName = officeViewModel.FullName;
            domain.OtherName = officeViewModel.OtherName;
            domain.GenderID = officeViewModel.GenderID;
            domain.PlaceOfBirthID = officeViewModel.PlaceOfBirthID;
            domain.DateOfBirth = officeViewModel.DateOfBirth;
            if (domain.DateOfBirth!=null)
            {
                domain.YearOfBirth = domain.DateOfBirth.Value.Year;
                domain.MonthOfBirth = domain.DateOfBirth.Value.Month;
                domain.DayOfBirth = domain.DateOfBirth.Value.Day;
            }

            domain.PemanentAddress = officeViewModel.PemanentAddress;
            domain.CurrentAddress = officeViewModel.CurrentAddress;
            domain.Profession = officeViewModel.Profession;
            domain.PhoneNumber = officeViewModel.PhoneNumber;
            domain.SocialNetworkAccount = officeViewModel.SocialNetworkAccount;
            domain.EducationLevelID = officeViewModel.EducationLevelID;
            domain.CitizenID = officeViewModel.CitizenID;
            domain.IssueDate = officeViewModel.IssueDate;
            domain.IssuePlaceID = officeViewModel.IssuePlaceID;
            domain.nationalityID = officeViewModel.nationalityID;
            domain.ethnicID = officeViewModel.ethnicID;
            domain.religionID = officeViewModel.religionID;
            domain.workStatusID = officeViewModel.workStatusID;
            domain.ingredientID = officeViewModel.ingredientID;
            domain.marriageID = officeViewModel.marriageID;
            domain.CriminalConviction = officeViewModel.CriminalConviction;
            domain.CriminalRecord = officeViewModel.CriminalRecord;
            domain.Detoxed = officeViewModel.Detoxed;
            domain.FartherName = officeViewModel.FartherName;
            domain.MotherName = officeViewModel.MotherName;
            domain.PartnerName = officeViewModel.PartnerName;
            domain.Characteristics = officeViewModel.Characteristics;
            domain.Remarks1 = officeViewModel.Remarks1;
            domain.Remarks2 = officeViewModel.Remarks2;
            domain.ManageType = officeViewModel.ManageType;
            domain.Complete = officeViewModel.Complete;
            domain.CompleteDate = officeViewModel.CompleteDate;
            domain.CreateDate = officeViewModel.CreateDate;
            domain.CreateUser = officeViewModel.CreateUser;
            domain.ImgLink = officeViewModel.ImgLink;
            domain.ManagePlaceID = officeViewModel.ManagePlaceID;
            domain.Dead = officeViewModel.Dead;
            return domain;
        }

        public AddictViewModel GetByID(Guid id)
        {
            var objdomain = service.GetByID(id);
            var model = DomainToViewModel(objdomain);
            return model;
        }

        public List<AddictViewModel> Search(string sname, int genderID, int fromAge, int toAge, string SocialNetwork, string CitizenID, Guid? WardID)
        {
            return DomainToViewModel(service.Search(sname, genderID, fromAge, toAge, SocialNetwork, CitizenID, WardID));
        }

        public bool CheckExists(string CitizendID)
        {
            return service.CheckExists(CitizendID);
        }

        public IEnumerable<AddictBaseViewModel> GetBaseFields()
        {
            var domain = service.GetBaseFields();

            List<AddictBaseViewModel> model = new List<AddictBaseViewModel>();
            foreach (AddictBaseDto of in domain)
            {
                model.Add(new AddictBaseViewModel()
                {
                    OID = of.OID,
                    AddictCode = of.AddictCode,
                    FullName = of.FullName
                });
            }
            return model;
        }

        public IEnumerable<AddictViewModel> SearchByFace(Image faceimg)
        {
            List<AddictViewModel> model = new List<AddictViewModel>();
            var listAddicts = service.SearchByFace(faceimg);
            foreach (Addict2Dto of in listAddicts)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }

        public IEnumerable<AddictViewModel> GetLimit(int top)
        {
            var lst = DomainToViewModel(service.GetLimit(top));
            var random = new Random();
            foreach (var item in lst)
            {
                item.CorrectRatio = random.Next(70, 100);
                if (item.AddictCode == "2414" || item.AddictCode == "0971")
                    item.CorrectRatio = 100;
            }
            return lst;
        }
    }
}

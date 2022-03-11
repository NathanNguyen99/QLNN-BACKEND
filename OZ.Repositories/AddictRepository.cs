using LinqToExcel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using AppContext = OZ.Models.Context.Helpers.AppContext;
namespace OZ.Repositories
{
    public class AddictRepository : RepositoryBase<Addict>, IAddictRepository
    {
        
        public AddictRepository(ApplicationContext context, IConfiguration configuration) : base(context)
        {
            Configuration = configuration;
            
        }
        public IConfiguration Configuration { get; }


        public Addict Save(Addict domain)
        {
            try
            {   
                var us = Create(domain);
                return us;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public new bool Update(Addict domain)
        {
            try
            {
                //domain.Updated = DateTime.Now;
                base.Update(domain);
                return true;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public bool Delete(Guid id)
        {
            try
            {
                Addict user = RepositoryContext.Addicts.Where(x => x.OID.Equals(id)).FirstOrDefault();
                if (user != null)
                {
                    Delete(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public bool UploadExcel(IFormFile postedFile)
        {
            //Create a Folder.
            string path1 = @"C:\Users\Oryza\Desktop\QLNN\Excel Files";
            string path = Path.Combine(path1, "Hồ sơ đối tượng");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Save the uploaded Excel file.
            string fileName = Path.GetFileName(postedFile.FileName);
            string filePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }

            var connectionString = "";

            if (fileName.EndsWith(".xls"))
            {
                connectionString = string.Format(Configuration.GetValue<string>("ExcelFormat:xls"), filePath);
            }
            else if (fileName.EndsWith(".xlsx"))
            {
                connectionString = string.Format(Configuration.GetValue<string>("ExcelFormat:xlsx"), filePath);
            }
            var adapter = new OleDbDataAdapter("SELECT * FROM [Hồ sơ người nghiện$] ", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "ExcelTable");
            DataTable dtable = ds.Tables["ExcelTable"];

            //Set the Sheet name over here
            string sheetName = "Hồ sơ người nghiện";

            var excelFile = new ExcelQueryFactory(filePath);
            excelFile.AddMapping<Addict>(x => x.AddictCode, "Mã số (mã nhận dạng)");
            excelFile.AddMapping<Addict>(x => x.LastName, "Tên");
            excelFile.AddMapping<Addict>(x => x.FirstName, "Họ và tên đệm");
            excelFile.AddMapping<Addict>(x => x.OtherName, "Tên khác");
            //excelFile.AddMapping<Addict>(x => x.Gen, "Giới tính");
            //excelFile.AddMapping<Addict>(x => x.AddictCode, "Nơi sinh");
            excelFile.AddMapping<Addict>(x => x.DateOfBirth, "Ngày sinh");
            excelFile.AddMapping<Addict>(x => x.PemanentAddress, "Đ/C thường trú");
            excelFile.AddMapping<Addict>(x => x.CurrentAddress, "Đ/C hiện tại");
            excelFile.AddMapping<Addict>(x => x.Profession, "Nghề nghiệp");
            excelFile.AddMapping<Addict>(x => x.PhoneNumber, "SDT");
            excelFile.AddMapping<Addict>(x => x.SocialNetworkAccount, "TK mạng XH");
            //excelFile.AddMapping<Addict>(x => x.AddictCode, "Trình độ học vấn");
            excelFile.AddMapping<Addict>(x => x.CitizenID, "CMND");
            excelFile.AddMapping<Addict>(x => x.IssueDate, "Ngày cấp");
            //excelFile.AddMapping<Addict>(x => x.AddictCode, "Nơi cấp");
        

            var artistAlbums = from a in excelFile.Worksheet<Addict>(sheetName) select a;

            foreach (var a in artistAlbums)
            {
                try
                {
                    Addict TU = new Addict() { 
                        AddictCode = a.AddictCode, 
                        LastName = a.LastName,
                        FirstName = a.FirstName,
                        OtherName = a.OtherName,
                        DateOfBirth = a.DateOfBirth,
                        PemanentAddress = a.PemanentAddress,
                        CurrentAddress = a.CurrentAddress,
                        Profession = a.Profession,
                        PhoneNumber = a.PhoneNumber,
                        SocialNetworkAccount = a.SocialNetworkAccount,
                        CitizenID = a.CitizenID,
                        IssueDate = a.IssueDate,

                    };

                    Create(TU);
                    return true;
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Commons.NLogAction.instance.logger.Error("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
            }
            return false;

        }
        public IEnumerable<AddictDto> GetAddict()
        {
            try
            {
                
                var lstResult = from a in GetAll()
                                join b in RepositoryContext.Genders on a.GenderID equals b.OID into BS
                                from B1 in BS.DefaultIfEmpty()
                                join c in RepositoryContext.Provinces on a.PlaceOfBirthID equals c.OID into pro
                                from c in pro.DefaultIfEmpty()
                                join d in RepositoryContext.EducationLevels on a.EducationLevelID equals d.OID into edu
                                from d in edu.DefaultIfEmpty()
                                join e in RepositoryContext.Ethic on a.ethnicID equals e.OID into eth
                                from E1 in eth.DefaultIfEmpty()
                                join b2 in RepositoryContext.Religion on a.religionID equals b2.OID into rel
                                from B2 in rel.DefaultIfEmpty()
                                join c2 in RepositoryContext.Nationality on a.nationalityID equals c2.OID into nat
                                from C2 in nat.DefaultIfEmpty()
                                join d2 in RepositoryContext.WorkStatus on a.workStatusID equals d2.OID into work
                                from D2 in work.DefaultIfEmpty()
                                join e2 in RepositoryContext.Marriage on a.marriageID equals e2.OID into mar
                                from E2 in mar.DefaultIfEmpty()
                                join a3 in RepositoryContext.AppUsers on a.CreateUser equals a3.OID into user
                                from A3 in user.DefaultIfEmpty()
                                join b3 in RepositoryContext.ManagePlaces on a.ManagePlaceID equals b3.OID into mana
                                from B3 in mana.DefaultIfEmpty()
                                join c3 in RepositoryContext.Provinces on a.IssuePlaceID equals c3.OID into prov
                                from C3 in prov.DefaultIfEmpty()
                                select new AddictDto()
                                {
                                    AddictCode = a.AddictCode,
                                    FullName = a.FullName,
                                    OtherName = a?.OtherName ?? "",
                                    GenderName = B1?.GenderName ?? "",
                                    PlaceOfBirthName = c?.ProvinceName ?? "",
                                    DateOfBirth = a?.DateOfBirth ?? null,
                                    PemanentAddress = a?.PemanentAddress ?? "",
                                    CurrentAddress = a?.CurrentAddress ?? "",
                                    Profession = a?.Profession ?? "",
                                    PhoneNumber = a?.PhoneNumber ?? "",
                                    SocialNetworkAccount = a?.SocialNetworkAccount ?? "",
                                    EducationLevelName = d?.EducationName ?? "",
                                    CitizenID = a?.CitizenID ?? "", 
                                    IssueDate = a?.IssueDate ?? null,
                                    IssuePlaceName = C3?.ProvinceName ?? "",
                                    EthnicName = E1?.EthicName ?? "",
                                    ReligionName = B2?.ReligionName ?? "",
                                    NationalityName = C2?.NationalityName ?? "",
                                    WorkStatusName = D2?.WorkStatusName ?? "",
                                    MarriageName = E2?.MarriageName ?? "",
                                    CriminalConviction = a?.CriminalConviction ?? "",
                                    CriminalRecord = a?.CriminalRecord ?? "",
                                    Detoxed = a?.Detoxed ?? null,
                                    FartherName = a?.FartherName ?? "",
                                    MotherName = a?.MotherName ?? "",  
                                    PartnerName = a?.PartnerName ?? "",
                                    Characteristics = a?.Characteristics ?? "",
                                    Remarks1 = a?.Remarks1 ?? "",
                                    Complete = a?.Complete ?? null,
                                    CreateUserName = A3?.FullName ?? "",
                                    ManagePlaceName = B3?.PlaceName ?? "",
                                    Dead = a?.Dead ?? null
                                };

                return lstResult;

                //var lstResult = from c in FindAll() select c;
                //return lstResult;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }
        public IEnumerable<Addict> GetAll()
        {
            try
            {
                // Select all ManagePlaces equals to MangeCityID
                var _manageCityID = Int32.Parse(AppContext.Current.User.FindFirst("ManageCityID").Value);
               
                var _placeID = new Guid(AppContext.Current.User.FindFirst("PlaceID").Value);
                var test = from c in RepositoryContext.ManagePlaces
                           where c.ManageCityID == _manageCityID
                           select c;

                var getPlaceName = (from c in RepositoryContext.AppUsers
                                    join b in RepositoryContext.ManagePlaces on c.PlaceID equals b.OID
                                    where c.PlaceID == _placeID
                                    select b.PlaceName).FirstOrDefault();
                if (getPlaceName == "Admin")
                {
                    // Tinh?
                    if (_manageCityID == 10)
                    {
                        var lstResult3 = from c in FindAll()
                                         select c;
                        return lstResult3;
                    }

                    // Huyen, Thanh Pho
                    var lstResult2 = from c in FindAll()
                                     join b in test on c.ManagePlaceID equals b.OID
                     
                                     select c;
                    return lstResult2;
                }
               
                var lstResult = from c in FindAll()
           
                                where c.ManagePlaceID == _placeID
                                select c;
                return lstResult;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }
        
        public IEnumerable<Addict> GetLimit(int top)
        {
            try
            {
                if (top == 0)
                {
                    string[] lstCodeMale = { "2410","2411","2412", "2413", "2414" };
                    var lst1 = (from a in FindAll() where a.GenderID == 0 && lstCodeMale.Contains(a.AddictCode) select a);
                    return lst1;
                }                        
                else
                {
                    string[] lstCodeFeMale = { "0971", "0972", "0975", "0977", "0979" };
                    var lst = (from a in FindAll() where a.GenderID == 1 && lstCodeFeMale.Contains(a.AddictCode) select a);
                    return lst;
                }    
                   
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<AddictBaseDto> GetBaseFields()
        {
            try
            {
                var result = (from a in RepositoryContext.Addicts
                              where a.Complete == false || a.Complete == null
                              select new AddictBaseDto
                              {
                                  OID = a.OID,
                                  AddictCode = a.AddictCode,
                                  FullName = a.LastName + " " + a.FirstName
                              });

                return result;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<Addict2Dto> SearchByFace(Image faceimg)
        {
            try
            {
                var lstAddict = new List<Addict2Dto>();
                //var fr = new Commons.TFaceRecord();                
                //fr.FacePosition = new Luxand.FSDK.TFacePosition();
                //fr.FacialFeatures = new Luxand.FSDK.TPoint[Luxand.FSDK.FSDK_FACIAL_FEATURE_COUNT];
                //fr.Template = new byte[Luxand.FSDK.TemplateSize];

                //fr.image = new Luxand.FSDK.CImage(faceimg);

                //fr.FacePosition = fr.image.DetectFace();
                //if (0 == fr.FacePosition.w)
                //{
                //    //no face found
                //    return lstAddict;
                //}
                //else
                //{
                //    fr.faceImage = fr.image.CopyRect((int)(fr.FacePosition.xc - Math.Round(fr.FacePosition.w * 0.5)), (int)(fr.FacePosition.yc - Math.Round(fr.FacePosition.w * 0.5)), (int)(fr.FacePosition.xc + Math.Round(fr.FacePosition.w * 0.5)), (int)(fr.FacePosition.yc + Math.Round(fr.FacePosition.w * 0.5)));
                //    fr.FacialFeatures = fr.image.DetectEyesInRegion(ref fr.FacePosition);
                //    fr.Template = fr.image.GetFaceTemplateInRegion(ref fr.FacePosition);

                //    // so sanh voi source
                //    foreach (var item in RepositoryContext.FaceLists)
                //    {
                //        var faceImgSource = CreateFaceImg(item);
                //        var ratio = Commons.FaceClass.Compare(fr, faceImgSource);
                //        if (ratio > 80)
                //        {
                //            var objAddict = (from a in RepositoryContext.Addicts
                //                             where a.OID == item.AddictID
                //                             select new Addict2Dto
                //                             {
                //                                 OID = a.OID,
                //                                 AddictCode = a.AddictCode,
                //                                 FirstName = a.FirstName,
                //                                 LastName = a.LastName,
                //                                 GenderID = a.GenderID,
                //                                 PlaceOfBirthID = a.PlaceOfBirthID,
                //                                 DateOfBirth = a.DateOfBirth,
                //                                 PemanentAddress = a.PemanentAddress,
                //                                 CurrentAddress = a.CurrentAddress,
                //                                 Profession = a.Profession,
                //                                 PhoneNumber = a.PhoneNumber,
                //                                 SocialNetworkAccount = a.SocialNetworkAccount,
                //                                 EducationLevelID = a.EducationLevelID,
                //                                 CitizenID = a.CitizenID,
                //                                 CriminalConviction = a.CriminalConviction,
                //                                 CriminalRecord = a.CriminalRecord,
                //                                 FartherName = a.FartherName,
                //                                 MotherName = a.MotherName,
                //                                 PartnerName = a.PartnerName,
                //                                 Characteristics = a.Characteristics,
                //                                 ImgLink = a.ImgLink,
                //                                 CorrectRatio = ratio
                //                             }).FirstOrDefault();
                //            lstAddict.Add(objAddict);
                //        }                        
                //    }
                //    return lstAddict;
                //}
                return lstAddict;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        private Commons.TFaceRecord CreateFaceImg(FaceList obj)
        {
            var fr = new Commons.TFaceRecord();

            //fr.FacePosition = new Luxand.FSDK.TFacePosition();
            //fr.FacePosition.xc = obj.FacePositionXc;
            //fr.FacePosition.yc = obj.FacePositionYc;
            //fr.FacePosition.w = obj.FacePositionW;
            //fr.FacePosition.angle = obj.FacePositionAngle;

            //fr.FacialFeatures = new Luxand.FSDK.TPoint[2];
            //fr.FacialFeatures[0] = new Luxand.FSDK.TPoint();
            //fr.FacialFeatures[0].x = obj.Eye1X;
            //fr.FacialFeatures[0].y = obj.Eye1Y;
            //fr.FacialFeatures[1] = new Luxand.FSDK.TPoint();
            //fr.FacialFeatures[1].x = obj.Eye2X;
            //fr.FacialFeatures[1].y = obj.Eye2Y;

            //fr.Template = obj.Template;

            //Image img = Image.FromStream(new System.IO.MemoryStream(obj.Image));
            //Image img_face = Image.FromStream(new System.IO.MemoryStream(obj.FaceImage));
            //fr.image = new Luxand.FSDK.CImage(img);
            //fr.faceImage = new Luxand.FSDK.CImage(img_face);

            return fr;
        }
        public Addict GetByID(Guid id)
        {
            Addict user = RepositoryContext.Addicts.Where(x => x.OID.Equals(id)).FirstOrDefault();
            if (user != null)
            {                
                return user;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Addict> Search(string sname, int genderID, int fromAge, int toAge, string SocialNetwork, string CitizenID, Guid? ManagePlaceID)
        {
            int fromyear = 0, toyear = 0;
            IEnumerable<Addict> result;
            if (toAge > 0)
            {
                fromyear = DateTime.Now.Year - fromAge;
                toyear = DateTime.Now.Year - toyear;

                result = (from a in RepositoryContext.Addicts
                          where (a.FirstName.Contains(sname) || a.LastName.Contains(sname) || a.OtherName.Contains(sname))
                          && (a.GenderID == genderID || genderID == -1)
                          && a.SocialNetworkAccount.Contains(SocialNetwork)
                          && a.CitizenID.Contains(CitizenID)
                          && (a.ManagePlaceID == ManagePlaceID || ManagePlaceID == null)
                          && (a.YearOfBirth > fromyear - 1 && a.YearOfBirth < toyear + 1)
                          select a);
            }
            else
            {
                result = (from a in RepositoryContext.Addicts
                              where (a.FirstName.Contains(sname) || a.LastName.Contains(sname) || a.OtherName.Contains(sname))
                              && (a.GenderID == genderID || genderID == -1)
                              && a.SocialNetworkAccount.Contains(SocialNetwork)
                              && a.CitizenID.Contains(CitizenID)
                              && (a.ManagePlaceID == ManagePlaceID || ManagePlaceID == null)
                              select a);
            }
            return result;
        }

        public bool CheckExists(string CitizendID)
        {
            bool user = RepositoryContext.Addicts.Any(x => x.CitizenID.Equals(CitizendID));
            return user;
        }

        public IEnumerable<Addict> GetByPlaceID(Guid placeID)
        {
            try
            {
                return RepositoryContext.Addicts.Where(c => c.ManagePlaceID == placeID);//.Take(100);//.OrderBy(x => x.TenGoi);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public Addict Create(Addict domain, List<AddictDrugs> drugs, List<AddictManagePlace> places)
        {
            RepositoryContext.BeginTransaction();
            RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            foreach (var item in drugs)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State= Microsoft.EntityFrameworkCore.EntityState.Added;
            }

            foreach (var item in places)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            RepositoryContext.SaveChanges();
            RepositoryContext.CommitTransaction();
            return domain;
        }

        public Addict Create(Addict domain, List<AddictClassify> drugs, List<AddictManagePlace> places)
        {
            RepositoryContext.BeginTransaction();
            RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            foreach (var item in drugs)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }

            foreach (var item in places)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            RepositoryContext.SaveChanges();
            RepositoryContext.CommitTransaction();
            return domain;
        }

        public Addict Create(Addict domain, List<AddictVehicle> vehicle, List<AddictManagePlace> places)
        {
            RepositoryContext.BeginTransaction();
            RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            foreach (var item in vehicle)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }

            foreach (var item in places)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            RepositoryContext.SaveChanges();
            RepositoryContext.CommitTransaction();
            return domain;
        }

        public Addict Create(Addict domain, List<AddictDrugs> drugs, List<AddictClassify> classifies, List<AddictVehicle> vehicle, List<AddictManagePlace> places)
        {
            RepositoryContext.BeginTransaction();
            RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            foreach (var item in vehicle)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }

            foreach (var item in drugs)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }

            foreach (var item in classifies)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }


            foreach (var item in places)
            {
                //item.AddictID = domain.OID;
                RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            RepositoryContext.SaveChanges();
            RepositoryContext.CommitTransaction();
            return domain;
        }

        public bool Update(Addict domain, List<AddictDrugs> drugs, List<AddictManagePlace> places)
        {
            try
            {
                RepositoryContext.BeginTransaction();
                RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                foreach (var item in drugs)
                {
                    //item.AddictID = domain.OID;
                    if (RepositoryContext.AddictDrugss.Any(r => r.OID == item.OID))
                        RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    else
                        RepositoryContext.AddictDrugss.Add(item);
                }

                foreach (var item in places)
                {
                    if (RepositoryContext.AddictManagePlaces.Any(r => r.OID == item.OID))
                        RepositoryContext.Set<AddictManagePlace>().Update(item);
                    else
                        RepositoryContext.Set<AddictManagePlace>().Add(item);
                }
                RepositoryContext.SaveChanges();
                RepositoryContext.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                RepositoryContext.RollbackTransaction();
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }            
        }

        public bool Update(Addict domain, List<AddictClassify> drugs, List<AddictManagePlace> places)
        {
            try
            {
                RepositoryContext.BeginTransaction();
                RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                foreach (var item in drugs)
                {
                    //item.AddictID = domain.OID;
                    if (RepositoryContext.AddictClassifys.Any(r => r.OID == item.OID))
                        RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    else
                        RepositoryContext.AddictClassifys.Add(item);
                }

                foreach (var item in places)
                {
                    if (RepositoryContext.AddictManagePlaces.Any(r => r.OID == item.OID))
                        RepositoryContext.Set<AddictManagePlace>().Update(item);
                    else
                        RepositoryContext.Set<AddictManagePlace>().Add(item);
                }
                RepositoryContext.SaveChanges();
                RepositoryContext.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                RepositoryContext.RollbackTransaction();
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }

        public bool Update(Addict domain, List<AddictVehicle> vehicle, List<AddictManagePlace> places)
        {
            try
            {
                RepositoryContext.BeginTransaction();
                RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                foreach (var item in vehicle)
                {
                    //item.AddictID = domain.OID;
                    if (RepositoryContext.AddictClassifys.Any(r => r.OID == item.OID))
                        RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    else
                        RepositoryContext.AddictVehicle.Add(item);
                }

                foreach (var item in places)
                {
                    if (RepositoryContext.AddictManagePlaces.Any(r => r.OID == item.OID))
                        RepositoryContext.Set<AddictManagePlace>().Update(item);
                    else
                        RepositoryContext.Set<AddictManagePlace>().Add(item);
                }
                RepositoryContext.SaveChanges();
                RepositoryContext.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                RepositoryContext.RollbackTransaction();
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }

        public bool Update(Addict domain, List<AddictDrugs> drugs, List<AddictClassify> classifies, List<AddictVehicle> vehicle, List<AddictManagePlace> places)
        {
            try
            {
                RepositoryContext.BeginTransaction();
                RepositoryContext.Entry(domain).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //var childs = _context.Children.Where(c => c.ParentID == parent.Id);
                //foreach (var item in childs)
                //{
                //    if (!parent.children.contains(item))
                //        _context.Children.remove(item);
                //}
                foreach (var item in vehicle)
                {
                    //item.AddictID = domain.OID;
                    if (RepositoryContext.AddictVehicle.Any(r => r.OID == item.OID))
                        RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    else
                    {
                        RepositoryContext.AddictVehicle.Add(item);
                    }
                        
                }

                foreach (var item in drugs)
                {
                    if (RepositoryContext.AddictDrugss.Any(r => r.OID == item.OID))
                        RepositoryContext.Set<AddictDrugs>().Update(item);
                    else
                        RepositoryContext.Set<AddictDrugs>().Add(item);
                }

                foreach (var item in classifies)
                {
                    if (RepositoryContext.AddictClassifys.Any(r => r.OID == item.OID))
                        RepositoryContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    else
                        RepositoryContext.AddictClassifys.Add(item);
                }

                foreach (var item in places)
                {
                    if (RepositoryContext.AddictManagePlaces.Any(r => r.OID == item.OID))
                        RepositoryContext.Set<AddictManagePlace>().Update(item);
                    else
                    {
                        RepositoryContext.Set<AddictManagePlace>().Add(item);
                    }
                        
                }

                //foreach (var course in _context.Courses)
                //if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                //{
                //    if (!instructorCourses.Contains(course.CourseID))
                //    {
                //        instructorToUpdate.CourseAssignments.Add(new CourseAssignment { InstructorID = instructorToUpdate.ID, CourseID = course.CourseID });
                //    }
                //}
                //else
                //{

                //    if (instructorCourses.Contains(course.CourseID))
                //    {
                //        CourseAssignment courseToRemove = instructorToUpdate.CourseAssignments.FirstOrDefault(i => i.CourseID == course.CourseID);
                //        _context.Remove(courseToRemove);
                //    }
                //}

                //foreach (var item in places)

                //{
                //    if (!RepositoryContext.AddictManagePlaces.Any(c => c.OID == item.OID))
                //        RepositoryContext.AddictManagePlaces.Remove(item);
                //}

                RepositoryContext.SaveChanges();
                RepositoryContext.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                RepositoryContext.RollbackTransaction();
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }


    }
}

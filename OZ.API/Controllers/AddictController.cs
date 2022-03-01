using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OZ.Interfaces;
using OZ.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using System.Data;
using ClosedXML.Excel;


namespace OZ.Api.Controllers
{
    [Route("api/[controller]")]
   
    [Authorize]
    public class AddictController : Controller
    {

        public IConfiguration configuration;

        IAddictMap userMap;
        public AddictController(IAddictMap map, IConfiguration iConfig)
        {
            userMap = map;
            configuration = iConfig;
        }
        // GET api/Addict
        [HttpGet]
        public IEnumerable<AddictViewModel> Get()
        {      
            return userMap.GetAll(); 
        }
        [HttpGet("GetAddict")]
        public IEnumerable<AddictViewModel2> GetAddict()
        {
            return userMap.GetAddict(); 
        }

        [HttpGet("GetByPlaceID")]
        public IEnumerable<AddictViewModel> GetByPlaceID(Guid placeID)
        {

            return userMap.GetByPlaceID(placeID); 
        }

        [HttpGet("SearchAddict")]
        //..api/SearchAddict?same=2&&genderID=-1&&fromAge=0&&toAge=3&&SocialNetwork=""&&CitizenID=""&&WarID=null
        //[HttpGet("{sname}/{genderID}/{fromAge}/{toAge}/{SocialNetwork}/{CitizenID}/{WardID}")]
        public IEnumerable<AddictViewModel> Get(string sname, int genderID, int fromAge, int toAge, string SocialNetwork, string CitizenID, Guid? WardID)
        {
            return userMap.Search(sname, genderID, fromAge, toAge, SocialNetwork, CitizenID, WardID); ;
        }
        // GET api/Addict/
        [HttpGet("{id}")]
        public AddictViewModel Get(Guid id)
        {
            return userMap.GetByID(id);
        }
        [HttpGet("GetBaseFields")]
        public IEnumerable<AddictBaseViewModel> GetBaseFields()
        {
            return userMap.GetBaseFields();
        }
        [HttpGet("CheckExists")]
        public ActionResult<bool> CheckExists(string CitizendID)
        {
            return userMap.CheckExists(CitizendID);// true is exists
        }
        // POST api/Addict
        [HttpPost]
        public AddictViewModel Post([FromBody] AddictViewModel user)
        {
            return userMap.Create(user);
        }
        // PUT api/Addict/5
        [HttpPut]
        public bool Put([FromBody] AddictViewModel user)
        {
            return userMap.Update(user);
            //return false;
        }
        [HttpPost("UploadExcel")]
        [Consumes("multipart/form-data")]
        public IActionResult UploadExcel([FromForm] IFormFile FileUpload)
        {
            userMap.UploadExcel(FileUpload);
            return Ok();
        }
        [HttpGet("ExportExcel")]
        public IActionResult Export()
        {
            DataTable dt = new DataTable("Hồ sơ người nghiện");
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("Mã số"),
                                        new DataColumn("Họ và tên"),
                                        new DataColumn("Tên khác"), 
                                        new DataColumn("Giới tính"),
                                        new DataColumn("Nơi sinh"),
                                        new DataColumn("Ngày sinh"),
                                        new DataColumn("Đ/C thường trú"),
                                        new DataColumn("Đ/C hiện tại"),
                                        new DataColumn("Nghề nghiệp"),
                                        new DataColumn("SDT"),
                                        new DataColumn("TK mạng XH"),
                                        new DataColumn("Trình độ học vấn"),
                                        new DataColumn("CMND"),
                                        new DataColumn("Ngày cấp"),
                                        new DataColumn("Nơi cấp"),
                                        new DataColumn("Dân tộc"),
                                        new DataColumn("Tôn giáo"),
                                        new DataColumn("Quốc tịch"),
                                        new DataColumn("Tình trạng công việc"),
                                        new DataColumn("Hôn nhân"),
                                        new DataColumn("Tiền sự"),
                                        new DataColumn("Tiền án"),
                                        new DataColumn("Từng cai nghiện"),
                                        new DataColumn("Họ và tên cha"),
                                        new DataColumn("Họ và tên mẹ"),
                                        new DataColumn("Nhân thân"),
                                        new DataColumn("Đặc điểm nhận dạng"),
                                        new DataColumn("Ghi chú"),
                                        new DataColumn("Hoàn thành"),
                                        new DataColumn("Ngày hoàn thành"),
                                        new DataColumn("Người tạo"),
                                        new DataColumn("Nơi quản lý"),
                                        new DataColumn("Đã chết"),
            });

            //.Take(10)
            //var ManagePlaces = from customer in RepositoryContext.ManagePlaces
            //                   select customer;
            var Addicts = GetAddict();
            foreach (var Addict in Addicts)
            {
                dt.Rows.Add(
                    Addict.AddictCode, 
                    Addict.FullName,
                    Addict.OtherName,
                    Addict.GenderName,
                    Addict.PlaceOfBirthName,
                    Addict.DateOfBirth,
                    Addict.PemanentAddress,
                    Addict.CurrentAddress,
                    Addict.Profession,
                    Addict.PhoneNumber,
                    Addict.SocialNetworkAccount,
                    Addict.EducationLevelName,
                    Addict.CitizenID,
                    Addict.IssueDate,
                    Addict.IssuePlaceName,
                    Addict.EthnicName,
                    Addict.ReligionName,
                    Addict.NationalityName,
                    Addict.WorkStatusName, 
                    Addict.MarriageName,
                    Addict.CriminalConviction,
                    Addict.CriminalRecord,
                    Addict.Detoxed,
                    Addict.FartherName,
                    Addict.MotherName,
                    Addict.PartnerName,
                    Addict.Characteristics,
                    Addict.Remarks1,
                    Addict.Complete,
                    Addict.CompleteDate,
                    Addict.CreateUserName,
                    Addict.ManagePlaceName,
                    Addict.Dead
                    );
            }
            
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }


        }
        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            userMap.Delete(id);
        }
        [HttpPost("CheckFace")]
        public async Task<IEnumerable<AddictViewModel>> CheckFace()
        {
            IFormFileCollection files = Request.Form.Files;

            IEnumerable<AddictViewModel> result = null; ;
            if (files.Count > 0)
            {
                var file1 = files[0];
                //var FaceImage = Image.FromStream(file1.OpenReadStream());
                MemoryStream ms = new MemoryStream();
                file1.CopyTo(ms);

                string resultString = await UploadImage(ms.ToArray(), file1.FileName);
                
                result = JsonConvert.DeserializeObject<IEnumerable<AddictViewModel>>(resultString);
            }

            return result;
            //return userMap.GetLimit(gender);
        }

        public async Task<string> UploadImage(byte[] fileValue, string filename)
        {
            try
            {
                string resultString = "";
                HttpClient client = new HttpClient();

                //Client config
                client.Timeout = TimeSpan.FromMinutes(10);
                string testApi = configuration.GetValue<string>("test_image_api:link");
                string configApi = configuration.GetValue<string>("config_image_api:link");

                //client.BaseAddress = new Uri("http://118.69.60.194:54400/");
                //client.BaseAddress = new Uri("https://localhost:44326/");

                //client.BaseAddress = new Uri(testApi);
                client.BaseAddress = new Uri(configApi);

                var multiForm = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(fileValue);


                fileContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("multipart/form-data");
                multiForm.Add(fileContent, "files", filename);

                var requestUri = new Uri($"api/Addict/CheckFace", UriKind.Relative);
                //var requestUri = new Uri("api/Addict/CheckFace");
                JsonConvert.SerializeObject(multiForm);

                using (var response = await client.PostAsync(requestUri, multiForm))
                {
                    resultString = response.Content.ReadAsStringAsync().Result;
                    //return "";
                    //response.Content;
                }

                return resultString;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return "";
                // throw;
            }

        }
    }
}

using Microsoft.AspNetCore.Http;
using OZ.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OZ.Interfaces
{
    public interface IAddictService
    {
        IEnumerable<Addict> GetAll();
        IEnumerable<AddictDto> GetAddict();

        IEnumerable<Addict> GetByPlaceID(Guid placeID);
        IEnumerable<AddictBaseDto> GetBaseFields();
        IEnumerable<Addict> Search(string sname, int genderID, int fromAge, int toAge, string SocialNetwork, string CitizenID, Guid? WardID);
        Addict GetByID(Guid id);
        bool CheckExists(string CitizendID);
        Addict Create(Addict domain);
        Addict Create(Addict domain, List<AddictDrugs> drugs, List<AddictManagePlace> places);
        Addict Create(Addict domain, List<AddictClassify> drugs, List<AddictManagePlace> places);
        Addict Create(Addict domain, List<AddictVehicle> vehicle, List<AddictManagePlace> places);
        Addict Create(Addict domain, List<AddictDrugs> drugs, List<AddictClassify> classifies, List<AddictVehicle> vehicle, List<AddictManagePlace> places);


        bool Update(Addict domain);
        bool Update(Addict domain, List<AddictDrugs> drugs, List<AddictManagePlace> places);
        bool Update(Addict domain, List<AddictClassify> drugs, List<AddictManagePlace> places);
        bool Update(Addict domain, List<AddictVehicle> vehicle, List<AddictManagePlace> places);
        bool Update(Addict domain, List<AddictDrugs> drugs, List<AddictClassify> classifies, List<AddictVehicle> vehicle, List<AddictManagePlace> places);
        bool Delete(Guid id);
        IEnumerable<Addict2Dto> SearchByFace(Image faceimg);
        bool UploadExcel(IFormFile postedFile);
        public IEnumerable<Addict> GetLimit(int top);
    }
}

using Microsoft.AspNetCore.Http;
using OZ.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OZ.Interfaces
{
    public interface IAddictMap
    {
        List<AddictViewModel> GetAll();
        List<AddictViewModel2> GetAddict();
        List<AddictViewModel> GetByPlaceID(Guid placeID);
        IEnumerable<AddictBaseViewModel> GetBaseFields();
        List<AddictViewModel> Search(string sname, int genderID, int fromAge, int toAge, string SocialNetwork, string CitizenID, Guid? WardID);
        AddictViewModel GetByID(Guid id);
        bool CheckExists(string CitizendID);
        bool Delete(Guid id);
        bool Update(AddictViewModel viewModel);
        AddictViewModel Create(AddictViewModel viewModel);
        bool UploadExcel(IFormFile postedFile);
        IEnumerable<AddictViewModel> SearchByFace(Image faceimg);
        public IEnumerable<AddictViewModel> GetLimit(int top);
    }
}

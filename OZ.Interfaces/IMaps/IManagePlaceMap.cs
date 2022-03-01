using Microsoft.AspNetCore.Http;
using OZ.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OZ.Interfaces
{
    public interface IManagePlaceMap
    {
        List<ManagePlaceViewModel> GetAll();
        ManagePlaceViewModel GetByID(Guid id);
        List<ManagePlaceViewModel> GetByType(int typ, int citytyp);
        List<ManagePlaceViewModel> GetPaging(string fieldOrder, int pageNumber, int pageSize, out int totalPages, out int totalRecords);
        string GetPlaceTypeName(int oid);
        bool Delete(Guid id);
        bool Update(ManagePlaceViewModel viewModel);
        ManagePlaceViewModel Create(ManagePlaceViewModel viewModel);
        bool UploadExcel(IFormFile postedFile);
        HttpResponseMessage ExportExcel();


    }
}

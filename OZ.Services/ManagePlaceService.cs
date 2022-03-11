using Microsoft.AspNetCore.Http;
using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OZ.Services
{
    public class ManagePlaceService : IManagePlaceService
    {
        private IManagePlaceRepository repository;
        private IAddictRepository addictRepository;
        public ManagePlaceService(IManagePlaceRepository userRepository, IAddictRepository iAddictRepository)
        {
            repository = userRepository;
            addictRepository = iAddictRepository;
        }
        public ManagePlaceDto SaveCreate(ManagePlace domain)
        {
            return repository.SaveCreate(domain);
        }
        public bool Update(ManagePlace domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public bool UploadExcel(IFormFile postedFile)
        {
            return repository.UploadExcel(postedFile);
        }
        public HttpResponseMessage ExportExcel()
        {
            return repository.ExportExcel();
        }
        public IEnumerable<ManagePlaceDto> GetAll()
        {
            return repository.GetAll();
        }

        public ManagePlaceDto GetByID(Guid id)
        {
            return repository.GetByID(id);
        }

        public string GetPlaceTypeName(int oid)
        {
            return repository.GetPlaceTypeName(oid);
        }

        public IEnumerable<ManagePlaceDto> GetByType(int typ, int citytyp)
        {
            return repository.GetByType(typ, citytyp);
        }

        public IEnumerable<ManagePlace> GetPaging(string fieldOrder, int pageNumber, int pageSize,  out int totalPages, out int totalRecords)
        {
            return repository.GetPaging(fieldOrder, pageNumber, pageSize, out totalPages, out totalRecords);
        }
    }
}



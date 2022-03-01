using Microsoft.AspNetCore.Http;
using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OZ.Services
{
    public class AddictService : IAddictService
    {
        private IAddictRepository repository;
        public AddictService(IAddictRepository userRepository)
        {
            repository = userRepository;
        }
        public Addict Create(Addict domain)
        {
            return repository.Create(domain);
        }
        public bool UploadExcel(IFormFile postedFile)
        {
            return repository.UploadExcel(postedFile);
        }
        public bool Update(Addict domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(Guid id)
        {
            return repository.Delete(id);
        }
        public IEnumerable<Addict> GetAll()
        {
            return repository.GetAll();
        }

        public IEnumerable<AddictDto> GetAddict()
        {
            return repository.GetAddict();
        }

        public Addict GetByID(Guid id)
        {
            return repository.GetByID(id);
        }

        public IEnumerable<Addict> Search(string sname, int genderID, int fromAge, int toAge, string SocialNetwork, string CitizenID, Guid? WardID)
        {
            return repository.Search(sname, genderID, fromAge, toAge, SocialNetwork, CitizenID, WardID);
        }

        public bool CheckExists(string CitizendID)
        {
            return repository.CheckExists(CitizendID);
        }

        public IEnumerable<Addict> GetByPlaceID(Guid placeID)
        {
            return repository.GetByPlaceID(placeID);
        }

        public Addict Create(Addict domain, List<AddictDrugs> drugs, List<AddictManagePlace> places)
        {
            return repository.Create(domain, drugs, places);
        }

        public Addict Create(Addict domain, List<AddictClassify> drugs, List<AddictManagePlace> places)
        {
            return repository.Create(domain, drugs, places);
        }

        public Addict Create(Addict domain, List<AddictVehicle> vehicle, List<AddictManagePlace> places)
        {
            return repository.Create(domain, vehicle, places);
        }

        public Addict Create(Addict domain, List<AddictDrugs> drugs, List<AddictClassify> classifies, List<AddictVehicle> vehicle, List<AddictManagePlace> places)
        {
            return repository.Create(domain, drugs, classifies, vehicle, places);
        }

        public bool Update(Addict domain, List<AddictDrugs> drugs, List<AddictManagePlace> places)
        {
            return repository.Update(domain, drugs, places);
        }

        public bool Update(Addict domain, List<AddictClassify> drugs, List<AddictManagePlace> places)
        {
            return repository.Update(domain, drugs, places);
        }

        public bool Update(Addict domain, List<AddictVehicle> vehicle, List<AddictManagePlace> places)
        {
            return repository.Update(domain, vehicle, places);
        }

        //Addict domain, List<AddictDrugs> drugs, List<AddictClassify> classifies, List<AddictVehicle> vehicle, List<AddictManagePlace> places
        public bool Update(Addict domain, List<AddictDrugs> drugs, List<AddictClassify> classifies, List<AddictVehicle> vehicle, List<AddictManagePlace> places)
        {
            return repository.Update(domain, drugs, classifies, vehicle, places);
        }

        public IEnumerable<AddictBaseDto> GetBaseFields()
        {
            return repository.GetBaseFields();
        }

        public IEnumerable<Addict2Dto> SearchByFace(Image faceimg)
        {
            return repository.SearchByFace(faceimg);
        }

        public IEnumerable<Addict> GetLimit(int top)
        {
            return repository.GetLimit(top);
        }
    }
}

using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class DashService : IDashService
    {
        private IDashRepository repository;
        public DashService(IDashRepository iRepository)
        {
            repository = iRepository;
        }

        public List<Dash01> GetDashBoard01()
        {
            return repository.GetDashBoard01().Result;
        }

        public List<Dash02> GetDashBoard02()
        {
            return repository.GetDashBoard02().Result;
        }

        public List<Dash03> GetDashBoard03()
        {
            return repository.GetDashBoard03().Result;
        }

        public List<Dash04> GetDashBoard04()
        {
            return repository.GetDashBoard04().Result;
        }

        public List<Dash05> GetDashBoard05()
        {
            return  repository.GetDashBoard05().Result;
        }
        public List<DashClassify> GetDashBoardClassify()
        {
            return repository.GetDashBoardClassify().Result;
        }

        public List<DashAddictType> GetDashBoardAddictType()
        {
            return repository.GetDashBoardAddictType().Result;
        }
    }
}

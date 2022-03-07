using OZ.Interfaces;
using OZ.Models;
using System;
using System.Collections.Generic;

namespace OZ.Services
{
    public class DashService : IDashService
    {
        private IDashRepository repository;
        private IAddictRepository addictRepository;
        private IAddictClassifyRepository addictClassifyRepository;

        public DashService(IDashRepository iRepository, IAddictRepository iAddictRepository, IAddictClassifyRepository iAddictClassifyRepository)
        {
            repository = iRepository;
            addictRepository = iAddictRepository;
            addictClassifyRepository = iAddictClassifyRepository;
        }

        public IEnumerable<Dash01> GetDashBoard01()
        {
            //return repository.GetDashBoard01().Result;
            return repository.GetDashBoard01(addictRepository);
        }

        public IEnumerable<Dash02> GetDashBoard02()
        {
            return repository.GetDashBoard02(addictRepository);
        }

        public List<Dash03> GetDashBoard03()
        {
            return repository.GetDashBoard03().Result;
        }

        public IEnumerable<Dash04> GetDashBoard04()
        {
            return repository.GetDashBoard04(addictRepository);
        }

        public IEnumerable<Dash05> GetDashBoard05()
        {
            return  repository.GetDashBoard05(addictRepository);
        }
        public IEnumerable<DashClassify> GetDashBoardClassify()
        {
            return repository.GetDashBoardClassify(addictClassifyRepository, addictRepository);
        }

        public IEnumerable<DashAddictType> GetDashBoardAddictType()
        {
            return repository.GetDashBoardAddictType();
        }
    }
}

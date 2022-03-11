using OZ.Interfaces;
using OZ.Models;
using OZ.ViewModels;
using System;
using System.Collections.Generic;

namespace OZ.Maps
{
    public class DashboardMap : IDashboardMap
    {
        IDashService empService;
        public DashboardMap(IDashService service)
        {
            empService = service;
        }
        
        public DashViewModel01 DomainToViewModel(Dash01 domain)
        {
            DashViewModel01 model = new DashViewModel01();            
            model.MonthID = domain.MonthID;            
            model.Qty = domain.Qty;            
            return model;
        }
        public IEnumerable<DashViewModel01> DomainToViewModel(IEnumerable<Dash01> domain)
        {
            List<DashViewModel01> model = new List<DashViewModel01>();
            foreach (Dash01 of in domain)
            {
                model.Add(DomainToViewModel(of));
            }
            return model;
        }

        public IEnumerable<DashViewModel01> GetDashBoard01()
        {
            return DomainToViewModel(empService.GetDashBoard01());
        }

        public IEnumerable<DashViewModel02> GetDashBoard02()
        {
            List<DashViewModel02> lstmodel = new List<DashViewModel02>();
            var dblist = empService.GetDashBoard02();
          
            foreach (var item in dblist)
            {
                lstmodel.Add(new DashViewModel02() { Syear = item.Syear, male = item.male, female = item.female });
            }
            return lstmodel;
        }

        public IEnumerable<DashViewModel03> GetDashBoard03()
        {
            List<DashViewModel03> lstmodel = new List<DashViewModel03>();
            var dblist = empService.GetDashBoard03();
            foreach (var item in dblist)
            {
                lstmodel.Add(new DashViewModel03() {  drugName = item.drugName, Qty = item.Qty });
            }
            return lstmodel;
        }

        public IEnumerable<DashViewModel04> GetDashBoard04()
        {
            List<DashViewModel04> lstmodel = new List<DashViewModel04>();
            var dblist = empService.GetDashBoard04();
            foreach (var item in dblist)
            {
                lstmodel.Add(new DashViewModel04() { levelName = item.levelName, Qty = item.Qty });
            }
            return lstmodel;
        }

        public IEnumerable<DashViewModel05> GetDashBoard05()
        {
            List<DashViewModel05> lstmodel = new List<DashViewModel05>();
            var dblist = empService.GetDashBoard05();
            foreach (var item in dblist)
            {
                lstmodel.Add(new DashViewModel05() { AgeRange = item.AgeRange, curQty = item.curQty, PreQty = item.PreQty });
            }
            return lstmodel;
        }

        public IEnumerable<DashViewModelClassify> GetDashBoardClassify()
        {
            List<DashViewModelClassify> lstmodel = new List<DashViewModelClassify>();
            var dblist = empService.GetDashBoardClassify();
            foreach (var item in dblist)
            {
                lstmodel.Add(new DashViewModelClassify() { classifyName = item.classifyName, Qty = item.Qty });
            }
            return lstmodel;
        }

        public IEnumerable<DashViewModelAddictType> GetDashBoardAddictType()
        {
            List<DashViewModelAddictType> lstmodel = new List<DashViewModelAddictType>();
            var dblist = empService.GetDashBoardAddictType();
            foreach (var item in dblist)
            {
                lstmodel.Add(new DashViewModelAddictType() { PlaceName = item.PlaceName, Qty = item.Qty });
            }
            return lstmodel;
        }
        //public IEnumerable<DashViewModel01> GetDashBoard01()
        //{
        //    DomainToViewModel(empService.ge());
        //}
    }
}

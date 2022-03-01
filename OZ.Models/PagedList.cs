using OZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OZ.Models
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PagedList()
        {           
        }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        //public List<T> ToList()
        //{
        //    return this.ToList();
        //}
        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        //internal static PagedList<ManagePlace> ToPagedList(IQueryable<AddictManagePlace> addictManagePlaces, int pageNumber, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

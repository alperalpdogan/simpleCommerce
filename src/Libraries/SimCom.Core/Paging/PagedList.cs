using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.Paging
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList()
        {

        }

        public PagedList(IList<T> source, int pageNumber, int pageSize, int? totalCount = null)
        {
            pageSize = Math.Max(pageSize, 1);

            if (pageNumber <= 0)
                pageNumber = 1;

            TotalCount = totalCount ?? source.Count;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageNumber = pageNumber;
            AddRange(totalCount != null ? source : source.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;
    }
}

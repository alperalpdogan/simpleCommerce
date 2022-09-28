using Microsoft.EntityFrameworkCore;
using SimCom.Core.Paging;
using SimCom.Data.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Data.Extensions
{
    public static class AsyncIQueryableExtensions
    {
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize, bool getOnlyTotalCount = false)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            pageSize = Math.Max(pageSize, 1);

            var count = await source.CountAsync();

            var data = new List<T>();

            if (!getOnlyTotalCount)
                data.AddRange(await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync());

            return new PagedList<T>(data, pageNumber, pageSize, count);
        }

        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, PaginationFilter filter)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            filter.PageSize = Math.Max(filter.PageSize, 1);

            var count = await source.CountAsync();

            var data = new List<T>();

            data.AddRange(await source.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync());

            return new PagedList<T>(data, filter.PageNumber, filter.PageSize, count);
        }
    }
}

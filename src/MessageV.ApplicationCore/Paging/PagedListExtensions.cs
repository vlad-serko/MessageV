using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MessageV.ApplicationCore.Paging
{
    public static class PagedListExtensions
    {
        public static Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize)
            => PagedList<T>.CreateAsync(source, pageIndex, pageIndex);
    }
}
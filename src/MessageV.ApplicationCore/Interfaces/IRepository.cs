using System.Collections.Generic;
using System.Threading.Tasks;
using MessageV.ApplicationCore.Entities;
using MessageV.ApplicationCore.Paging;
using MessageV.ApplicationCore.Specifications;

namespace MessageV.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<PagedList<T>> ListAsync(PaginationOptions options);
        Task<PagedList<T>> ListAsync(ISpecification<T> spec, PaginationOptions options);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
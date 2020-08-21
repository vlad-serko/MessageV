using System;
using System.Linq;
using System.Threading.Tasks;
using MessageV.ApplicationCore.Entities;
using MessageV.ApplicationCore.Interfaces;
using MessageV.ApplicationCore.Paging;
using MessageV.ApplicationCore.Specifications;
using Microsoft.EntityFrameworkCore;

namespace MessageV.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ChatContext _context;
        private readonly DbSet<T> _set;
        
        public Repository(ChatContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            var entry = _set.Add(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public Task DeleteAsync(T entity)
        {
            _set.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return _set.FindAsync(id).AsTask();
        }

        public Task<PagedList<T>> ListAsync(PaginationOptions options)
        {
            return _set.ToPagedListAsync(options.PageIndex, options.PageSize);
        }

        public Task<PagedList<T>> ListAsync(ISpecification<T> spec, PaginationOptions options)
        {
            return ApplySpecification(_set.AsQueryable(), spec)
                .ToPagedListAsync(options.PageIndex, options.PageSize);
        }

        public Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        private static IQueryable<T> ApplySpecification(IQueryable<T> source, ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(source,
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return secondaryResult.Where(spec.Criteria);
        }
    }
}
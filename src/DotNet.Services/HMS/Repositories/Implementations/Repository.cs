using DotNet.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Services.HMS.Repositories.Interfaces;
using System.Linq.Expressions;

namespace DotNet.Services.HMS.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DotNetContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DotNetContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public  IQueryable<T> Query()
        {
            return  _dbSet.AsQueryable();
        }
        public IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);  // Add each include to the query
            }

            return query;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            
         _dbSet.Remove(entity);            
            
        }
    }
}

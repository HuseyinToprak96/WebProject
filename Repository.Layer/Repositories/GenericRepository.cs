using Core.Layer.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Layer.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        protected readonly AppDbContext _db;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task Add(T t)
        {
            await _dbSet.AddAsync(t);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
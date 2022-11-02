using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Interfaces.Repository
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task Add(T t);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}

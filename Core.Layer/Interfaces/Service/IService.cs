using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Interfaces.Service
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T t);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}

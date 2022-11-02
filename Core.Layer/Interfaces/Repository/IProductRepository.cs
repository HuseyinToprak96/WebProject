using Core.Layer.Entities;
using Core.Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Interfaces.Repository
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        IQueryable<Product> Search(ECategory category);
    }
}

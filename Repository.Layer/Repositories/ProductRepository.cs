using Core.Layer.Entities;
using Core.Layer.Enums;
using Core.Layer.Interfaces.Repository;
using Repository.Layer.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext db) : base(db)
        {
        }

        public  IQueryable<Product> Search(ECategory category)
        {
            return _db.Products.Where(x => x.Category == category);
        }
    }
}

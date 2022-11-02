using Core.Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            for (int i = 1; i <= 1000; i++)
            {
                builder.HasData(new Product { Id = i, Description=$"Açıklama {i}", Status=true, Unit=1000, UnitPrice=100, CreatedDate=DateTime.Now });
            }
        }
    }
}

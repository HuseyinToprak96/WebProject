using Core.Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Layer.Datas
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is Base entityReferences)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferences.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReferences.UpdateDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is Base entityReferences)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferences.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReferences).Property(x => x.CreatedDate).IsModified = false;
                                entityReferences.UpdateDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }


            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}

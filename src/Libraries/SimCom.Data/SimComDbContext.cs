using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimCom.Core.DomainModels.Common;
using SimCom.Core.DomainModels.Users;
using SimCom.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SimCom.Data
{

    public class SimComDbContext : IdentityDbContext<User, Role, string>
    {
        public SimComDbContext(DbContextOptions<SimComDbContext> options) : base(options)
        {

        }

        public DbSet<AttributeValue> AttributeValues { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<CategoryAttribute> CategoryAttribute { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductAttribute> ProductAttribute { get; set; }

        public DbSet<ProductAttributeValueCombination> ProductAttributeValueCombination { get; set; }

        public DbSet<ProductCategoryMapping> ProductCategoryMapping { get; set; }

        public DbSet<ProductPicture> ProductPicture { get; set; }

        public DbSet<ProductReview> ProductReview { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<SoftDeletedEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.Entity.Deleted = true;
                        entry.Entity.DeletedOnUtc = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<SoftDeletedEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.Entity.Deleted = true;
                        entry.Entity.DeletedOnUtc = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}

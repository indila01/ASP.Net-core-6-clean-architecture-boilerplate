using Boilerplate.Common.Entity;
using Boilerplate.Common.Repository;
using Boilerplate.DataAccess.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.DataAccess.EFCustomizations
{
    public partial class BoilerplateDbContext : DbContext, IBoilerplateDbContext
    {
        public BoilerplateDbContext(DbContextOptions<BoilerplateDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDescriptor).Assembly);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public Task<int> SaveChangesAsync() => SaveChangesAsync();
    }

    

   
}

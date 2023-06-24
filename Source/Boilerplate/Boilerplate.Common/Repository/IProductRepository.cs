using Boilerplate.Common.Entity;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Common.Repository
{
    public interface IProductRepository
    {
       public DbSet<Product> Products { get; set; }

    }
}
using Boilerplate.Common.Entity;
using Boilerplate.Common.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.DataAccess.EFCustomizations
{
    public partial class BoilerplateDbContext : IProductRepository
    {
        public Task<List<Product>> GetProducts(string? productName)
        {
            if (!string.IsNullOrEmpty(productName))
            {
                return Products.Where(i => i.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            }
            else
            {
                return Products.ToListAsync();
            }
        }
    }
}

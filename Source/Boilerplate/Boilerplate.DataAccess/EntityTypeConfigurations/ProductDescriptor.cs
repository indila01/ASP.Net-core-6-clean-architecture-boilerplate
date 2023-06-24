using Boilerplate.Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.DataAccess.EntityTypeConfigurations
{
    internal class ProductDescriptor : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(u => u.ProductID);

            builder.Property(u => u.ProductName)
                .HasMaxLength(50)
                .IsRequired(true);
            builder.Property(u => u.ProductPrice)
                .IsRequired(true);
            builder.Property(u => u.ProductDescription)
                .HasMaxLength(200)
                .IsRequired(false);
            builder.Property(u => u.ProductQuantity)
               .HasDefaultValue(1)
              .IsRequired(true);
        }
    }
}

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
    public class UserDescriptor : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserID);

            builder.Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired(true);
            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.Property(u => u.FirstName)
              .HasMaxLength(100)
              .IsRequired(false);

            builder.Property(u => u.LastName)
              .HasMaxLength(100)
              .IsRequired(false);

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired(true);
            builder.HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}

using Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            // Primary key
            builder.HasKey(x => x.Id);

            // Id
            builder.Property(x => x.Id)
                   .ValueGeneratedNever(); // vì bạn tự set Guid
                                           // Name
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Status)
                .HasConversion<int>();

            

        }
    }
}

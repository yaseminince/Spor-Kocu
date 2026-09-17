using Microsoft.EntityFrameworkCore;
using Sporkocu.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(x => x.Title).IsUnique();
            builder.HasData(new Role
            {
                Id = 1,
                Title = "ADMIN",
                Description = "Admin",
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
            }
         );
        }
    }
}

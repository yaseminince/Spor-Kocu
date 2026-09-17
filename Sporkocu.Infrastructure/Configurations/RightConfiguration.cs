using Microsoft.EntityFrameworkCore;
using Sporkocu.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Infrastructure.Configurations
{
    public class RightConfiguration : IEntityTypeConfiguration<Right>
    {
        public void Configure(EntityTypeBuilder<Right> builder)
        {
            builder.HasData(new Right
            {
                Id = 1,
                RoleId = 1,
                UserId = 1,
                CreatedBy = 1,
                CreatedDate = DateTime.Now

            });
        }
    }
}

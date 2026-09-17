using Microsoft.EntityFrameworkCore;
using Sporkocu.Domain.Base;
using Sporkocu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Infrastructure.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Unit> builder)
        {

            builder.HasData(new Unit
            {
                Id = 1,
                Title = "Kilo Verme",
                Icon = "kilo-verme.png",
                Description = "Kilo vermek için tüyolar",
                CreatedDate = DateTime.Now,
                CreatedBy = 1,
                Status = 1
            });
        }
    }
}


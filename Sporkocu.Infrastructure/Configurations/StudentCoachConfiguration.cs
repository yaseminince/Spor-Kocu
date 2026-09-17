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
    public class StudentCoachConfiguration : IEntityTypeConfiguration<StudentCoach>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudentCoach> builder)
        {

            builder.HasData(new StudentCoach
            {
                Id = 1,
                UserId = 1,
                Title = "Kilo Verme Koçluğu ",
                Description = "Kilo verme yolculuğunda yardımcı olacak hocalarımız mevcuttur.",
                CreatedDate = DateTime.Now,
                CategoryId = 1,
                CreatedBy = 1,
                Status = 1
            });
        }
    }
}
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
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasData(new Exercise
            {
                Id = 1,
                Title = "BenchPress",
                Description = "Haftada en fazla 3 gün yapılması önerilir",
                ImagePath = "benchpress.png",
                CreatedBy = 1,
                CreatedDate = DateTime.Now

            });
        }
    }
}
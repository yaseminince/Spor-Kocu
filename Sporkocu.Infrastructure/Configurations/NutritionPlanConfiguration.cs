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
    public class NutritionPlanConfiguration : IEntityTypeConfiguration<NutritionPlan>
    {
        public void Configure(EntityTypeBuilder<NutritionPlan> builder)
        {
            builder.HasData(new NutritionPlan
            {
                Id = 1,
                Title = "Diyet Listesi",
                Description = "1 ayda 3-4 kilo verdirecek o liste.",
                CreatedBy = 1,
                CreatedDate = DateTime.Now

            });
        }
    }
}
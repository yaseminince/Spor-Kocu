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
    public class NutritionPlanDetailConfiguration : IEntityTypeConfiguration<NutritionPlanDetail>
    {
        public void Configure(EntityTypeBuilder<NutritionPlanDetail> builder)
        {
            builder.HasData(new NutritionPlanDetail
            {
                Id = 1,
                NutritionPlanId = 1,
                FoodId = 1,
                Meal = "Kahvaltı",
                CreatedBy = 1,
                CreatedDate = DateTime.Now

            });
        }
    }
}
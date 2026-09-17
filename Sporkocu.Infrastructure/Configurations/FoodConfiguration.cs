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
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasData(new Food
            {
                Id = 1,
                Title = "Avokadolu Yumurtalı Kızarmış Ekmek",
                Description = "Zengin içerikli kahvaltı.",
                Calorie = "320 kalori",
                Protein = "14 gram",
                Carbonhydrate = "30 gram",
                Oil = "35 gram",
                Image = "avokado-tost.png" ,
                CreatedBy = 1,
                CreatedDate = DateTime.Now

            });
        }
    }
}
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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = 1,
                Title = "Fitness",
                Description = "Fitness ve egzersiz içerikleri",
                CreatedBy = 1,
                CreatedDate = DateTime.Now

            });
        }
    }
}
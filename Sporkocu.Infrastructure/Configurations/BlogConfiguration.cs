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
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasData(new Blog
            {
                Id = 1,
                Title = "Kas Gelişimi İçin Temel Kurallar",
                SubTitle = "Yeni Başlayanlar İçin Rehber",
                HtmlContent = "<p>Düzenli antrenman ve doğru beslenme kas gelişiminin temelidir.</p>",
                CoverImagePath = "blog1.jpg",
                CategoryId = 1,
                CreatedBy = 1,
                CreatedDate = DateTime.Now

            });
        }
    }
}
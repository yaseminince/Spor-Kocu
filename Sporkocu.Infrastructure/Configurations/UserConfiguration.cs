using Microsoft.EntityFrameworkCore;
using Sporkocu.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            // hiç kimse aynı emaille kayıt olamıyor
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasData(new User
            {
                Id = 1,
                Email = "admin@admin.com",
                CreatedBy = 1,
                FullName = "Yasemin İnce",
                CreatedDate = DateTime.Now,
                Password = "123123",
                Address = "",
                Phone = "",
                PremiumPackage = 1,
                ProfilePicPath = "",
            });
        }
    }
}

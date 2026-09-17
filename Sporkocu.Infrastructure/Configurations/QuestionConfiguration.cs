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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(new Question
            {
                Id = 1,
                Title = "1 günde kaç set benchpress yapılmalı?",
                Description = "Boyum 174 cm kilom da 65, yeni başlayan biri olarak günde kaç set benchpress yapmalıyım?",
                UserId = 1,
                CreatedBy = 1,
                CreatedDate = DateTime.Now

            });
        }
    }
}
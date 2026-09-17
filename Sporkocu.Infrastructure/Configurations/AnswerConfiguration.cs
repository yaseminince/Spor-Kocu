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
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasData(new Answer
            {
                Id = 1,
                QuestionId = 1,
                Description = "Günde 10 set ile başlamanız idealdir. Her haftada 5er set şeklinde çıkarın",
                Step = 1,
                UserId = 1 ,
                CreatedBy = 1,
                CreatedDate = DateTime.Now

            });
        }
    }
}
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
    public class ScheduleLessonConfiguration : IEntityTypeConfiguration<ScheduleLesson>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ScheduleLesson> builder)
        {

            builder.HasData(new ScheduleLesson
            {
                Id = 1,
                UserId = 1,
                StartTime = DateTime.Now,
                StartHour = "09.00",
                EndHour = "11.00",
                CreatedDate = DateTime.Now,
                CreatedBy = 1,
                Status = 1
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class ScheduleLesson : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public string? Note { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class Exercise : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public string? VideoLinkPath { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
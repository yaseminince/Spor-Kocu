using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class Food : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Calorie { get; set; }
        public string Protein { get; set; }
        public string Carbonhydrate { get; set; }
        public string Oil { get; set; }
        public string? Image { get; set; }
    }
}
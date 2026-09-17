using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class Unit : BaseEntity // master tablo
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }


}
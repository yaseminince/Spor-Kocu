using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class Right : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        #region Relations
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        #endregion
    }
}
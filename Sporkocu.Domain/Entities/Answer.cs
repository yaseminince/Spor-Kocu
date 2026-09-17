using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public int Step { get; set; }
        public int UserId { get; set; }

        #region Relations
        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}
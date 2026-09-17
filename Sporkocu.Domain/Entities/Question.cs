using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class Question : BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        #region Relations
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class StudentCoach : BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        // regionla açıp kapanabilir bölüm oluşturuluyor
        #region Relations 
        public virtual Category Category { get; set; }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class Blog : BaseEntity
    {

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string HtmlContent { get; set; }
        public string CoverImagePath { get; set; }
        public int CategoryId { get; set; }
        #region Relations
        public virtual Category Category { get; set; }
        #endregion
    }

}
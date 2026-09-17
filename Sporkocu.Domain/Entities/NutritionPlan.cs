using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class NutritionPlan : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        #region Relations
        // beslenme programına bağlı beslenme programı detayı

        public ICollection<NutritionPlanDetail> NutritionPlans { get; set; }
        #endregion
    }
}
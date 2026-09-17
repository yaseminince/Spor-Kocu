using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sporkocu.Domain.Base;

namespace Sporkocu.Domain.Entities
{
    public class NutritionPlanDetail : BaseEntity
    {
        public int NutritionPlanId { get; set; }
        public int FoodId { get; set; }
        public string Meal { get; set; }

        #region Relations
        public virtual NutritionPlan NutritionPlan { get; set; }
        #endregion
    }
}
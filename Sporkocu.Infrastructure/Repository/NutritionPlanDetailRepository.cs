using Sporkocu.Application.Interfaces.Repository;
using Sporkocu.Application.Interfaces.Repository.Base;
using Sporkocu.Domain.Entities;
using Sporkocu.Infrastructure.EFCore;
using Sporkocu.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Infrastructure.Repository
{
    public class NutritionPlanDetailRepository : EFRepository<NutritionPlanDetail>, INutritionPlanDetailRepository
    {
        public NutritionPlanDetailRepository(SportContext context) : base(context)
        {
        }
    }
}

using Sporkocu.Application.Interfaces.Repository;
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
    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SportContext context) : base(context)
        {
        }
    }
}

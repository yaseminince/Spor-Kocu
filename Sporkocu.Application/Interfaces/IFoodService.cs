using Sporkocu.Application.DTO.Request;
using Sporkocu.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Application.Interfaces
{
    public interface IFoodService : IGenericService<FoodResponse,FoodRequest>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Application.DTO.Base
{
    public class BaseRequest<T>
    {
        public T Entity { get; set; }
        public List<T> EntityList { get; set; }
    }
}

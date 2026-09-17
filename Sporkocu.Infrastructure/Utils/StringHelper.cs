using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sporkocu.Infrastructure.Utils
{
    public static class StringHelper
    {
        public static string CreateRandomValidKey()
        {
            var response = "";
            response = Guid.NewGuid().ToString();
            return response;
        }

        // 6 haneli random bi aktivasyon kodu 
        public static string CreateEmailValidationCode()
        {
            var res = RandomNumberGenerator.Create();
            var buffer = new byte[10];
            res.GetBytes(buffer);
            var activationCode = BitConverter.ToString(buffer).Replace("-", "");
            return activationCode.Substring(0, 6);
        }
    }
}

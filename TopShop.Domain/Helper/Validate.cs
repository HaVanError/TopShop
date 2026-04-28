using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TopShop.Domain.Helper
{
    public static class Validate
    {
        public static T ValidateRequired<T>(T value, string fieldName)
        {
           if(value == null || (value is string str && string.IsNullOrWhiteSpace(str)) || (value is Guid guid && guid == Guid.Empty))
            {
                throw new ArgumentException($"{fieldName} không được để trống.");
            }
            return value;
        }
    }
}

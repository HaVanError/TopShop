using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShop.Domain.ValueObject
{
    public class ProductName
    {
        public string Value { get; }
        public ProductName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tên sản phẩm không được rỗng");
            Value = value;
        }
    }
}

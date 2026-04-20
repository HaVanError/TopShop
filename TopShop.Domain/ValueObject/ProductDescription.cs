using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShop.Domain.ValueObject
{
    public class ProductDescription
    {
        public string Value { get; }
        public ProductDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Mô tả sản phẩm không được rỗng");
            Value = value;
        }
    }
}

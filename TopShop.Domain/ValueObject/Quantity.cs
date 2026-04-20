using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShop.Domain.ValueObject
{
    public class Quantity
    {
        public int Value { get; }
        public Quantity(int value)
        {
            if (value < 0)
                throw new ArgumentException("Số lượng không hợp lệ");
            Value = value;
        }
    }
}

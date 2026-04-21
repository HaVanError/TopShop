using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShop.Domain.Entity
{
    public class Category
    {
        public Guid Id { get; private  set; } = Guid.NewGuid(); // Sử dụng Guid làm khóa chính cho danh mục
        public string Name { get; private set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
        private Category() { }
        public Category(string name)
        {
            Helper.Validate.ValidateRequired(name, "Tên danh mục");
            Name = name;
        }
        public void  ChangeName(string newName)
        {
            Helper.Validate.ValidateRequired(newName, "Tên danh mục");
            Name = newName;
        }
        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            Products.Add(product);
            product.SetCategoryId(this.Id); // Thiết lập khóa ngoại cho sản phẩm
            product.Category = this; // Thiết lập quan hệ 1-n giữa Category và Product
        }

    }
}

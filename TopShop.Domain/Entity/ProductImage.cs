using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShop.Domain.Entity
{
    public class ProductImage
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ProductId { get; private set; }
        public string ImageUrl { get; private set; }
        
        private ProductImage() { }
        public ProductImage(Guid productId, string imageUrl)
        {
            ProductId = productId;
            ImageUrl = imageUrl;
        }
        public void ChangeImageUrl(string newImageUrl)
        {
            Helper.Validate.ValidateRequired(newImageUrl, "URL hình ảnh");
            ImageUrl = newImageUrl;
        }
        public void ChangeProductId(Guid newProductId)
        {
            Helper.Validate.ValidateRequired(newProductId, "Id sản phẩm");
            ProductId = newProductId;
        }


    }
}

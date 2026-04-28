using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopShop.Domain.Enum;
using TopShop.Domain.ValueObject;

namespace TopShop.Domain.Entity
{
    public class Product
    {
        public Guid Id { get;  private set; } = Guid.NewGuid(); // Sử dụng Guid làm khóa chính cho sản phẩm
        public string Name { get; private set; } 
        public string Descriptions { get; private set; } 
        public Price Price { get; private set; }
        public Quantity Quantity { get; private set; }
        public ProductStatus Status { get; private set; } = ProductStatus.Activate; // Trạng thái hoạt động của sản phẩm (mặc định là đang bán)
        public Guid CategoryId { get; private set; } // khóa ngoại đến Category
        public Category Category { get; private set; } // quan hệ 1 -n với Category
        private Product() { }
        public Product(string productName, string descriptions, Price price, Quantity quantity)
        {
           
            Helper.Validate.ValidateRequired(productName, "Tên sản phẩm");
            Helper.Validate.ValidateRequired(descriptions, "Mô tả sản phẩm");
            Name = productName;
            Descriptions = descriptions;
            Price = price;
            Quantity = quantity;
        }
        //kiểm tra trạng thái của sản phẩm trước khi thực hiện các hành vi thay đổi thông tin sản phẩm
        private void EnsureActive()
        {
            if (Status != ProductStatus.Activate)
                throw new InvalidOperationException("Sản phẩm không hoạt động.");
        }

        // các hành vi thay đổi trạng thái của sản phẩm
        public void ChangeName(string newName)
        {
            EnsureActive();
            Helper.Validate.ValidateRequired(newName, "Tên sản phẩm");
            Name = newName;
        }
        public void ChangeDescriptions(string newDescriptions)
        {
            EnsureActive();
            Helper.Validate.ValidateRequired(newDescriptions, "Mô tả sản phẩm");
            Descriptions = newDescriptions;
        }
        
        public void ChangeQuantity(Quantity newQuantity)
        {
            EnsureActive();
            Quantity = newQuantity;
        }

        public void ChangePrice(Price newPrice)
        {
            EnsureActive();
            Price = newPrice;
        }
        // Phương thức để giảm số lượng sản phẩm khi có đơn hàng
        public void ReduceStock(Quantity amount)
        {
            EnsureActive();
            if (amount.Value > Quantity.Value)
                throw new InvalidOperationException("Không đủ hàng trong kho.");
            Quantity = new Quantity(Quantity.Value - amount.Value);
        }
        // Phương thức để mở bán 1 sản phẩm 
        public void Activate()
        {
            Status = ProductStatus.Activate;
        }
        // Phương thức để ngừng bán 1 sản phẩm
        public void Deactivate()
        {
            Status = ProductStatus.Inactive;
        }

        //Phương thức tính tổng giá trị của sản phẩm dựa trên số lượng và giá
        public decimal CalculateTotalValue()
        {
            return Price.Value * Quantity.Value;
        }
        // phương thức set giá trị IdDanhmuc cho sản phẩm
        public void ChangeCategory(Guid categoryId)
        {
            EnsureActive();
            if (categoryId == Guid.Empty)// kiểm tra nếu categoryId là Guid.Empty thì ném lỗi 
                throw new ArgumentException("Category không hợp lệ");

            if (CategoryId == categoryId)
                return; // nếu categoryId mới giống với categoryId hiện tại thì không cần thay đổi
            CategoryId = categoryId;
        }

        //override
        //    public string ToString()
        //{
        //    return $"Tên sản phẩm: {Name}, Mô tả: {Descriptions}, Giá: {Price.Value}, Số lượng: {Quantity.Value} , Trạng thái: {Status} ";
        //}
    }
}

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
        public int Id { get; set; }
        public ProductName Name { get; private set; } 
        public ProductDescription Descriptions { get; private set; } 
        public Price Price { get; private set; }
        public Quantity Quantity { get; private set; }
        public ProductStatus Status { get; private set; } = ProductStatus.Activate; // Trạng thái hoạt động của sản phẩm (mặc định là đang bán)
        private Product() { }
        public Product(ProductName productName, ProductDescription descriptions, Price price, Quantity quantity)
        {
            Name = productName;
            Descriptions = descriptions;
            Price = price;
            Quantity = quantity;
        }

        private void EnsureActive()
        {
            if (Status != ProductStatus.Activate)
                throw new InvalidOperationException("Sản phẩm không hoạt động.");
        }

        // các hành vi thay đổi trạng thái của sản phẩm
        public void ChangeName(ProductName newName)
        {
            EnsureActive();
            Name = newName;
        }
        public void ChangeDescriptions(ProductDescription newDescriptions)
        {
            EnsureActive();
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

    }
}

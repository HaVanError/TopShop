using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Product() { }
        public Product(ProductName productName, ProductDescription descriptions, Price price, Quantity quantity)
        {
            Name = productName;
            Descriptions = descriptions;
            Price = price;
            Quantity = quantity;
        }
        // các hành vi thay đổi trạng thái của sản phẩm
        public void ChangeName(ProductName newName)
        {
            Name = newName;
        }
        public void ChangeDescriptions(ProductDescription newDescriptions)
        {
            Descriptions = newDescriptions;
        }
        public void ChangeQuantity(Quantity newQuantity)
        {
            Quantity = newQuantity;
        }

        public void ChangePrice(Price newPrice)
        {
            Price = newPrice;
        }
        // Phương thức để giảm số lượng sản phẩm khi có đơn hàng
        public void ReduceStock(int amount)
        {
            if (amount > Quantity.Value)
                throw new InvalidOperationException("Không đủ hàng trong kho.");
            Quantity = new Quantity(Quantity.Value - amount);
        }
        //Phương thức tính tổng giá trị của sản phẩm dựa trên số lượng và giá
        public decimal CalculateTotalValue()
        {
            return Price.Value * Quantity.Value;
        }

    }
}

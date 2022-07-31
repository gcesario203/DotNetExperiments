using Basket.API.Entities.DataObject;

namespace Basket.API.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public ShoppingCartItem() { }

        public ShoppingCartItem(int quantity, Product product)
        {
            Quantity = quantity;

            Product = product;
        }

        public decimal GetProductValue()
        {
            return Product.Price * Quantity;
        }
    }
}
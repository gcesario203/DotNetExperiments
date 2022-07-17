namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        
        public IEnumerable<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal TotalPrice {
            get
            {
                if(Items == null || Items.Count() == 0)
                    return 0M;

                return Items.Sum(x => x.GetProductValue());
            }
        }

        public ShoppingCart(string username)
        {
            UserName = username;
        }
        public ShoppingCart(string username, IEnumerable<ShoppingCartItem> products)
        {
            UserName = username;
            Items = products;
        }
    }
}
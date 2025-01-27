using NLog;
using Unit8Practice.Shopping.DiscountStrategies;

namespace Unit8Practice.Shopping
{
    internal class ShoppingCart
    {
        private readonly IDiscountStrategy _discountStrategy;
        private readonly List<ShopItem> _items = new List<ShopItem>();


        public ShoppingCart(List<ShopItem> items, IDiscountStrategy discountStrategy)
        {
            _items = items;
            _discountStrategy = discountStrategy;
        }


        public void AddProduct(ShopItem item)
        {
            _items.Add(item);
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var product in _items)
            {
                decimal priceWithDiscount = _discountStrategy.ApplyDiscount(product.Price);
                total += priceWithDiscount;
                LogManager.GetCurrentClassLogger().Info($"Total price is changed to {total}");
            }
            return total;
        }
    }
}

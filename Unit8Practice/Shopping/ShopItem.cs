using Unit8Practice.Shopping.DiscountStrategies;

namespace Unit8Practice.Shopping
{
    internal class ShopItem : IShopItem
    {        
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Category { get; private set; }

        public ShopItem(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}

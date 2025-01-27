namespace Unit8Practice.Shopping.DiscountStrategies
{
    internal interface IDiscountStrategy
    {
        // TO DO: maybe use IShopItem instead of price?
        public decimal ApplyDiscount(decimal price);
    }
}

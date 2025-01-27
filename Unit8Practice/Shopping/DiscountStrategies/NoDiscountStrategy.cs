namespace Unit8Practice.Shopping.DiscountStrategies
{
    internal class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price;
        }
    }
}

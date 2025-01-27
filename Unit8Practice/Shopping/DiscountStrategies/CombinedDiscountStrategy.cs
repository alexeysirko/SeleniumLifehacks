namespace Unit8Practice.Shopping.DiscountStrategies
{
    internal class CombinedDiscountStrategy : IDiscountStrategy
    {
        private readonly IEnumerable<IDiscountStrategy> _discountStrategies;

        /// <summary>
        /// Combines strategies one by one
        /// </summary>
        /// <param name="discountStrategies"> Applies discount in order of the strategies </param>
        public CombinedDiscountStrategy(IEnumerable<IDiscountStrategy> discountStrategies)
        {
            _discountStrategies = discountStrategies;
        }

        public decimal ApplyDiscount(decimal price)
        {
            decimal discountedPrice = price;
            foreach (var strategy in _discountStrategies)
            {
                if (discountedPrice <= 0)
                {
                    throw new ArgumentOutOfRangeException("Discounts made price zero or less");
                }
                discountedPrice = strategy.ApplyDiscount(price);
            }
            return discountedPrice;
        }
    }
}

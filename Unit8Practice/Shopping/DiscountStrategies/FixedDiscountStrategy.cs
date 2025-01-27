using System.Diagnostics;

namespace Unit8Practice.Shopping.DiscountStrategies
{
    internal class FixedDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal _discountAmount;

        public FixedDiscountStrategy(decimal discountAmount)
        {
            _discountAmount = discountAmount;
        }

        public decimal ApplyDiscount(decimal price)
        {
            if (price < _discountAmount)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Discount is bigger than price");
            }

            return price - _discountAmount;
        }
    }
}

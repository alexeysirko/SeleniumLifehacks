namespace Unit8Practice.Shopping.DiscountStrategies
{
    internal class PercentageDiscountStrategy : IDiscountStrategy
    {
        private decimal _percentage;
        private const decimal MIN_PERCENTAGE_EXCLUDE = 0;
        private const decimal MAX_PERCENTAGE_INCLUDE = 100;


        public PercentageDiscountStrategy(decimal percentage)
        {
            SetPercentage(percentage);
        }

        private void SetPercentage(decimal percentage)
        {
            if (percentage <= MIN_PERCENTAGE_EXCLUDE || percentage > MAX_PERCENTAGE_INCLUDE)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), $"Percentage must be in {MIN_PERCENTAGE_EXCLUDE} - {MAX_PERCENTAGE_INCLUDE} range");
            }
            _percentage = percentage;
        }

        public decimal ApplyDiscount(decimal price)
        {
            return price - (price * _percentage / 100);
        }
    }
}

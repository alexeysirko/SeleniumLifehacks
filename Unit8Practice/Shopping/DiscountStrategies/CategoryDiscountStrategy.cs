namespace Unit8Practice.Shopping.DiscountStrategies
{
    internal class CategoryDiscountStrategy : IDiscountStrategy
    {
        private readonly Dictionary<string, IDiscountStrategy> _categoryDiscounts;

        public CategoryDiscountStrategy(Dictionary<string, IDiscountStrategy> categoryDiscounts)
        {
            _categoryDiscounts = categoryDiscounts;
        }

        public decimal ApplyDiscount(decimal price)
        {
            throw new NotImplementedException("Another abstract layer");
        }
    }
}

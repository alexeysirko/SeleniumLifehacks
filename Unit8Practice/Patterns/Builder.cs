namespace Unit8Practice.Patterns
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Cart
    {
        public List<Product> Products { get; private set; } = new List<Product>();
        public decimal TotalPrice { get; private set; }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            TotalPrice += product.Price;
        }
    }

    public class Discount
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }

    public class Order
    {
        public Cart Cart { get; set; }
        public List<Discount> Discounts { get; private set; } = new List<Discount>();
        public decimal FinalPrice { get; private set; }

        public void CalculateFinalPrice()
        {
            FinalPrice = Cart.TotalPrice;
            foreach (var discount in Discounts)
            {
                FinalPrice -= discount.Amount;
            }
        }
    }

    public interface IOrderBuilder
    {
        void BuildCart();
        void AddProductToCart(Product product);
        void ApplyDiscount(Discount discount);
        Order GetOrder();
    }

    public class OrderBuilder : IOrderBuilder
    {
        private Order _order = new Order();

        public void BuildCart()
        {
            _order.Cart = new Cart();
        }

        public void AddProductToCart(Product product)
        {
            _order.Cart.AddProduct(product);
        }

        public void ApplyDiscount(Discount discount)
        {
            _order.Discounts.Add(discount);
        }

        public Order GetOrder()
        {
            _order.CalculateFinalPrice();
            return _order;
        }
    }

    public class OrderDirector
    {
        private readonly IOrderBuilder _builder;

        public OrderDirector(IOrderBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructOrder(List<Product> products, List<Discount> discounts)
        {
            _builder.BuildCart();
            foreach (var product in products)
            {
                _builder.AddProductToCart(product);
            }
            foreach (var discount in discounts)
            {
                _builder.ApplyDiscount(discount);
            }
        }       
    }

    public class BuilderLogic()
    {
        public static void MainBulderLogic()
        {
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 1000 },
                new Product { Name = "Mouse", Price = 50 }
            };

            var discounts = new List<Discount>
            {
                new Discount { Description = "Summer Sale", Amount = 100 }
            };

            IOrderBuilder builder = new OrderBuilder();
            OrderDirector director = new OrderDirector(builder);

            director.ConstructOrder(products, discounts);
            Order order = builder.GetOrder();

            Console.WriteLine($"Final Price: {order.FinalPrice}");
        }
    }
}

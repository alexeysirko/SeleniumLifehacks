using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit8Practice.Birzha
{
    public abstract class Decorator
    {
        protected IStockableComponent _component;

        public Decorator(IStockableComponent component)
        {
            _component = component;
        }

        public void BuyExchange(IExchange exchange)
        {
            _component.BuyExchange(exchange);
        }

        public void SellExchange(IExchange exchange)
        {
            _component.SellExchange(exchange);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit8Practice.Birzha
{
    public interface IStockableComponent
    {
        public IExchange BuyExchange(IExchange exchange);
        public IExchange SellExchange(IExchange exchange);
    }
}

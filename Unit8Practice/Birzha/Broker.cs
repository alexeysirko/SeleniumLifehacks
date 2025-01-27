using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit8Practice.Birzha
{
    public class Broker : IStockableComponent
    {
        private StockMarket _market;

        public Broker(StockMarket market)
        {
            _market = market;
        }

        public IExchange BuyExchange(IExchange exchange)
        {
            return _market.BuyExchange();
        }

        public IExchange SellExchange(IExchange exchange)
        {
            return _market.SellExchange();
        }
    }
}

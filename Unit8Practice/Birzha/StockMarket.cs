using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit8Practice.Birzha
{
    public abstract class StockMarket
    {
        private IMessageProtocol _protocol;

        public StockMarket(IMessageProtocol protocol)
        {
            _protocol = protocol;
        }

        public abstract IExchange BuyExchange();

        public abstract IExchange SellExchange();
    }
}

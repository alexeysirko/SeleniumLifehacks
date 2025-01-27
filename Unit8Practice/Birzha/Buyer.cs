using OpenCvSharp;

namespace Unit8Practice.Birzha
{
    public class Buyer
    {
        private IWallet _wallet;

        public Buyer(IWallet wallet)
        {
            _wallet = wallet;
        }

        public void BuyExcange(Broker brocker, IExchange wishedExchange)
        {
            var boughtExchange = brocker.BuyExchange(wishedExchange);
            _wallet.AddExhange(boughtExchange);
        }

        public void SellExcange(Broker brocker, IExchange exchange)
        {
            var selledExchange = brocker.BuyExchange(exchange);
            _wallet.AddExhange(selledExchange);
        }
    }
}

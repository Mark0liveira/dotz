namespace Dotz.ValueObjects
{
    public class DotzCoin
    {
        public DotzCoin(decimal coin)
        {
            Coin = coin.ToString("0.##");
        }

        public string Coin { get; private set; }
    }
}

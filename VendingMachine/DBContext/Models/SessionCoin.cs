namespace VendingMachine.DBContext.Models
{
    public class SessionCoin
    {
        public int SessionCoinId { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int CoinId { get; set; }
        public Coin Coin { get; set; }
        public int Amount { get; set; }
    }
}

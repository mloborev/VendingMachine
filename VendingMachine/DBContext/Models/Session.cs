namespace VendingMachine.DBContext.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public DateTime SessionStartTime { get; set; }
        public List<Coin> Coins { get; set; }
    }
}

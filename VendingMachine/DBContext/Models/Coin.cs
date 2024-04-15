using System.ComponentModel.DataAnnotations;

namespace VendingMachine.DBContext.Models
{
    public class Coin
    {
        [Key]
        public int CoinId { get; set; }
        public int Value { get; set; }
        public bool IsBlocked { get; set; }
        public int Amount { get; set; }
        public int VendingMachineId { get; set; }
        public VendingMachine VendingMachine { get; set; }
    }
}

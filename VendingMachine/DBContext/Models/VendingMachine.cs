using System.ComponentModel.DataAnnotations;

namespace VendingMachine.DBContext.Models
{
    public class VendingMachine
    {
        [Key]
        public int VendingMachineId { get; set; }
        public List<Coin> Coins { get; set; } = new List<Coin>();
        public List<Drink> Drinks { get; set; } = new List<Drink>();
    }
}

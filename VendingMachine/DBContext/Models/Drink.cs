using System.ComponentModel.DataAnnotations;

namespace VendingMachine.DBContext.Models
{
    public class Drink
    {
        [Key]
        public int DrinkId { get; set; }
        public string Name { get; set; } = "";
        public string IMGPath { get; set; } = "";
        public int Cost { get; set; }
        public int Amount { get; set; }
        public int VendingMachineId { get; set; }
        public VendingMachine VendingMachine { get; set; }
    }
}

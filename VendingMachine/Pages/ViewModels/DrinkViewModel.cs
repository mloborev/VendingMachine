using VendingMachine.DBContext.Models;

namespace VendingMachine.Pages.ViewModels
{
    public class DrinkViewModel
    {
        public List<Drink> Drinks { get; set; } = new List<Drink>();
        public List<string> ImgPaths { get; set; } = new List<string>();
    }
}

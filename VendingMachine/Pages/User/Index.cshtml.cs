using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using VendingMachine.DBContext;
using VendingMachine.Pages.Models;
using VendingMachine.Pages.ViewModels;
using VendingMachine.Repositories.Interfaces;

namespace VendingMachine.Pages.User
{
    public class IndexModel : PageModel
    {
        private IDrinkRepository _drinkRepository;
        private ICoinRepository _coinRepository;
        private IJSRuntime _jsRuntime;

        private List<CoinCount> _coinCount { get; set; }
        public DrinkViewModel DrinkViewModel { get; set; } = new DrinkViewModel();
        public IndexModel(IDrinkRepository drinkRepository, ICoinRepository coinRepository, IJSRuntime jSRuntime)
        {
            _drinkRepository = drinkRepository;
            _coinRepository = coinRepository;
            _jsRuntime = jSRuntime;
        }
        public async Task OnGetAsync()
        {
            var drinks = await _drinkRepository.GetAllDataAsync();
            var coins = await _coinRepository.GetAllDataAsync();
            DrinkViewModel.Drinks = drinks;
            DrinkViewModel.Coins = coins;
        }

        public async Task OnPostAsync(string drinkId)
        {
            var coins = await _coinRepository.GetAllDataAsync();
            for(var i = 1; i < 5; i++)
            {
                var data = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", $"coin{i}");
                var coin = coins.FirstOrDefault(x => x.CoinId == i);
                _coinCount.Add(new CoinCount { Value = coin.Value, Amount = Convert.ToInt32(data) });
            }
        }
    }
}

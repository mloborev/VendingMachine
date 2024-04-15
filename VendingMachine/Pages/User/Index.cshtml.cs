using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VendingMachine.DBContext;
using VendingMachine.Pages.ViewModels;
using VendingMachine.Repositories;

namespace VendingMachine.Pages.User
{
    public class IndexModel : PageModel
    {
        private IDrinkRepository _drinkRepository;
        public IWebHostEnvironment _env;
        public DrinkViewModel DrinkViewModel { get; set; } = new DrinkViewModel();
        public IndexModel(IDrinkRepository drinkRepository, IWebHostEnvironment env)
        {
            _drinkRepository = drinkRepository;
            _env = env;
        }
        public async Task OnGetAsync()
        {
            var drinks = await _drinkRepository.GetAllDataAsync();
            var imgPaths = drinks.Select(drink => drink.IMGPath).ToList();
            var physicalImgPaths = new List<string>();
            foreach (var imgPath in imgPaths)
            {
                physicalImgPaths.Add(_env.WebRootFileProvider.GetFileInfo(imgPath)?.PhysicalPath!);
            }
            DrinkViewModel.Drinks = drinks;
            DrinkViewModel.ImgPaths = physicalImgPaths;
        }
    }
}

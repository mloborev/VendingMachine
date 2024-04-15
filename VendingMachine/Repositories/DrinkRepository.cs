using Microsoft.EntityFrameworkCore;
using VendingMachine.DBContext;
using VendingMachine.DBContext.Models;

namespace VendingMachine.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private ApplicationContext _context;
        public DrinkRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Drink>> GetAllDataAsync()
        {
            return await _context.Drinks.ToListAsync();
        }
    }
}

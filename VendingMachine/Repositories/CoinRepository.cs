using Microsoft.EntityFrameworkCore;
using VendingMachine.DBContext;
using VendingMachine.DBContext.Models;
using VendingMachine.Repositories.Interfaces;

namespace VendingMachine.Repositories
{
    public class CoinRepository : ICoinRepository
    {
        private ApplicationContext _context;
        public CoinRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Coin>> GetAllDataAsync()
        {
            return await _context.Coins.ToListAsync();
        }
    }
}

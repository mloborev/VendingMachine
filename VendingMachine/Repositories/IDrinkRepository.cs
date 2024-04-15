using System.Reflection.Metadata;
using VendingMachine.DBContext.Models;

namespace VendingMachine.Repositories
{
    public interface IDrinkRepository
    {
        Task<List<Drink>> GetAllDataAsync();
    }
}

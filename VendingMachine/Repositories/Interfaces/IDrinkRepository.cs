using System.Reflection.Metadata;
using VendingMachine.DBContext.Models;

namespace VendingMachine.Repositories.Interfaces
{
    public interface IDrinkRepository
    {
        Task<List<Drink>> GetAllDataAsync();
    }
}

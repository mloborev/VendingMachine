using VendingMachine.DBContext.Models;

namespace VendingMachine.Repositories.Interfaces
{
    public interface ICoinRepository
    {
        Task<List<Coin>> GetAllDataAsync();
    }
}

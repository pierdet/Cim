using Cim.Lib.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cim.Lib.Data.Repository
{
    public interface IInventoryRepository
    {
        Task AddInventoryAsync(string name);
        void AddInventory(string name);
        Task RemoveInventoryAsync(string name);
        void RemoveInventory(string name);
        Task<IEnumerable<Inventory>> GetInventoriesAsync();
        IEnumerable<Inventory> GetInventories();
        Task<Inventory> GetInventoryByNameAsync(string name);
        Inventory GetInventoryByName(string name);
        Task UpdateInventoryAsync(Inventory inventory);
        void UpdateInventory(Inventory inventory);

    }
}

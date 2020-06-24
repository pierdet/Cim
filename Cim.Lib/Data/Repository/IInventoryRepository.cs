using Cim.Lib.Data.Entities;
using System.Collections.Generic;

namespace Cim.Lib.Data.Repository
{
    public interface IInventoryRepository
    {
        void AddInventory(string name);
        IEnumerable<Inventory> GetInventories();
        Inventory GetInventoryByName(string name);
        void UpdateInventory(Inventory inventory);

    }
}

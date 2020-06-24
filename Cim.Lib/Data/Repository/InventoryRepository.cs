using Cim.Lib.Data.Entities;
using Cim.Lib.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cim.Lib.Data.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
       InventoryContext _context;
        public InventoryRepository(InventoryContext context)
        {
            _context = context;
        }
        public void AddInventory(string name)
        {
            using (_context)
            {
                if((_context.Inventories.FirstOrDefault(n => n.Name == name)) != null){
                    throw new Exception("Inventory already exists");
                }
                else
                {
                    var entity = new Inventory
                    {
                        Name = name
                    };
                    using (_context)
                    {
                        _context.Inventories.Add(entity);
                        _context.SaveChanges();
                    }
                }
            }
        }

        public IEnumerable<Inventory> GetInventories()
        {
            using (_context)
            {
                return _context.Inventories.ToList();
            }
        }

        public Inventory GetInventoryByName(string name)
        {
            using (_context)
            {
                return _context.Inventories
                    .Include(i => i.Hosts)
                    .FirstOrDefault(i => i.Name == name);
            }
        }

        public void UpdateInventory(Inventory inventory)
        {
            using (_context)
            {
                _context.Inventories.Update(inventory);
                _context.SaveChanges();
            }
        }
    }
}

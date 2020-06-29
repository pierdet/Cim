using Cim.Lib.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            
            if(_context.Inventories.Any(n => n.Name == name)){
                throw new Exception("Inventory already exists");
            }
            else
            {
                var entity = new Inventory
                {
                    Name = name
                };
                _context.Inventories.Add(entity);
                _context.SaveChanges();
            }
            
        }
        public void RemoveInventory(string name)
        {
            if (!(_context.Inventories.Any(n => n.Name == name)))
            {
                throw new Exception("Inventory doesn't exist!");
            }
            else
            {
                _context.Inventories.Remove(GetInventoryByName(name));
                _context.SaveChanges();
            }
        }

        public IEnumerable<Inventory> GetInventories()
        {
            return _context.Inventories.ToList();   
        }

        public Inventory GetInventoryByName(string name)
        {
            return _context.Inventories
                .Include(i => i.Hosts)
                .FirstOrDefault(i => i.Name == name);

        }

        public void UpdateInventory(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            _context.SaveChanges();
        }
    }
}

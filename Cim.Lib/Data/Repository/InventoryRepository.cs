using Cim.Lib.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task AddInventoryAsync(string name)
        {
            if (_context.Inventories.Any(n => n.Name == name))
            {
                throw new Exception("Inventory already exists");
            }
            else
            {
                var entity = new Inventory
                {
                    Name = name
                };
                await _context.Inventories.AddAsync(entity);
                await _context.SaveChangesAsync();
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
        public async Task RemoveInventoryAsync(string name)
        {
            if (!(_context.Inventories.Any(n => n.Name == name)))
            {
                throw new Exception("Inventory doesn't exist!");
            }
            else
            {
                await Task.Run (() => _context.Inventories.Remove(GetInventoryByName(name)));
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Inventory> GetInventories()
        {
            return _context.Inventories.ToList();   
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public Inventory GetInventoryByName(string name)
        {
            return _context.Inventories
                .Include(i => i.Hosts)
                .FirstOrDefault(i => i.Name == name);

        }
        public async Task<Inventory> GetInventoryByNameAsync(string name)
        {
            return await _context.Inventories
                .Include(i => i.Hosts)
                .FirstOrDefaultAsync(i => i.Name == name);
        }

        public void UpdateInventory(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            _context.SaveChanges();
        }
        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }
    }
}

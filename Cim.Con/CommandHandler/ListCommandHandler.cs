using Cim.Con.CommandOptions;
using Cim.Lib.Data.Repository;
using Cim.Con.UI;
using System;

namespace Cim.Con.CommandHandler
{
    public class ListCommandHandler : ICommandHandler<ListOptions>
    {
        IInventoryRepository _inventoryRepository;
        IGui _gui;
        public ListCommandHandler(IInventoryRepository inventoryRepository, IGui gui)
        {
            _inventoryRepository = inventoryRepository;
            _gui = gui;
        }
        
        public int RunCommand(ListOptions opts)
        {
            if(opts.Inventory == null)
            {
                //No inventory specified, list all inventories
                try
                {
                    var inventories = _inventoryRepository.GetInventories();
                    foreach(var inventory in inventories)
                    {
                        _gui.WriteLine(inventory.Name);
                    }
                    return 0;
                }
                catch (ArgumentNullException e)
                {
                    _gui.WriteError($"Failed to list inventories, have you created any? - { e }");
                    return 1;
                }
                
            }
            else
            {
                //Inventory specified, list all hosts
                try
                {
                    var inventory = _inventoryRepository.GetInventoryByName(opts.Inventory);
                    if (inventory.Hosts.Count > 0)
                    {
                        _gui.WriteLine($"Hosts in {inventory.Name}:");
                        foreach (var host in inventory.Hosts)
                        {
                            _gui.WriteLine(host.HostName);
                        }
                        return 0;
                    }
                    _gui.WriteError($"{inventory.Name} doesn't contain any hosts");
                    return 1;
                }
                catch (Exception e)
                {
                    _gui.WriteError($"Failed to list the hosts in {opts.Inventory}, does the inventory exist?");
                    return 1;
                }
            }
        }
    }
}

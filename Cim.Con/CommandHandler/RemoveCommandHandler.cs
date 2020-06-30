using Cim.Con.CommandOptions;
using Cim.Con.UI;
using Cim.Lib.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Threading.Tasks;

namespace Cim.Con.CommandHandler
{
    public class RemoveCommandHandler : ICommandHandler<RemoveOptions>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IGui _gui;
        public RemoveCommandHandler(IInventoryRepository inventoryRepository, IGui gui)
        {
            _inventoryRepository = inventoryRepository;
            _gui = gui;
        }
        public async Task<int> RunCommand(RemoveOptions opts)
        {
            try
            {
                var inventory = await _inventoryRepository.GetInventoryByNameAsync(opts.Inventory);
                foreach(var hostName in opts.Hosts)
                {
                    //Todo Optimize
                    if(inventory.Hosts.Any(n => n.HostName == hostName))
                    {
                        inventory.Hosts.RemoveAll(h => h.HostName == hostName);
                        _gui.WriteSuccess($"Removed { hostName } from { inventory.Name }");
                    }
                    else
                    {
                        _gui.WriteError($"Failed to remove { hostName } from { inventory.Name }");
                    }
                }
                await _inventoryRepository.UpdateInventoryAsync(inventory);
                return 0;
            }
            catch (Exception e)
            {
                // Inventory does not exist, write error
                _gui.WriteError($"Failed to remove the specified hosts from {opts.Inventory}, does the inventory exist?");
                return 1;
            }
        }
    }
}

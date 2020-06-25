using Cim.Con.CommandOptions;
using Cim.Con.UI;
using Cim.Lib.Data.Entities;
using Cim.Lib.Data.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cim.Con.CommandHandler
{
    // TODO Implement AddHandler
    public class AddCommandHandler : ICommandHandler<AddOptions>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IGui _gui;
        public AddCommandHandler(IInventoryRepository inventoryRepository, IGui gui)
        {
            _inventoryRepository = inventoryRepository;
            _gui = gui;
        }
        public int RunCommand(AddOptions opts)
        {
            try
            {
                var inventory =_inventoryRepository.GetInventoryByName(opts.Inventory);
                foreach(var hostName in opts.Hosts)
                {
                    inventory.Hosts.Add(new Host { HostName = hostName });
                }
                _inventoryRepository.UpdateInventory(inventory);
                return 0;
            }
            catch (Exception e)
            {
                _gui.WriteError($"Failed to add the specified hosts to {opts.Inventory}, does the inventory exist?");
                return 1;
            }
        }
    }
}

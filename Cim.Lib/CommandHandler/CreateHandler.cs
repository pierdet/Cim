using Cim.Lib.CommandOptions;
using Cim.Lib.Data.Repository;
using Cim.Lib.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.CommandHandler
{
    public class CreateHandler : ICreateHandler
    {
        IInventoryRepository _inventoryRepository;
        IGui _gui;
        public CreateHandler(IInventoryRepository inventoryRepository, IGui gui)
        {
            _inventoryRepository = inventoryRepository;
            _gui = gui;
        }
        
        public int RunCreateAndReturnExitCode(CreateOptions opts)
        {
            try
            {
                _inventoryRepository.AddInventory(opts.Inventory);
                _gui.WriteSuccess($"Created inventory {opts.Inventory}");
                return 0;
            }
            catch (Exception e)
            {
                _gui.WriteError($"Failed to create {opts.Inventory} - { e }");
                return 1;
            }
        }
    }
}

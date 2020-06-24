using Cim.Lib.CommandOptions;
using Cim.Lib.Data.Repository;
using Cim.Lib.UI;
using System;

namespace Cim.Lib.CommandHandler
{
    public class CreateCommandHandler : ICommandHandler<CreateOptions>
    {
        IInventoryRepository _inventoryRepository;
        IGui _gui;
        public CreateCommandHandler(IInventoryRepository inventoryRepository, IGui gui)
        {
            _inventoryRepository = inventoryRepository;
            _gui = gui;
        }
        
        public int RunCommand(CreateOptions opts)
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

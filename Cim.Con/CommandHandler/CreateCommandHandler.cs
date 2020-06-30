using Cim.Con.CommandOptions;
using Cim.Lib.Data.Repository;
using Cim.Con.UI;
using System;
using System.Threading.Tasks;

namespace Cim.Con.CommandHandler
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
        
        public async Task<int> RunCommand(CreateOptions opts)
        {
            try
            {
                await _inventoryRepository.AddInventoryAsync(opts.Inventory);
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

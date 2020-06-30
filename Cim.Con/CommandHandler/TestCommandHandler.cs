using Cim.Con.CommandOptions;
using Cim.Con.UI;
using Cim.Lib.Data.Repository;
using Cim.Lib.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cim.Con.CommandHandler
{
    public class TestCommandHandler : ICommandHandler<TestOptions>
    {
        // Todo Implement TestCommandHandler
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IGui _gui;
        private readonly IConnectionValidator _connectionValidator;
        public TestCommandHandler(IInventoryRepository inventoryRepository,
            IGui gui,
            IConnectionValidator connectionValidator)
        {
            _inventoryRepository = inventoryRepository;
            _gui = gui;
            _connectionValidator = connectionValidator;
        }
        public async Task<int> RunCommand(TestOptions opts)
        {
            try
            {
                var inventory = await _inventoryRepository.GetInventoryByNameAsync(opts.Inventory);
                if (inventory.Hosts.Count > 0)
                {
                    _gui.WriteLine($"Testing connection to hosts in {inventory.Name}:");
                    foreach (var host in inventory.Hosts)
                    {
                        var result = _connectionValidator.Validate(host.HostName);
                        if (result.Success)
                        {
                            _gui.WriteSuccess($"{host.HostName} is reachable");
                        }
                        else
                        {
                            _gui.WriteError($"{host.HostName} is not reachable: {result.ErrorMessage}");
                        }
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

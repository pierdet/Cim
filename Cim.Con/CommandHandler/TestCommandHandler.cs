using Cim.Con.CommandOptions;
using Cim.Con.UI;
using Cim.Lib.Data.Entities;
using Cim.Lib.Data.Repository;
using Cim.Lib.Net;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    var hostNames = new List<string>();
                    foreach (var host in inventory.Hosts)
                    {
                        hostNames.Add(host.HostName);
                    }
                    _gui.WriteLine($"Testing connection to hosts in {inventory.Name}:");
                    var results = await _connectionValidator.ValidateParallelAsync(hostNames);
                    foreach (var result in results)
                    {
                        if (result.Success)
                        {
                            _gui.WriteSuccess($"{ result.Connection } is reachable");
                        }
                        else
                        {
                            _gui.WriteError($"{ result.Connection } is not reachable - { result.ErrorMessage }");
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

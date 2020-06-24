using Cim.Lib.CommandOptions;
using Cim.Lib.Data.Repository;
using Cim.Lib.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.CommandHandler
{
    public class ListHandler : IListHandler
    {
        IInventoryRepository _inventoryRepository;
        IGui _gui;
        public ListHandler(IInventoryRepository inventoryRepository, IGui gui)
        {
            _inventoryRepository = inventoryRepository;
            _gui = gui;
        }
        public int RunListAndReturnExitCode(ListOptions opts)
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
                
                // TODO - Implement
                // inventory specified
                return 1;
            }
        }
    }
}

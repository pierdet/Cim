﻿using Cim.Con.CommandOptions;
using Cim.Con.UI;
using Cim.Lib.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Con.CommandHandler
{
    public class DeleteCommandHandler : ICommandHandler<DeleteOptions>
    {
        IInventoryRepository _inventoryRepository;
        IGui _gui;
        public DeleteCommandHandler(IInventoryRepository inventoryRepository, IGui gui)
        {
            _inventoryRepository = inventoryRepository;
            _gui = gui;
        }
        public int RunCommand(DeleteOptions opts)
        {
            try
            {
                _inventoryRepository.RemoveInventory(opts.Inventory);
                _gui.WriteSuccess($"Deleted inventory {opts.Inventory}");
                return 0;
            }
            catch (Exception e)
            {
                _gui.WriteError($"Failed to delete {opts.Inventory} - { e }");
                return 1;
            }
        }
    }
}

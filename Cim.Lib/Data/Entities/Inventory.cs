﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.Data.Entities
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public List<Host> Hosts { get; set; } = new List<Host>();
    }
}

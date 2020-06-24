using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.CommandOptions
{
    [Verb("list", HelpText = "List inventories")]
    public class ListOptions
    {
        [Option('i', "inventory-name", Required = false, HelpText = "Specify an inventory to list the hosts of")]
        public string Inventory { get; set; }
    }
}

using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Con.CommandOptions
{
    [Verb("remove", HelpText = "Remove hosts from an inventory")]
    public class RemoveOptions
    {
        [Option('i', "inventory-name", Required = true, HelpText = "Specify the inventory to remove the hosts from")]
        public string Inventory { get; set; }
        [Option('h', "host-name", Required = true, HelpText = "Specify the hosts remove from the inventory, separated by a space", Separator = ' ')]
        public IEnumerable<string> Hosts { get; set; }
    }
}

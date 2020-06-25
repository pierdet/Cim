using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Con.CommandOptions
{
    [Verb("test", HelpText = "Test network connection to hosts in inventories")]
    public class TestOptions
    {
        [Option('i', "inventory-name", Required = true, HelpText = "Specify the name of the inventory to test")]
        public string Inventory { get; set; }
    }
}

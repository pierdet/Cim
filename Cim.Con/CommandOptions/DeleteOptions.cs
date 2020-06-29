using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Con.CommandOptions
{
    [Verb("delete", HelpText = "Delete an inventory")]
    public class DeleteOptions
    {
        [Option('i', "inventory-name", Required = true, HelpText = "Specify the name of the inventory to delete")]
        public string Inventory { get; set; }
    }
}

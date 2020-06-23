using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.CommandOptions
{
    [Verb("list", HelpText = "Add hosts to an inventory")]
    public class ListOptions
    {
        [Option('i', "inventory", Required = true, HelpText = "Specify the inventory to list the hosts of")]
        public string Inventory { get; set; }
    }
}

using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.CommandOptions
{
    [Verb("add", HelpText = "Add hosts to an inventory")]
    public class AddOptions
    {
        [Option('i', "inventory-name", Required = true, HelpText = "Specify the inventory to add the host to")]
        public string Inventory { get; set; }
        [Option('h', "host-name", Required = true, HelpText = "Specify the hosts to add to the inventory")]
        public string[] Hosts { get; set; }
    }
}

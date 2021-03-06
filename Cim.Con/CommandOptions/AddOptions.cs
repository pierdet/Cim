﻿using CommandLine;
using System.Collections.Generic;

namespace Cim.Con.CommandOptions
{
    [Verb("add", HelpText = "Add hosts to an inventory")]
    public class AddOptions
    {
        [Option('i', "inventory-name", Required = true, HelpText = "Specify the inventory to add the host to")]
        public string Inventory { get; set; }
        [Option('h', "host-name", Required = true, HelpText = "Specify the hosts to add to the inventory, separated by a space", Separator = ' ')]
        public IEnumerable<string> Hosts { get; set; }
    }
}

using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.CommandOptions
{
    [Verb("add", HelpText = "Add hosts to an inventory")]
    public class AddOptions
    {
        [Option('i', "inventory", Required = true, HelpText = "Specify the inventory to add the host to")]
        public string Inventory { get; set; }
    }
}

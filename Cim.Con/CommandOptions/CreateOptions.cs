using CommandLine;

namespace Cim.Con.CommandOptions
{
    [Verb("create", HelpText = "Create a new inventory")]
    public class CreateOptions
    {
        [Option('i', "inventory-name", Required = true, HelpText = "Specify the name of the inventory to create")]
        public string Inventory { get; set; }
    }
}

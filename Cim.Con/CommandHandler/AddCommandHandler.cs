using Cim.Con.CommandOptions;
using System;

namespace Cim.Con.CommandHandler
{
    // TODO Implement AddHandler
    public class AddCommandHandler : ICommandHandler<AddOptions>
    {
        public int RunCommand(AddOptions opts)
        {
            Console.WriteLine(opts.Inventory);
            return 123;
        }
    }
}

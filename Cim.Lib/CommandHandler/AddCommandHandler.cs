using Cim.Lib.CommandOptions;
using System;

namespace Cim.Lib.CommandHandler
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

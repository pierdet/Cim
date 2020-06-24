using Cim.Lib.CommandOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.CommandHandler
{
    // TODO Implement AddHandler
    public class AddHandler : IAddHandler
    {
        public int RunAddAndReturnExitCode(AddOptions opts)
        {
            Console.WriteLine(opts.Inventory);
            return 123;
        }
    }
}

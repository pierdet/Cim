using Cim.Lib.CommandOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.CommandHandler
{
    public class ListHandler : IListHandler
    {
        public int RunListAndReturnExitCode(ListOptions opts)
        {
            Console.WriteLine(opts.Inventory);
            return 123;
        }
    }
}

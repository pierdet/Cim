using Cim.Lib.CommandOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.CommandHandler
{
    public interface ICreateHandler
    {
        int RunCreateAndReturnExitCode(CreateOptions opts);
    }
}

using Cim.Lib.CommandHandler;
using Cim.Lib.CommandOptions;
using CommandLine;
using System;
using System.Collections.Generic;

namespace Cim.Con
{
    class Program
    {
        static int Main(string[] args)
        {
            var addHandler = Factory.CreateAddHandler();
            var listHandler = Factory.CreateListHandler();
            return CommandLine.Parser.Default.ParseArguments<AddOptions, ListOptions>(args)
            .MapResult(
              (AddOptions opts) => addHandler.RunAddAndReturnExitCode(opts),
              (ListOptions opts) => listHandler.RunListAndReturnExitCode(opts),
              errs => 1);
        }
        
    }
}

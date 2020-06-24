using Cim.Lib.CommandOptions;
using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using Cim.Lib.CommandHandler;

namespace Cim.Con
{
    public class CimApplication : ICimApplication
    {
        IAddHandler _addHandler;
        IListHandler _listHandler;
        public CimApplication(IAddHandler addHandler, IListHandler listHandler)
        {
            _addHandler = addHandler;
            _listHandler = listHandler;
        }
        public void run(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<AddOptions, ListOptions>(args)
            .MapResult(
              (AddOptions opts) => _addHandler.RunAddAndReturnExitCode(opts),
              (ListOptions opts) => _listHandler.RunListAndReturnExitCode(opts),
              errs => 1);
        }
    }
}

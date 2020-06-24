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
        // Inject Verb handlers
        IAddHandler _addHandler;
        IListHandler _listHandler;
        ICreateHandler _createHandler;
        public CimApplication(IAddHandler addHandler, IListHandler listHandler, ICreateHandler createHandler)
        {
            _addHandler = addHandler;
            _listHandler = listHandler;
            _createHandler = createHandler;
        }
        public void run(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<AddOptions, ListOptions, CreateOptions>(args)
            .MapResult(
              (AddOptions opts) => _addHandler.RunAddAndReturnExitCode(opts),
              (ListOptions opts) => _listHandler.RunListAndReturnExitCode(opts),
              (CreateOptions opts) => _createHandler.RunCreateAndReturnExitCode(opts),
              errs => 1);
        }
    }
}

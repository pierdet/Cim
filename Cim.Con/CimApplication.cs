using Cim.Lib.CommandOptions;
using CommandLine;

namespace Cim.Con
{
    public class CimApplication : ICimApplication
    {
        private readonly CommandHandlerFactory _factory;

        // Inject Verb handlers
        public CimApplication(CommandHandlerFactory factory)
        {
            _factory = factory;
        }
        public void run(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<AddOptions, ListOptions, CreateOptions>(args)
            .MapResult(
              (dynamic opts) => _factory.Create(opts).RunCommand(opts),
                errs => decimal.MinusOne);
        }
    }
}

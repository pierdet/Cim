using Cim.Con.CommandHandler;
using Cim.Con.CommandOptions;
using CommandLine;
using System;
using System.Linq;
using System.Reflection;

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
            var types = LoadTypes();

            Parser.Default.ParseArguments(args, types)
            .MapResult(
              (dynamic opts) => _factory.Create(opts).RunCommand(opts),
                errs => decimal.MinusOne);
        }

        // Dynamically get all Types that implements the VerbAttribe, i.e. AddOptions, ListOptions etc.
        private static Type[] LoadTypes()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();
        }
    }
}

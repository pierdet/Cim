using Autofac;
using Cim.Lib.CommandHandler;

namespace Cim.Con
{
    public class CommandHandlerFactory
    {
        private readonly ILifetimeScope _scope;

        public CommandHandlerFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public ICommandHandler<TCommand> Create<TCommand>()
        {
            return _scope.Resolve<ICommandHandler<TCommand>>();
        }
        
        public ICommandHandler<TCommand> Create<TCommand>(TCommand command) 
        {
            return _scope.Resolve<ICommandHandler<TCommand>>();
        }
    }
}
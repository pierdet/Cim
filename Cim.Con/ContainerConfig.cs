using Autofac;
using Cim.Con.CommandHandler;
using Cim.Lib.Data;
using Cim.Lib.Data.Repository;
using Cim.Con.UI;
using Cim.Con.CommandOptions;

namespace Cim.Con
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AddCommandHandler>().As<ICommandHandler<AddOptions>>();
            builder.RegisterType<ListCommandHandler>().As<ICommandHandler<ListOptions>>();
            builder.RegisterType<CreateCommandHandler>().As<ICommandHandler<CreateOptions>>();

            builder.RegisterType<CommandHandlerFactory>().AsSelf();
            
            builder.RegisterType<CimApplication>().As<ICimApplication>();

            // TODO How to create an interface for InventoryContext?
            builder.RegisterType<InventoryContext>().AsSelf();
            builder.RegisterType<InventoryRepository>().As<IInventoryRepository>();

            builder.RegisterType<Gui>().As<IGui>();
            

            return builder.Build();
        }
    }
}

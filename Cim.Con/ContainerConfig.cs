using Autofac;
using Cim.Con.CommandHandler;
using Cim.Lib.Data;
using Cim.Lib.Data.Repository;
using Cim.Con.UI;
using Cim.Con.CommandOptions;
using Microsoft.Extensions.Caching.Memory;
using Cim.Lib.Net;
using Microsoft.Extensions.Configuration;
using System.Net.NetworkInformation;

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
            builder.RegisterType<TestCommandHandler>().As<ICommandHandler<TestOptions>>();
            builder.RegisterType<DeleteCommandHandler>().As<ICommandHandler<DeleteOptions>>();
            builder.RegisterType<RemoveCommandHandler>().As<ICommandHandler<RemoveOptions>>();

            builder.RegisterType<CommandHandlerFactory>().AsSelf();
            
            builder.RegisterType<CimApplication>().As<ICimApplication>();

            
            builder.RegisterType<InventoryContext>().AsSelf();
            builder.RegisterType<InventoryRepository>().As<IInventoryRepository>();
            builder.RegisterType<ConnectionValidator>().As<IConnectionValidator>();
            builder.RegisterType<Ping>().InstancePerRequest().AsSelf();

            builder.RegisterType<Gui>().As<IGui>();
            

            return builder.Build();
        }
    }
}

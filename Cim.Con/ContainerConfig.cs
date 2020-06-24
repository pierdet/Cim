using Autofac;
using Cim.Lib.CommandHandler;
using Cim.Lib.Data;
using Cim.Lib.Data.Repository;
using Cim.Lib.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Con
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AddHandler>().As<IAddHandler>();
            builder.RegisterType<ListHandler>().As<IListHandler>();
            builder.RegisterType<CreateHandler>().As<ICreateHandler>();
            
            builder.RegisterType<CimApplication>().As<ICimApplication>();

            //TODO How to create an interface for InventoryContext?
            builder.RegisterType<InventoryContext>().AsSelf();
            builder.RegisterType<InventoryRepository>().As<IInventoryRepository>();

            builder.RegisterType<Gui>().As<IGui>();
            

            return builder.Build();
        }
    }
}

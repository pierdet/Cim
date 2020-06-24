using Autofac;
using Cim.Lib.CommandHandler;
using Cim.Lib.Data;
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
            builder.RegisterType<CimApplication>().As<ICimApplication>();
            builder.RegisterType<InventoryContext>().As<DbContext>();

            return builder.Build();
        }
    }
}

using Autofac;
using Cim.Lib.CommandHandler;
using Cim.Lib.CommandOptions;
using Cim.Lib.Data;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Cim.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure DI
            var container = ContainerConfig.Configure();
            using(var scope = container.BeginLifetimeScope())
            {
                // ensure DB exists
                using(var db = scope.Resolve<InventoryContext>())
                {
                    db.Database.EnsureCreated();
                }
                // request an instance of ICimApplication and run it
                var app = scope.Resolve<ICimApplication>();
                app.run(args);
            }
        }
        
    }
}

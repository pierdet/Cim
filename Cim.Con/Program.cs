using Autofac;
using Cim.Lib.CommandHandler;
using Cim.Lib.CommandOptions;
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
            var container = ContainerConfig.Configure();
            using(var scope = container.BeginLifetimeScope())
            {
                using(var db = scope.Resolve<DbContext>())
                {
                    db.Database.EnsureCreated();
                }
                var app = scope.Resolve<ICimApplication>();
                app.run(args);
            }
        }
        
    }
}

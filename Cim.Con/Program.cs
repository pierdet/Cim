using Autofac;
using Cim.Lib.Data;
using System.Threading.Tasks;

namespace Cim.Con
{
    class Program
    {
        static async Task Main(string[] args)
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
                await app.run(args);
            }
            
        }
        
    }
}

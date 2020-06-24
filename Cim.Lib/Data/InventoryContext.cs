using Cim.Lib.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cim.Lib.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext()
        {

        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Host> Hosts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbPath = Path.Combine(Environment.CurrentDirectory, "cim.db");
            options.UseSqlite("Data Source = " + dbPath);
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Inventory>(inventory =>
            {
                inventory.HasKey(i => i.InventoryId);
            });

            builder.Entity<Host>(host =>
            {
                host.HasKey(h => h.HostId);

                host.HasOne(h => h.Inventory)
                    .WithMany(i => i.Hosts)
                    .HasForeignKey(h => h.InventoryId);
            });
        }
    }
}   

    

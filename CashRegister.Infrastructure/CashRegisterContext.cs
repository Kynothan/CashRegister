using CashRegister.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Infrastructure
{
    public class CashRegisterContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockMovement> StockMovement { get; set; }
        public DbSet<Tax> Tax { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        public string DbPath { get; }

        public CashRegisterContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "cashRegister.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.LogTo(Console.WriteLine);
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}

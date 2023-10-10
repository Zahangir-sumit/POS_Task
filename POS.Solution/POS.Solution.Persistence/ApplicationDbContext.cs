using Microsoft.EntityFrameworkCore;
using POS.Solution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Solution.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid() ,ProductName = "IPhone15", Price = 150000 },
                new Product { Id = Guid.NewGuid(), ProductName = "Xiaomi Note 10 pro", Price = 25000 },
                new Product { Id = Guid.NewGuid(), ProductName = "Samsung S20 Ultra", Price = 120000 },
                new Product { Id = Guid.NewGuid(), ProductName = "Oneplus 8 pro", Price = 80000 },
                new Product { Id = Guid.NewGuid(), ProductName = "Oneplus 8 T", Price = 75000 },
                new Product { Id = Guid.NewGuid(), ProductName = "Huawei Mate 40", Price = 100000 },
                new Product { Id = Guid.NewGuid(), ProductName = "Moto M3", Price = 75000 }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}

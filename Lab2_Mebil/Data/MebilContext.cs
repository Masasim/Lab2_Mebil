namespace Lab2_Mebil.Data
{
    using Lab2_Mebil.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    public class MebilContext : DbContext
    {
        public MebilContext(DbContextOptions<MebilContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<FurnitureInWarehouse> FurnitureInWarehouses { get; set; }
        public DbSet<FurnitureInOrder> FurnitureInOrders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.id);
            modelBuilder.Entity<Warehouse>().HasKey(w => w.id);
            modelBuilder.Entity<Factory>().HasKey(f => f.id);
            modelBuilder.Entity<Order>().HasKey(o => o.id);
            modelBuilder.Entity<Furniture>().HasKey(f => f.id);
            modelBuilder.Entity<Invoice>().HasKey(i => i.id);

            //If any entities are keyless, uncomment the lines below
            modelBuilder.Entity<FurnitureInOrder>().HasNoKey();
            modelBuilder.Entity<FurnitureInWarehouse>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}

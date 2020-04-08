﻿using SportsStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

namespace SportsStore.Data
{
    public class StoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<ImportOrder> ImportOrders { get; set; }
        public DbSet<ImportedProduct> ImportedProducts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderedProduct>().ToTable("OrderedProduct");
            modelBuilder.Entity<ImportOrder>().ToTable("ImportOrder");
            modelBuilder.Entity<ImportedProduct>().ToTable("ImportedProduct");

            modelBuilder.Entity<OrderedProduct>()
                .HasKey(op => new { op.OrderID, op.ProductID });

            modelBuilder.Entity<OrderedProduct>()
                .HasOne<Order>(op => op.Order)
                .WithMany(o => o.OrderedProducts)
                .HasForeignKey(op => op.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderedProduct>()
                .HasOne<Product>(op => op.Product)
                .WithMany(p => p.OrderedProducts)
                .HasForeignKey(op => op.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                .HasForeignKey(c => c.CustomerID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
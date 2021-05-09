using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Database=CustomerDb;Integrated Security=SSPI;ConnectRetryCount=0");
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Category>().HasData(
            //    new Category
            //    {
            //        CategoryId = 1,
            //        CategoryName = "Basic",
            //    },

            //    new Category()
            //    {
            //        CategoryId = 2,
            //        CategoryName = "Moderate",
            //    },
            //    new Category()
            //    {
            //        CategoryId = 3,
            //        CategoryName = "Advanced"
            //    }, 
            //    new Category()
            //    {
            //        CategoryId = 4,
            //        CategoryName = "SuperAdvanced",

            //    });

           
            //modelBuilder.Entity<Customer>().HasData(
            //     new Customer()
            //     {
            //         Id = 1,
            //         CustomerName = "John Conner",
            //         PhoneNumber = "70588270240",
            //         CityName = "Pune",
            //         PrimaryContact = "Linda Conner",
            //         CategoryId = 1
            //     },

            //    new Customer()
            //    {
            //        Id = 2,
            //        CustomerName = "Jane Conner",
            //        PhoneNumber = "70588270241",
            //        CityName = "Mumbai",
            //        PrimaryContact = "Jeff Conner",
            //        CategoryId = 2
            //    },
            //       new Customer()
            //       {
            //           Id = 3,
            //           CustomerName = "Jamie Kirby",
            //           PhoneNumber = "70588270244",
            //           CityName = "Mumbai",
            //           PrimaryContact = "Linda Connor",
            //           CategoryId = 3
            //       },
            //     new Customer()
            //     {
            //         Id = 4,
            //         CustomerName = "Josh Donald",
            //         PhoneNumber = "70588270242",
            //         CityName = "Lucknow",
            //         PrimaryContact = "Milinda Donald",
            //         CategoryId = 4
            //     },
            //     new Customer()
            //     {
            //         Id = 5,
            //         CustomerName = "Joshua Krane",
            //         PhoneNumber = "70588270243",
            //         CityName = "Aurangabad",
            //         PrimaryContact = "Mary Krane",
            //         CategoryId = 1
            //     });
            //modelBuilder.Entity<Customer>(
            //  entity =>
            //  {
            //      entity.HasOne(d => d.Category)
            //          .WithMany()
            //          .HasForeignKey("CategoryId");
            //  });


        }
    }
}

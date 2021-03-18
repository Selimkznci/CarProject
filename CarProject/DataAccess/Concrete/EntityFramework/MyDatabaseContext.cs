using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class MyDatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Rental;Trusted_Connection=True")); 
        }
        public DbSet<Car> cars { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Rental> Rentals { get; set; }
    }
}

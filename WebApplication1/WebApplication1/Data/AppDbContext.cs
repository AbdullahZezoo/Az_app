using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(string connectionString) : base()
        {
            
        }
        public IDbSet<User> users { get; set; }
        public IDbSet<Customer> customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Customer>().ToTable("customers");
        }

    }
}

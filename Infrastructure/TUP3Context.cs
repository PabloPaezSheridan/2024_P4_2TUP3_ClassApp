using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TUP3Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<Product> Products { get; set; }

        public TUP3Context(DbContextOptions<TUP3Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

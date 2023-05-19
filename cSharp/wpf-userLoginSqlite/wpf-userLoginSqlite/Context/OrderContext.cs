using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_userLoginSqlite.Models;

namespace wpf_userLoginSqlite.Context
{
  public class OrderContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source = DataOrder.db");
    }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set;} = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<OrderDetail> orderDetails { get; set; } = null!;
  }
}

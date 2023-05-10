using Microsoft.EntityFrameworkCore;
using PrismBlankApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismBlankApp.DataContext
{
  public class UserDataContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source = UserFile.db");
    }

    public DbSet<User> Users { get; set; }
  }
}

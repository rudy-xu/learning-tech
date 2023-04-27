using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_userLoginSqlite
{
    public class UserDataContext:DbContext
    {

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source = DataFile.db");
    }

    public DbSet<User> Users { get; set; }

  }
}

using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using wpf_userLoginSqlite.Context;
using wpf_userLoginSqlite.Helper;
using wpf_userLoginSqlite.Models;

namespace wpf_userLoginSqlite
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      string lang = System.Globalization.CultureInfo.CurrentCulture.Name;
      if (lang == Common.LanguageTypes[LanguageEnum.en_us])
      {
        LanguageHelper.ChangeLanguage(LanguageEnum.en_us);
      }

      //DatabaseFacade facade = new DatabaseFacade(new UserDataContext());
      //facade.EnsureCreated();

      using (OrderContext context = new OrderContext())
      {
        Product veggieSpecial = new Product()
        {
          Name = "Veggie Product",
          Price = 12.99M
        };

        context.Products.Add(veggieSpecial);

        context.SaveChanges();
      }
    }
  }
}


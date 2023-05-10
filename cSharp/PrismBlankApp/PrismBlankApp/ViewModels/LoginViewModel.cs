using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using PrismBlankApp.DataContext;
using PrismBlankApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismBlankApp.ViewModels
{
  public class LoginViewModel : BindableBase
  {
    private string _account;
    private string _password;

    public string Account
    {
      get { return _account; }
      set { _account = value; }
    }
    public string Password
    {
      get { return _password; }
      set { _password = value; }
    }

    public DelegateCommand<object> LoginCommand { get; private set; }

    public LoginViewModel()
    {
      LoginCommand = new DelegateCommand<object>(Login);
    }

    private void Login(object obj)
    {
      
      var userName = _account;
      var password = _password;

      using (UserDataContext context = new UserDataContext())
      {
        bool isExisted = context.Users.Any(user => user.Name == userName && user.Password == password);

        if (isExisted)
        {
          (obj as Window).DialogResult = true;
        }
        else
        {
          MessageBox.Show("User Not Found");
        }
      }
    }
  }
}

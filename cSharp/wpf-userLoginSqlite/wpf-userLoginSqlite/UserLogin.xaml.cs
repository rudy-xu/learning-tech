using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpf_userLoginSqlite
{
  /// <summary>
  /// Interaction logic for UserLogin.xaml
  /// </summary>
  public partial class UserLogin : Window
  {
    public UserLogin()
    {
      InitializeComponent();
    }

    private void Submit_Click(object sender, RoutedEventArgs e)
    {
      var userName = account.Text;
      var password = pwd.Text;

      using (UserDataContext context = new UserDataContext())
      {
        bool isExisted = context.Users.Any(user => user.Name == userName && user.Password == password);

        if (isExisted) {
          GrantAccess();
          Close();
        } else {
          MessageBox.Show("User Not Found");
        }
      }
    }

    public void GrantAccess()
    {
     MainPage mainPage = new MainPage();
      mainPage.Show();
    }
  }
}

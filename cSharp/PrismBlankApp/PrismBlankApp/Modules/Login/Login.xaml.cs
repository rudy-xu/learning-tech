using PrismBlankApp.Modules.ViewB;
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

namespace PrismBlankApp.Views
{
  /// <summary>
  /// Interaction logic for Login.xaml
  /// </summary>
  public partial class Login : Window
  {
    public Login()
    {
      /**
       * LoadComponent
       * 加载 xaml 文件并将其转换为由 XAML 文件的根元素指定的对象的实例, 并未渲染窗口
       * 猜测应由些监听进程去监听并渲染转换后的实例
       */
      InitializeComponent();
      //this.DataContext = new LoginViewModel();
    }

        //private void testLogin(object sender, RoutedEventArgs e)
        //{
        //  this.DialogResult = true;
        //}
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace example01
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void ButtonAddName_Click(object sender, RoutedEventArgs e)
    {
      if (!string.IsNullOrWhiteSpace(txtName.Text) && !lastNames.Items.Contains(txtName.Text))
      {
        lastNames.Items.Add(txtName.Text);
        txtName.Clear();
      }
    }

    private void OnKeyDownHandler(Object sender, KeyEventArgs e) {
      if (e.Key == Key.Return) {
        lastNames.Items.Add(txtName.Text);
        txtName.Clear();
      }
    }
  }
}

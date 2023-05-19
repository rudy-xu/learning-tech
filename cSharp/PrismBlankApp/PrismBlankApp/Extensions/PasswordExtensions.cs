using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismBlankApp.Extensions
{
  public class PasswordExtensions
  {
    public static string GetPassword(DependencyObject obj)
    {
      return (string)obj.GetValue(PasswordProperty);
    }

    public static void SetPassword(DependencyObject obj, string value)
    {
      obj.SetValue(PasswordProperty, value);
    }

    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordExtensions), new PropertyMetadata(string.Empty, OnPasswordPropertyChanged));

    static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
      var passwordBox = sender as PasswordBox;
      string pwd = (string)e.NewValue;
      if (passwordBox != null && passwordBox.Password != pwd)
      {
        passwordBox.Password = pwd;
      }
    }
  }

  public class PasswordBehavior : Behavior<PasswordBox>
  {
    protected override void OnAttached()
    {
      base.OnAttached();
      AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
    }

    private void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
    {
      PasswordBox passwordBox = sender as PasswordBox;
      string pwd = PasswordExtensions.GetPassword(passwordBox);
      if (passwordBox != null && passwordBox.Password != pwd)
      {
        PasswordExtensions.SetPassword(passwordBox, passwordBox.Password);
      }
    }

    protected override void OnDetaching()
    {
      base.OnDetaching();
      AssociatedObject.PasswordChanged -= AssociatedObject_PasswordChanged;
    }
  }
}

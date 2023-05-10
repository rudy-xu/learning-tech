using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismBlankApp.ViewModels
{
  /**
   * 导航到此页面，如何接收参数
   *  - 需要继承 INavigationAware 并重写相关函数
   * 
   * 拦截请求的话
   *  - 需要继承 IConfirmNavigationRequest 并重写相关函数
   *  - IConfirmNavigationRequest 接口也已经继承了 INavigationAware (导航相关的)
   */
  public class ViewBViewModel : BindableBase, IConfirmNavigationRequest
  {
    public ViewBViewModel()
    {
    }


    private string _title;
    public string Title
    {
      get { return _title; }
      set { _title = value; RaisePropertyChanged(); }
    }

    /**
     * 每次导航进入的时候是否重用之前的实例
     * true - 重用，不用重新构造实例(不会再次进入构造函数)
     * false - 不重用，重新调用构造函数，重新渲染
     */
    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
      return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {

    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
      if (navigationContext.Parameters.ContainsKey("content"))
        Title = navigationContext.Parameters.GetValue<string>("content");
    }

    /**
     * 路由跳出去前的确认
     */
    void IConfirmNavigationRequest.ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
    {
      bool result = true;

      if (MessageBox.Show("Are you sure navigate?", "Kind tips", MessageBoxButton.YesNo) == MessageBoxResult.No)
      {
        result = false;
      }

      /**
       * true - 跳转
       * false - 不跳转
       */
      continuationCallback(result);
    }
  }
}

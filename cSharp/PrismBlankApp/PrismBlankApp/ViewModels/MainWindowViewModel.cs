using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows.Media.Animation;

namespace PrismBlankApp.ViewModels
{
  public class MainWindowViewModel : BindableBase
  {
    /**
     * 用于管理当前窗口可用的区域
     */
    private readonly IRegionManager regionManager;

    /**
     * 导航日志
     * 记录当前系统的路由情况
     * 可以用于前进后退等功能
     */
    private IRegionNavigationJournal journal;


    /**
     * 对话服务
     * 弹窗(Dialog)
     */
    private readonly IDialogService _dialogService;


    /**
     * 委托命令绑定
     * 绑定业务和UI
     */
    public DelegateCommand<string> OpenCommand { get; private set; }
    public DelegateCommand BackCommand { get; private set; }
    public DelegateCommand<string> ShowCommand { get; private set; }


    private string _title = "Prism Application";
    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
    {
      /**
       * 管理 Dialog
       */
      ShowCommand = new DelegateCommand<string>(OpenDialog);
      this._dialogService = dialogService;


      /**
       * 管理已经定义的所有区域
       */
      OpenCommand = new DelegateCommand<string>(Open);
      BackCommand = new DelegateCommand(Back);
      this.regionManager = regionManager;
    }

    private void Back()
    {
      if(journal.CanGoBack) journal.GoBack();
    }

    public void OpenDialog(string obj)
    {
      DialogParameters dialogParameters = new DialogParameters
      {
        { "Title", "Test Dialog" }
      };
      _dialogService.ShowDialog(obj, dialogParameters, callback =>
      {
        /**
         * 回调是指：当用户点击取消或者确认的时候传回的参数
         */
        if (callback.Result == ButtonResult.OK)
        {
          string result = callback.Parameters.GetValue<string>("Value");
        }
      });
    }

    public void Open(string obj)
    {
      /**
       * 导航传参
       */
      NavigationParameters keys = new NavigationParameters
      {
        { "content", "Test navigation function" }
      };

      /**
       * 如何实现动态绑定的 OpenCommand 命令，打开各个区域展示相关页面/组件
       *  - 首先通过 IRegionManager 接口获取全局定义的可用区域
       *  - 向此区域动态设置内容
       *  - 设置的方式是
       *    - 依赖注入形式 (在 app.xaml.cs 注入)
       *    - ViewModel 中绑定设置 Command (MainWindowViewModel.cs 中实现)
       *  - 类似于路由跳转到另一个页面，同时可以传一些参数
       */
      regionManager.Regions["ContentRegion"].RequestNavigate(obj, callBack =>
      {
        if((bool)callBack.Result)
        {
          /**
           * 上下文有个 NavigationService(导航服务)
           * 会存储每次的导航记录 / 日志
           */
          journal = callBack.Context.NavigationService.Journal;
        }
      },keys);
    }
  }
}

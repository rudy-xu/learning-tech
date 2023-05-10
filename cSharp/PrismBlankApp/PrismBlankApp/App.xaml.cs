//using ModuleWPFTutorialApp;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Prism.Ioc;
using Prism.Modularity;
using PrismBlankApp.DataContext;
using PrismBlankApp.ViewModels;
using PrismBlankApp.Views;
using System.Windows;

namespace PrismBlankApp
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App
  {
    // ==================== 初始化窗口程序
    protected override Window CreateShell()
    {
      // DB init
      DatabaseFacade facade = new DatabaseFacade(new UserDataContext());
      facade.EnsureCreated();

      // 通过 IoC 容器获取主窗口
      return Container.Resolve<MainWindow>();

      // 调用窗口构造函数
      //return Container.Resolve<Login>();
    }
    // 函数结束之后自动调用了 LoginViewModel的无参构造函数  -- 从而使得命令绑定生效

    protected override void InitializeShell(Window shell)
    {
      // 初始化之前的拦截
      if (Container.Resolve<Login>().ShowDialog() == false)
      {
        Application.Current?.Shutdown();
      }
      else
      {
        base.InitializeShell(shell);
      }
    }

    // ===================== 依赖注入
    /**
     * 如何实现动态绑定的 OpenCommand 命令，打开各个区域展示相关页面/组件
     *  - 首先通过 IRegionManager 接口获取全局定义的可用区域
     *  - 向此区域动态设置内容
     *  - 设置的方式是
     *    - 依赖注入形式 (在 app.xaml.cs 注入)
     *    - ViewModel 中绑定设置 Command (MainWindowViewModel.cs 中实现)
     *  - 类似于路由跳转到另一个页面，同时可以传一些参数
     */
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // 注册
      containerRegistry.RegisterForNavigation<ViewA>("CutomeName_View");
      containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
      containerRegistry.RegisterForNavigation<ViewC>();
    }

    //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    //{
    //  moduleCatalog.AddModule<ModuleWPFTutorialAppProfile>();
    //  base.ConfigureModuleCatalog(moduleCatalog);
    //}

    protected override IModuleCatalog CreateModuleCatalog()
    {
      return new ConfigurationModuleCatalog();
    }
  }
}

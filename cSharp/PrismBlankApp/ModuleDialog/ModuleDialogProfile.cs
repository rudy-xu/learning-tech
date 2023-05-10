using ModuleDialog.ViewModels;
using ModuleDialog.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDialog
{
  public class ModuleDialogProfile : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // 依赖注入 -- RegisterDialog
      // 绑定上下文关系 <MyDialog, MyDialogViewModel>
      containerRegistry.RegisterDialog<MyDialog, MyDialogViewModel>();
    }
  }
}

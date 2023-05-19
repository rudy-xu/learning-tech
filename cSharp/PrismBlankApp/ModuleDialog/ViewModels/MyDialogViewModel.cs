using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDialog.ViewModels
{
  public class MyDialogViewModel : IDialogAware
  {
    public DelegateCommand CancelCommand { get; set; }
    public DelegateCommand OkCommand { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public event Action<IDialogResult> RequestClose;

    public MyDialogViewModel()
    {
      CancelCommand = new DelegateCommand(Cancel);
      OkCommand = new DelegateCommand(Save);
    }
    private void Save()
    {
      RequestClose?.Invoke(new DialogResult(ButtonResult.No));
    }
    private void Cancel()
    {
      OnDialogClosed();
    }

    public bool CanCloseDialog()
    {
      return true;
    }

    public void OnDialogClosed()
    {
      DialogParameters dialogParameters = new DialogParameters
      {
        /**
         * 这个参数会在用户点击取消按钮时候传回
         */
        { "Value", "Hello ~"}
      };

      RequestClose?.Invoke(new DialogResult(ButtonResult.OK, dialogParameters));
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
      Title = parameters.GetValue<string>("Title");
      Content = parameters.GetValue<string>("Content");
    }
  }
}

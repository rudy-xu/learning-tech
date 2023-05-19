using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace ModuleWPFTutorialApp.ViewModels
{
  public class ModuleAppViewModel : BindableBase
  {
    private string _txtName;
    private ObservableCollection<string> _nameList = new ObservableCollection<string>();
    public string TxtName
    {
      get { return _txtName; }
      set { SetProperty(ref _txtName, value); }
    }

    public ObservableCollection<string> NameList
    {
      get { return _nameList; }
      set { SetProperty(ref _nameList, value); }
    }
    public DelegateCommand AddCommand { get; private set; }
    public DelegateCommand KeyDownCommand { get; private set; }

    public ModuleAppViewModel()
    {
      AddCommand = new DelegateCommand(addName);
      KeyDownCommand = new DelegateCommand(OnKeyDownHandler);
    }

    public void addName()
    {
      if (!string.IsNullOrWhiteSpace(TxtName) && !NameList.Contains(TxtName))
      {
        NameList.Add(TxtName);
        TxtName = "";
      }
    }

    public void OnKeyDownHandler()
    {
      NameList.Add(TxtName);
      TxtName = "";
    }
  }
}

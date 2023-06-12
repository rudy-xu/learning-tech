using PrismBlankApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PrismBlankApp.Helpers
{
  public class LanguageHelper
  {

    private static Enum _language = LanguageEnum.zh_cn;

    public static Enum Language
    {
      get { return _language; }
      set { _language = value; }
    }

    private static readonly string _lanResoursePrefix = "pack://application:,,,/PrismBlankApp;component/Resources/Languages";
    private static readonly Dictionary<Enum, ResourceDictionary> _languageResource = new Dictionary<Enum, ResourceDictionary>()
    {
      { LanguageEnum.en_us, new ResourceDictionary() { Source = new Uri($"{_lanResoursePrefix}/en-us.xaml") } },
      { LanguageEnum.zh_cn, new ResourceDictionary() { Source = new Uri($"{_lanResoursePrefix}/zh-cn.xaml") } }
    };

    public static void ChangeLanguage(Enum language)
    {
      Application.Current.Resources.MergedDictionaries.Add(_languageResource[language]);
      _language = language;
    }
  }
}

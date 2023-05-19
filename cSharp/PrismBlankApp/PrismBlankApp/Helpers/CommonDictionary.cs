using PrismBlankApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismBlankApp.Helpers
{
  public class Common
  {
    public static readonly Dictionary<Enum, string> LanguageTypes = new Dictionary<Enum, string>()
    {
      { LanguageEnum.en_us, "en-US"},
      { LanguageEnum.zh_cn, "zh-CN"}
    };
  }
}

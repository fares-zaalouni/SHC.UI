using Microsoft.UI.Xaml.Controls;
using SHC.UI.WinUI.MVVM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Windows.Interfaces;

public interface INavigationConfigurator
{
    void RegisterFrame(string key, Frame frame);
    void RegisterPage(PageKey pageKey, string frameKey, Type pageType);
}

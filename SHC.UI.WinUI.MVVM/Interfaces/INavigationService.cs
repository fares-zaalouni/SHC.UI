using SHC.UI.WinUI.MVVM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.WinUI.MVVM.Interfaces;

public interface INavigationService
{
    void Navigate(PageKey pageKey, object parameter = null);
    public void GoBack(PageKey pageKey);
}

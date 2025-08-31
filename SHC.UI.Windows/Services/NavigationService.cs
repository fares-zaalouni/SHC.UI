using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using SHC.UI.Windows.Interfaces;
using SHC.UI.WinUI.MVVM.Common;
using SHC.UI.WinUI.MVVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SHC.UI.Windows.Services;

public class NavigationService : INavigationService, INavigationConfigurator
{
    private readonly Dictionary<string, Frame> _frames = new Dictionary<string, Frame>();
    private readonly Dictionary<PageKey, (string, Type)> _pages = new Dictionary<PageKey, (string, Type)>();
    

    public NavigationService()
    {
    }

   
    public void RegisterFrame(string key, Frame frame)
    {
        _frames[key] = frame;
    }

    public void RegisterPage(PageKey pageKey, string frameKey, Type pageType)
    {
        if (_frames.TryGetValue(frameKey, out _))
        {
            _pages[pageKey] = (frameKey, pageType);
        }
        else
        {
            throw new ArgumentException($"Frame with key '{frameKey}' not found.");
        }
    }

    private Frame GetFrameForPage(PageKey pageKey)
    {
        if (!_pages.TryGetValue(pageKey, out var page))
            throw new ArgumentException($"Page with key '{pageKey}' not found.");
        if (!_frames.TryGetValue(page.Item1, out var frame))
            throw new ArgumentException($"Frame with key '{page.Item1}' not found.");
        return frame;
    }
    public  void Navigate(PageKey pageKey, object parameter = null)
    {
        var frame = GetFrameForPage(pageKey);
        frame.Navigate(_pages[pageKey].Item2, parameter);
    }

    public void GoBack(PageKey pageKey)
    {
        var frame = GetFrameForPage(pageKey);
        frame.GoBack();
    }
   /* public void SetTheme(ElementTheme theme)
    {
        if (CurrentTheme == theme) return;
        if (CurrentFrame == null)
            throw new Exception("Current Frame not set");
        CurrentFrame.RequestedTheme = theme;
        CurrentTheme = theme;
    }*/

}

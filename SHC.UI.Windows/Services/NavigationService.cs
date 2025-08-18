using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using SHC.UI.WinUI.MVVM.Common;
using SHC.UI.WinUI.MVVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Windows.Services;

public class NavigationService : INavigationService
{
    private static NavigationService _instance;
    private readonly Dictionary<string, Frame> _frames = new Dictionary<string, Frame>();
    private static readonly Dictionary<PageKey, (string, Type)> _pages = new Dictionary<PageKey, (string, Type)>();
    
    public ElementTheme CurrentTheme { get; private set; } = ElementTheme.Light;
    public Frame CurrentFrame { get; private set; }

    private NavigationService()
    {
        // Private constructor to prevent instantiation
    }

    public static NavigationService GetInstance()
    {
        if (_instance == null)
        {
            _instance = new NavigationService();
        }
        return _instance;
    }
    public void RegisterFrame(string key, Frame frame)
    {
        _frames[key] = frame;
    }

    public void RegisterPage(PageKey pageKey, string frameKey, Type pageType)
    {
        if (_frames.TryGetValue(frameKey, out Frame frame))
        {
            _pages[pageKey] = (frameKey, pageType);
        }
        else
        {
            throw new ArgumentException($"Frame with key '{frameKey}' not found.");
        }
    }

    public  void Navigate(PageKey pageKey, object parameter = null)
    {

        if (_pages.TryGetValue(pageKey, out (string, Type) page))
        {
            if(_frames.TryGetValue(page.Item1, out Frame frame))
            {
                frame.Navigate(page.Item2, parameter);
            }
            else
            {
                throw new ArgumentException($"Frame with key '{page.Item1}' not found.");
            }

        }
        else
        {
            throw new ArgumentException($"Page with key '{pageKey}' not found.");
        }
    }

    public void GoBack(PageKey pageKey)
    {
        if (_pages.TryGetValue(pageKey, out (string, Type) page))
        {
            if (_frames.TryGetValue(page.Item1, out Frame frame))
            {
                frame.GoBack();
            }
            else
            {
                throw new ArgumentException($"Frame with key '{page.Item1}' not found.");
            }

        }
        else
        {
            throw new ArgumentException($"Page with key '{pageKey}' not found.");
        }
    }
    public void SetTheme(ElementTheme theme)
    {
        if (CurrentTheme == theme) return;
        if (CurrentFrame == null)
            throw new Exception("Current Frame not set");
        CurrentFrame.RequestedTheme = theme;
        CurrentTheme = theme;
    }

}

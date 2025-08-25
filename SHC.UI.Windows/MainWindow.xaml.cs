using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SHC.UI.Shared.Settings;
using SHC.UI.Windows.Interfaces;
using SHC.UI.Windows.Pages;
using SHC.UI.Windows.Services;
using SHC.UI.WinUI.MVVM.Common;
using SHC.UI.WinUI.MVVM.Interfaces;
using SHC.UI.WinUI.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SHC.UI.Windows
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        MainViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();


            ViewModel = App.Services.GetRequiredService<MainViewModel>();
            RegisterFrameAndPages();
            InitSettings();
        }

        private void RegisterFrameAndPages()
        {
            var NavigationService = App.Services.GetRequiredService<INavigationConfigurator>();
            NavigationService.RegisterFrame("MainFrame", MainFrame);
            NavigationService.RegisterPage(PageKey.Login, "MainFrame", typeof(LoginPage));
            NavigationService.RegisterPage(PageKey.Content, "MainFrame", typeof(ContentPage));
        }

        private void InitSettings()
        {
            var settingsManager = App.Services.GetRequiredService<ILocalSettingsManager>();
            LocalSettings? localSettings = settingsManager.GetSettings();
            if(localSettings == null)
            {
                localSettings = settingsManager.DefaultSettings();
                settingsManager.SaveSettings(localSettings);
            }
        }
    }

}

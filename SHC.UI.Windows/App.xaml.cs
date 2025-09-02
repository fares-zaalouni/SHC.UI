using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using SHC.UI.Shared.Common;
using SHC.UI.Shared.Security;
using SHC.UI.Shared.Services;
using SHC.UI.Shared.Session;
using SHC.UI.Shared.Settings;
using SHC.UI.Windows.Interfaces;
using SHC.UI.Windows.Pages;
using SHC.UI.Windows.Security;
using SHC.UI.Windows.Services;
using SHC.UI.Windows.Settings;
using SHC.UI.WinUI.MVVM.Interfaces;
using SHC.UI.WinUI.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SHC.UI.Windows
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private Window? _window;
        public static IServiceProvider Services { get; private set; }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            var services = new ServiceCollection();

            services.AddSingleton<HttpClient>(sp =>
            {
                return new HttpClient
                {
                    BaseAddress = new Uri(ConfigProvider.ApiSettings.BaseUrl)
                };
            });

            // Register services that depend on it
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<UserService>();
            services.AddTransient<IPatientService, PatientService>();


            //Security
            services.AddTransient<IAuthenticatedApiClient, AuthenticatedApiClient>();



            // Credential Storage
            services.AddTransient<ICredentialStorage, CredentialStorage>();


            // One Singleton for bot page registration and navigation
            services.AddSingleton<NavigationService>();
            services.AddSingleton<INavigationService>(sp => sp.GetRequiredService<NavigationService>());
            services.AddSingleton<INavigationConfigurator>(sp => sp.GetRequiredService<NavigationService>());

            //Settings Service
            services.AddTransient<ILocalSettingsManager, LocalSettingsManager>();


            // Session Management
            services.AddSingleton<ISessionManager, SessionManager>();


            // Register VMs
            services.AddTransient<MainViewModel>();
            services.AddTransient<LoginPageViewModel>();
            services.AddTransient<ContentPageViewModel>();
            services.AddTransient<RegisterPatientViewModel>();
            services.AddTransient<PatientEssentialInfoViewModel>();
            services.AddTransient<PatientOptionalInfoViewModel>();




            Services = services.BuildServiceProvider();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            _window = new MainWindow();
            _window.Activate();

        }
        
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SHC.UI.Windows.Interfaces;
using SHC.UI.WinUI.MVVM.Common;
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

namespace SHC.UI.Windows.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPatientPage : Page
    {
        public RegisterPatientViewModel ViewModel = App.Services.GetRequiredService<RegisterPatientViewModel>();
        private INavigationConfigurator _navigationConfigurator = App.Services.GetRequiredService<INavigationConfigurator>();
        public RegisterPatientPage()
        {
            InitializeComponent();
            _navigationConfigurator.RegisterFrame("PatientInfo", PatientInfo);
            _navigationConfigurator.RegisterPage(PageKey.PatientEssentialInfo, "PatientInfo", typeof(PatientEssentialInfoPage));
            _navigationConfigurator.RegisterPage(PageKey.PatientOptionalInfo, "PatientInfo", typeof(PatientOptionalInfoPage));
            DataContext = ViewModel;

        }
    }
}

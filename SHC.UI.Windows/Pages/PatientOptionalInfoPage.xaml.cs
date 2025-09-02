using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SHC.UI.Shared.DTOs.Requests;
using SHC.UI.Windows.Dialogs;
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
    public sealed partial class PatientOptionalInfoPage : Page
    {
        public PatientOptionalInfoViewModel ViewModel = App.Services.GetRequiredService<PatientOptionalInfoViewModel>();
        public PatientOptionalInfoPage()
        {
            InitializeComponent();
            var dialogFactory = new DialogFactory(XamlRoot);
            this.Loaded += (s, e) =>
            {
                var dialogFactory = new DialogFactory(this.XamlRoot);
                ViewModel.SetDialogFactory(dialogFactory);
            };
            DataContext = ViewModel;    
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is RegisterPatientRequestDTO patientRequestDTO)
            {
                // Use the patientId
                ViewModel.OnNavigatedTo(patientRequestDTO);
            }
        }
    }
}

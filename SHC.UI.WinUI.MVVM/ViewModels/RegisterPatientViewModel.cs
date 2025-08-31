using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHC.UI.Shared.DTOs.Requests;
using SHC.UI.WinUI.MVVM.Common;
using SHC.UI.WinUI.MVVM.Forms;
using SHC.UI.WinUI.MVVM.Forms.Validators;
using SHC.UI.WinUI.MVVM.Interfaces;
using System.Diagnostics;


namespace SHC.UI.WinUI.MVVM.ViewModels;

public partial class RegisterPatientViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    public RegisterPatientViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    public void OnLoaded()
    {
        _navigationService.Navigate(PageKey.PatientEssentialInfo);
    }
}

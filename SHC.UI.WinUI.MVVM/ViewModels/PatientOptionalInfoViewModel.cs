using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHC.UI.Shared.DTOs.Requests;
using SHC.UI.WinUI.MVVM.Common;
using SHC.UI.WinUI.MVVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SHC.UI.WinUI.MVVM.ViewModels;

public partial class PatientOptionalInfoViewModel : ObservableObject, INavigationAware
{
    private INavigationService _navigationService;
    public RegisterPatientRequestDTO RegisterPatientRequest { get; set; }
    public PatientOptionalInfoViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is RegisterPatientRequestDTO patientRequestDTO)
        {
            RegisterPatientRequest = patientRequestDTO;
        }
    }
    public void OnNavigatedFrom()
    {
        throw new NotImplementedException();
    }
    [RelayCommand]
    public void GoBack()
    {
        _navigationService.GoBack(PageKey.PatientOptionalInfo);
    }
}

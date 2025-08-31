using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SHC.UI.WinUI.MVVM.Common;
using SHC.UI.WinUI.MVVM.Interfaces;


namespace SHC.UI.WinUI.MVVM.ViewModels;

public partial class ContentPageViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    public ContentPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void OnLoaded()
    {
        _navigationService.Navigate(PageKey.RegisterPatient);
    }
}

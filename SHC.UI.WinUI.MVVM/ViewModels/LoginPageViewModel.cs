using CommunityToolkit.Mvvm.ComponentModel;
using SHC.UI.Shared.Common;
using SHC.UI.Shared.Models;
using SHC.UI.Shared.Models.Records;
using SHC.UI.Shared.Services;
using SHC.UI.WinUI.MVVM.Common;
using SHC.UI.WinUI.MVVM.Interfaces;
using System.Diagnostics;


namespace SHC.UI.WinUI.MVVM.ViewModels;

public partial class LoginPageViewModel : ObservableObject
{
    [ObservableProperty]
    public partial string PhoneNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Password { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string ErrorMessage { get; set; } = string.Empty;
    [ObservableProperty]
    public partial bool IsLoading { get; set; } = false;

    private readonly INavigationService _navigationService;
    private readonly UserService _userService;
    public LoginPageViewModel(
        INavigationService navigationService,
        UserService userService
        )
    {
        _navigationService = navigationService;
        _userService = userService;
    }
    public async Task Login()
    {
        //remove when done
        //_navigationService.Navigate(PageKey.Content);


        ErrorMessage = string.Empty;
        IsLoading = true;
        Result<LoginInfo> result = await _userService.LoginAsync(PhoneNumber, Password, Roles.Secretary);
        IsLoading = false;
        if (result.IsSuccess)
        {
            ErrorMessage = _navigationService.GetType().Name;
            _navigationService.Navigate(PageKey.Content);
        }
        else
        {
            ErrorMessage = result.Error!.Message;
        }
    }
}

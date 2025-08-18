using CommunityToolkit.Mvvm.ComponentModel;
using SHC.UI.WinUI.MVVM.Common;
using SHC.UI.WinUI.MVVM.Interfaces;


namespace SHC.UI.WinUI.MVVM.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial string Username { get; set; } = string.Empty;
        [ObservableProperty]
        public partial string Password { get; set; } = string.Empty;

        private readonly INavigationService _navigationService;
        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public void Login()
        {
            _navigationService.Navigate(PageKey.Content);
        }
    }
}

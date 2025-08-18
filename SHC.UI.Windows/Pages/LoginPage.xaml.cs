
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SHC.UI.Windows.Services;
using SHC.UI.WinUI.MVVM.ViewModels;
using Windows.Devices.Enumeration;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SHC.UI.Windows.Pages;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class LoginPage : Page
{
    public LoginPageViewModel ViewModel;
    public LoginPage()
    {
        InitializeComponent();
        ViewModel = new LoginPageViewModel(NavigationService.GetInstance());
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }
}



using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SHC.UI.WinUI.MVVM.Interfaces;
using System;

namespace SHC.UI.Windows.Dialogs;

public class DialogFactory : IDialogFactory
{
    private XamlRoot _xamlRoot;
    public DialogFactory(XamlRoot xamlRoot)
    {
        _xamlRoot = xamlRoot;
    }
    public async void PopUp(string title, string message, Action callback)
    {
        ContentDialog dialog = new ContentDialog();

        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
        dialog.XamlRoot = _xamlRoot;
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.Title = "Save your work?";
        dialog.PrimaryButtonText = "Save";
        dialog.PrimaryButtonClick += (_, _) => callback();
        dialog.SecondaryButtonText = "Don't Save";
        dialog.CloseButtonText = "Cancel";
        dialog.DefaultButton = ContentDialogButton.Primary;

        var result = await dialog.ShowAsync();

    }
}

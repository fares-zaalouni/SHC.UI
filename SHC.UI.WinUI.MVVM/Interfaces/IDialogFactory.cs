
namespace SHC.UI.WinUI.MVVM.Interfaces;

public interface IDialogFactory
{
    public void PopUp(
        string title,
        string message,
        Action callback );

}

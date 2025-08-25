namespace SHC.UI.Shared.Settings
{
    public interface ILocalSettingsManager
    {
        LocalSettings DefaultSettings();
        LocalSettings? GetSettings();
        void SaveSettings(LocalSettings settings);
    }
}

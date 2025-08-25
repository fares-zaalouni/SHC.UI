using Microsoft.Windows.Storage;
using SHC.UI.Shared.Settings;
using System;
using System.IO;
using System.Text.Json;

namespace SHC.UI.Windows.Settings
{
    public class LocalSettingsManager : ILocalSettingsManager
    {
        private readonly string _settingsPath;

        public LocalSettingsManager()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var appFolder = Path.Combine(folder, "SHC.UI");
            Directory.CreateDirectory(appFolder);

            _settingsPath = Path.Combine(appFolder, "settings.json");
        }

        public LocalSettings? GetSettings()
        {
            if (!File.Exists(_settingsPath))
                return null;

            var json = File.ReadAllText(_settingsPath);
            return JsonSerializer.Deserialize<LocalSettings>(json) ?? DefaultSettings();
        }

        public void SaveSettings(LocalSettings settings)
        {
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_settingsPath, json);
        }

        public LocalSettings DefaultSettings()
        {
            return new LocalSettings
            {
                DeviceId = Guid.NewGuid()
            };
        }
    }
}

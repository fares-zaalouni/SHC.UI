using Microsoft.Extensions.Configuration;


namespace SHC.UI.Shared.Common
{
    public static class ConfigProvider
    {
        private static IConfigurationRoot? _configuration;

        public static IConfigurationRoot Configuration => _configuration ??= new ConfigurationBuilder()
            .AddJsonFile("Configs/appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        public static ApiSettings ApiSettings => Configuration.GetSection("ApiSettings").Get<ApiSettings>()!;
    }
}

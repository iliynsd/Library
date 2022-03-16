using Microsoft.Extensions.Configuration;

namespace Library.Config
{
    public static class Configuration
    {
        private static readonly IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
        
        public static string GetSection(string name) => _configuration.GetSection(name).Value;
    }
}
using Microsoft.Extensions.Configuration;

namespace Persistence.Configuration
{
    static class ConnectionString
    {
        public static string MssqlLocalDb
        {
            get
            {
                ConfigurationManager manager = new();
                manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/API"));
                manager.AddJsonFile("appsettings.json");
                return manager.GetConnectionString("Default");
            }
        }
    }
}

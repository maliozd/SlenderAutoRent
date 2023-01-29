using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using Serilog.Core;

namespace API.LoggerConfigurationHandler
{
    public static class LoggerConfigurationHandler
    {
        public static Logger GetConfiguratedLogger()
        {
            Logger logger = new LoggerConfiguration().WriteTo.Console().
                WriteTo.File("logs/log.txt").Enrich.FromLogContext().
                MinimumLevel.Information().CreateLogger();
            return logger;
        }

        public static void AddHttpLoggingExtension(this IServiceCollection services)
        {
            services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All;
                logging.RequestHeaders.Add("sec-ch-ua");
                logging.MediaTypeOptions.AddText("application/javascript");
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
            });
        }
    }
}

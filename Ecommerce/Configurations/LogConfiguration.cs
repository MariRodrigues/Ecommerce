using Serilog.Events;
using Serilog;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Configurations
{
    public static class LogConfiguration
    {
        public static void Apply(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}

using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HangfirePOC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var options = new SqlServerStorageOptions
                    {
                        PrepareSchemaIfNecessary = true
                    };

                    GlobalConfiguration.Configuration
                        .UseSqlServerStorage(@"Server=localhost,1433;Database=HANGFIRE;User=SA;Password=Secret@1234");

                    services.AddHostedService<Worker>();
                });
    }
}


using DBStuff;
using MediatRStuff;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestWorkerWithMediatR
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


                    services.AddApplication();
                    services.AddPersistence(hostContext.Configuration.GetConnectionString("MyDatabase"));

                    //Not working, Will work if you change the env var name in launchsettings.json but wont get the correct appsetting.  
                    //Will default to Production
                    // services.AddHostedService<Worker>();

                    //Apparently the correct way to call scoped
                    services.AddHostedService<ScopedWorker>();


                });
    }
}

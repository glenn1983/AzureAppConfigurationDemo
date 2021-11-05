using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAppConfigurationDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                webBuilder.ConfigureAppConfiguration(config =>
                {
                    var settings = config.Build();
                    config.AddAzureAppConfiguration(options =>
                    options.Connect("Endpoint=https://demotestappconfig.azconfig.io;Id=yy7+-l4-s0:A2RUnar9s+AHcquPPs3w;Secret=9VRMHwQPXGOpcFG5PMfsSA8H5dk2TB9cFeTrlZpRci0=").UseFeatureFlags()
                    ); 

                }).UseStartup<Startup>());
    }
}

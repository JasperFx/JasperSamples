using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jasper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InMemoryMediator
{
    #region sample_InMemoryMediatorProgram
    public class Program
    {
        // Change the return type to Task<int> to communicate
        // success/failure codes
        public static Task<int> Main(string[] args)
        {
            return CreateHostBuilder(args)

                // This replaces Build().Start() from the default
                // dotnet new templates
                .RunJasper(args);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                // You can do the Jasper configuration inline with a 
                // Lambda, but here I've centralized the Jasper
                // configuration into a separate class
                .UseJasper<JasperConfig>()

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    #endregion
}

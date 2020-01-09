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
    // SAMPLE: InMemoryMediatorProgram
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

                // This by itself is enough to add Jasper to an
                // existing ASP.Net Core system as an in process
                // mediator library
                .UseJasper(opts =>
                {
                    // configure Jasper if you need to, or this
                    // Lambda can be omitted entirely if the defaults
                    // are suitable
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    // ENDSAMPLE
}

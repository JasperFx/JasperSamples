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
<<<<<<< HEAD
        public static Task<int> Main(string[] args)
        {
            return CreateHostBuilder(args).RunJasper(args);
=======
        // Change the return type to Task<int> to communicate
        // success/failure codes
        public static Task<int> Main(string[] args)
        {
            return CreateHostBuilder(args)

                // This replaces Build().Start() from the default
                // dotnet new templates
                .RunJasper(args);
>>>>>>> e636deca5380091ed89980adaf2a7e2d26870dc9
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
<<<<<<< HEAD
                .UseJasper<JasperConfig>()
=======

                // This by itself is enough to add Jasper to an
                // existing ASP.Net Core system as an in process
                // mediator library
                .UseJasper(opts =>
                {
                    // configure Jasper if you need to, or this
                    // Lambda can be omitted entirely if the defaults
                    // are suitable
                })

>>>>>>> e636deca5380091ed89980adaf2a7e2d26870dc9
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    // ENDSAMPLE
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jasper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Worker
{
    // SAMPLE: SimpleJasperWorker
    public class Program
    {
        // The Jasper-ified version
        public static Task<int> Main(string[] args)
        {
            return CreateHostBuilder().RunJasper(args);
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()

                // This adds Jasper with a default JasperOptions
                .UseJasper()

                .ConfigureServices((hostContext, services) =>
                {
                    // If you're not familiar with IHostedService,
                    // it's a .Net Core mechanism to start and stop
                    // long running routines within a .Net Core application
                    services.AddHostedService<Worker>();
                });
    }
    // ENDSAMPLE






}

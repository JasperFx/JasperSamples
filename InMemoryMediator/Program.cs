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
    public class Program
    {
        public static Task<int> Main(string[] args)
        {
            return CreateHostBuilder(args).RunJasper(args);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseJasper<JasperConfig>()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

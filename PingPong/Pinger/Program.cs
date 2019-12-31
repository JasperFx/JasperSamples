using System.Threading.Tasks;
using Jasper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Pinger
{
    public class Program
    {
        public static Task<int> Main(string[] args)
        {
            return CreateHostBuilder().RunJasper(args);
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host
            .CreateDefaultBuilder()
            
            // Reducing the logging noise so you can see the pings
            // and pongs
            .ConfigureLogging(x => x.ClearProviders())
            
            .UseJasper<JasperConfig>();
    
    }


}
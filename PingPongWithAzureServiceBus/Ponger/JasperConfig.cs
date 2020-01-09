using Jasper;
using Jasper.AzureServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Ponger
{
    internal class JasperConfig : JasperOptions
    {
        public JasperConfig()
        {
            Endpoints.ListenToAzureServiceBusQueue("pings");
        }
    }

}
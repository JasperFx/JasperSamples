using Jasper;
using Jasper.AzureServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Pinger
{
    #region sample_JasperConfigForAzureServiceBus
    internal class JasperConfig : JasperOptions
    {
        public JasperConfig()
        {
            // Publish all messages to an Azure Service Bus queue
            Endpoints
                .PublishAllMessages()
                .ToAzureServiceBusQueue("pings");

            // Listen to incoming messages from an Azure Service Bus
            // queue
            Endpoints.ListenToAzureServiceBusQueue("pongs");

            // Because Jasper rides on top of the built in
            // .Net Core generic host, you can use the
            // IHostedService
            Services.AddHostedService<PingerService>();
        }
    }
    #endregion

}

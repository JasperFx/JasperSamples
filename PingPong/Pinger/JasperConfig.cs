using Jasper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Pinger
{
    internal class JasperConfig : JasperOptions
    {
        public JasperConfig()
        {
            // Using the lightweight TCP transport, register
            // an endpoint for all outgoing messages
            Endpoints.PublishAllMessages().ToPort(2222);
            
            // Listen to incoming messages using the lightweight
            // TCP transport on port 2223
            Endpoints.ListenAtPort(2223);

            // You an register additional IoC services
            // directly in the JasperOptions with either
            // Lamar specific registrations or in this case,
            // the built in DI abstractions in .Net Core
            
            // Because Jasper rides on top of the built in
            // .Net Core generic host, you can use the 
            // IHostedService
            Services.AddHostedService<PingerService>();
        }
    }

}
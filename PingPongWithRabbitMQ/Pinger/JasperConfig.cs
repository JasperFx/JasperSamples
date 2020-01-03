using Jasper;
using Jasper.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Pinger
{
    internal class JasperConfig : JasperOptions
    {
        public JasperConfig()
        {
            Endpoints
                .ListenToRabbitQueue("pongs")

                // With the Rabbit MQ transport, you probably
                // want to explicitly designate a specific queue or topic
                // for replies
                .UseForReplies();

            Endpoints.PublishAllMessages().ToRabbit("pings");
            
            // Configure Rabbit MQ connections and optionally declare Rabbit MQ
            // objects through an extension method on JasperOptions.Endpoints
            Endpoints.ConfigureRabbitMq(rabbit =>
            {
                // Using a local installation of Rabbit MQ
                // via a running Docker image
                rabbit.ConnectionFactory.HostName = "localhost";
                rabbit.AutoProvision = true;
                rabbit.DeclareQueue("pongs");
                rabbit.DeclareQueue("pings");
            });
            
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
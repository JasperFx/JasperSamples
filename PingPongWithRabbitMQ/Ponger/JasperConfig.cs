using Jasper;
using Jasper.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace Ponger
{
    internal class JasperConfig : JasperOptions
    {
        public JasperConfig()
        {
            Endpoints
                .ListenToRabbitQueue("pings")

                // With the Rabbit MQ transport, you probably
                // want to explicitly designate a specific queue or topic
                // for replies
                .UseForReplies();

            // Configure Rabbit MQ connections and optionally declare Rabbit MQ
            // objects through an extension method on JasperOptions.Endpoints
            Endpoints.ConfigureRabbitMq(rabbit =>
            {
                // Using a local installation of Rabbit MQ
                // via a running Docker image
                rabbit.ConnectionFactory.HostName = "localhost";
                rabbit.AutoProvision = true;
                rabbit.DeclareQueue("pings");
            });
        }
        
    }

}
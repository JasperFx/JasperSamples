using Jasper;
using Jasper.Persistence.Postgresql;
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
            Endpoints
                .PublishAllMessages()
                .ToPort(2222)
                
                // Use message persistence at this endpoint
                .Durably();
            
            // Listen to incoming messages using the lightweight
            // TCP transport on port 2223
            Endpoints
                .ListenAtPort(2223)

                // Use message persistence at this endpoint
                .Durable();

            // You an register additional IoC services
            // directly in the JasperOptions with either
            // Lamar specific registrations or in this case,
            // the built in DI abstractions in .Net Core
            
            // Because Jasper rides on top of the built in
            // .Net Core generic host, you can use the 
            // IHostedService
            Services.AddHostedService<PingerService>();
        }
        
        public override void Configure(IHostEnvironment hosting, IConfiguration config)
        {
            if (hosting.IsDevelopment())
            {
                // In development mode, we're just going to have the message persistence
                // schema objects dropped and rebuilt on app startup so you're
                // always starting from a clean slate
                Advanced.StorageProvisioning = StorageProvisioning.Rebuild;
            }

            // Just the normal work to get the connection string out of 
            // application configuration
            var connectionString = config.GetConnectionString("postgresql");

            // Setting up Sql Server-backed message persistence
            Extensions.PersistMessagesWithPostgresql(connectionString, "pings");

        }
    }

}
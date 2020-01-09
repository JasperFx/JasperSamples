using Jasper;
using Jasper.Persistence.Marten;
using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MediatorWithMarten
{
    public class JasperConfig : JasperOptions
    {
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

            // Integrating Marten into the Jasper application. This also
            // quietly adds Postgresql-backed message persistence as well
            Extensions.UseMarten(opts =>
            {
                opts.Connection(connectionString);

                // This options is only suitable for development
                if (hosting.IsDevelopment())
                {
                    opts.AutoCreateSchemaObjects = AutoCreate.All;
                }
            });
        }
    }

}
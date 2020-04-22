using InMemoryMediator.Items;
using Jasper;
using Jasper.Persistence.EntityFrameworkCore.Codegen;
using Jasper.Persistence.Sagas;
using Jasper.Persistence.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InMemoryMediator
{
    // SAMPLE: InMemoryMediator-JasperConfig
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
            var connectionString = config.GetConnectionString("sqlserver");

            // Setting up Sql Server-backed message persistence
            // This requires a reference to Jasper.Persistence.SqlServer
            Extensions.PersistMessagesWithSqlServer(connectionString);

            // Register the EF Core DbContext
            Services.AddDbContext<ItemsDbContext>(
                x => x.UseSqlServer(connectionString),

                // This is important! Using Singleton scoping
                // of the options allows Jasper + Lamar to significantly
                // optimize the runtime pipeline of the handlers that
                // use this DbContext type
                optionsLifetime:ServiceLifetime.Singleton);
        }
    }
    // ENDSAMPLE

}

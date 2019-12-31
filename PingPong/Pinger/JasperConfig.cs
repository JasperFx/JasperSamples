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
            Endpoints.PublishAllMessages().ToPort(2222);
            Endpoints.ListenAtPort(2223);

            Services.AddSingleton<IHostedService, PingerService>();
        }
    }

}
using Jasper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Ponger
{
    internal class JasperConfig : JasperOptions
    {
        public JasperConfig()
        {
            Endpoints.ListenAtPort(2222);
        }
    }

}
using System;
using Alba;
using Microsoft.Extensions.Hosting;

namespace WebApplication.Testing
{
    public class AppFixture : IDisposable
    {
        public AppFixture()
        {
            // Use the application configuration the way that it is in the real application
            // project
            var builder = Program.CreateHostBuilder(new string[0])
                
                // You may need to do this for any static 
                // content or files in the main application including
                // appsettings.json files
                
                // DirectoryFinder is an Alba helper
                .UseContentRoot(DirectoryFinder.FindParallelFolder("WebApplication")) 
                
                // Override the hosting environment to "Testing"
                .UseEnvironment("Testing"); 

            // This is the Alba scenario wrapper around
            // TestServer and an active .Net Core IHost
            System = new SystemUnderTest(builder);

            // There's also a BeforeEachAsync() signature
            System.BeforeEach(httpContext =>
            {
                // Take any kind of setup action before
                // each simulated HTTP request
                
                // In this case, I'm setting a fake JWT token on each request
                // as a demonstration
                httpContext.Request.Headers["Authorization"] = $"Bearer {generateToken()}";
            });

            System.AfterEach(httpContext =>
            {
                // Take any kind of teardown action after
                // each simulated HTTP request
            });

        }

        private string generateToken()
        {
            // In a current project, we implement this method
            // to create a valid JWT token with the claims that
            // the web services require
            return "Fake";
        }

        public SystemUnderTest System { get; }

        public void Dispose()
        {
            System?.Dispose();
        }
    }
    
    
}
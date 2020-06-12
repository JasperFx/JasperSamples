using System;
using Alba;
using Marten;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service;

namespace Tests
{
    public class AppFixture : IDisposable
    {
        public AppFixture()
        {
            var builder = Program
                .CreateHostBuilder(new string[0]);
            System = new SystemUnderTest(builder);

            Store = System.Services.GetRequiredService<IDocumentStore>();
        }
        
        public SystemUnderTest System { get; }

        public IDocumentStore Store { get; }


        public void Dispose()
        {
            System?.Dispose();
        }
    }
}
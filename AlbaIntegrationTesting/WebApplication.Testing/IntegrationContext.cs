using System;
using System.Threading.Tasks;
using Alba;
using Xunit;

namespace WebApplication.Testing
{
    public abstract class IntegrationContext : IClassFixture<AppFixture>
    {
        protected IntegrationContext(AppFixture fixture)
        {
            Fixture = fixture;
        }

        public AppFixture Fixture { get; }

        /// <summary>
        /// Runs Alba HTTP scenarios through your ASP.Net Core system
        /// </summary>
        /// <param name="configure"></param>
        /// <returns></returns>
        protected Task<IScenarioResult> Scenario(Action<Scenario> configure)
        {
            return Fixture.System.Scenario(configure);
        }



        protected SystemUnderTest System => Fixture.System;

        protected IServiceProvider Services => Fixture.System.Services;

    }
}
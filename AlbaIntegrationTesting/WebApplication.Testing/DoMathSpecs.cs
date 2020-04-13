using System.Threading.Tasks;
using Alba;
using Shouldly;
using WebApplication.Controllers;
using Xunit;

namespace WebApplication.Testing
{
    public class DoMathSpecs : IntegrationContext
    {
        public DoMathSpecs(AppFixture fixture) : base(fixture)
        {
        }

        // This specification uses the shorthand helpers in Alba
        // that's useful when you really only care about the data
        // going in or out of the HTTP endpoint
        [Fact]
        public async Task do_some_math_adds_and_multiples_shorthand()
        {
            var answers = await System.GetAsJson<Answers>("/math/3/4");
            
            answers.Sum.ShouldBe(7);
            answers.Product.ShouldBe(12);
        }
        
        // This specification shows the longhand way of executing an
        // Alba scenario and using some of its declarative assertions
        // about the expected HTTP response
        [Fact]
        public async Task do_some_math_adds_and_multiples_longhand()
        {
            var result = await Scenario(x =>
            {
                x.Get.Url("/math/3/4");
                x.ContentTypeShouldBe("application/json; charset=utf-8");
            });

            var answers = result.ResponseBody.ReadAsJson<Answers>();
            
            
            answers.Sum.ShouldBe(7);
            answers.Product.ShouldBe(12);
        }
    }
}
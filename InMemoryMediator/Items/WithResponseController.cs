using System.Threading.Tasks;
using Jasper;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryMediator.Items
{
    #region sample_InMemoryMediator_WithResponseController
    public class WithResponseController : ControllerBase
    {
        private readonly ICommandBus _bus;

        public WithResponseController(ICommandBus bus)
        {
            _bus = bus;
        }

        // MVC Core calls this method, and uses the signature
        // and attributes like the [FromBody] to "know" how
        // to call this code at runtime
        [HttpPost("/items/create2")]
        public Task<ItemCreated> Create([FromBody] CreateItemCommand command)
        {
            // Using Jasper as a Mediator, and receive the
            // expected response from Jasper
            return _bus.Invoke<ItemCreated>(command);
        }
    }
    #endregion








}

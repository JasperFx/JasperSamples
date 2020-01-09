using System.Threading.Tasks;
using Jasper;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryMediator.Items
{
    public class WithResponseController : ControllerBase
    {
        private readonly ICommandBus _bus;

        public WithResponseController(ICommandBus bus)
        {
            _bus = bus;
        }

        [HttpPost("/items/create")]
        public Task<ItemCreated> Create([FromBody] CreateItemCommand command)
        {
            // Using Jasper as a Mediator, and receive the
            // expected response from Jasper
            return _bus.Invoke<ItemCreated>(command);
        }
    }
}
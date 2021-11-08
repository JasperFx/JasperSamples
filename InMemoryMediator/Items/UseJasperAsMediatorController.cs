using System.Threading.Tasks;
using Jasper;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryMediator.Items
{
    #region sample_InMemoryMediator_UseJasperAsMediatorController
    public class UseJasperAsMediatorController : ControllerBase
    {
        private readonly ICommandBus _bus;

        public UseJasperAsMediatorController(ICommandBus bus)
        {
            _bus = bus;
        }

        [HttpPost("/items/create")]
        public Task Create([FromBody] CreateItemCommand command)
        {
            // Using Jasper as a Mediator
            return _bus.Invoke(command);
        }
    }
    #endregion


}

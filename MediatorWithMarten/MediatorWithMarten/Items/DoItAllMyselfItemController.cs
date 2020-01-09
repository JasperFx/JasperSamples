using System.Threading.Tasks;
using Jasper;
using Jasper.Persistence.Marten;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace MediatorWithMarten.Items
{
    // This controller does all the transactional work and business
    // logic all by itself
    public class DoItAllMyselfItemController : ControllerBase
    {
        private readonly IMessageContext _messaging;
        private readonly IDocumentSession _session;

        public DoItAllMyselfItemController(IMessageContext messaging, IDocumentSession session)
        {
            _messaging = messaging;
            _session = session;
        }
        
        [HttpPost("/items/create")]
        public async Task Create([FromBody] CreateItemCommand command)
        {
            // Start the "Outbox" transaction
            await _messaging.EnlistInTransaction(_session);

            
            // Create a new Item entity
            var item = new Item
            {
                Name = command.Name
            };

            // Add the item to the current
            // IDocumentSession unit of work
            _session.Store(item);
            
            // Publish an event to anyone
            // who cares that a new Item has
            // been created
            var @event = new ItemCreated
            {
                Id = item.Id
            };
            
            // Because the message context is enlisted in an
            // "outbox" transaction, these outgoing messages are
            // held until the ongoing transaction completes
            await _messaging.Send(@event);

            // Commit the unit of work. This will persist
            // both the Item entity we created above, and
            // also a Jasper Envelope for the outgoing
            // ItemCreated message. If the operation
            // succeeds, the outgoing Jasper messages will
            // be released to Jasper's sending agents
            await _session.SaveChangesAsync();
        }
    }
}
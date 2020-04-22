using System.Linq;
using Baseline;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryMediator.Items
{
    public class ItemsController : ControllerBase
    {
        [HttpGet("items")]
        public string GetItems([FromServices] ItemsDbContext context)
        {
            var items = context.Items.AsQueryable().ToList();

            if (items.Any())
            {
                var text = items.Select(x => x.Name).Join("\n");

                return $"The items are:\n{text}";
            }
            else
            {
                return "There are no persisted items yet";
            }
            

        }
    }
}
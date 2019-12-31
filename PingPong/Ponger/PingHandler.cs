using System;
using System.Threading.Tasks;
using Jasper;
using Oakton;

namespace Ponger
{
    public static class PingHandler
    {
        public static Task Handle(PingMessage message, IMessageContext context)
        {
            ConsoleWriter.Write(ConsoleColor.Blue, $"Got ping #{message.Number}");
            
            var response = new PongMessage
            {
                Number = message.Number
            };

            return context.RespondToSender(response);
        }
    }
}
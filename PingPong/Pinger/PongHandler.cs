using System;
using Messages;
using Oakton;

namespace Pinger
{
    // SAMPLE: PongHandler
    // Simple message handler for the PongMessage responses
    // The "Handler" suffix is important as a naming convention
    // to let Jasper know that it should build a message handling
    // pipeline around public methods on this class
    public static class PongHandler
    {
        // "Handle" is recognized by Jasper as a message handling
        // method. Handler methods can be static or instance methods
        public static void Handle(PongMessage message)
        {
            ConsoleWriter.Write(ConsoleColor.Blue, $"Got pong #{message.Number}");
        }
    }
    // ENDSAMPLE
}

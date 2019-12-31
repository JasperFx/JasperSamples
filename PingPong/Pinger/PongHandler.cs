using System;
using Oakton;

namespace Pinger
{
    public static class PongHandler
    {
        public static void Handle(PongMessage message)
        {
            ConsoleWriter.Write(ConsoleColor.Blue, $"Got pong #{message.Number}");
        }
    }
}
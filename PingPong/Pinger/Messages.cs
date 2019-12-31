using Jasper.Attributes;

namespace Pinger
{
    [MessageIdentity("Ping")]
    public class PingMessage
    {
        public int Number { get; set; }
    }

    [MessageIdentity("Pong")]
    public class PongMessage
    {
        public int Number { get; set; }
    }
}
// This directs Oakton to look for command
// types within this assembly

using System;
using Oakton;
using Oakton.AspNetCore;

[assembly:Oakton.OaktonCommandAssembly]

namespace OaktonDevelopmentCommands
{
    // The conditional compilation here just keeps this command from
    // being present in the Release build of the application
#if DEBUG
    // This is also an OaktonAsyncCommand if you need to 
    // call async APIs
    [Description("I'm a simple command that just starts up the app and says hello")]
    public class SayHelloCommand : OaktonCommand<NetCoreInput>
    {
        public override bool Execute(NetCoreInput input)
        {
            // Super cheesy, just starting up the application
            // and shutting it right down
            using (var host = input.BuildHost())
            {
                // You do have access to the host's underlying
                // IoC provider, and hence to any application service
                // including the compiled IConfiguration as well
                
                Console.WriteLine("Hey, I can start up the application!");
            }

            // Gotta return true to let Oakton know that the command succeeded
            // This is important if you're using commands that need to report
            // success or failure to the command line.
            return true;
        }
    }
#endif
}
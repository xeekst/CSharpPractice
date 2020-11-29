using System;
using System.Threading.Tasks;
using SuperSocket.Command;

namespace Practice.SuperSocket{
    public class AsyncHelloCommandFilterAttribute : AsyncCommandFilterAttribute
    {
        public override async ValueTask OnCommandExecutedAsync(CommandExecutingContext commandContext)
        {
            Console.WriteLine("Hello Executed");
            await Task.Delay(0);
        }

        public override async ValueTask<bool> OnCommandExecutingAsync(CommandExecutingContext commandContext)
        {
            Console.WriteLine("Hello Executing");
            await Task.Delay(0);
            return true;
        }
    }
}
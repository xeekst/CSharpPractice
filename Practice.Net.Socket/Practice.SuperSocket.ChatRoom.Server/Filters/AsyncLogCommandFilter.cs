using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SuperSocket.Command;

namespace Practice.SuperSocket.ChatRoom.Server.Filters
{
    public class AsyncLogCommandFilter : AsyncCommandFilterAttribute
    {
        private ILogger _logger;
        // public AsyncLogCommandFilter(ILogger logger)
        // {
        //     _logger = logger;
        // }
        public override async ValueTask OnCommandExecutedAsync(CommandExecutingContext commandContext)
        {
            string log = $"Executed:Accept Command:{commandContext.CurrentCommand.ToString()} from:{commandContext.Session.SessionID}";
            //_logger.LogInformation(log);
            Console.WriteLine(log);
        }

        public override async ValueTask<bool> OnCommandExecutingAsync(CommandExecutingContext commandContext)
        {
            string log = $"Executing:Accept Command:{commandContext.CurrentCommand.ToString()} from:{commandContext.Session.SessionID}";

            return await Task.FromResult(true);
        }
    }
}
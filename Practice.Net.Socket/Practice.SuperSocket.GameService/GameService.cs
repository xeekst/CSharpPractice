using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SuperSocket;
using SuperSocket.Server;

namespace Practice.SuperSocket.GameService
{
    public class GameService<TReceivePackageInfo> : SuperSocketService<TReceivePackageInfo>
        where TReceivePackageInfo : class
    {
        public GameService(IServiceProvider serviceProvider, IOptions<ServerOptions> serverOptions) : base(serviceProvider, serverOptions)
        {

        }
        protected override async ValueTask OnSessionConnectedAsync(IAppSession session)
        {
            // do something right after the sesssion is connected
            await base.OnSessionConnectedAsync(session);
        }

        protected override async ValueTask OnSessionClosedAsync(IAppSession session)
        {
            // do something right after the sesssion is closed
            await base.OnSessionClosedAsync(session);
        }

    }
}
using System.Linq;
using System.Threading.Tasks;
using SuperSocket.Command;
using SuperSocket.ProtoBase;
using SuperSocket.WebSocket.Server;

namespace Practice.SuperSocket.WebSocket
{
    public class ADD : IAsyncCommand<WebSocketSession, StringPackageInfo>
    {
        public async ValueTask ExecuteAsync(WebSocketSession session, StringPackageInfo package)
        {
            var result = package.Parameters
                .Select(p => int.Parse(p))
                .Sum();

            await session.SendAsync(result.ToString());
        }
    }
}
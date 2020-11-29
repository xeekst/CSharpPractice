using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket.EchoServer
{
    public class ADD : IAsyncCommand<StringPackageInfo>
    {
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            var result = package.Parameters
            .Select(p => int.Parse(p))
            .Sum();
            await session.SendAsync(Encoding.UTF8.GetBytes(result.ToString() + Environment.NewLine));
        }
    }
}
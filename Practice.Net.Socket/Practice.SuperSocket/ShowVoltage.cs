
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperSocket;
using SuperSocket.ProtoBase;
using SuperSocket.Command;

namespace Practice.SuperSocket
{
    [Command(Key = 0x03)]
    public class ShowVoltage : IAsyncCommand<StringPackageInfo>
    {
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {

        }
    }
}
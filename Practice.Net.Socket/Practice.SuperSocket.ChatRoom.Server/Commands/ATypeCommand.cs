using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Server.Interface;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket.ChatRoom.Server.Commands
{
    public class ATypeCommand : IAsyncCommand<StringPackageInfo>
    {
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {

        }
    }
}
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket.Command
{
    public class MULT : IAsyncCommand<StringPackageInfo>
    {
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            var r = 1;
            package.Parameters.ToList().ForEach(e=>  r*=int.Parse(e));
            await session.SendAsync(Encoding.UTF8.GetBytes(r.ToString() + "\r\n"));
        }
    }
}
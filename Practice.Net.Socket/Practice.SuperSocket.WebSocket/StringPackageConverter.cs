using System;
using System.Linq;
using SuperSocket.Command;
using SuperSocket.ProtoBase;
using SuperSocket.WebSocket;

namespace Practice.SuperSocket.WebSocket
{
    public class StringPackageConverter : IPackageMapper<WebSocketPackage, StringPackageInfo>
    {
        public StringPackageInfo Map(WebSocketPackage package)
        {
            var pack = new StringPackageInfo();
            var arr = package.Message.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
            pack.Key = arr[0];
            pack.Parameters = arr.Skip(1).ToArray();
            return pack;
        }
    }
}
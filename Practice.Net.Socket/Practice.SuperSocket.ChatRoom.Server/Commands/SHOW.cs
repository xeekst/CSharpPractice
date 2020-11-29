using System;
using System.Text;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Server.Interface;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket.ChatRoom.Server.Commands
{
    public class SHOW : IAsyncCommand<StringPackageInfo>
    {
        private IRoomManager _rootManager;
        public SHOW(IRoomManager rootManager)
        {
            _rootManager = rootManager;
        }
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            //string param = package.Parameters.Length > 0 ? package.Parameters[0] : string.Empty;
            var commands = new string[] { "BROADCASTROOM: 发送广播消息到所在到房间到所有人", "GOROOM: 前往某个房间", "PWD: 展示当前Chator的信息", "UPDATENICKNAME: 更新自己的昵称", "SHOW: 展示所有的命令" };
            var text = Environment.NewLine + "========================" + Environment.NewLine
                    + string.Join(Environment.NewLine, commands) 
                    + Environment.NewLine + "========================" + Environment.NewLine;
            await session.SendAsync(Encoding.UTF8.GetBytes(text));
        }
    }
}
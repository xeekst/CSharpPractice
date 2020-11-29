using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Server.Filters;
using Practice.SuperSocket.ChatRoom.Server.Interface;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket.ChatRoom.Server.Commands
{
    public class PWD : IAsyncCommand<StringPackageInfo>
    {
        private IRoomManager _rootManager;
        public PWD(IRoomManager rootManager)
        {
            _rootManager = rootManager;
        }
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            var room = _rootManager.GetChatorRoom(session.SessionID);
            var chatorSession = room?.GetChator(session.SessionID);
            
            string text = $"NickName:{chatorSession?.NickName} Room:{room?.RoomId}" + Environment.NewLine;
            await session.SendAsync(Encoding.UTF8.GetBytes(text));
        }
    }
}
using System;
using System.Text;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Server.Interface;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket.ChatRoom.Server.Commands
{
    [Command("UpdateNickName")]
    public class UPDATENICKNAME : IAsyncCommand<StringPackageInfo>
    {
        private IRoomManager _roomManager;
        public UPDATENICKNAME(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            string nickName = string.Join('·',package.Parameters);
            var room = _roomManager.GetChatorRoom(session.SessionID);
            var chatorSession = room?.GetChator(session.SessionID);
            chatorSession.NickName = nickName;
            room.UpdateOrAddChator(session.SessionID,chatorSession);
            
            await session.SendAsync(Encoding.UTF8.GetBytes($"{nickName} has Updated !" + Environment.NewLine));
        }
    }
}
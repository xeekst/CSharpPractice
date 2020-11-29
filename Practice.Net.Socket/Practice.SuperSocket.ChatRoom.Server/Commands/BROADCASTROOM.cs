using System;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Server.Filters;
using Practice.SuperSocket.ChatRoom.Server.Interface;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Practice.SuperSocket.ChatRoom.Server.Commands
{
    [Command("BroadcastRoom")]
    [AsyncLogCommandFilter]
    public class BROADCASTROOM : IAsyncCommand<StringPackageInfo>
    {
        private IRoomManager _roomManager;
        public BROADCASTROOM(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            var room = _roomManager.GetChatorRoom(session.SessionID);
            var chatorSession = room.GetChator(session.SessionID);
            if(package.Parameters.Length < 3) return;

            var senderId = package.Parameters[0];
            var senderName = package.Parameters[1];
            string message = package.Parameters[2];
            
            if (room != null && !string.IsNullOrWhiteSpace(message))
            {
                await _roomManager.Broadcast(room.RoomId, senderId + "|" + senderName + "|" + message);
            }
        }
    }
}
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Server;
using Practice.SuperSocket.ChatRoom.Server.Interface;
using SuperSocket;
using SuperSocket.Server;

namespace Practice.SuperSocket.ChatRoom.Server.Components
{
    public class ChatorSession : AppSession
    {
        private IRoomManager _roomManager;
        public string Id { get; internal set; }
        public int DefaultRoomId { get; private set; } = 0;
        public string NickName { get; set; }

        public ChatorSession(IRoomManager roomManager) : base()
        {
            _roomManager = roomManager;
            NickName = Utils.GenRandomName();
        }

        private async Task OnlinedNotice(IAppSession session)
        {
            var availableRoomsIds = _roomManager.GetRoomIds().Select(id => id.ToString());
            var availableRoomIdText = "Select One Room Into: \r\n" + string.Join('\t', availableRoomsIds) + "\r\n";
            await session.Channel.SendAsync(Encoding.UTF8.GetBytes(availableRoomIdText));
        }
        protected override async ValueTask OnSessionConnectedAsync()
        {
            _roomManager.AppendChator2Room(DefaultRoomId, this);
            // the logic after the session gets connected
            string noticeText = $"Chator Onlined {base.SessionID} \r\n";
            await _roomManager.Broadcast(DefaultRoomId, noticeText);

            await OnlinedNotice(this);
            Console.WriteLine($"Session {base.SessionID} connected");
        }

        protected override async ValueTask OnSessionClosedAsync(EventArgs e)
        {
            // the logic after the session gets closed
            string noticeText = $"Chator Offlined {SessionID} \r\n";
            var room = _roomManager.GetChatorRoom(SessionID);
            await room?.Broadcast(noticeText);
            Console.WriteLine($"Session {base.SessionID} closed");
        }
    }
}
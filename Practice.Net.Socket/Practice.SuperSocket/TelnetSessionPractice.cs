using System;
using System.Threading.Tasks;
using SuperSocket.Server;

namespace Practice.SuperSocket
{
    public class TelnetSessionPractice
    {

    }
    public class PlayerSession : AppSession
    {
        public int GameHallId { get; internal set; }

        public int RoomId { get; internal set; }
    }
    public class TelnetSession : AppSession
    {
        protected override async ValueTask OnSessionConnectedAsync()
        {
            // do something right after the sesssion is connected
        }

        protected override async ValueTask OnSessionClosedAsync(EventArgs e)
        {
            // do something right after the sesssion is closed
        }
    }
}
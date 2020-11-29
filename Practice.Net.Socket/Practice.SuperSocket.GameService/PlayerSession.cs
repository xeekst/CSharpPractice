using SuperSocket.Server;

namespace Practice.SuperSocket.GameService
{
    public class PlaySession : AppSession
    {
        public int GameHallId { get; internal set; }

        public int RoomId { get; internal set; }
    }
}
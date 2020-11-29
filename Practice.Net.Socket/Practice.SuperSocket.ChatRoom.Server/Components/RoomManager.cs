using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Server.Interface;
using SuperSocket;

namespace Practice.SuperSocket.ChatRoom.Server.Components
{
    public class RoomManager : IRoomManager
    {
        private Dictionary<int, ChatorRoom> _roomDict;
        public int DefaultRoomId = 0;
        public RoomManager(int roomNumber)
        {
            _roomDict = new Dictionary<int, ChatorRoom>();
            if (roomNumber > 0)
            {
                Enumerable.Range(1001, roomNumber).ToList().ForEach(e =>
                {
                    _roomDict[e] = new ChatorRoom(e);
                });
            }

            _roomDict[0] = new ChatorRoom(0);
        }

        public List<int> GetRoomIds()
        {
            return _roomDict.Keys.Where(r => !r.Equals(0)).ToList();
        }
        public bool AddRoom(int roomId, ChatorRoom room)
        {
            _roomDict[roomId] = room;
            return true;
        }
        public bool RemoveRoom(int roomId, ChatorRoom room)
        {
            if (_roomDict.ContainsKey(roomId))
            {
                return _roomDict.Remove(roomId);
            }
            return false;
        }
        public ChatorRoom GetChatorRoom(string sessionId)
        {
            var sourceRoom = _roomDict.Values.Where(r => r.ChatorSessionDict.ContainsKey(sessionId)).FirstOrDefault();
            return sourceRoom;
        }

        // 广播消息
        public async Task Broadcast(int roomId, string message)
        {
            if (_roomDict.TryGetValue(roomId, out ChatorRoom room))
            {
                await room.Broadcast(message);
            }
        }

        public async Task Notice(int roomId, string sessionId, string message)
        {
            if (_roomDict.TryGetValue(roomId, out ChatorRoom room))
            {
                await room.Notice(sessionId, message);
            }
        }

        public bool AppendChator2Room(int roomId, ChatorSession session)
        {
            if (_roomDict.TryGetValue(roomId, out ChatorRoom room))
            {
                room.UpdateOrAddChator(session.SessionID, session);
                return true;
            }
            return false;
        }

        public bool RemoveChator2Room(int roomId, string sessionId)
        {
            if (_roomDict.TryGetValue(roomId, out ChatorRoom room))
            {
                room.RemoveChator(sessionId);
                return true;
            }
            return false;
        }

        public bool ChangeChatorRoom(int targetRoomId, string sessionId)
        {
            var sourceRoom = _roomDict.Values.Where(r => r.ChatorSessionDict.ContainsKey(sessionId)).FirstOrDefault();

            var chatorSession = sourceRoom?.GetChator(sessionId);

            if (sourceRoom != null && chatorSession != null && _roomDict.TryGetValue(targetRoomId, out ChatorRoom targetRoom))
            {
                targetRoom.UpdateOrAddChator(sessionId, chatorSession);
                sourceRoom.RemoveChator(chatorSession.SessionID);
                return true;
            }
            return false;
        }
    }
}
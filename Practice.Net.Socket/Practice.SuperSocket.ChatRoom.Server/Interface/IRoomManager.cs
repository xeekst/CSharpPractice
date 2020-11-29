using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Server.Components;
using SuperSocket;

namespace Practice.SuperSocket.ChatRoom.Server.Interface
{
    public interface IRoomManager
    {
        List<int> GetRoomIds();
        bool AddRoom(int roomId, ChatorRoom room);
        bool RemoveRoom(int roomId, ChatorRoom room);
        bool AppendChator2Room(int roomId,ChatorSession session);
        bool ChangeChatorRoom(int targetRoomId,string sessionId);
        bool RemoveChator2Room(int roomId,string sessionId);
        ChatorRoom GetChatorRoom(string sessionId);
        Task Broadcast(int roomId, string message);
        Task Notice(int roomId, string sessionId, string message);
    }
}

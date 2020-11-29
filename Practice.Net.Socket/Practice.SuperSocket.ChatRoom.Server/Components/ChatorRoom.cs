using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket;

namespace Practice.SuperSocket.ChatRoom.Server.Components
{
    public class ChatorRoom
    {
        private Dictionary<string, ChatorSession> _chatorSessionDict;

        public ChatorRoom(int id)
        {
            RoomId = id;
            _chatorSessionDict = new Dictionary<string, ChatorSession>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public Dictionary<string, ChatorSession> ChatorSessionDict
        {
            get { return _chatorSessionDict; }
            private set { }
        }

        #region Chator CURD
        public ChatorSession GetChator(string sessionId)
        {
            if (_chatorSessionDict.TryGetValue(sessionId, out ChatorSession session))
            {
                return session;
            }
            return null;
        }
        public void UpdateOrAddChator(string sessiongId, ChatorSession session)
        {
            _chatorSessionDict[sessiongId] = session;
        }
        public bool RemoveChator(string sessionId)
        {
            if (_chatorSessionDict.ContainsKey(sessionId))
            {
                _chatorSessionDict.Remove(sessionId);
                return true;
            }
            return false;
        }
        #endregion
        public async Task Broadcast(string message)
        {
            List<string> deleteKeyList = new List<string>();
            foreach (var kv in _chatorSessionDict)
            {
                IAppSession s = kv.Value;
                if (!s.Channel.IsClosed)
                {
                    await s.SendAsync(Encoding.UTF8.GetBytes(message));
                }
                else
                {
                    deleteKeyList.Add(kv.Key);
                }
            };
            deleteKeyList.ForEach(k => _chatorSessionDict.Remove(k));

        }

        public async Task Notice(string sessionId, string message)
        {
            if (_chatorSessionDict.TryGetValue(sessionId, out ChatorSession session))
            {
                await (session as IAppSession).SendAsync(Encoding.UTF8.GetBytes(message));
            }
        }
    }
}
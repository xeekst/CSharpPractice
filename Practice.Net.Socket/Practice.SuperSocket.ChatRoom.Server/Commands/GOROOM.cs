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
    [Command("GoRoom")]
    [AsyncLogCommandFilter]
    public class GOROOM : IAsyncCommand<StringPackageInfo>
    {
        private IRoomManager _roomManager;
        public GOROOM(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            string param = package.Parameters.FirstOrDefault();

            if (int.TryParse(param, out int roomId))
            {
                if (_roomManager.GetRoomIds().Contains(roomId))
                {
                    _roomManager.ChangeChatorRoom(roomId, session.SessionID);

                    string successText = $"Well,You have been in Room:{roomId}" + Environment.NewLine;
                    await session.SendAsync(Encoding.UTF8.GetBytes(successText));
                    return;
                }
            }
            string failText = $"Oops,Can not found Room:{string.Join(' ', package.Parameters)}" + Environment.NewLine;
            await session.SendAsync(Encoding.UTF8.GetBytes(failText));
        }
    }
}
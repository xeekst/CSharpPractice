using System;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.SuperSocket.ChatRoom.Client.Implement
{
    public class ChatView
    {
        private ChatUIUnit _chatUnit;
        private ChatSocket _chatSocket;
        public Chator _chator;
        /// <summary>
        /// 响应式 接收消息 信箱
        /// </summary>
        private ISubject<ChatMessageModel> _receivedMessageBox;
        /// <summary>
        /// 响应式 发送消息信箱
        /// </summary>
        private ISubject<ChatMessageModel> _sendMessageBox;
        private bool _isGoChatRoom = false;
        private SemaphoreSlim renderLock = new SemaphoreSlim(1, 1);

        public ISubject<ChatMessageModel> ReceiveMessageBox => _receivedMessageBox;
        public ChatView(ChatSocket chatSocket)
        {
            _chatSocket = chatSocket;
            _chatUnit = new ChatUIUnit();
            _chator = new Chator() { ChatorId = Guid.NewGuid().ToString(), ChatorName = Utils.GenRandomName() };
            _receivedMessageBox = new Subject<ChatMessageModel>();
            _sendMessageBox = new Subject<ChatMessageModel>();
            // 消息监听
            Subscribe();
            _chatSocket.Connect();
            // 开启socket接收消息
            _chatSocket.ListenReceiveMessageOnTask(OnReceiveMessage);
            GoChatRoom();

        }

        public void Stop()
        {
            _chatSocket.Stop();
        }

        public async Task ListenInputForSend()
        {
            await renderLock.WaitAsync();
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Please enter will send message , end with <Enter>.");
                string input = Console.ReadLine();
                _chatUnit.RemoveLastRow(3);
                _chatSocket.SendMessage($"{_chator.ChatorId} {_chator.ChatorName} {input}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _chatUnit.ResetConsole();
                renderLock.Release();
            }
        }
        public void SendMessage(string message)
        {
            ChatMessageModel model = new ChatMessageModel()
            {
                ChatorId = _chator.ChatorId,
                ChatorName = _chator.ChatorName,
                Message = message
            };
            _sendMessageBox.OnNext(model);
        }
        private void OnReceiveMessage(string message)
        {
            string[] parms = message.Split('|');
            if (parms.Length < 3)
            {
                _receivedMessageBox.OnNext(new ChatMessageModel() { Message = message });
            }
            else
            {
                var senderId = parms[0];
                var senderName = parms[1];
                var msg = parms[2];
                ChatMessageModel model = new ChatMessageModel()
                {
                    ChatorId = senderId,
                    ChatorName = senderName,
                    Message = msg
                };
                _receivedMessageBox.OnNext(model);
            }

        }


        private void GoChatRoom()
        {
            string[] roomIds = new string[3] { "1001", "1002", "1003" };
            string roomId = Console.ReadLine();
            while (true)
            {
                _chatSocket.SendRamMessage($"GOROOM {roomId}\r\n");
                if (roomIds.Contains(roomId))
                {
                    Console.WriteLine("break");
                    break;
                }
                else
                {
                    roomId = Console.ReadLine();
                }
            }
            _isGoChatRoom = true;
        }

        private void Subscribe()
        {
            _receivedMessageBox?.Subscribe(async (m) =>
            {
                await renderLock.WaitAsync();
                try
                {
                    string msg = string.Empty;

                    bool isSelf = m.ChatorId == _chator.ChatorId;
                    msg = isSelf ? $"{m.Message} <=:{m.ChatorName}" : $"{m.ChatorName}:=> {m.Message}";
                    if (_isGoChatRoom) _chatUnit.RemoveLastRow();

                    await _chatUnit.ReceiveMessage(msg, isSelf);
                    if (_isGoChatRoom) PrintEnterMessage();


                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    renderLock.Release();
                }
            });
            _sendMessageBox?.Subscribe(async (m) =>
            {
                await renderLock.WaitAsync();
                try
                {
                    _chatUnit.RemoveLastRow();
                    string msg = $"{m.Message} <=:{m.ChatorName}";

                    await _chatUnit.SendMessage(msg);
                    //await _chatUnit.RemoveLastRow();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    renderLock.Release();
                }
            });
        }
        private void PrintEnterMessage()
        {
            Console.WriteLine("Press a 'F' to Input Message; press the 'Q' key to quit.");
        }
    }
}
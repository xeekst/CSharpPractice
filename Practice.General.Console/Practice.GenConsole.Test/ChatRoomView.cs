using System;
using System.Reactive.Subjects;
using System.Threading;

namespace Practice.GenConsole.Test
{
    public class ChatRoomView
    {
        private ChatUIUnit _chatUnit;
        /// <summary>
        /// 响应式 接收消息 信箱
        /// </summary>
        private ISubject<ChatMessageModel> _receivedMessageBox;
        /// <summary>
        /// 响应式 发送消息信箱
        /// </summary>
        private ISubject<ChatMessageModel> _sendMessageBox;

        private SemaphoreSlim renderLock = new SemaphoreSlim(1, 1);

        public ChatRoomView()
        {
            _chatUnit = new ChatUIUnit();
            _receivedMessageBox = new Subject<ChatMessageModel>();
            _sendMessageBox = new Subject<ChatMessageModel>();
            Subscribe();
        }

        public void OnReceiveMessage(ChatMessageModel message)
        {
            //_chatUnit.RemoveLastRow();
            _receivedMessageBox.OnNext(message);
        }

        public void OnSendMessage(ChatMessageModel message)
        {
            //_chatUnit.RemoveLastRow();
            _sendMessageBox.OnNext(message);
        }

        private void Subscribe()
        {
            _receivedMessageBox?.Subscribe(async (m) =>
            {
                await renderLock.WaitAsync();
                try
                {
                    string msg = string.Empty;
                    
                    bool isSelf = m.ChatorId == "1001";
                    msg = isSelf ? $"{m.ChatorName} <=:{m.Message}" : $"{m.ChatorName}:=> {m.Message}";
                    await _chatUnit.ReceiveMessage(msg,m.ChatorId == "1001");
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
    }
}
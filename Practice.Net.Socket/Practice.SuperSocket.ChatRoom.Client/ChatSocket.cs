using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Practice.SuperSocket.ChatRoom.Client.Implement;

namespace Practice.SuperSocket.ChatRoom.Client
{
    public class ChatSocket
    {
        private Socket _socket = null;
        private IPAddress _ip;
        private int _port;
        public ChatSocket(string ipAddress, int port)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ip = IPAddress.Parse(ipAddress);
            _port = port;

        }

        public void Connect()
        {
            _socket.Connect(new IPEndPoint(_ip, _port));
        }
        public void Stop()
        {
            _socket.Disconnect(true);
        }
        public void ListenReceiveMessageOnTask(Action<string> ReceivedMsgFunc)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    //接受从服务器返回的信息
                    string recvStr = "";
                    byte[] recvBytes = new byte[1024];
                    int bytes;
                    bytes = _socket.Receive(recvBytes, recvBytes.Length, 0);    //从服务器端接受返回信息 
                    recvStr += Encoding.UTF8.GetString(recvBytes, 0, bytes);
                    if (string.IsNullOrWhiteSpace(recvStr))
                    {
                        break;
                    }
                    //Console.WriteLine("服务端发来消息：{0}", recvStr);
                    ReceivedMsgFunc(recvStr);
                    //_chatView.OnReceiveMessage(recvStr);
                }
            });
            //Console.WriteLine("服务端发来消息：{0}", recvStr); 
        }
        public void SendMessage(string msg)
        {
            string model = $"BROADCASTROOM {msg}\r\n";
            _socket.Send(Encoding.UTF8.GetBytes(model));
        }

        public void SendRamMessage(string msg)
        {
            _socket.Send(Encoding.UTF8.GetBytes(msg));
        }
    }
}

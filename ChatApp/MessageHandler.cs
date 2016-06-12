using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
    class MessageHandler
    {
        public void SendMessage(String stringToSend, TcpClient tcpClient)
        {
            // Send the message over the network.
            NetworkStream str = tcpClient.GetStream();
            byte[] msg = Encoding.UTF8.GetBytes(stringToSend);
            str.Write(msg, 0, msg.Length);
        }
    }
}

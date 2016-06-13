using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ChatApp
{
    public class RemoteClient
    {
        public TcpClient tcpClient;
        public string clientName;
        public bool hasRecievedUsername = false;

        public void ReadLoop()
        {
            Byte[] bytes = new byte[256];
            String data = null;

            // Get a stream object for reading and writing.
            NetworkStream stream = tcpClient.GetStream();

            int i;
            try
            {
                // Loop to recieve all data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    if (!hasRecievedUsername)
                    {
                        clientName = Encoding.UTF8.GetString(bytes, 0, i);
                        hasRecievedUsername = true;
                        Console.WriteLine("Received username!");
                        Console.WriteLine("Remote Client started with username : " + clientName);
                        NetworkStream str = tcpClient.GetStream();
                        byte[] msg = Encoding.UTF8.GetBytes("Server: Hello, you have connected you cunt! Your name is : " + clientName);
                        str.Write(msg, 0, msg.Length);
                        Console.WriteLine(tcpClient.Connected + "connection status");
                    }
                    // Translates data bytes to UTF8 string.
                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine("Server Recieved: {0}", data);
                }
                Console.WriteLine(this + "Remote client Recieve loop closed!");
            }
            catch (Exception e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public RemoteClient(TcpClient client)
        {
            tcpClient = client;
        }

        public void Disconnect()
        {
            tcpClient.Close();
        }
    }
}

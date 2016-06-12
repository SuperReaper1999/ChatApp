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
    class RemoteClient
    {
        public static TcpClient tcpClient;
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
                    }
                    // Translates data bytes to UTF8 string.
                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine("Recieved: {0}", data);
                }
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

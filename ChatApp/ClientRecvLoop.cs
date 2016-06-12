using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    class ClientRecvLoop
    {
        public TcpClient tcpClient;
        public Form mainWindow;

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
                    // Translates data bytes to UTF8 string.
                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine(this + "Recieved: {0}", data);
                }
                Console.WriteLine("Client receive Loop ended!");
                mainWindow.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(this + "SocketException: {0}", e);
            }
        }

        public ClientRecvLoop(TcpClient client, Form window)
        {
            tcpClient = client;
            mainWindow = window;
        }
    }
}

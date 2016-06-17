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
        public MainWindow mainWindow;
        public bool isInitialConnection = true;

        public void ReadLoop()
        {
            Byte[] bytes = new byte[256];
            String data = null;

            // Get a stream object for reading and writing.
            NetworkStream stream = tcpClient.GetStream();

            int i;
            try
            {
                // Loop to recieve all data sent by the server.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    Console.WriteLine("ClientRecvLoop is running happily?");
                    // Translates data bytes to UTF8 string.
                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine("Client Recieved: {0}", data);

                    mainWindow.Invoke((MethodInvoker)delegate
                    {
                        // Updates the chat history from the forms thread.
                        mainWindow.chatHistory.AppendText(data);
                        mainWindow.chatHistory.AppendText(Environment.NewLine);
                    });

                    if (data.Contains("Server: Hello, you have connected you cunt! Your name is :") && isInitialConnection)
                    {
                        string[] dataSplit = data.Split(':');
                        mainWindow.myName = dataSplit[dataSplit.Length - 1];
                        Console.WriteLine("Recieved initial connection message, current connection status = " + tcpClient.Connected + " and username = " + mainWindow.myName);
                        isInitialConnection = false;
                    }
                }
                Console.WriteLine("Client receive Loop ended!");

                mainWindow.Invoke((MethodInvoker)delegate
                {
                    // close the form on the forms thread
                    mainWindow.Close();
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(this + "SocketException: {0}", e);
            }
        }

        public ClientRecvLoop(TcpClient client)
        {
            MainWindow chatWindow = new MainWindow();
            chatWindow.Show();
            tcpClient = client;
            mainWindow = chatWindow;
            chatWindow.tcpClient = this.tcpClient;
        }
    }
}

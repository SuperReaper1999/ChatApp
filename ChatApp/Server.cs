using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatApp
{
    class Server
    {
        public static int portNumber = 30000;
        public static TcpListener connectionListener = null;
        public static List<RemoteClient> connectedClients = new List<RemoteClient>();
        public void Main()
        {
            try
            {
                IPAddress localAddr = IPAddress.Parse("192.168.0.32");

                connectionListener = new TcpListener(localAddr, portNumber);

                // Start listening for client requests.
                connectionListener.Start();

                // Enter the listening loop.
                while (true)
                {
                    Console.WriteLine("Wating for some cunt to connect.....");

                    // Perform a blocking call to accept requests.
                    TcpClient client = connectionListener.AcceptTcpClient();
                    Console.WriteLine("Fucking connected!" + client.Client.RemoteEndPoint);
                    RemoteClient cl = new RemoteClient(client);
                    connectedClients.Add(cl);
                    Thread clientThread = new Thread(new ThreadStart(cl.ReadLoop));
                    clientThread.Start();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
        public static void DisconnectClients()
        {
            foreach (RemoteClient c in connectedClients)
            {
                Console.WriteLine("Server forcibly disconnecting " + c.clientName + c.tcpClient.Client.RemoteEndPoint);
                c.Disconnect(); 
            }
            if (connectionListener != null)
            {
                connectionListener.Stop();
            }
        }
    }
}

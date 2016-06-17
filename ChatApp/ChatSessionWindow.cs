using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ChatApp
{

    public partial class ChatSessionWindow : Form
    {
        public static Form chatSessionWindow;

        public ChatSessionWindow()
        {
            InitializeComponent();
            usernameTextBox.Text = Environment.UserName;
            chatSessionWindow = this;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient tcpClient = new TcpClient(ipBox.Text, Server.portNumber);
                NetworkStream stream = tcpClient.GetStream();
                ClientRecvLoop clientRecLoop = new ClientRecvLoop(tcpClient);
                Thread clientRecLoopThread = new Thread(new ThreadStart(clientRecLoop.ReadLoop));
                clientRecLoopThread.IsBackground = true;
                clientRecLoopThread.Start();
                byte[] msg = Encoding.UTF8.GetBytes(usernameTextBox.Text);
                stream.Write(msg, 0, msg.Length);
                this.Hide();
            }
            catch (Exception exception)
            {
                Console.WriteLine(this + "SocketException: {0}", exception);
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            Thread serverThread = new Thread(new ThreadStart(server.Main));
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void ChatSessionWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.DisconnectClients();
            Console.WriteLine("Chat session window closed, all clients disconnected!" + this);
        }
    }
}

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
                ClientRecvLoop clientRecLoop = new ClientRecvLoop(tcpClient, this);
                Thread clientRecLoopThread = new Thread(new ThreadStart(clientRecLoop.ReadLoop)); 
                // now its called when the client connects.... I don't understand why but it works.
                // I'm assuming something that follows this line is a blocking call which therefor does not allow the code after it to be executed so
                // the client thread isn't started until the blocking call is completed and closing the program forces that call to end which then allows it to continue and start the thread
                // Am I correct in this assumption?
                clientRecLoopThread.Start();
                byte[] msg = Encoding.UTF8.GetBytes(usernameTextBox.Text);
                stream.Write(msg, 0, msg.Length);
                MainWindow ChatWindow = new MainWindow();
                this.Hide();
                ChatWindow.ShowDialog();
                /*
                ClientRecvLoop clientRecLoop = new ClientRecvLoop(tcpClient, this);
                Thread clientRecLoopThread = new Thread(new ThreadStart(clientRecLoop.ReadLoop)); // only called once the client disconnects... hmm...
                clientRecLoopThread.Start();*/
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
            serverThread.Start();
        }

        private void ChatSessionWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.DisconnectClients();
            Console.WriteLine("Chat session window closed, all clients disconnected!" + this);
        }
    }
}

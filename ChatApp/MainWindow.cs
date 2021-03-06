using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class MainWindow : Form
    {
        public TcpClient tcpClient;
        public RemoteClient remoteClient;
        public string myName;

        MessageHandler messageHandler = new MessageHandler();
        public MainWindow()
        {
            InitializeComponent();
            userList.Items.Add("test thing");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("Hey I closed!");
            ChatSessionWindow.chatSessionWindow.Show();
            Server.DisconnectClients();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(messageBox.Text))
            {
                messageHandler.SendMessage(myName + ": " + messageBox.Text, tcpClient);
                messageBox.Clear();
            }
        }

        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                sendButton_Click(null,null);
            }
        }

        private void chatHistory_TextChanged(object sender, EventArgs e)
        {
            chatHistory.ScrollToCaret();
        }
    }
}

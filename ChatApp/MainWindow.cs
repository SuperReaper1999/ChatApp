using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAndDisconnect(this);
        }

        public static void CloseAndDisconnect(MainWindow window)
        {
            window.Close(); // Stack overflow here.
            Console.WriteLine("Hey I (The main window) closed!");
            ChatSessionWindow.chatSessionWindow.Show();
            Server.DisconnectClients();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseAndDisconnect(this);
        }
    }
}

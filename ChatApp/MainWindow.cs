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
    }
}

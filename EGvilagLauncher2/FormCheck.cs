using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Security;
using Microsoft.Win32;

namespace EGvilagLauncher2
{
    public partial class FormCheck : Form
    {
        private Socket clientSocket;

        public RegistryKey key;

        public FormCheck()
        {
            InitializeComponent();
        }

        private void FormCheck_Load(object sender, EventArgs e)
        {
            try
            {
                key = Registry.CurrentUser.OpenSubKey("Software\\EGvilagLauncher", true);
                
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.BeginConnect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888), new AsyncCallback(ConnectCallback), null);
            }
            catch (SecurityException ex)
            {
                MessageBox.Show("Nem sikerült elérnem a regisztrációs adatbázist. \r\n Rendszergazda ", "Biztonsági hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                (this.Parent as FormMain).Close();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConnectCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndConnect(AR);
                //Now we can enable Send and anything
                SendData("Hello!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SendData(string message)
        {
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
            }
            catch (SocketException) { } //Server closed
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }

        private void SendCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndSend(AR);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FormCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((clientSocket != null) && (clientSocket.Connected))
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
    }
}

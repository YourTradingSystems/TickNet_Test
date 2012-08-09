using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TickNet
{
    public partial class ConnectionDlg : Form
    {
        private RegistryKey regKey;
        public String Host;
        public String Login;
        public String Password;
        public ConnectionDlg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Host = textHost.Text;
            Login = textLogin.Text;
            Password = textPass.Text;
            regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\TickNet\\DBServer");
            regKey.SetValue("DB_Server",textHost.Text);
            regKey.SetValue("DB_Login",textLogin.Text);
            regKey.SetValue("DB_Pass",textPass.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void ConnectionDlg_Load(object sender, EventArgs e)
        {
            regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\TickNet\\DBServer");
            textHost.Text = regKey.GetValue("DB_Server").ToString();
            textLogin.Text = regKey.GetValue("DB_Login").ToString();
            textPass.Text = regKey.GetValue("DB_Pass").ToString();
        }
    }
}

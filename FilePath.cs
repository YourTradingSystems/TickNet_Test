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
    public partial class frmFilePath : Form
    {
        private string currentFp;
        private string newFp;

        public frmFilePath()
        {
            InitializeComponent();
        }

        public string cFp 
        {
            get { return currentFp; }
        }

        public string nFp
        {
            set { newFp = value; }
        }

        public void SaveFP()
        {
            newFp = txtNewFP.Text;
            if (string.IsNullOrEmpty(currentFp))
            {
                MessageBox.Show("Need a value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Save user prefs to reg.
                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.CreateSubKey("Software\\TickNet\\KeyRes");
                regKey.SetValue("FilePath", newFp);
                lblStatus.Text = "Settings saved in registry";
            }
        }

        public string GetFP()
        {
            RegistryKey regKey1 = Registry.CurrentUser;
            regKey1 = regKey1.CreateSubKey("Software\\TickNet\\KeyRes");
            currentFp = regKey1.GetValue("FilePath", "C:\\").ToString();
            txtFilePath.Text = currentFp;

            return currentFp;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFP();
        }

        private void frmFilePath_Load(object sender, EventArgs e)
        {
            GetFP();
            SetToolTip();
        }

        private void SetToolTip()
        {
            ToolTip tt = new ToolTip();

            tt.SetToolTip(this.btnSave, "Save file path and filename to the registry");
            tt.SetToolTip(this.btnExit, "Exit the form");
            tt.SetToolTip(this.txtNewFP, "Enter new file path");
            tt.SetToolTip(this.txtFilePath, "Current file path");
        }

        private void txtNewFP_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}

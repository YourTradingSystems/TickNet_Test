using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TickNet
{
    public partial class frmWait : Form
    {
        private bool visible = false;
        public frmWait()
        {
            InitializeComponent();
        }

        private void requestsLable_TextChanged(object sender, EventArgs e)
        {
            if (!IsDisposed)
            {
                if ((requestsLable.Text == "0") && visible)
                    this.Hide();
            }
        }

        private void requestsLable_Click(object sender, EventArgs e)
        {

        }

        private void frmWait_Validated(object sender, EventArgs e)
        {
            visible = true;
        }

        private void frmWait_FormClosed(object sender, FormClosedEventArgs e)
        {
            visible = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace DataNet
{
    public partial class About : Form
    {
        const string vMajor = "3";
        const string vMinor = "3";
        const string vBuild = "0";
        const string vRevision = "0";

        
        public About()
        {
            InitializeComponent();
            vNumber();
        }

        private void llWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("iexplore.exe","Coming soon");      // "http://www.calm-markets.co.uk/index.php");
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("About", "llWeb_LinkClicked", ex);
              
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

       public  void vNumber()
       {
          //Type type = Type.GetType ("System.Int32");
          //Assembly assembly = Assembly.GetAssembly (type);
          //AssemblyName assemblyName = assembly.GetName();
          //Version version = assemblyName.Version;
          
          //label6.Text = version.Major.ToString() + "." + version.Minor + "." + version.Build + "." + version.Revision;
           label6.Text =  vMajor + "." + vMinor + "." + vBuild + "." + vRevision;
       }

      
   
    }
}

using System.Diagnostics;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using CQG;


namespace TickNet
{
	sealed class modErrorHandler
	{
		
		/// <summary>
		/// Handles the error and shows a message box.
		/// </summary>
		/// <param name="modName">
		/// Module name, in which the error has occurred.
		/// </param>
		/// <param name="funcName">
		/// Function name, in which the error has occurred.
		/// </param>
		/// <param name="ex">
		/// The exception generated in the described function of the described module.
		/// </param>
		public static void ShowError(string modName, string funcName, Exception ex)
		{
			string sMsg;
			
			sMsg = "Module : " + modName + Environment.NewLine;
			sMsg += "Function : " + funcName + Environment.NewLine;
		    sMsg += "Thread : " + Thread.CurrentThread;
			sMsg += "Source : " + ex.Source + Environment.NewLine;
			sMsg += "Status : " + ex.GetType().ToString() + Environment.NewLine;
			sMsg += "Description : " + ex.Message;

            MessageBox.Show(sMsg, "TickNet", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
	}
	
}

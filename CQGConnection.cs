using System.Diagnostics;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using CQG;

namespace TickNet
{
    class CQGConnection 
    {
        // The CQGCEL object, which encapsulates the main functionality of CQG API
        //  [field: System.CLSCompliant(false)] 
        //public CQGCEL CEL;
        private int m_NotStarted = 0;

        public void CreateConnection(CQGCEL CEL)
        {
            try
            {
                // Creates the CQGCEL object
                CEL = new CQGCEL();
                CEL.DataError += new CQG._ICQGCELEvents_DataErrorEventHandler(CEL_DataError);
                CEL.DataConnectionStatusChanged += new CQG._ICQGCELEvents_DataConnectionStatusChangedEventHandler(CEL_DataConnectionStatusChanged);
                CEL.APIConfiguration.ReadyStatusCheck = eReadyStatusCheck.rscOff;
                CEL.APIConfiguration.CollectionsThrowException = false;
                CEL.APIConfiguration.TimeZoneCode = eTimeZone.tzGreenwich;
                // Disables the controls
                CEL_DataConnectionStatusChanged(eConnectionStatus.csConnectionDown);
                // Starts up the CQGCEL
                CEL.Startup();

                
             }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("CQGConnection.cs", "CreateConnection", ex);
            }
        }

        /// <summary>
        /// This event is fired, when CQGCEL detects some abnormal discrepancy between data expected and data received.
        /// </summary>
        /// <param name="cqg_error">
        /// The object, in which the error has occurred.
        /// </param>
        /// <param name="error_description">
        /// The string, describing the error.
        /// </param>
        private void CEL_DataError(object cqg_error, string error_description)
        {
            try
            {
                if (cqg_error is CQGError)
                {
                    CQGError cqgErr = (CQGError)cqg_error;

                    if (cqgErr.Code == 102)
                    {
                        error_description += " Restart the application.";
                    }
                    else if (cqgErr.Code == 125)
                    {
                        error_description += " Turn on CQG Client and restart the application.";
                    }
                }

                MessageBox.Show(error_description, "TickNet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("CQGConnection.cs", "CEL_DataError", ex);
            }
        }

        /// <summary>
        /// This event is fired, when some changes occur in the connection with CQG data server.
        /// </summary>
        /// <param name="newStatus">
        /// The current status of the connection with the data server.
        /// </param>
        private void CEL_DataConnectionStatusChanged(CQG.eConnectionStatus new_status)
        {
            System.Drawing.Color BackCol;

            try
            {
                if (new_status == eConnectionStatus.csConnectionUp)
                {
                    BackCol = System.Drawing.Color.FromArgb(0, 209, 15);
                    m_NotStarted = 1;
                    //sInfo = "DATA Connection is UP";
                }
                else if (new_status == eConnectionStatus.csConnectionDelayed)
                {
                    BackCol = System.Drawing.Color.FromArgb(255, 114, 0);
                    //sInfo = "DATA Connection is Delayed";
                }
                else
                {
                    BackCol = System.Drawing.Color.FromArgb(255, 114, 0);
                    //sInfo = "DATA Connection is Down";
                }
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("CQGConnection.cs", "CEL_DataConnectionStatusChanged", ex);
            }
        }

        public int systemStatus()
        {
            return m_NotStarted;
        }



    }
}

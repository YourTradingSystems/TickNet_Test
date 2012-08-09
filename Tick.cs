using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CQG;

namespace TickNet
{
    class Tick
    {
        private CQGCEL m_CEL;
        /// FullName of selected instrument
        private string m_InstrumentFullName;
        private string m_selectedSym;
        private bool m_InitializingCEL = false;
     

        private void Start_CEL()
      {
         try
         {
           // m_InitializingCEL = true;

            m_CEL = new CQGCEL();

            m_CEL.CELStarted += new _ICQGCELEvents_CELStartedEventHandler(CEL_CELStarted);
            m_CEL.DataConnectionStatusChanged += new _ICQGCELEvents_DataConnectionStatusChangedEventHandler(CEL_DataConnectionStatusChanged);
            //m_CEL.DataError += new _ICQGCELEvents_DataErrorEventHandler(CEL_DataError);

            m_CEL.IncorrectSymbol += new _ICQGCELEvents_IncorrectSymbolEventHandler(CEL_IncorrectSymbol);
            m_CEL.InstrumentSubscribed += new _ICQGCELEvents_InstrumentSubscribedEventHandler(CEL_InstrumentSubscribed);
            //m_CEL.InstrumentChanged += new _ICQGCELEvents_InstrumentChangedEventHandler(CEL_InstrumentChanged);
            //m_CEL.InstrumentDOMChanged += new _ICQGCELEvents_InstrumentDOMChangedEventHandler(CEL_InstrumentDOMChanged);

            m_CEL.APIConfiguration.CollectionsThrowException = false;
            m_CEL.APIConfiguration.ReadyStatusCheck = eReadyStatusCheck.rscOff;
            m_CEL.APIConfiguration.TimeZoneCode = eTimeZone.tzCentral;
            m_CEL.APIConfiguration.DefaultInstrumentSubscriptionLevel = eDataSubscriptionLevel.dsQuotesAndBBA;
            //m_CEL.APIConfiguration.SnapshotPeriod = Convert.ToInt32(txtSnapshotPeriod.Text);
            //m_CEL.APIConfiguration.DOMUpdatesMode = m_DOMUpdatesMode;
            //m_CEL.APIConfiguration.DOMUpdatesPeriod = Convert.ToInt32(txtDOMUpdatePeriod.Text);

            //m_CEL.Startup();
         }
         catch (Exception ex)
         {
             modErrorHandler.ShowError("ticknet", "Start_CEL", ex);
         }
      }

        private void CEL_CELStarted()
        {
            try
            {
                
                    m_CEL.NewInstrument(m_selectedSym);
            }
            catch (Exception ex)
            {
               modErrorHandler.ShowError("ticknet", "Start_CEL", ex);
            }
        }

        

        /// <summary>
        /// This event is fired, when some changes occur in the connection with the CQG data server.
        /// </summary>
        /// <param name="newStatus">
        /// The current status of the connection with the data server.
        /// </param>
        private void CEL_DataConnectionStatusChanged(eConnectionStatus newStatus)
        {
            try
            {
                string info;
                System.Drawing.Color BackCol;

                if (newStatus != eConnectionStatus.csConnectionUp)
                {
                    BackCol = System.Drawing.Color.FromArgb(255, 114, 0);
                    info = "DATA Connection is " + (newStatus == eConnectionStatus.csConnectionDelayed ?
                       "Delayed" : "Down").ToString();

                    //txtSymbol.Text = "";
                    //btnSubscribe.Enabled = false;
                }
                else
                {
                    BackCol = System.Drawing.Color.FromArgb(192, 209, 205);
                    info = "DATA Connection is UP";
                    MessageBox.Show(info);
                    //SetSubscribeButtonStatus();
                }

                //lblDataConnection.BackColor = BackCol;
                //lblDataConnection.Text = info;
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("ticknet", "CEL_DataConnectionStatusChanged", ex);
            }
        }





        //private CQGInstrument Instrument = new CQGInstrument();
        /// <summary>
        /// This event is fired when a new instrument is resolved and subscribed.
        /// </summary>
        /// <param name="symbol">
        /// The commodity symbol that was requested by the user in the NewInstrument method.
        /// </param>
        /// <param name="Instrument">
        /// The resolved CQGInstrument object.
        /// </param>
        public void CEL_InstrumentSubscribed(string symbol, CQGInstrument instrument)
        {

            string p = instrument.FullName.ToString();  //.DOMAsks.ToString();

            MessageBox.Show(p );


            //if (m_InitializingCEL || instrument == null) return;

            //try
            //{
            //    if (m_reSubcriptionCount > 0)
            //    {
            //        m_reSubcriptionCount--;
            //        Debug.WriteLine("m_reSubcriptionCount: " + symbol);
            //        if (m_reSubcriptionCount == 0)
            //        {
            //            SetSubscriptionLevel();
            //        }
            //        return;
            //    }

            //    int index = lstInstruments.Items.IndexOf(instrument.FullName);
            //    if (index == -1)
            //    {
            //        lstInstruments.Items.Add(instrument.FullName);
            //        //Changing the selection triggers a call to DisplayQuotesAndDynamicProperties
            //        lstInstruments.SelectedIndex = lstInstruments.Items.Count - 1;
            //    }
            //    else
            //    {
            //        lstInstruments.SelectedIndex = index;
            //    }

            //    btnSubscribe.Enabled = false;
            //    txtSymbol.Text = "";
            //    txtSymbol.Focus();

            //    SetSubscriptionLevel();
            //}
            //catch (Exception ex)
            //{
            //    ErrorHandler.HandleError("frmInstrumentProperties", "CEL_InstrumentSubscribed -" + symbol, ex);
            //}
        }

        /// <summary>
        /// This event is fired, when a not tradable symbol name is passed to the NewInstrument method.
        /// </summary>
        /// <param name="symbl">
        /// The name of the incorrect symbol, i.e., what was passed to the NewInstrument method.
        /// </param>
        public void CEL_IncorrectSymbol(string symbl)
        {
            try
            {
                //SetSubscribeButtonStatus();

                MessageBox.Show("tick.cs   JEFF");

                //string p = "Invalid Symbol";

                //txtSymbol.Focus();
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("Tick.cs", "CEL_IncorrectSymbol", ex);
            }
        }
        
        
        public void cel_InstrumentSubscribed(string Symbl)  //, CQGInstrument Instrument)
        {
            //Instrument.get_Tag("CLAH2");
            //CQGInstrument Instrument = new CQGInstrument();
           


            MessageBox.Show(Symbl + "   JEFF");
            //if (Instrument == null)
            //{
            //    // Failed to subscribe instrument 
            //    return;
            //}

            ////if (Instrument.get_Tag(strSomeTagName) == true)
            //if (Instrument != null)
            //{
            //    // Instrument was already subscribed once 
            //}
            //else
            //{
            //    Instrument.set_Tag(strSomeTagName, true);
            //    // Instrument subscribed first time 
            //}
            //// Here we tell CQGCEL to send us ask/bid change notifications along 
            //// with quote changes 
            //Instrument.DataSubscriptionLevel = eDataSubscriptionLevel.dsQuotesAndBBA;
            //MessageBox.Show(Symbl + "   JEFF");

            //Console.WriteLine(Symbl);
            //Console.WriteLine(Instrument.Description);
            //Console.WriteLine(Instrument.YearString);
            //Console.WriteLine(Instrument.MonthChar);
        }

       
    }
}

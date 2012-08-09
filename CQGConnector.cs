using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQG;

namespace TickNet
{
    class CQGConnector
    {
        private CQG.CQGCEL CEL;
        public CQGConnector()
        {
            CEL = new CQGCEL();
            //m_CEL.CELStarted += new _ICQGCELEvents_CELStartedEventHandler(CEL_CELStarted);
            //m_CEL.DataConnectionStatusChanged += new _ICQGCELEvents_DataConnectionStatusChangedEventHandler(CEL_DataConnectionStatusChanged);
            //m_CEL.DataError += new _ICQGCELEvents_DataErrorEventHandler(CEL_DataError);
            //m_CEL.IncorrectSymbol += new _ICQGCELEvents_IncorrectSymbolEventHandler(CEL_IncorrectSymbol);
            //m_CEL.InstrumentSubscribed += new _ICQGCELEvents_InstrumentSubscribedEventHandler(CEL_InstrumentSubscribed);
            //m_CEL.InstrumentDOMChanged += new _ICQGCELEvents_InstrumentDOMChangedEventHandler(CEL_InstrumentDOMChanged);
            //m_CEL.InstrumentDOMChanged += this.CEL_InstrumentDOMChanged;
            CEL.APIConfiguration.CollectionsThrowException = false;
            CEL.APIConfiguration.ReadyStatusCheck = eReadyStatusCheck.rscOff;
            CEL.APIConfiguration.TimeZoneCode = eTimeZone.tzGMT;
            CEL.APIConfiguration.DefaultInstrumentSubscriptionLevel = eDataSubscriptionLevel.dsQuotesAndBBA;
            //m_CEL.APIConfiguration.SnapshotPeriod = Convert.ToInt32(txtSnapshotPeriod.Text);
            CEL.APIConfiguration.DOMUpdatesMode = eDOMUpdatesMode.domUMDynamic;
            //m_CEL.APIConfiguration.DOMUpdatesPeriod = Convert.ToInt32(txtDOMUpdatePeriod.Text);
            //m_ver = m_CEL.Environment.CELVersion.ToString();

            CEL.Startup();
        }
        public void addStartedListener(_ICQGCELEvents_CELStartedEventHandler item)
        {
            CEL.CELStarted += item;
        }
        public void removeStartedListener(_ICQGCELEvents_CELStartedEventHandler item)
        {
            CEL.CELStarted -= item;
        }
        public void addDataConnectionStatusChangedListener(_ICQGCELEvents_DataConnectionStatusChangedEventHandler item)
        {
            CEL.DataConnectionStatusChanged += item;
        }
        public void removeDataConnectionStatusChangedListener(_ICQGCELEvents_DataConnectionStatusChangedEventHandler item)
        {
            CEL.DataConnectionStatusChanged -= item;
        }
        public void addDataErrorListener(_ICQGCELEvents_DataErrorEventHandler item)
        {
            CEL.DataError += item;
        }
        public void removeDataErrorListener(_ICQGCELEvents_DataErrorEventHandler item)
        {
            CEL.DataError -= item;
        }
        public void addIncorrectSymbolListener(_ICQGCELEvents_IncorrectSymbolEventHandler item)
        {
            CEL.IncorrectSymbol += item;
        }
        public void removeIncorrectSymbolListener(_ICQGCELEvents_IncorrectSymbolEventHandler item)
        {
            CEL.IncorrectSymbol -= item;
        }
        public  void addInstrumentSubscribedListener(_ICQGCELEvents_InstrumentSubscribedEventHandler item)
        {
            CEL.InstrumentSubscribed += item;
        }
        public void removeInstrumentSubscribedListener(_ICQGCELEvents_InstrumentSubscribedEventHandler item)
        {
            CEL.InstrumentSubscribed -= item;
        }
        public void addInstrumentDOMChangedListene(_ICQGCELEvents_InstrumentDOMChangedEventHandler item)
        {
            CEL.InstrumentDOMChanged += item;
        }
        public void removeInstrumentDOMChangedListene(_ICQGCELEvents_InstrumentDOMChangedEventHandler item)
        {
            CEL.InstrumentDOMChanged -= item;
        }
        public void CQG_Start()
        {
            try
            {
                CEL.Startup();
            }
            catch (Exception ex)
            {

                modErrorHandler.ShowError("ticknet", "Start_CEL", ex);
            }
        }
        public void CQG_Stop()
        {
            try
            {
                CEL.Shutdown();
            }
            catch (Exception ex)
            {

                modErrorHandler.ShowError("ticknet", "Stop_CEL", ex);
            }
        }
        public CQGCEL ICEL
        {
            get { return CEL; }
        }
    }
}

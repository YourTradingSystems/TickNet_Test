using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CQG;
using Microsoft.Win32;
using MySql.Data.MySqlClient;


namespace TickNet
{
    
    public partial class frmTickNet : Form
    {
        // The CQGCEL object, which encapsulates the main functionality of CQG API
        //  [field: System.CLSCompliant(false)] 
        private List<string> symNames = new List<string>();
        private uint ticks = 0;
        private string m_sInfo = "";
        private uint m_qroup_ID = 0;
        private RegistryKey regKey;

        private string MyConString;
                                //"PASSWORD=EU8bKrrmJ9AHJApw;";   //6w7muMhJunuD49nn;";
        //private CQG.CQGCEL m_CEL;
        
        private int m_NotStarted = 0;
        private string m_Hour;
        private string m_Min;
        private string m_Sec;
        private string m_Month;
        private string m_Day;
        private string m_Year;
  
        private string m_tableName;
        private string m_path ;
        private string m_selectedSym = "";
        // CQGCEL line time
        private DateTime m_LineTime;
        private frmFilePath fp;
        private MySqlConnection connection;
        private MySqlCommand command;
        private List<String> queryList;
        private Mutex MySQL_Thread_Mutex;
        private Semaphore MySQL_Thread_Semaphore;
        private bool isCanceled;
        private uint requests;
        private frmWait f_wait;
        private CQGConnector connector;
        private bool isNewTrade;
        private bool firstTride;
        private double PrevTradePrice;
        private double PrevTradeVol;
        private DateTime PrevTradeTime;

        public frmTickNet()
        {
            InitializeComponent();
        }

        private void frmTickNet_Load(object sender, EventArgs e)
        {
            ConnectionDlg conDlg = new ConnectionDlg();
            if (conDlg.ShowDialog() == DialogResult.OK)
            {
                MyConString = "SERVER=" + conDlg.Host + ";" +
                              "DATABASE=cqg_info;" +
                              "UID=" + conDlg .Login+ ";" + "PASSWORD="+conDlg.Password;
            }
            else
            {
                this.Close();
            }
            regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\TickNet");
            txtSymbol.Text = regKey.GetValue("Symbol").ToString();
            requests = 1;
            setTableDate();
            //fp = new frmFilePath();
            //m_path = fp.GetFP();
            //LoadFields();
            btnCancel.Enabled = false;
            btnStop.Enabled = false;
            this.Text += " " + System.Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy HH:mm:ss"); //form text
            SetToolTip();
            MySQL_Thread_Mutex = new Mutex(false, "MySQL_Thread_Mutex");
            MySQL_Thread_Semaphore = new Semaphore(0, 999999);
            //MySQL_Thread_Semaphore.
            isCanceled = false;
            f_wait = new frmWait();
            queryList = new List<string>();
        }
        private void setTableDate()
        {
            m_Hour = System.DateTime.Now.Hour.ToString();
            m_Min = System.DateTime.Now.Minute.ToString();
            m_Sec = System.DateTime.Now.Second.ToString();
            m_Month = System.DateTime.Now.Month.ToString();
            m_Day = System.DateTime.Now.Day.ToString();
            m_Year = System.DateTime.Now.Year.ToString();
        }

        private void SetToolTip()
        {
            ToolTip tt = new ToolTip();

            tt.SetToolTip(this.btnStart, "Run TickNet real time data collection");
            tt.SetToolTip(this.btnCancel, "Cancel the symbol run");
            tt.SetToolTip(this.btnStop, "Stop the symbol run");
            tt.SetToolTip(this.btnExit, "Close and Exit TickNet");
            tt.SetToolTip(this.lbxCurrentFields, "select data fields for data collection");
            tt.SetToolTip(this.txtSymbol, "Enter symbol name");
            tt.SetToolTip(this.nudDOMDepth, "Select DOM level");
        }

        private void Start_CEL()
        {/*
            try
            {
                m_CEL = new CQGCEL();

                m_CEL.CELStarted += new _ICQGCELEvents_CELStartedEventHandler(CEL_CELStarted);
                m_CEL.DataConnectionStatusChanged += new _ICQGCELEvents_DataConnectionStatusChangedEventHandler(CEL_DataConnectionStatusChanged);
                m_CEL.DataError += new _ICQGCELEvents_DataErrorEventHandler(CEL_DataError);
                m_CEL.IncorrectSymbol += new _ICQGCELEvents_IncorrectSymbolEventHandler(CEL_IncorrectSymbol);
                m_CEL.InstrumentSubscribed += new _ICQGCELEvents_InstrumentSubscribedEventHandler(CEL_InstrumentSubscribed);
                //m_CEL.InstrumentDOMChanged += new _ICQGCELEvents_InstrumentDOMChangedEventHandler(CEL_InstrumentDOMChanged);
                m_CEL.InstrumentDOMChanged += this.CEL_InstrumentDOMChanged;
                m_CEL.APIConfiguration.CollectionsThrowException = false;
                m_CEL.APIConfiguration.ReadyStatusCheck = eReadyStatusCheck.rscOff;
                m_CEL.APIConfiguration.TimeZoneCode = eTimeZone.tzCentral;
                m_CEL.APIConfiguration.DefaultInstrumentSubscriptionLevel = eDataSubscriptionLevel.dsQuotesAndBBA;
                //m_CEL.APIConfiguration.SnapshotPeriod = Convert.ToInt32(txtSnapshotPeriod.Text);
                m_CEL.APIConfiguration.DOMUpdatesMode = eDOMUpdatesMode.domUMDynamic;
                //m_CEL.APIConfiguration.DOMUpdatesPeriod = Convert.ToInt32(txtDOMUpdatePeriod.Text);
                //m_ver = m_CEL.Environment.CELVersion.ToString();
                
                m_CEL.Startup();
            }
            catch (Exception ex)
            {
                
                modErrorHandler.ShowError("ticknet", "Start_CEL", ex);
            }*/
            connector = new CQGConnector();
            connector.addStartedListener(CEL_CELStarted);
            connector.addDataConnectionStatusChangedListener(CEL_DataConnectionStatusChanged);
            connector.addDataErrorListener(CEL_DataError);
            connector.addIncorrectSymbolListener(CEL_IncorrectSymbol);
            connector.addInstrumentSubscribedListener(CEL_InstrumentSubscribed);
            connector.addInstrumentDOMChangedListene(CEL_InstrumentDOMChanged);
        }

        /// <summary>
        /// Sets the new time
        /// </summary>
        /// <returns>
        /// New time value
        /// </returns>
        public DateTime LineTime
        {
            set
            {
                m_LineTime = value;
            }
        }

        private void CEL_InstrumentDOMChanged(CQGInstrument instrument, CQGDOMQuotes prevAsks, CQGDOMQuotes prevBids)
        {
            ticks += 1;
            if (!isCanceled)
            {
                tsAskDpth.Text = Convert.ToString(instrument.DOMAsks.Count);
                tsBidDpth.Text = Convert.ToString(instrument.DOMBids.Count);
                
                if (!firstTride)
                {

                    if ((instrument.Trade.Price != PrevTradePrice) || (instrument.Trade.Volume != PrevTradeVol) || (instrument.Timestamp != PrevTradeTime))
                    {
                        isNewTrade = true;
                    }
                    else
                    {
                        isNewTrade = false;
                    }
                    PrevTradePrice = instrument.Trade.Price;
                    PrevTradeVol = instrument.Trade.Volume;
                    PrevTradeTime = instrument.Timestamp;
                }
                else
                {
                    PrevTradePrice = instrument.Trade.Price;
                    PrevTradeVol = instrument.Trade.Volume;
                    PrevTradeTime = instrument.Timestamp;
                }
                firstTride = false;
                String _query = QueryBuilder.InsertData(m_tableName, instrument, Convert.ToInt32(nudDOMDepth.Value), m_qroup_ID,isNewTrade);
                RunSQL(_query, "InsertData");
                m_qroup_ID +=1;
            }
            else
            {
                RunSQL("DROP TABLE IF EXISTS " + m_tableName, "flush");
                //m_CEL.Shutdown();
                connector.CQG_Stop();
                //isCanceled = false;
            }
        } 

        private void CEL_CELStarted()
        {
            try
            {
                connector.ICEL.NewInstrument(m_selectedSym);
             //  MessageBox.Show(m_ver);
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("ticknet", "Start_CEL", ex);
            }
        }

        /// <summary>
        /// This event is fired, when an instrument is resolved and subscribed
        //' Description: Occurs when an instrument is resolved and subscribed
        //'
        //' Parameters:
        //'    symbol_ (string) <in> - the symbol used in the btnSubscribe function
        //'    Instrument (CQGInstrument) <in> - the subscribed CQGInstrument
        public void CEL_InstrumentSubscribed(string symbol, CQG.ICQGInstrument instrument)
        {
            try
            {
                if (instrument == null)
                {
                    // Failed to subscribe instrument 
                    //lblSymbolStatus.Text = "Not Valid";
                    return;
                }
                System.Drawing.Color BackCol;
                BackCol = System.Drawing.Color.FromArgb(0, 255, 0);
                //lblSymbolStatus.Text = "Not Valid";
                lblSymbolStatus.BackColor = BackCol;
                instrument.DataSubscriptionLevel = eDataSubscriptionLevel.dsQuotesAndDOM;
                //lblSymbolStatus.Text = "Valid";
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("ticknet", "CEL_InstrumentSubscribed", ex);
            }
        }
       
        /// <summary>
        /// This event is fired, when a not tradable symbol name is passed to the NewInstrument method.
        /// </summary>
        /// <param name="symbl">
        /// The name of the incorrect symbol, i.e., what was passed to the NewInstrument method.
        /// </param>
        public void CEL_IncorrectSymbol(string symbol)
        {
            try
            {
                System.Drawing.Color BackCol;
                BackCol = System.Drawing.Color.FromArgb(255,0 ,0);
                //lblSymbolStatus.Text = "Not Valid";
                lblSymbolStatus.BackColor = BackCol;
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("ticknet", "CEL_IncorrectSymbol", ex);
            }
        }

     
        /// <summary>
        /// Shuts down CEL.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// A CancelEventArgs that contains the event data.
        /// </param>
        private void frmTickNet_FormClosing(object sender, FormClosingEventArgs e)
        {
            connector.CQG_Stop();
        }

        private void lnkCM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("iexplore.exe", "Coming soon");      // "http://www.calm-markets.co.uk/index.php");
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("frmTickNet", "lnkCM_LinkClicked", ex);
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
                    m_sInfo = "UP";
                    nudDOMDepth.Enabled = false;
                    btnCancel.Enabled = true;
                    btnStop.Enabled = true;
                    btnStart.Enabled = false;
                }
                else if (new_status == eConnectionStatus.csConnectionDelayed)
                {
                    BackCol = System.Drawing.Color.FromArgb(205, 114, 0);
                    m_sInfo = "De";
                    m_NotStarted = 0;
                    nudDOMDepth.Enabled = false; 
                    btnCancel.Enabled = false;
                    btnStop.Enabled = false;
                    btnStart.Enabled = true;
                }
                else
                {
                    BackCol = System.Drawing.Color.FromArgb(255, 0, 0);
                    m_sInfo = "Do";
                    m_NotStarted = 0;
                    nudDOMDepth.Enabled = true;
                    btnCancel.Enabled = false;
                    btnStop.Enabled = false;
                    btnStart.Enabled = true;
                }
                lblDataConnStatus.BackColor = BackCol;
                lblDataConnStatus.Text = m_sInfo;
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("frmTickNet", "CEL_DataConnectionStatusChanged", ex);
            }
        }

        public int systemStatus()
        {
            return m_NotStarted;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
             m_selectedSym = txtSymbol.Text;
            if (String.IsNullOrEmpty(m_selectedSym))
            {
                DialogResult result = MessageBox.Show("NO Symbol?", "Data symbol error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                /*
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object unused)
                                                                  {
                                                                      Start_CEL();
                                                                  }));
                 */
                
                setTableDate();
                isCanceled = false;
                isNewTrade = true;
                m_qroup_ID = 0;
                firstTride = true;
                Start_CEL();

                //if (m_NotStarted == 0)
                //{
                //    MessageBox.Show("CQG is not running, System will exit", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //    this.Dispose();
                //    this.Close();
                //}

                //if (m_NotStarted == 1)   //&& m_BadSymbol == 1)
                //{
                
                    //string table = BuildTable();
                int symbolLen = m_selectedSym.Length;
                m_tableName = m_selectedSym.Substring(5, symbolLen - 5) + "_" + m_Month + "_" + m_Day + "_" + m_Year + "_" + m_Hour + "_" + m_Min + "_" + m_Sec;
                String table = QueryBuilder.createTable(m_tableName);
                    //CreateTable(table);
                 RunSQL(table, "flush");
                 btnStop.Enabled = true;
                 btnCancel.Enabled = true;
                 btnStart.Enabled = false;
                 //m_CEL.Environment.LineTime.ToString();
               //}
            }
        }

        private string BuildTable()
        {
            //try
            //{
            int symbolLen = m_selectedSym.Length;
            m_tableName = m_selectedSym.Substring(5, symbolLen - 5) +"_"+ m_Month +"_"+ m_Day +"_"+ m_Year +"_"+ m_Hour +"_"+ m_Min +"_"+ m_Sec;

            string buildQuery = "";
            buildQuery += "CREATE TABLE " + m_tableName;
            buildQuery += "(index_id INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,";
            buildQuery += " symbol VARCHAR(20), ";

            StringBuilder sb = new StringBuilder();
            foreach (object objItem in lbxCurrentFields.SelectedItems)
            {
                if (sb.Length > 0) sb.Append("\n");
                buildQuery += " " + objItem.ToString() + " VARCHAR(10),";
            }

            if (nudDOMDepth.Value > 1)
            {
                for (int index = 1; index < nudDOMDepth.Value; index++)
                {
                    buildQuery += "DOMBidVol_" + index.ToString() + " VARCHAR(10),";
                    buildQuery += "DOMAskVol_" + index.ToString() + " VARCHAR(10),";
                    buildQuery += "DOMBid_" + index.ToString() + " VARCHAR(10),";
                    buildQuery += "DOMAsk_" + index.ToString() + " VARCHAR(10),";
                }
            }
            buildQuery += " ts VARCHAR(30) DEFAULT 'no timestamp') ";

                //MessageBox.Show(buildQuery);
            return buildQuery;
            //}
            //catch (Exception ex)
            //{
            //    modErrorHandler.ShowError("ticknet", "CreateTable", ex);
            //    return 0;
            //}
        }

        private void RunSQL(string query, string functionName)  //was CreateTable()
        {
            requests += 1;
            toolStripStatusRequests.Text = Convert.ToString(requests);
            //toolStripLoad.Step = (int)requests;
            //MySQL_Thread_Semaphore.WaitOne(0);
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object unused)
                                                              {
                                                                  MySQL_Thread_Mutex.WaitOne();
                                                                  if (connection == null)
                                                                  {
                                                                      connection = new MySqlConnection(MyConString);
                                                                      connection.Open();
                                                                  }
                                                                  else
                                                                  {
                                                                      if (connection.State == ConnectionState.Closed)
                                                                      {
                                                                          connection.Open();
                                                                      }
                                                                  }
                                                                  try
                                                                  {
                                                                      String goupedQuery = "";
                                                                      if (queryList.Count <= 200)
                                                                      {
                                                                          queryList.Add(query);
                                                                          if (functionName != "flush")
                                                                            return;
                                                                      }
                                                                      foreach (string s in queryList)
                                                                      {
                                                                          goupedQuery += s;
                                                                      }
                                                                      queryList.Clear();
                                                                      command = connection.CreateCommand();
                                                                      command.CommandText = "SET AUTOCOMMIT=0;";
                                                                      command.ExecuteNonQuery();
                                                                      command.CommandText = goupedQuery;
                                                                      //command.ExecuteNonQuery();
                                                                      command.ExecuteScalar();
                                                                      command.CommandText = "commit;";
                                                                      command.ExecuteScalar();
                                                                  }
                                                                  catch (Exception ex)
                                                                  {
                                                                      modErrorHandler.ShowError("ticknet", functionName,
                                                                                                ex);
                                                                      //connection = new MySqlConnection(MyConString);
                                                                  }
                                                                  finally
                                                                  {
                                                                      requests -= 1;
                                                                      toolStripStatusRequests.Text = Convert.ToString(requests);
                                                                       
                                                                      //toolStripLoad.Step = (int)requests;
                                                                      //f_wait.requestsLable.Text =
                                                                      //    toolStripStatusRequests.Text;
                                                                      MySQL_Thread_Mutex.ReleaseMutex();
                                                                      //MySQL_Thread_Semaphore.Release();
                                                                  }
                                                              }));
            //connection.Close();
        }

  
        public void InsertData(string query)  //CQGTimedBar timedBar, long recordIndex, CQGTimedBarsRequest req, string timeInt, string runDate, string sQL)
        {
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            try
            {
                command.CommandText = query;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("ticknet", "InsertData", ex);
            }
            connection.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            try
            {
                ExitTheApp();
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("btnExit_Click", "btnStop_Click", ex);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            m_selectedSym = txtSymbol.Text;
            DialogResult result = DialogResult;
            try
            {
                result = MessageBox.Show("This action will close & stop the run for symbol: " + m_selectedSym + " Continue ?", "STOP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //m_CEL.Shutdown();
                    connector.CQG_Stop();
                    //f_wait.ShowDialog();
                    btnCancel.Enabled = false;
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    ticks = 0;
                    RunSQL("","flush");
                }
            }
             catch (Exception ex)
            {
                modErrorHandler.ShowError("frmTickNet", "btnStop_Click", ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_selectedSym = txtSymbol.Text;
            //string query = "DROP TABLE IF EXISTS " + m_tableName;

            DialogResult result = DialogResult;
             try
             {
                if (String.IsNullOrEmpty(m_selectedSym))
                {
                    result = MessageBox.Show("Stop data collection?", "STOP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    result = MessageBox.Show("This action will cancel the data run and all data will be lost for symbol : " + m_selectedSym + " Continue ?", "CANCEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        isCanceled = true;
                        //RunSQL(query, "RunSQL");
                        btnStart.Enabled = true;
                        btnStop.Enabled = false;
                        btnCancel.Enabled = false;
                        ticks = 0;
                    }
                    // DropTable(); change for runSQL() above
                }
             }
             catch (Exception ex)
            {
                modErrorHandler.ShowError("frmTickNet", "btnCancel_Click", ex);
            }
        }


        

        private void LoadFields()
        {
            //Default all fields selected
            ReadFile rf = new ReadFile();
            //fp.ShowDialog(this);
            List<string> parsedData = rf.parseCSV(m_path);
            for (int indx = 0; indx < parsedData.Count; indx++)
            {
                lbxCurrentFields.Items.Add(parsedData[indx]);
                lbxCurrentFields.SelectedIndex = indx;
            }
        }

        private void filePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFilePath fp = new frmFilePath();
            fp.Show();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitTheApp();
           
        }

        private void ExitTheApp()
        {
            m_selectedSym = txtSymbol.Text;
            DialogResult result = DialogResult;
            try
            {
                if (String.IsNullOrEmpty(m_selectedSym))
                {
                    result = MessageBox.Show("Exit without running?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    result = MessageBox.Show("This action will terminate & close this run for symbol: " + m_selectedSym + " Continue ?", "Close & Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (result == DialogResult.Yes)
                {
                    //f_wait.ShowDialog();
                    //MySQL_Thread_Semaphore.WaitOne();
                    //RunSQL("","flush");
                    if (!isCanceled)
                        RunSQL("", "flush");            
                    this.Dispose();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("frmTickNet", "ExitTheApp", ex);
            }
        
        }

        private void btnStart_Validated(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmTickNet_FormClosed(object sender, FormClosedEventArgs e)
        {
            regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\TickNet");
            regKey.SetValue("Symbol", txtSymbol.Text);
        }
    }//class
}//namespace

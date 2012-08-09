using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using CQG;


namespace TickNet 
{
    class SymbolBoxes : System.Windows.Forms.Form
    {
        private List<TextBox> inputTextBoxes;
        private int m_index = 0;
        public string m_selectedSym = "";
        private CQGCEL m_CEL;

        public SymbolBoxes(int numOfForms, List<string> symNames, List<string> dBFields)
        {
            string fieldView = "";
            string g = "";
            int strLen = 0;

            
            //Initialize list of input text boxes
            inputTextBoxes = new List<TextBox>();

            for (int i = 0; i < numOfForms; i++)
            {
                Form form = new Form();
                TextBox txtSymbol = new TextBox();
                Button btnStart = new Button();
                Button btnEnd = new Button();
                Button btnCancel = new Button();
                Label lblHeader = new Label();
                Label lblfieldView = new Label();

                Label lblInstrumentDescription = new Label();

                if (symNames.Count == 0)//????
                {
                    g = "   ";
                }
                else
                {
                    g = symNames[i].ToString();
                }

                strLen = g.Length;

                form.Text = "SYMBOL";   
                form.Name = "frm" + i.ToString();
                form.FormBorderStyle = FormBorderStyle.Fixed3D;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Location = new System.Drawing.Point(10 + (i * 5), 10 + (i * 5));
                form.StartPosition = FormStartPosition.Manual;
                form.Size = new System.Drawing.Size(480, 200);
                form.Show();


                txtSymbol.Location = new System.Drawing.Point(10, 20);
                txtSymbol.Name = "txtSymbol";
                txtSymbol.Text = g.Substring(3, (strLen - 3)).ToUpper();
                //txtSymbol.CharacterCasing.ToString().ToUpper();
                txtSymbol.Size = new System.Drawing.Size(250, 20);
                txtSymbol.TabIndex = 0;
                txtSymbol.Visible = true;
                txtSymbol.TextChanged += new System.EventHandler(MMtxtSymbol_TextChanged);
                form.Controls.Add(txtSymbol);
                //Add the newly created text box to the list of input text boxes
                inputTextBoxes.Add(txtSymbol);


                btnStart.Location = new System.Drawing.Point(10, 50);
                btnStart.Name = "btnStart";
                btnStart.Text = "Start";
                btnStart.Size = new System.Drawing.Size(100, 30);
                btnStart.TabIndex = 1;
                btnStart.Visible = true;
                form.Controls.Add(btnStart);
                btnStart.Click += new System.EventHandler(MMbtnStart_Click);

                btnEnd.Location = new System.Drawing.Point(160, 50);
                btnEnd.Name = "btnEnd";
                btnEnd.Text = "End";
                btnEnd.Size = new System.Drawing.Size(100, 30);
                btnEnd.TabIndex = 2;
                btnEnd.Visible = true;
                form.Controls.Add(btnEnd);
                btnEnd.Click += new System.EventHandler(MMbtnEnd_Click);

                btnCancel.Location = new System.Drawing.Point(310, 50);
                btnCancel.Name = "btnCancel";
                btnCancel.Text = "Cancel";
                btnCancel.Size = new System.Drawing.Size(100, 30);
                btnCancel.TabIndex = 3;
                btnCancel.Visible = true;
                form.Controls.Add(btnCancel);
                btnCancel.Click += new System.EventHandler(MMbtnCancel_Click);

                //View the INSERT fields
                FontFamily family = new FontFamily("Arial");
                Font font = new Font(family, 12.0f, FontStyle.Bold | FontStyle.Regular);
                lblHeader.Location = new System.Drawing.Point(10, 100);
                lblHeader.Name = "lblHeader";
                lblHeader.Text = "Fields selected to be recorded";
                lblHeader.BorderStyle = BorderStyle.None;
                lblHeader.Size = new System.Drawing.Size(400, 20);
                lblHeader.ForeColor = System.Drawing.Color.Blue;
                lblHeader.Font = font;
                lblHeader.TabIndex = 4;
                lblHeader.Visible = true;
                form.Controls.Add(lblHeader);

                FontFamily family2 = new FontFamily("Times New Roman");
                Font font2 = new Font(family, 10.0f, FontStyle.Bold);
                fieldView = "";
                lblfieldView.Location = new System.Drawing.Point(10, 120);
                lblfieldView.Name = "lblfieldView";
                lblfieldView.Text = "";
                lblfieldView.BorderStyle = BorderStyle.None;
                lblfieldView.Size = new System.Drawing.Size(400, 30);
                lblfieldView.ForeColor = System.Drawing.Color.CadetBlue;
                lblfieldView.Font = font2;
                lblfieldView.TabIndex = 4;
                lblfieldView.Visible = true;

                //fieldView = "Fields selected to insert into t_ticknet : ";
                for (int ind = 0; ind < dBFields.Count; ind++)
                {
                    if (dBFields[ind] != "")
                    {
                        fieldView += dBFields[ind] + " ";
                    }
                    if(ind != dBFields.Count-1)
                    {
                        fieldView += ",";
                    }
                }

                lblfieldView.Text = fieldView;
                form.Controls.Add(lblfieldView);

                //good or bad symbol
                FontFamily family3 = new FontFamily("Arial");
                Font font3 = new Font(family, 12.0f, FontStyle.Bold | FontStyle.Regular);
                lblInstrumentDescription.Location = new System.Drawing.Point(470, 200);
                lblInstrumentDescription.Name = "lblInstrumentDescription";
                lblInstrumentDescription.Text = "nothing";
                lblInstrumentDescription.BorderStyle = BorderStyle.None;
                lblInstrumentDescription.Size = new System.Drawing.Size(100, 20);
                lblInstrumentDescription.ForeColor = System.Drawing.Color.Blue;
                lblInstrumentDescription.Font = font;
                lblInstrumentDescription.TabIndex = 4;
                lblInstrumentDescription.Visible = true;
                form.Controls.Add(lblInstrumentDescription);


                
            }
        }

        protected void MMtxtSymbol_TextChanged(object who, EventArgs e)
        {
            //CQGConnection cqg_conn = new CQGConnection();
            
            //TextBox myBox = this.Controls.FindControl("txtSymbol");
       
            MessageBox.Show("changed > " + who );
        }

        protected void MMbtnStart_Click(object who, EventArgs e)
        {
            //Tick tick = new Tick();
            string p = Form.ActiveForm.Name.ToString();
            string s = p.Substring(3, 1);
            int w = Convert.ToInt32(s);

            foreach (Control ct in Form.ActiveForm.Controls)
            {
                //MessageBox.Show(ct.ToString());
                if (ct is TextBox)
                {
                   //tick.CEL_IncorrectSymbol(((TextBox)(ct)).Text); 

                    m_selectedSym = ((TextBox)(ct)).Text;
                    //Tick tick = new Tick(m_selectedSym);
                }
            }

            m_CEL = new CQGCEL();

            // m_CEL.CELStarted += new _ICQGCELEvents_CELStartedEventHandler(CEL_CELStarted);
            m_CEL.DataConnectionStatusChanged += new _ICQGCELEvents_DataConnectionStatusChangedEventHandler(CEL_DataConnectionStatusChanged);
        }

        protected void MMbtnEnd_Click(object who, EventArgs e)
        {
            MessageBox.Show("switching off");
            ClearOut();
        }

        protected void MMbtnCancel_Click(object who, EventArgs e)
        {
            MessageBox.Show("Cancel data Collection?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            
        }

        private void ClearOut()
        {
            //Form.ActiveForm.Dispose();
            Form.ActiveForm.Close();
        }
        //************************************************

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
                    MessageBox.Show(info);
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
                MessageBox.Show("data connection");
                //lblDataConnection.BackColor = BackCol;
                //lblDataConnection.Text = info;
            }
            catch (Exception ex)
            {
                modErrorHandler.ShowError("ticknet", "CEL_DataConnectionStatusChanged", ex);
            }
        }


    } //Class
}//Namespace

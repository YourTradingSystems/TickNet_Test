namespace TickNet
{
    partial class frmTickNet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.lbxCurrentFields = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblDataConnStatus = new System.Windows.Forms.Label();
            this.txtAsk = new System.Windows.Forms.TextBox();
            this.lblSymbolStatus = new System.Windows.Forms.Label();
            this.txtBid = new System.Windows.Forms.TextBox();
            this.txtDOMBid = new System.Windows.Forms.TextBox();
            this.txtDOMAsk = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAsk = new System.Windows.Forms.Label();
            this.lblBid = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudDOMDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusRequests = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsBidDpth = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsAskDpth = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.nudDOMDepth)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(237, 112);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 31);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbxCurrentFields
            // 
            this.lbxCurrentFields.FormattingEnabled = true;
            this.lbxCurrentFields.Location = new System.Drawing.Point(197, 293);
            this.lbxCurrentFields.Name = "lbxCurrentFields";
            this.lbxCurrentFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxCurrentFields.Size = new System.Drawing.Size(146, 69);
            this.lbxCurrentFields.TabIndex = 14;
            this.lbxCurrentFields.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Symbol Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Data Fields";
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(93, 60);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(146, 20);
            this.txtSymbol.TabIndex = 18;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 112);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(65, 32);
            this.btnStart.TabIndex = 19;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.Validated += new System.EventHandler(this.btnStart_Validated);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(86, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 32);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(160, 112);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(71, 32);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblDataConnStatus
            // 
            this.lblDataConnStatus.AutoSize = true;
            this.lblDataConnStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDataConnStatus.Location = new System.Drawing.Point(93, 9);
            this.lblDataConnStatus.Name = "lblDataConnStatus";
            this.lblDataConnStatus.Size = new System.Drawing.Size(18, 15);
            this.lblDataConnStatus.TabIndex = 22;
            this.lblDataConnStatus.Text = "   ";
            // 
            // txtAsk
            // 
            this.txtAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtAsk.Location = new System.Drawing.Point(133, 237);
            this.txtAsk.Name = "txtAsk";
            this.txtAsk.Size = new System.Drawing.Size(58, 21);
            this.txtAsk.TabIndex = 24;
            // 
            // lblSymbolStatus
            // 
            this.lblSymbolStatus.AutoSize = true;
            this.lblSymbolStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSymbolStatus.Location = new System.Drawing.Point(237, 26);
            this.lblSymbolStatus.Name = "lblSymbolStatus";
            this.lblSymbolStatus.Size = new System.Drawing.Size(2, 15);
            this.lblSymbolStatus.TabIndex = 25;
            // 
            // txtBid
            // 
            this.txtBid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBid.Location = new System.Drawing.Point(64, 341);
            this.txtBid.Name = "txtBid";
            this.txtBid.Size = new System.Drawing.Size(63, 21);
            this.txtBid.TabIndex = 26;
            // 
            // txtDOMBid
            // 
            this.txtDOMBid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOMBid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtDOMBid.Location = new System.Drawing.Point(133, 341);
            this.txtDOMBid.Name = "txtDOMBid";
            this.txtDOMBid.Size = new System.Drawing.Size(63, 21);
            this.txtDOMBid.TabIndex = 27;
            // 
            // txtDOMAsk
            // 
            this.txtDOMAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOMAsk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtDOMAsk.Location = new System.Drawing.Point(200, 237);
            this.txtDOMAsk.Name = "txtDOMAsk";
            this.txtDOMAsk.Size = new System.Drawing.Size(58, 21);
            this.txtDOMAsk.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "BID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "ASK";
            // 
            // txtQuote
            // 
            this.txtQuote.Location = new System.Drawing.Point(65, 289);
            this.txtQuote.Name = "txtQuote";
            this.txtQuote.Size = new System.Drawing.Size(62, 20);
            this.txtQuote.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "QUOTE";
            // 
            // txtTrade
            // 
            this.txtTrade.Location = new System.Drawing.Point(133, 289);
            this.txtTrade.Name = "txtTrade";
            this.txtTrade.Size = new System.Drawing.Size(58, 20);
            this.txtTrade.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "TRADE";
            // 
            // lblAsk
            // 
            this.lblAsk.AutoSize = true;
            this.lblAsk.Location = new System.Drawing.Point(194, 221);
            this.lblAsk.Name = "lblAsk";
            this.lblAsk.Size = new System.Drawing.Size(35, 13);
            this.lblAsk.TabIndex = 37;
            this.lblAsk.Text = "label8";
            // 
            // lblBid
            // 
            this.lblBid.AutoSize = true;
            this.lblBid.Location = new System.Drawing.Point(21, 364);
            this.lblBid.Name = "lblBid";
            this.lblBid.Size = new System.Drawing.Size(35, 13);
            this.lblBid.TabIndex = 38;
            this.lblBid.Text = "label8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "DOM Depth";
            // 
            // nudDOMDepth
            // 
            this.nudDOMDepth.Location = new System.Drawing.Point(93, 34);
            this.nudDOMDepth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudDOMDepth.Name = "nudDOMDepth";
            this.nudDOMDepth.Size = new System.Drawing.Size(34, 20);
            this.nudDOMDepth.TabIndex = 40;
            this.nudDOMDepth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "CQG Status";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel1.Text = "Queries in the queue";
            // 
            // toolStripStatusRequests
            // 
            this.toolStripStatusRequests.Name = "toolStripStatusRequests";
            this.toolStripStatusRequests.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusRequests.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel2.Text = "Depth(Bid:Ask)";
            // 
            // tsBidDpth
            // 
            this.tsBidDpth.Name = "tsBidDpth";
            this.tsBidDpth.Size = new System.Drawing.Size(13, 17);
            this.tsBidDpth.Text = "0";
            // 
            // tsAskDpth
            // 
            this.tsAskDpth.Name = "tsAskDpth";
            this.tsAskDpth.Size = new System.Drawing.Size(13, 17);
            this.tsAskDpth.Text = "0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusRequests,
            this.toolStripStatusLabel2,
            this.tsBidDpth,
            this.tsAskDpth});
            this.statusStrip1.Location = new System.Drawing.Point(0, 149);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(538, 22);
            this.statusStrip1.TabIndex = 42;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(338, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(176, 108);
            this.listView1.TabIndex = 43;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // frmTickNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 171);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblBid);
            this.Controls.Add(this.lblAsk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudDOMDepth);
            this.Controls.Add(this.txtTrade);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQuote);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDOMAsk);
            this.Controls.Add(this.txtDOMBid);
            this.Controls.Add(this.txtBid);
            this.Controls.Add(this.txtAsk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxCurrentFields);
            this.Controls.Add(this.lblSymbolStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.lblDataConnStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTickNet";
            this.Text = "TickNet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTickNet_FormClosed);
            this.Load += new System.EventHandler(this.frmTickNet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDOMDepth)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lbxCurrentFields;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblDataConnStatus;
        private System.Windows.Forms.TextBox txtAsk;
        private System.Windows.Forms.Label lblSymbolStatus;
        private System.Windows.Forms.TextBox txtBid;
        private System.Windows.Forms.TextBox txtDOMBid;
        private System.Windows.Forms.TextBox txtDOMAsk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQuote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAsk;
        private System.Windows.Forms.Label lblBid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudDOMDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusRequests;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsBidDpth;
        private System.Windows.Forms.ToolStripStatusLabel tsAskDpth;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView listView1;
    }
}
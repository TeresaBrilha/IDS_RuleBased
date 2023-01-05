namespace IDS_Project
{
    partial class IDS
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
            this.StartSnifferBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TbVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPackets = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStopSniffing = new System.Windows.Forms.Button();
            this.btnTcp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRemoveFilters = new System.Windows.Forms.Button();
            this.btnUDP = new System.Windows.Forms.Button();
            this.btnArp = new System.Windows.Forms.Button();
            this.listDevices = new System.Windows.Forms.ListBox();
            this.btnICMP = new System.Windows.Forms.Button();
            this.btnIGMP = new System.Windows.Forms.Button();
            this.btnSniffFromFile = new System.Windows.Forms.Button();
            this.tbAlerts = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartSnifferBtn
            // 
            this.StartSnifferBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StartSnifferBtn.Enabled = false;
            this.StartSnifferBtn.Location = new System.Drawing.Point(11, 7);
            this.StartSnifferBtn.Name = "StartSnifferBtn";
            this.StartSnifferBtn.Size = new System.Drawing.Size(95, 34);
            this.StartSnifferBtn.TabIndex = 0;
            this.StartSnifferBtn.Text = "Start Sniffing";
            this.StartSnifferBtn.UseVisualStyleBackColor = false;
            this.StartSnifferBtn.Click += new System.EventHandler(this.StartSnifferBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Devices to Listen";
            // 
            // TbVersion
            // 
            this.TbVersion.Location = new System.Drawing.Point(94, 58);
            this.TbVersion.Name = "TbVersion";
            this.TbVersion.Size = new System.Drawing.Size(100, 20);
            this.TbVersion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "NPcap Version:";
            // 
            // tbPackets
            // 
            this.tbPackets.Location = new System.Drawing.Point(15, 252);
            this.tbPackets.Name = "tbPackets";
            this.tbPackets.Size = new System.Drawing.Size(776, 186);
            this.tbPackets.TabIndex = 5;
            this.tbPackets.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Packets";
            // 
            // btnStopSniffing
            // 
            this.btnStopSniffing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnStopSniffing.Enabled = false;
            this.btnStopSniffing.Location = new System.Drawing.Point(214, 6);
            this.btnStopSniffing.Name = "btnStopSniffing";
            this.btnStopSniffing.Size = new System.Drawing.Size(100, 33);
            this.btnStopSniffing.TabIndex = 7;
            this.btnStopSniffing.Text = "Stop Sniffing";
            this.btnStopSniffing.UseVisualStyleBackColor = false;
            this.btnStopSniffing.Click += new System.EventHandler(this.btnStopSniffing_Click);
            // 
            // btnTcp
            // 
            this.btnTcp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTcp.Enabled = false;
            this.btnTcp.Location = new System.Drawing.Point(557, 10);
            this.btnTcp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTcp.Name = "btnTcp";
            this.btnTcp.Size = new System.Drawing.Size(71, 32);
            this.btnTcp.TabIndex = 8;
            this.btnTcp.Text = "TCP";
            this.btnTcp.UseVisualStyleBackColor = false;
            this.btnTcp.Click += new System.EventHandler(this.btnTcp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Filtros";
            // 
            // btnRemoveFilters
            // 
            this.btnRemoveFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRemoveFilters.Enabled = false;
            this.btnRemoveFilters.Location = new System.Drawing.Point(458, 10);
            this.btnRemoveFilters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveFilters.Name = "btnRemoveFilters";
            this.btnRemoveFilters.Size = new System.Drawing.Size(94, 32);
            this.btnRemoveFilters.TabIndex = 11;
            this.btnRemoveFilters.Text = "Remove Filters";
            this.btnRemoveFilters.UseVisualStyleBackColor = false;
            this.btnRemoveFilters.Click += new System.EventHandler(this.btnRemoveFilters_Click);
            // 
            // btnUDP
            // 
            this.btnUDP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUDP.Enabled = false;
            this.btnUDP.Location = new System.Drawing.Point(633, 10);
            this.btnUDP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUDP.Name = "btnUDP";
            this.btnUDP.Size = new System.Drawing.Size(71, 32);
            this.btnUDP.TabIndex = 12;
            this.btnUDP.Text = "UDP";
            this.btnUDP.UseVisualStyleBackColor = false;
            this.btnUDP.Click += new System.EventHandler(this.btnUDP_Click);
            // 
            // btnArp
            // 
            this.btnArp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnArp.Enabled = false;
            this.btnArp.Location = new System.Drawing.Point(708, 9);
            this.btnArp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnArp.Name = "btnArp";
            this.btnArp.Size = new System.Drawing.Size(71, 32);
            this.btnArp.TabIndex = 13;
            this.btnArp.Text = "ARP";
            this.btnArp.UseVisualStyleBackColor = false;
            this.btnArp.Click += new System.EventHandler(this.btnArp_Click);
            // 
            // listDevices
            // 
            this.listDevices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listDevices.FormattingEnabled = true;
            this.listDevices.Location = new System.Drawing.Point(15, 114);
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(776, 95);
            this.listDevices.TabIndex = 15;
            this.listDevices.SelectedIndexChanged += new System.EventHandler(this.listDevices_SelectedIndexChanged);
            // 
            // btnICMP
            // 
            this.btnICMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnICMP.Enabled = false;
            this.btnICMP.Location = new System.Drawing.Point(557, 45);
            this.btnICMP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnICMP.Name = "btnICMP";
            this.btnICMP.Size = new System.Drawing.Size(71, 32);
            this.btnICMP.TabIndex = 16;
            this.btnICMP.Text = "ICMP";
            this.btnICMP.UseVisualStyleBackColor = false;
            this.btnICMP.Click += new System.EventHandler(this.btnICMP_Click_1);
            // 
            // btnIGMP
            // 
            this.btnIGMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIGMP.Enabled = false;
            this.btnIGMP.Location = new System.Drawing.Point(633, 45);
            this.btnIGMP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIGMP.Name = "btnIGMP";
            this.btnIGMP.Size = new System.Drawing.Size(71, 32);
            this.btnIGMP.TabIndex = 17;
            this.btnIGMP.Text = "IGMP";
            this.btnIGMP.UseVisualStyleBackColor = false;
            this.btnIGMP.Click += new System.EventHandler(this.btnIGMP_Click);
            // 
            // btnSniffFromFile
            // 
            this.btnSniffFromFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSniffFromFile.Location = new System.Drawing.Point(112, 6);
            this.btnSniffFromFile.Name = "btnSniffFromFile";
            this.btnSniffFromFile.Size = new System.Drawing.Size(95, 34);
            this.btnSniffFromFile.TabIndex = 18;
            this.btnSniffFromFile.Text = "Sniff From File";
            this.btnSniffFromFile.UseVisualStyleBackColor = false;
            this.btnSniffFromFile.Click += new System.EventHandler(this.btnSniffFromFile_Click);
            // 
            // tbAlerts
            // 
            this.tbAlerts.Location = new System.Drawing.Point(797, 22);
            this.tbAlerts.Name = "tbAlerts";
            this.tbAlerts.Size = new System.Drawing.Size(335, 416);
            this.tbAlerts.TabIndex = 19;
            this.tbAlerts.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(794, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Alerts";
            // 
            // IDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1144, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbAlerts);
            this.Controls.Add(this.btnSniffFromFile);
            this.Controls.Add(this.btnIGMP);
            this.Controls.Add(this.btnICMP);
            this.Controls.Add(this.listDevices);
            this.Controls.Add(this.btnArp);
            this.Controls.Add(this.btnUDP);
            this.Controls.Add(this.btnRemoveFilters);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTcp);
            this.Controls.Add(this.btnStopSniffing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPackets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TbVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartSnifferBtn);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "IDS";
            this.Text = "IDS";
            this.Load += new System.EventHandler(this.IDS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartSnifferBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tbPackets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStopSniffing;
        private System.Windows.Forms.Button btnTcp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemoveFilters;
        private System.Windows.Forms.Button btnUDP;
        private System.Windows.Forms.Button btnArp;
        private System.Windows.Forms.ListBox listDevices;
        private System.Windows.Forms.Button btnICMP;
        private System.Windows.Forms.Button btnIGMP;
        private System.Windows.Forms.Button btnSniffFromFile;
        private System.Windows.Forms.RichTextBox tbAlerts;
        private System.Windows.Forms.Label label4;
    }
}


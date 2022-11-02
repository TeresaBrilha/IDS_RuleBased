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
            this.TbDevices = new System.Windows.Forms.RichTextBox();
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
            this.SuspendLayout();
            // 
            // StartSnifferBtn
            // 
            this.StartSnifferBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.StartSnifferBtn.Location = new System.Drawing.Point(15, 9);
            this.StartSnifferBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartSnifferBtn.Name = "StartSnifferBtn";
            this.StartSnifferBtn.Size = new System.Drawing.Size(156, 53);
            this.StartSnifferBtn.TabIndex = 0;
            this.StartSnifferBtn.Text = "Start Sniffing";
            this.StartSnifferBtn.UseVisualStyleBackColor = false;
            this.StartSnifferBtn.Click += new System.EventHandler(this.StartSnifferBtn_Click);
            // 
            // TbDevices
            // 
            this.TbDevices.Location = new System.Drawing.Point(16, 160);
            this.TbDevices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbDevices.Name = "TbDevices";
            this.TbDevices.Size = new System.Drawing.Size(1033, 134);
            this.TbDevices.TabIndex = 1;
            this.TbDevices.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Devices";
            // 
            // TbVersion
            // 
            this.TbVersion.Location = new System.Drawing.Point(147, 109);
            this.TbVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbVersion.Name = "TbVersion";
            this.TbVersion.Size = new System.Drawing.Size(132, 22);
            this.TbVersion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "SharpPcap Version:";
            // 
            // tbPackets
            // 
            this.tbPackets.Location = new System.Drawing.Point(13, 332);
            this.tbPackets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPackets.Name = "tbPackets";
            this.tbPackets.Size = new System.Drawing.Size(1033, 209);
            this.tbPackets.TabIndex = 5;
            this.tbPackets.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 312);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Packets";
            // 
            // btnStopSniffing
            // 
            this.btnStopSniffing.BackColor = System.Drawing.Color.LightCoral;
            this.btnStopSniffing.Location = new System.Drawing.Point(179, 9);
            this.btnStopSniffing.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopSniffing.Name = "btnStopSniffing";
            this.btnStopSniffing.Size = new System.Drawing.Size(169, 53);
            this.btnStopSniffing.TabIndex = 7;
            this.btnStopSniffing.Text = "Stop Sniffing";
            this.btnStopSniffing.UseVisualStyleBackColor = false;
            this.btnStopSniffing.Click += new System.EventHandler(this.btnStopSniffing_Click);
            // 
            // btnTcp
            // 
            this.btnTcp.Location = new System.Drawing.Point(743, 12);
            this.btnTcp.Name = "btnTcp";
            this.btnTcp.Size = new System.Drawing.Size(95, 39);
            this.btnTcp.TabIndex = 8;
            this.btnTcp.Text = "TCP";
            this.btnTcp.UseVisualStyleBackColor = true;
            this.btnTcp.Click += new System.EventHandler(this.btnTcp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(562, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Filtros";
            // 
            // btnRemoveFilters
            // 
            this.btnRemoveFilters.Location = new System.Drawing.Point(611, 12);
            this.btnRemoveFilters.Name = "btnRemoveFilters";
            this.btnRemoveFilters.Size = new System.Drawing.Size(126, 39);
            this.btnRemoveFilters.TabIndex = 11;
            this.btnRemoveFilters.Text = "Remove Filters";
            this.btnRemoveFilters.UseVisualStyleBackColor = true;
            this.btnRemoveFilters.Click += new System.EventHandler(this.btnRemoveFilters_Click);
            // 
            // btnUDP
            // 
            this.btnUDP.Location = new System.Drawing.Point(844, 12);
            this.btnUDP.Name = "btnUDP";
            this.btnUDP.Size = new System.Drawing.Size(95, 39);
            this.btnUDP.TabIndex = 12;
            this.btnUDP.Text = "UDP";
            this.btnUDP.UseVisualStyleBackColor = true;
            this.btnUDP.Click += new System.EventHandler(this.btnUDP_Click);
            // 
            // IDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(1067, 554);
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
            this.Controls.Add(this.TbDevices);
            this.Controls.Add(this.StartSnifferBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "IDS";
            this.Text = "IDS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartSnifferBtn;
        private System.Windows.Forms.RichTextBox TbDevices;
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
    }
}


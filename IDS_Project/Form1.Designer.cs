namespace IDS_Project
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // StartSnifferBtn
            // 
            this.StartSnifferBtn.BackColor = System.Drawing.Color.LightCoral;
            this.StartSnifferBtn.Location = new System.Drawing.Point(318, 12);
            this.StartSnifferBtn.Name = "StartSnifferBtn";
            this.StartSnifferBtn.Size = new System.Drawing.Size(132, 61);
            this.StartSnifferBtn.TabIndex = 0;
            this.StartSnifferBtn.Text = "Start Sniffing";
            this.StartSnifferBtn.UseVisualStyleBackColor = false;
            this.StartSnifferBtn.Click += new System.EventHandler(this.StartSnifferBtn_Click);
            // 
            // TbDevices
            // 
            this.TbDevices.Location = new System.Drawing.Point(12, 130);
            this.TbDevices.Name = "TbDevices";
            this.TbDevices.Size = new System.Drawing.Size(776, 96);
            this.TbDevices.TabIndex = 1;
            this.TbDevices.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dispositivos";
            // 
            // TbVersion
            // 
            this.TbVersion.Location = new System.Drawing.Point(122, 88);
            this.TbVersion.Name = "TbVersion";
            this.TbVersion.Size = new System.Drawing.Size(100, 20);
            this.TbVersion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SharpPcap Version:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TbVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbDevices);
            this.Controls.Add(this.StartSnifferBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartSnifferBtn;
        private System.Windows.Forms.RichTextBox TbDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbVersion;
        private System.Windows.Forms.Label label2;
    }
}


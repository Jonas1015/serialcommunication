namespace serialcom
{
    partial class ConnectionWindow
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
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.logs = new System.Windows.Forms.TextBox();
            this.logsLabel = new System.Windows.Forms.Label();
            this.clearLogsButton = new System.Windows.Forms.Button();
            this.sendTestData = new System.Windows.Forms.Button();
            this.reconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Location = new System.Drawing.Point(33, 31);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.connectionStatusLabel.TabIndex = 21;
            this.connectionStatusLabel.Visible = false;
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(36, 71);
            this.logs.Multiline = true;
            this.logs.Name = "logs";
            this.logs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logs.Size = new System.Drawing.Size(736, 293);
            this.logs.TabIndex = 22;
            // 
            // logsLabel
            // 
            this.logsLabel.AutoSize = true;
            this.logsLabel.Location = new System.Drawing.Point(33, 55);
            this.logsLabel.Name = "logsLabel";
            this.logsLabel.Size = new System.Drawing.Size(30, 13);
            this.logsLabel.TabIndex = 23;
            this.logsLabel.Text = "Logs";
            // 
            // clearLogsButton
            // 
            this.clearLogsButton.Location = new System.Drawing.Point(684, 409);
            this.clearLogsButton.Name = "clearLogsButton";
            this.clearLogsButton.Size = new System.Drawing.Size(88, 29);
            this.clearLogsButton.TabIndex = 24;
            this.clearLogsButton.Text = "Clear";
            this.clearLogsButton.UseVisualStyleBackColor = true;
            this.clearLogsButton.Click += new System.EventHandler(this.clearLogsButton_Click);
            // 
            // sendTestData
            // 
            this.sendTestData.Location = new System.Drawing.Point(36, 409);
            this.sendTestData.Name = "sendTestData";
            this.sendTestData.Size = new System.Drawing.Size(88, 29);
            this.sendTestData.TabIndex = 25;
            this.sendTestData.Text = "Test";
            this.sendTestData.UseVisualStyleBackColor = true;
            this.sendTestData.Click += new System.EventHandler(this.sendTestData_Click);
            // 
            // reconnect
            // 
            this.reconnect.Location = new System.Drawing.Point(684, 15);
            this.reconnect.Name = "reconnect";
            this.reconnect.Size = new System.Drawing.Size(88, 29);
            this.reconnect.TabIndex = 26;
            this.reconnect.Text = "Reconnect";
            this.reconnect.UseVisualStyleBackColor = true;
            this.reconnect.Click += new System.EventHandler(this.reconnect_Click);
            // 
            // ConnectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reconnect);
            this.Controls.Add(this.sendTestData);
            this.Controls.Add(this.clearLogsButton);
            this.Controls.Add(this.logsLabel);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.connectionStatusLabel);
            this.Name = "ConnectionWindow";
            this.Text = "TCP/IP Connections monitor";
            this.Load += new System.EventHandler(this.ConnectionWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.TextBox logs;
        private System.Windows.Forms.Label logsLabel;
        private System.Windows.Forms.Button clearLogsButton;
        public TcpIpConnection tcpConnection;
        public string dataToBeSent;
        public string DbConnectionString;
        public string ipAddress;
        public int port;
        private System.Windows.Forms.Button sendTestData;
        private System.Windows.Forms.Button reconnect;
    }
}
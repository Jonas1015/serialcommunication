using System.Configuration;

namespace serialcom
{
    partial class Homepage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepage));
            this.ConnectionTab = new System.Windows.Forms.TabControl();
            this.registerTcpIpConnection = new System.Windows.Forms.TabPage();
            this.errorLabel = new System.Windows.Forms.Label();
            this.autoEstablish = new System.Windows.Forms.CheckBox();
            this.autoEstablishLabel = new System.Windows.Forms.Label();
            this.headingLabel = new System.Windows.Forms.Label();
            this.connectionNameLabel = new System.Windows.Forms.Label();
            this.connectionName = new System.Windows.Forms.TextBox();
            this.instanceSave = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.clientRadio = new System.Windows.Forms.RadioButton();
            this.serverRadio = new System.Windows.Forms.RadioButton();
            this.stateLabel = new System.Windows.Forms.Label();
            this.tcpIpConnectionsList = new System.Windows.Forms.TabPage();
            this.establishConnection = new System.Windows.Forms.Button();
            this.deleteConnection = new System.Windows.Forms.Button();
            this.editConnection = new System.Windows.Forms.Button();
            this.reloadConnectionList = new System.Windows.Forms.Button();
            this.tcpIpConnections = new System.Windows.Forms.DataGridView();
            this.newSerialConnection = new System.Windows.Forms.TabPage();
            this.testOpenSerialPort = new System.Windows.Forms.Button();
            this.parity = new System.Windows.Forms.ComboBox();
            this.stopBit = new System.Windows.Forms.ComboBox();
            this.transferBits = new System.Windows.Forms.ComboBox();
            this.transferBitsLabel = new System.Windows.Forms.Label();
            this.stopBitLabel = new System.Windows.Forms.Label();
            this.serialPortName = new System.Windows.Forms.ComboBox();
            this.autoOpen = new System.Windows.Forms.CheckBox();
            this.autoOpenLabel = new System.Windows.Forms.Label();
            this.serialPortNameLabel = new System.Windows.Forms.Label();
            this.saveSerialPortSettings = new System.Windows.Forms.Button();
            this.baudRate = new System.Windows.Forms.TextBox();
            this.parityLabel = new System.Windows.Forms.Label();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.serialConnectionsList = new System.Windows.Forms.TabPage();
            this.clearLogs = new System.Windows.Forms.Button();
            this.logsLabel = new System.Windows.Forms.Label();
            this.logs = new System.Windows.Forms.TextBox();
            this.openSerialPort = new System.Windows.Forms.Button();
            this.deleteSerialPort = new System.Windows.Forms.Button();
            this.editSerialPort = new System.Windows.Forms.Button();
            this.reloadSerialPorts = new System.Windows.Forms.Button();
            this.serialConnections = new System.Windows.Forms.DataGridView();
            this.ConnectionTab.SuspendLayout();
            this.registerTcpIpConnection.SuspendLayout();
            this.tcpIpConnectionsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpIpConnections)).BeginInit();
            this.newSerialConnection.SuspendLayout();
            this.serialConnectionsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialConnections)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionTab
            // 
            this.ConnectionTab.Controls.Add(this.registerTcpIpConnection);
            this.ConnectionTab.Controls.Add(this.tcpIpConnectionsList);
            this.ConnectionTab.Controls.Add(this.newSerialConnection);
            this.ConnectionTab.Controls.Add(this.serialConnectionsList);
            this.ConnectionTab.Location = new System.Drawing.Point(3, 3);
            this.ConnectionTab.Multiline = true;
            this.ConnectionTab.Name = "ConnectionTab";
            this.ConnectionTab.SelectedIndex = 0;
            this.ConnectionTab.Size = new System.Drawing.Size(797, 452);
            this.ConnectionTab.TabIndex = 11;
            // 
            // registerTcpIpConnection
            // 
            this.registerTcpIpConnection.Controls.Add(this.errorLabel);
            this.registerTcpIpConnection.Controls.Add(this.autoEstablish);
            this.registerTcpIpConnection.Controls.Add(this.autoEstablishLabel);
            this.registerTcpIpConnection.Controls.Add(this.headingLabel);
            this.registerTcpIpConnection.Controls.Add(this.connectionNameLabel);
            this.registerTcpIpConnection.Controls.Add(this.connectionName);
            this.registerTcpIpConnection.Controls.Add(this.instanceSave);
            this.registerTcpIpConnection.Controls.Add(this.port);
            this.registerTcpIpConnection.Controls.Add(this.ipAddress);
            this.registerTcpIpConnection.Controls.Add(this.portLabel);
            this.registerTcpIpConnection.Controls.Add(this.ipLabel);
            this.registerTcpIpConnection.Controls.Add(this.clientRadio);
            this.registerTcpIpConnection.Controls.Add(this.serverRadio);
            this.registerTcpIpConnection.Controls.Add(this.stateLabel);
            this.registerTcpIpConnection.Location = new System.Drawing.Point(4, 22);
            this.registerTcpIpConnection.Name = "registerTcpIpConnection";
            this.registerTcpIpConnection.Padding = new System.Windows.Forms.Padding(3);
            this.registerTcpIpConnection.Size = new System.Drawing.Size(789, 426);
            this.registerTcpIpConnection.TabIndex = 0;
            this.registerTcpIpConnection.Text = "Registrater New Connection";
            this.registerTcpIpConnection.UseVisualStyleBackColor = true;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(29, 279);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 24;
            this.errorLabel.Visible = false;
            // 
            // autoEstablish
            // 
            this.autoEstablish.AutoSize = true;
            this.autoEstablish.Location = new System.Drawing.Point(511, 42);
            this.autoEstablish.Name = "autoEstablish";
            this.autoEstablish.Size = new System.Drawing.Size(15, 14);
            this.autoEstablish.TabIndex = 23;
            this.autoEstablish.UseVisualStyleBackColor = true;
            // 
            // autoEstablishLabel
            // 
            this.autoEstablishLabel.AutoSize = true;
            this.autoEstablishLabel.Location = new System.Drawing.Point(395, 42);
            this.autoEstablishLabel.Name = "autoEstablishLabel";
            this.autoEstablishLabel.Size = new System.Drawing.Size(58, 10);
            this.autoEstablishLabel.TabIndex = 22;
            this.autoEstablishLabel.Text = "Auto Connect";
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Location = new System.Drawing.Point(26, 73);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(0, 13);
            this.headingLabel.TabIndex = 21;
            // 
            // connectionNameLabel
            // 
            this.connectionNameLabel.AutoSize = true;
            this.connectionNameLabel.Location = new System.Drawing.Point(26, 106);
            this.connectionNameLabel.Name = "connectionNameLabel";
            this.connectionNameLabel.Size = new System.Drawing.Size(99, 13);
            this.connectionNameLabel.TabIndex = 20;
            this.connectionNameLabel.Text = "Connection Name *";
            // 
            // connectionName
            // 
            this.connectionName.Location = new System.Drawing.Point(170, 103);
            this.connectionName.Multiline = true;
            this.connectionName.Name = "connectionName";
            this.connectionName.Size = new System.Drawing.Size(422, 29);
            this.connectionName.TabIndex = 19;
            // 
            // instanceSave
            // 
            this.instanceSave.Location = new System.Drawing.Point(670, 201);
            this.instanceSave.Name = "instanceSave";
            this.instanceSave.Size = new System.Drawing.Size(91, 37);
            this.instanceSave.TabIndex = 18;
            this.instanceSave.Text = "Save";
            this.instanceSave.UseVisualStyleBackColor = true;
            this.instanceSave.Click += new System.EventHandler(this.instanceSave_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(465, 201);
            this.port.Multiline = true;
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(127, 32);
            this.port.TabIndex = 17;
            // 
            // ipAddress
            // 
            this.ipAddress.Location = new System.Drawing.Point(170, 201);
            this.ipAddress.Multiline = true;
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(211, 32);
            this.ipAddress.TabIndex = 16;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(413, 204);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(33, 13);
            this.portLabel.TabIndex = 15;
            this.portLabel.Text = "Port *";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(26, 204);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(65, 13);
            this.ipLabel.TabIndex = 14;
            this.ipLabel.Text = "IP Address *";
            // 
            // clientRadio
            // 
            this.clientRadio.AutoSize = true;
            this.clientRadio.Location = new System.Drawing.Point(278, 38);
            this.clientRadio.Name = "clientRadio";
            this.clientRadio.Size = new System.Drawing.Size(51, 17);
            this.clientRadio.TabIndex = 13;
            this.clientRadio.Text = "Client";
            this.clientRadio.UseVisualStyleBackColor = true;
            // 
            // serverRadio
            // 
            this.serverRadio.AutoSize = true;
            this.serverRadio.Checked = true;
            this.serverRadio.Location = new System.Drawing.Point(170, 38);
            this.serverRadio.Name = "serverRadio";
            this.serverRadio.Size = new System.Drawing.Size(56, 17);
            this.serverRadio.TabIndex = 12;
            this.serverRadio.TabStop = true;
            this.serverRadio.Text = "Server";
            this.serverRadio.UseVisualStyleBackColor = true;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(26, 38);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(115, 13);
            this.stateLabel.TabIndex = 11;
            this.stateLabel.Text = "TCP/IP Client/Server *";
            // 
            // tcpIpConnectionsList
            // 
            this.tcpIpConnectionsList.Controls.Add(this.establishConnection);
            this.tcpIpConnectionsList.Controls.Add(this.deleteConnection);
            this.tcpIpConnectionsList.Controls.Add(this.editConnection);
            this.tcpIpConnectionsList.Controls.Add(this.reloadConnectionList);
            this.tcpIpConnectionsList.Controls.Add(this.tcpIpConnections);
            this.tcpIpConnectionsList.Location = new System.Drawing.Point(4, 22);
            this.tcpIpConnectionsList.Name = "tcpIpConnectionsList";
            this.tcpIpConnectionsList.Padding = new System.Windows.Forms.Padding(3);
            this.tcpIpConnectionsList.Size = new System.Drawing.Size(789, 426);
            this.tcpIpConnectionsList.TabIndex = 1;
            this.tcpIpConnectionsList.Text = "Registered Connections";
            this.tcpIpConnectionsList.UseVisualStyleBackColor = true;
            // 
            // establishConnection
            // 
            this.establishConnection.Location = new System.Drawing.Point(670, 159);
            this.establishConnection.Name = "establishConnection";
            this.establishConnection.Size = new System.Drawing.Size(91, 35);
            this.establishConnection.TabIndex = 7;
            this.establishConnection.Text = "Connect";
            this.establishConnection.UseVisualStyleBackColor = true;
            this.establishConnection.Click += new System.EventHandler(this.EstablishConnection_Click);
            // 
            // deleteConnection
            // 
            this.deleteConnection.Location = new System.Drawing.Point(670, 377);
            this.deleteConnection.Name = "deleteConnection";
            this.deleteConnection.Size = new System.Drawing.Size(91, 36);
            this.deleteConnection.TabIndex = 6;
            this.deleteConnection.Text = "Delete";
            this.deleteConnection.UseVisualStyleBackColor = true;
            this.deleteConnection.Click += new System.EventHandler(this.deleteConnection_Click);
            // 
            // editConnection
            // 
            this.editConnection.Location = new System.Drawing.Point(670, 316);
            this.editConnection.Name = "editConnection";
            this.editConnection.Size = new System.Drawing.Size(91, 36);
            this.editConnection.TabIndex = 5;
            this.editConnection.Text = "Edit";
            this.editConnection.UseVisualStyleBackColor = true;
            this.editConnection.Click += new System.EventHandler(this.editConnection_Click);
            // 
            // reloadConnectionList
            // 
            this.reloadConnectionList.Location = new System.Drawing.Point(670, 18);
            this.reloadConnectionList.Name = "reloadConnectionList";
            this.reloadConnectionList.Size = new System.Drawing.Size(91, 36);
            this.reloadConnectionList.TabIndex = 4;
            this.reloadConnectionList.Text = "Reload";
            this.reloadConnectionList.UseVisualStyleBackColor = true;
            this.reloadConnectionList.Click += new System.EventHandler(this.reloadConnectionList_Click);
            // 
            // tcpIpConnections
            // 
            this.tcpIpConnections.AllowDrop = true;
            this.tcpIpConnections.AllowUserToAddRows = false;
            this.tcpIpConnections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tcpIpConnections.BackgroundColor = System.Drawing.Color.White;
            this.tcpIpConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tcpIpConnections.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcpIpConnections.Location = new System.Drawing.Point(3, 3);
            this.tcpIpConnections.Name = "tcpIpConnections";
            this.tcpIpConnections.ReadOnly = true;
            this.tcpIpConnections.Size = new System.Drawing.Size(633, 420);
            this.tcpIpConnections.TabIndex = 1;
            // 
            // newSerialConnection
            // 
            this.newSerialConnection.Controls.Add(this.testOpenSerialPort);
            this.newSerialConnection.Controls.Add(this.parity);
            this.newSerialConnection.Controls.Add(this.stopBit);
            this.newSerialConnection.Controls.Add(this.transferBits);
            this.newSerialConnection.Controls.Add(this.transferBitsLabel);
            this.newSerialConnection.Controls.Add(this.stopBitLabel);
            this.newSerialConnection.Controls.Add(this.serialPortName);
            this.newSerialConnection.Controls.Add(this.autoOpen);
            this.newSerialConnection.Controls.Add(this.autoOpenLabel);
            this.newSerialConnection.Controls.Add(this.serialPortNameLabel);
            this.newSerialConnection.Controls.Add(this.saveSerialPortSettings);
            this.newSerialConnection.Controls.Add(this.baudRate);
            this.newSerialConnection.Controls.Add(this.parityLabel);
            this.newSerialConnection.Controls.Add(this.baudRateLabel);
            this.newSerialConnection.Location = new System.Drawing.Point(4, 22);
            this.newSerialConnection.Name = "newSerialConnection";
            this.newSerialConnection.Padding = new System.Windows.Forms.Padding(3);
            this.newSerialConnection.Size = new System.Drawing.Size(789, 426);
            this.newSerialConnection.TabIndex = 2;
            this.newSerialConnection.Text = "New Serial Connection";
            this.newSerialConnection.UseVisualStyleBackColor = true;
            // 
            // testOpenSerialPort
            // 
            this.testOpenSerialPort.Location = new System.Drawing.Point(547, 246);
            this.testOpenSerialPort.Name = "testOpenSerialPort";
            this.testOpenSerialPort.Size = new System.Drawing.Size(91, 37);
            this.testOpenSerialPort.TabIndex = 40;
            this.testOpenSerialPort.Text = "Test";
            this.testOpenSerialPort.UseVisualStyleBackColor = true;
            this.testOpenSerialPort.Visible = false;
            this.testOpenSerialPort.Click += new System.EventHandler(this.testOpenSerialPort_Click);
            // 
            // parity
            // 
            this.parity.FormattingEnabled = true;
            this.parity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.parity.Location = new System.Drawing.Point(130, 101);
            this.parity.Name = "parity";
            this.parity.Size = new System.Drawing.Size(176, 21);
            this.parity.TabIndex = 39;
            // 
            // stopBit
            // 
            this.stopBit.FormattingEnabled = true;
            this.stopBit.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "One Point Five"});
            this.stopBit.Location = new System.Drawing.Point(130, 175);
            this.stopBit.Name = "stopBit";
            this.stopBit.Size = new System.Drawing.Size(176, 21);
            this.stopBit.TabIndex = 38;
            // 
            // transferBits
            // 
            this.transferBits.FormattingEnabled = true;
            this.transferBits.Items.AddRange(new object[] {
            "8 bits",
            "7 bits",
            "6 bits",
            "5 bits"});
            this.transferBits.Location = new System.Drawing.Point(513, 105);
            this.transferBits.Name = "transferBits";
            this.transferBits.Size = new System.Drawing.Size(176, 21);
            this.transferBits.TabIndex = 37;
            // 
            // transferBitsLabel
            // 
            this.transferBitsLabel.AutoSize = true;
            this.transferBitsLabel.Location = new System.Drawing.Point(397, 101);
            this.transferBitsLabel.Name = "transferBitsLabel";
            this.transferBitsLabel.Size = new System.Drawing.Size(66, 13);
            this.transferBitsLabel.TabIndex = 36;
            this.transferBitsLabel.Text = "Transfer Bits";
            // 
            // stopBitLabel
            // 
            this.stopBitLabel.AutoSize = true;
            this.stopBitLabel.Location = new System.Drawing.Point(28, 175);
            this.stopBitLabel.Name = "stopBitLabel";
            this.stopBitLabel.Size = new System.Drawing.Size(44, 13);
            this.stopBitLabel.TabIndex = 34;
            this.stopBitLabel.Text = "Stop Bit";
            // 
            // serialPortName
            // 
            this.serialPortName.FormattingEnabled = true;
            this.serialPortName.Location = new System.Drawing.Point(130, 36);
            this.serialPortName.Name = "serialPortName";
            this.serialPortName.Size = new System.Drawing.Size(176, 21);
            this.serialPortName.TabIndex = 33;
            // 
            // autoOpen
            // 
            this.autoOpen.AutoSize = true;
            this.autoOpen.Location = new System.Drawing.Point(513, 174);
            this.autoOpen.Name = "autoOpen";
            this.autoOpen.Size = new System.Drawing.Size(15, 14);
            this.autoOpen.TabIndex = 32;
            this.autoOpen.UseVisualStyleBackColor = true;
            // 
            // autoOpenLabel
            // 
            this.autoOpenLabel.AutoSize = true;
            this.autoOpenLabel.Location = new System.Drawing.Point(397, 175);
            this.autoOpenLabel.Name = "autoOpenLabel";
            this.autoOpenLabel.Size = new System.Drawing.Size(58, 13);
            this.autoOpenLabel.TabIndex = 31;
            this.autoOpenLabel.Text = "Auto Open";
            // 
            // serialPortNameLabel
            // 
            this.serialPortNameLabel.AutoSize = true;
            this.serialPortNameLabel.Location = new System.Drawing.Point(28, 36);
            this.serialPortNameLabel.Name = "serialPortNameLabel";
            this.serialPortNameLabel.Size = new System.Drawing.Size(64, 13);
            this.serialPortNameLabel.TabIndex = 30;
            this.serialPortNameLabel.Text = "Port Name *";
            // 
            // saveSerialPortSettings
            // 
            this.saveSerialPortSettings.Location = new System.Drawing.Point(672, 246);
            this.saveSerialPortSettings.Name = "saveSerialPortSettings";
            this.saveSerialPortSettings.Size = new System.Drawing.Size(91, 37);
            this.saveSerialPortSettings.TabIndex = 28;
            this.saveSerialPortSettings.Text = "Save";
            this.saveSerialPortSettings.UseVisualStyleBackColor = true;
            this.saveSerialPortSettings.Click += new System.EventHandler(this.saveSerialPortSettings_Click);
            // 
            // baudRate
            // 
            this.baudRate.Location = new System.Drawing.Point(513, 29);
            this.baudRate.Multiline = true;
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(176, 28);
            this.baudRate.TabIndex = 26;
            // 
            // parityLabel
            // 
            this.parityLabel.AutoSize = true;
            this.parityLabel.Location = new System.Drawing.Point(28, 101);
            this.parityLabel.Name = "parityLabel";
            this.parityLabel.Size = new System.Drawing.Size(33, 13);
            this.parityLabel.TabIndex = 25;
            this.parityLabel.Text = "Parity";
            // 
            // baudRateLabel
            // 
            this.baudRateLabel.AutoSize = true;
            this.baudRateLabel.Location = new System.Drawing.Point(397, 36);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(58, 13);
            this.baudRateLabel.TabIndex = 24;
            this.baudRateLabel.Text = "Baud Rate";
            // 
            // serialConnectionsList
            // 
            this.serialConnectionsList.Controls.Add(this.clearLogs);
            this.serialConnectionsList.Controls.Add(this.logsLabel);
            this.serialConnectionsList.Controls.Add(this.logs);
            this.serialConnectionsList.Controls.Add(this.openSerialPort);
            this.serialConnectionsList.Controls.Add(this.deleteSerialPort);
            this.serialConnectionsList.Controls.Add(this.editSerialPort);
            this.serialConnectionsList.Controls.Add(this.reloadSerialPorts);
            this.serialConnectionsList.Controls.Add(this.serialConnections);
            this.serialConnectionsList.Location = new System.Drawing.Point(4, 22);
            this.serialConnectionsList.Name = "serialConnectionsList";
            this.serialConnectionsList.Padding = new System.Windows.Forms.Padding(3);
            this.serialConnectionsList.Size = new System.Drawing.Size(789, 426);
            this.serialConnectionsList.TabIndex = 3;
            this.serialConnectionsList.Text = "Serial Connections";
            this.serialConnectionsList.UseVisualStyleBackColor = true;
            // 
            // clearLogs
            // 
            this.clearLogs.Location = new System.Drawing.Point(569, 287);
            this.clearLogs.Name = "clearLogs";
            this.clearLogs.Size = new System.Drawing.Size(91, 36);
            this.clearLogs.TabIndex = 15;
            this.clearLogs.Text = "Clear";
            this.clearLogs.UseVisualStyleBackColor = true;
            this.clearLogs.Click += new System.EventHandler(this.clearLogs_Click);
            // 
            // logsLabel
            // 
            this.logsLabel.AutoSize = true;
            this.logsLabel.Location = new System.Drawing.Point(6, 225);
            this.logsLabel.Name = "logsLabel";
            this.logsLabel.Size = new System.Drawing.Size(30, 13);
            this.logsLabel.TabIndex = 14;
            this.logsLabel.Text = "Logs";
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(9, 241);
            this.logs.Multiline = true;
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(554, 163);
            this.logs.TabIndex = 13;
            // 
            // openSerialPort
            // 
            this.openSerialPort.Location = new System.Drawing.Point(6, 174);
            this.openSerialPort.Name = "openSerialPort";
            this.openSerialPort.Size = new System.Drawing.Size(91, 35);
            this.openSerialPort.TabIndex = 12;
            this.openSerialPort.Text = "Open";
            this.openSerialPort.UseVisualStyleBackColor = true;
            this.openSerialPort.Click += new System.EventHandler(this.openSerialPort_Click);
            // 
            // deleteSerialPort
            // 
            this.deleteSerialPort.Location = new System.Drawing.Point(557, 173);
            this.deleteSerialPort.Name = "deleteSerialPort";
            this.deleteSerialPort.Size = new System.Drawing.Size(91, 36);
            this.deleteSerialPort.TabIndex = 11;
            this.deleteSerialPort.Text = "Delete";
            this.deleteSerialPort.UseVisualStyleBackColor = true;
            this.deleteSerialPort.Click += new System.EventHandler(this.deleteSerialPort_Click);
            // 
            // editSerialPort
            // 
            this.editSerialPort.Location = new System.Drawing.Point(448, 173);
            this.editSerialPort.Name = "editSerialPort";
            this.editSerialPort.Size = new System.Drawing.Size(91, 36);
            this.editSerialPort.TabIndex = 10;
            this.editSerialPort.Text = "Edit";
            this.editSerialPort.UseVisualStyleBackColor = true;
            this.editSerialPort.Click += new System.EventHandler(this.editSerialPort_Click);
            // 
            // reloadSerialPorts
            // 
            this.reloadSerialPorts.Location = new System.Drawing.Point(245, 173);
            this.reloadSerialPorts.Name = "reloadSerialPorts";
            this.reloadSerialPorts.Size = new System.Drawing.Size(91, 36);
            this.reloadSerialPorts.TabIndex = 9;
            this.reloadSerialPorts.Text = "Reload";
            this.reloadSerialPorts.UseVisualStyleBackColor = true;
            this.reloadSerialPorts.Click += new System.EventHandler(this.reloadSerialPorts_Click);
            // 
            // serialConnections
            // 
            this.serialConnections.AllowDrop = true;
            this.serialConnections.AllowUserToAddRows = false;
            this.serialConnections.AllowUserToDeleteRows = false;
            this.serialConnections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.serialConnections.BackgroundColor = System.Drawing.Color.White;
            this.serialConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serialConnections.Location = new System.Drawing.Point(5, 18);
            this.serialConnections.Name = "serialConnections";
            this.serialConnections.ReadOnly = true;
            this.serialConnections.Size = new System.Drawing.Size(776, 149);
            this.serialConnections.TabIndex = 8;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 464);
            this.Controls.Add(this.ConnectionTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Homepage";
            this.Text = "Home Page";
            this.Load += new System.EventHandler(this.Homepage_Load);
            this.ConnectionTab.ResumeLayout(false);
            this.registerTcpIpConnection.ResumeLayout(false);
            this.registerTcpIpConnection.PerformLayout();
            this.tcpIpConnectionsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcpIpConnections)).EndInit();
            this.newSerialConnection.ResumeLayout(false);
            this.newSerialConnection.PerformLayout();
            this.serialConnectionsList.ResumeLayout(false);
            this.serialConnectionsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialConnections)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ConnectionTab;
        private System.Windows.Forms.TabPage registerTcpIpConnection;
        private System.Windows.Forms.TabPage tcpIpConnectionsList;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Label connectionNameLabel;
        private System.Windows.Forms.TextBox connectionName;
        private System.Windows.Forms.Button instanceSave;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.RadioButton clientRadio;
        private System.Windows.Forms.RadioButton serverRadio;
        private string DbConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private string ipAddressValue;
        private int portValue;
        private ConnectionWindow connectionWindow;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label autoEstablishLabel;
        private System.Windows.Forms.Button establishConnection;
        private System.Windows.Forms.Button deleteConnection;
        private System.Windows.Forms.Button editConnection;
        private System.Windows.Forms.Button reloadConnectionList;
        private System.Windows.Forms.DataGridView tcpIpConnections;
        private System.Windows.Forms.CheckBox autoEstablish;
        private System.Windows.Forms.Label errorLabel;
        private SerialCommunication serialPort;
        private System.Windows.Forms.TabPage newSerialConnection;
        private System.Windows.Forms.TabPage serialConnectionsList;
        private System.Windows.Forms.Button openSerialPort;
        private System.Windows.Forms.Button deleteSerialPort;
        private System.Windows.Forms.Button editSerialPort;
        private System.Windows.Forms.Button reloadSerialPorts;
        private System.Windows.Forms.DataGridView serialConnections;
        private System.Windows.Forms.CheckBox autoOpen;
        private System.Windows.Forms.Label autoOpenLabel;
        private System.Windows.Forms.Label serialPortNameLabel;
        private System.Windows.Forms.Button saveSerialPortSettings;
        private System.Windows.Forms.TextBox baudRate;
        private System.Windows.Forms.Label parityLabel;
        private System.Windows.Forms.Label baudRateLabel;
        private System.Windows.Forms.ComboBox serialPortName;
        private System.Windows.Forms.ComboBox stopBit;
        private System.Windows.Forms.ComboBox transferBits;
        private System.Windows.Forms.Label transferBitsLabel;
        private System.Windows.Forms.Label stopBitLabel;
        private System.Windows.Forms.ComboBox parity;
        private System.Windows.Forms.Button testOpenSerialPort;
        private System.Windows.Forms.Button clearLogs;
        private System.Windows.Forms.Label logsLabel;
        private System.Windows.Forms.TextBox logs;
        private int idHolder = 0;
    }
}


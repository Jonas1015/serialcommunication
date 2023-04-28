using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Data.SQLite;
using System.Reflection;
using System.IO;

namespace serialcom
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            this.LoadTcpIpConnections();
            this.LoadSerialSettings();
            this.autoOpenSerialConnection();
            this.establishTcpIpConnection();
        }

        private void EstablishConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tcpIpConnections.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = this.tcpIpConnections.SelectedRows[0];
                    this.ipAddressValue = selectedRow.Cells["IP Address"].Value.ToString();
                    this.portValue = int.Parse(selectedRow.Cells["Port"].Value.ToString());

                    if(this.ipAddressValue != null)
                    {
                       establishTcpIpConnection(true);
                    }
                } else
                {
                    throw new Exception("Select 1 row to use when establishing a connection.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't establish connection. Error {ex.Message}");
            }   
        }

        private void establishTcpIpConnection(bool isManualConnection = false)
        {
            try
            {

                string fileContents;
                string filePath = @"C:\Abbott-m2000rt_Results.txt";

                // Open the file for reading using a StreamReader
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read the contents of the file into a string
                    fileContents = reader.ReadToEnd();

                    // Display the contents of the file in the console
                }
                if(this.ipAddress != null)
                {
                    connectionWindow = new ConnectionWindow(this.ipAddressValue, this.portValue)
                    {
                        DbConnectionString = this.DbConnectionString,
                        dataToBeSent = fileContents,

                    };
                } else
                {
                    connectionWindow = new ConnectionWindow
                    {
                        DbConnectionString = this.DbConnectionString,
                        dataToBeSent = fileContents,

                    };

                }
                if (isManualConnection)
                {
                    connectionWindow.createTcpIpConnection();
                    connectionWindow.Show();
                } 
                else
                {
                    if (!connectionWindow.AutoStartTcpIpConnection())
                    {
                        connectionWindow.createTcpIpConnection();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void instanceSave_Click(object sender, EventArgs e)
        {
            SaveTcpIpConnection();
            LoadTcpIpConnections();
        }

        private void SaveTcpIpConnection()
        {
            try
            {
                if (
                    this.connectionName.Text.Length > 0 &&
                    this.ipAddress.Text.Length > 0 &&
                    this.port.Text.Length > 0 &&
                    (this.serverRadio.Checked || this.clientRadio.Checked)
                )
                {
                    if(idHolder == 0)
                    {
                        string type = this.serverRadio.Checked ? "Server" : this.clientRadio.Checked ? "Client" : null;
                        int port = 80;
                        int autoEstablishConnection = this.autoEstablish.Checked ? 1 : 0;
                        if (int.TryParse(this.port.Text, out int result))
                        {
                            port = result;
                        }
                        string query = $"SELECT * FROM TcpIpSettings WHERE type='{type}' AND connection_name='{this.connectionName.Text}' AND ip_address='{this.ipAddress.Text}' AND port={port};";
                        SQLiteConnection connection = new SQLiteConnection(this.DbConnectionString);
                        connection.Open();
                        SQLiteCommand command = new SQLiteCommand(query, connection);
                        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            if (autoEstablishConnection == 1)
                            {
                                query = $"UPDATE TcpIpSettings SET auto_connect=0;";
                                command = new SQLiteCommand(query, connection);
                                command.ExecuteNonQuery();
                            }
                            query = $"INSERT INTO TcpIpSettings Values (NULL, '{type}', '{this.connectionName.Text}', '{this.ipAddress.Text}', {port}, {autoEstablishConnection});";
                            command = new SQLiteCommand(query, connection);
                            var response = command.ExecuteNonQuery();
                            if (response > 0)
                            {

                                MessageBox.Show("TCP/IP connection settings saved successfully");
                                this.serverRadio.Checked = false;
                                this.clientRadio.Checked = false;
                                this.autoEstablish.Checked = false;
                                this.connectionName.Text = null;
                                this.ipAddress.Text = null;
                                this.port.Text = null;
                                this.LoadTcpIpConnections();
                            }
                            else
                            {
                                throw new Exception("Couldn't save data into the database.");
                            }
                        }
                        if (dataTable.Rows.Count > 0)
                        {
                            this.errorLabel.Text = "This connection exists, change some details before saving.";
                            this.errorLabel.Visible = true;
                        }
                        connection.Close();
                    }

                    if (this.idHolder > 0)
                    {
                        string type = this.serverRadio.Checked ? "Server" : this.clientRadio.Checked ? "Client" : null;
                        int port = 80;
                        int autoEstablishConnection = this.autoEstablish.Checked ? 1 : 0;
                        if (int.TryParse(this.port.Text, out int result))
                        {
                            port = result;
                        }
                        string query = $"UPDATE TcpIpSettings SET type='{type}', connection_name='{this.connectionName.Text}', ip_address='{this.ipAddress.Text}', port={port}, auto_connect={autoEstablishConnection} WHERE id={this.idHolder};";
                        SQLiteConnection connection = new SQLiteConnection(this.DbConnectionString);
                        connection.Open();
                        SQLiteCommand command = new SQLiteCommand(query, connection);
                        command = new SQLiteCommand(query, connection);
                        var response = command.ExecuteNonQuery();
                        if (response > 0)
                        {

                            MessageBox.Show("TCP/IP connection settings updated successfully");
                            this.serverRadio.Checked = false;
                            this.clientRadio.Checked = false;
                            this.autoEstablish.Checked = false;
                            this.connectionName.Text = null;
                            this.ipAddress.Text = null;
                            this.port.Text = null;
                            
                            this.ConnectionTab.SelectedTab = this.tcpIpConnectionsList;
                        }
                        else
                        {
                            throw new Exception("Couldn't save data into the database.");
                        }
                        if (autoEstablishConnection == 1)
                        {
                            query = $"UPDATE TcpIpSettings SET auto_connect=0 WHERE id!={this.idHolder};";
                            command = new SQLiteCommand(query, connection);
                            response = command.ExecuteNonQuery();
                        }
                        this.idHolder = 0;
                        connection.Close();
                    }
                }
                else
                {
                    this.errorLabel.Text = "All fields with asterisks (*) are mandatory! Fill them before saving.";
                    this.errorLabel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save data. Error: {ex.Message}");
            }
        }

        private void LoadTcpIpConnections()
        {
            try
            {
                string query = $"SELECT * FROM TcpIpSettings;";
                SQLiteConnection connection = new SQLiteConnection(this.DbConnectionString);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                DataTable dataTable2 = new DataTable();
                dataTable2.Columns.Add("S/N");
                dataTable2.Columns.Add("Connection Name");
                dataTable2.Columns.Add("IP Address");
                dataTable2.Columns.Add("Port");
                dataTable2.Columns.Add("Type");
                dataTable2.Columns.Add("Auto Connect");
                dataTable2.Columns.Add("id");
                int count = 1;
                foreach (DataRow row in dataTable.Rows)
                {
                    DataRow newRow = dataTable2.NewRow();
                    newRow["S/N"] = count;
                    newRow["id"] = row["id"];
                    newRow["Connection Name"] = row["connection_name"];
                    newRow["IP Address"] = row["ip_address"];
                    newRow["Port"] = row["port"];
                    newRow["Type"] = row["type"];
                    string autoConnect = "No";
                    if (row["auto_connect"].ToString() == "1") autoConnect = "Yes";
                    newRow["Auto Connect"] = autoConnect;
                    dataTable2.Rows.Add(newRow);
                    count++;
                }
                this.tcpIpConnections.DataSource = dataTable2;
                this.tcpIpConnections.Columns["id"].Visible = false;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message.ToString()}");
            }
        }

        private void reloadConnectionList_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadTcpIpConnections();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data. Error: {ex.Message.ToString()}");
            }
        }

        private void HandleSerialCommunication(string serialPortName, int baudRate, int transferBits, string stopBit, string parity)
        {
            try
            {
                serialPort = new SerialCommunication();
                serialPort.startSerialPort(serialPortName, baudRate, transferBits, stopBit, parity);
                if (serialPort.serialPort.IsOpen)
                {
                    serialPort.readSerialPort();
                    if (serialPort._continue)
                    {
                        this.logs.Text += $"\r\n {serialPort.receivedData} [{DateTime.Now}]";
                    }
                    if (!serialPort._continue)
                    {
                        this.connectionWindow.dataToBeSent = serialPort.receivedData;
                        this.connectionWindow.sendConnectionData();
                    }
                }
                else
                {
                    this.logs.Text += $"\r\n Serial Port is not open. [{DateTime.Now}]";
                }
            }
            catch (Exception ex)
            {
                this.logs.Text += $"\r\n Can't Open serial port. Error: {ex.Message}";
            }
        }

        private void LoadSerialSettings()
        {
            try
            {
                string query = $"SELECT * FROM SerialSettings;";
                SQLiteConnection connection = new SQLiteConnection(this.DbConnectionString);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                DataTable dataTable2 = new DataTable();
                dataTable2.Columns.Add("S/N");
                dataTable2.Columns.Add("Port Name");
                dataTable2.Columns.Add("BaudRate");
                dataTable2.Columns.Add("Transfer Bits");
                dataTable2.Columns.Add("Stop Bit");
                dataTable2.Columns.Add("Parity");
                dataTable2.Columns.Add("Auto Open");
                dataTable2.Columns.Add("id");

                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
                idColumn.Name = "id";
                idColumn.Visible = false;

                int count = 1;
                foreach (DataRow row in dataTable.Rows)
                {
                    DataRow newRow = dataTable2.NewRow();
                    newRow["S/N"] = count;
                    newRow["id"] = row["id"];
                    newRow["Port Name"] = row["port_name"];
                    newRow["BaudRate"] = row["baud_rate"];
                    newRow["Transfer Bits"] = row["transfer_bits"];
                    newRow["Stop Bit"] = row["stop_bit"];
                    newRow["Parity"] = row["parity"];
                    string autoStart = "No";
                    if (row["auto_open"].ToString() == "1") autoStart = "Yes";
                    newRow["Auto Open"] = autoStart;
                    dataTable2.Rows.Add(newRow);
                    count++;
                }
                this.serialConnections.DataSource = dataTable2;
                this.serialConnections.Columns["id"].Visible = false;
                connection.Close();

                this.serialPortName.DataSource = SerialPort.GetPortNames().Length > 0 ? SerialPort.GetPortNames() : new string[] { "No Serial Ports Detected" };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message.ToString()}");
            }
        }

        private void SaveSerialSettings()
        {
            try
            {
                var serialPortName = this.serialPortName.SelectedItem.ToString();
                var parityBitsValue = this.parity.SelectedItem != null ? this.parity.SelectedItem.ToString() : "None";
                var stopBitValue = this.stopBit.SelectedItem != null ? this.stopBit.SelectedItem.ToString() : "None";
                var transferBitsValue = 
                    this.transferBits.SelectedItem.ToString() == "8 bits" ? 8 
                    : this.transferBits.SelectedItem.ToString() == "7 bits" ? 7
                    : this.transferBits.SelectedItem.ToString() == "6 bits" ? 6
                    : this.transferBits.SelectedItem.ToString() == "5 bits" ? 5
                    : 8;
                var autoOpen = this.autoOpen.Checked ? 1 : 0;
                var baudRateValue = 9600;
                if (int.TryParse(this.baudRate.Text, out int baudRate))
                {
                    baudRateValue = baudRate;
                }

                if(this.idHolder == 0)
                {
                    string query = $"SELECT * FROM SerialSettings WHERE port_name='{serialPortName}' AND parity='{parityBitsValue}' AND transfer_bits={transferBitsValue} AND stop_bit='{stopBitValue}';";
                    SQLiteConnection connection = new SQLiteConnection(this.DbConnectionString);
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count == 0)
                    {
                        if (autoOpen == 1)
                        {
                            query = $"UPDATE SerialSettings SET auto_open=0;";
                            command = new SQLiteCommand(query, connection);
                            command.ExecuteNonQuery();
                        }
                        query = $"INSERT INTO SerialSettings Values (NULL, '{serialPortName}', {autoOpen}, '{parityBitsValue}', {transferBitsValue}, '{stopBitValue}', {baudRateValue});";
                        command = new SQLiteCommand(query, connection);
                        var response = command.ExecuteNonQuery();
                        if (response > 0)
                        {

                            MessageBox.Show("Serial Port Settings saved successfully");
                            this.serialPortName.SelectedItem = null;
                            this.autoOpen.Checked = false;
                            this.baudRate.Text = null;
                            this.stopBit.Text = null;
                            this.transferBits.SelectedItem = null;
                            this.parity = null;
                        }
                        else
                        {
                            MessageBox.Show("Couldn't save data into the database.");
                        }
                    }
                    if (dataTable.Rows.Count > 0)
                    {
                        this.errorLabel.Text = "This port already exists!";
                        this.errorLabel.Visible = true;
                    }
                    connection.Close();
                }
                else
                {
                    SQLiteConnection connection = new SQLiteConnection(this.DbConnectionString);
                    connection.Open();
                    
                    string query = $"UPDATE SerialSettings SET port_name='{serialPortName}', auto_open={autoOpen}, parity='{parityBitsValue}', transfer_bits={transferBitsValue}, stop_bit='{stopBitValue}', baud_rate={baudRateValue} WHERE id={this.idHolder};";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    var response = command.ExecuteNonQuery();
                    if (response > 0)
                    {

                        MessageBox.Show("Serial Port Settings updated successfully");
                        this.serialPortName.SelectedItem = null;
                        this.autoOpen.Checked = false;
                        this.baudRate.Text = null;
                        this.stopBit.Text = null;
                        this.transferBits.SelectedItem = null;
                        this.parity = null;
                    }
                    else
                    {
                        MessageBox.Show("Couldn't save data into the database.");
                    }

                    if(autoOpen == 1 && this.idHolder > 0)
                    {
                        query = $"UPDATE SerialSettings SET auto_open=0 WHERE id != {idHolder};";
                        command = new SQLiteCommand(query, connection);
                        response = command.ExecuteNonQuery();
                        if (response > 0)
                        {
                            this.serialPortName.SelectedItem = null;
                            this.autoOpen.Checked = false;
                            this.baudRate.Text = null;
                            this.stopBit.Text = null;
                            this.transferBits.SelectedItem = null;
                            this.parity = null;
                        }
                        else
                        {
                            MessageBox.Show("Couldn't set auto open for unapplied fields.");
                        }
                    }
                    connection.Close();
                    this.idHolder = 0;
                }

                this.ConnectionTab.SelectedTab = this.serialConnectionsList;

            } 
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void saveSerialPortSettings_Click(object sender, EventArgs e)
        {
            this.SaveSerialSettings();
            this.LoadSerialSettings();
        }

        private void reloadSerialPorts_Click(object sender, EventArgs e)
        {
            this.LoadSerialSettings();
        }

        private void autoOpenSerialConnection()
        {
            string query = $"SELECT * FROM SerialSettings WHERE auto_open=1;";
            SQLiteConnection connection = new SQLiteConnection(this.DbConnectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            if(dataTable.Rows.Count == 1)
            {
                var portName = dataTable.Rows[0]["port_name"].ToString();
                var baudRate = int.Parse(dataTable.Rows[0]["baud_rate"].ToString());
                var parity = dataTable.Rows[0]["parity"].ToString();
                var transferBits = int.Parse(dataTable.Rows[0]["transfer_bits"].ToString());
                var StopBit = dataTable.Rows[0]["stop_bit"].ToString();

                HandleSerialCommunication(portName, baudRate, transferBits, StopBit, parity);
            }
        }

        private void openSerialPort_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.serialConnections.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = this.serialConnections.SelectedRows[0];
                    var portName = selectedRow.Cells["Port Name"].Value.ToString();
                    var baudRate = int.Parse(selectedRow.Cells["BaudRate"].Value.ToString());
                    var parity = selectedRow.Cells["Parity"].Value.ToString();
                    var transferBits = int.Parse(selectedRow.Cells["Transfer Bits"].Value.ToString());
                    var StopBit = selectedRow.Cells["Stop Bit"].Value.ToString();


                    if (portName.Contains("No Serial"))
                    {
                        throw new Exception("Unknown serial port.");
                    }
                    HandleSerialCommunication(portName, baudRate, transferBits, StopBit, parity);
                }
                else
                {
                    throw new Exception("Select 1 row to use when establishing a connection.");
                }
            }
            catch (Exception ex)
            {
                this.logs.Text += $"\r\n Can't establish connection. Error {ex.Message} [{DateTime.Now}]";
            }
        }

        private void testOpenSerialPort_Click(object sender, EventArgs e)
        {
            try
            {
                var serialPortName = this.serialPortName.SelectedItem.ToString();
                var parityBitsValue = this.parity.SelectedItem != null ? this.parity.SelectedItem.ToString() : "None";
                var stopBitValue = this.stopBit.SelectedItem != null ? this.stopBit.SelectedItem.ToString() : "None";
                var transferBitsValue =
                    this.transferBits.SelectedItem.ToString() == "8 bits" ? 8
                    : this.transferBits.SelectedItem.ToString() == "7 bits" ? 7
                    : this.transferBits.SelectedItem.ToString() == "6 bits" ? 6
                    : this.transferBits.SelectedItem.ToString() == "5 bits" ? 5
                    : 8;
                var baudRateValue = 9600;
                if (int.TryParse(this.baudRate.Text, out int baudRate))
                {
                    baudRateValue = baudRate;
                }
                HandleSerialCommunication(serialPortName, baudRateValue, transferBitsValue, stopBitValue, parityBitsValue);
            }
            catch (Exception ex)
            {
                this.logs.Text += $"\r\n Can't establish connection. Error {ex.Message} [{DateTime.Now}]";
            }
        }

        private void editSerialPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.serialConnections.SelectedRows.Count == 1)
                {
                    GetSelectedSerialPortData("Edit");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couln't edit record. Error {ex.Message}");
            }
        }

        private void editConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tcpIpConnections.SelectedRows.Count == 1)
                {
                    GetSelectedTcpIpConnectionData("Edit");
                } else
                {
                    throw new Exception("Select 1 row if you need to edit.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couln't edit record. Error {ex.Message}");
            }
        }

        private void GetSelectedTcpIpConnectionData(string action)
        {
            try
            {
                DataGridViewRow selectedRow = this.tcpIpConnections.SelectedRows[0];
                this.idHolder = int.Parse(selectedRow.Cells["id"].Value.ToString());
                if (action == "Edit")
                {
                    var connectionName = selectedRow.Cells["Connection Name"].Value.ToString();
                    var ipAddress = selectedRow.Cells["IP Address"].Value.ToString();
                    var port = selectedRow.Cells["Port"].Value.ToString();
                    var autoConnect = selectedRow.Cells["Auto Connect"].Value.ToString() == "Yes";
                    var type = selectedRow.Cells["Type"].Value.ToString();


                    this.connectionName.Text = connectionName;
                    this.ipAddress.Text = ipAddress;
                    this.port.Text = port;
                    this.serverRadio.Checked = type == "Server";
                    this.clientRadio.Checked = type == "Client";
                    this.autoEstablish.Checked = autoConnect;
                    this.ConnectionTab.SelectedTab = this.registerTcpIpConnection;
                }
            }
            catch (Exception)
            {
                throw new Exception("Failed to obtain data from selected row.");
            }
        }
        private void GetSelectedSerialPortData(string action)
        {
            try
            {

                DataGridViewRow selectedRow = this.serialConnections.SelectedRows[0];
                this.idHolder = int.Parse(selectedRow.Cells["id"].Value.ToString());
                if (action == "Edit")
                {
                    var portName = selectedRow.Cells["Port Name"].Value.ToString();
                    var baudRate = selectedRow.Cells["BaudRate"].Value.ToString();
                    var parity = selectedRow.Cells["Parity"].Value.ToString();
                    var transferBits = int.Parse(selectedRow.Cells["Transfer Bits"].Value.ToString());
                    var StopBit = selectedRow.Cells["Stop Bit"].Value.ToString();
                    var autoOpen = selectedRow.Cells["Auto Open"].Value.ToString();

                    this.serialPortName.SelectedItem = portName;
                    this.baudRate.Text = baudRate;
                    this.parity.SelectedItem = parity;
                    this.transferBits.SelectedItem = transferBits == 8 ? "8 bits" :
                        transferBits == 7 ? "7 bits" :
                        transferBits == 6 ? "6 bits" :
                        "5 bits";
                    this.stopBit.SelectedItem = StopBit;
                    this.autoOpen.Checked = autoOpen == "Yes" ? true : false;
                    this.ConnectionTab.SelectedTab = this.newSerialConnection;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to obtain data from selected row. Error: {ex.Message}");
            }
        }

        private void DeleteSerialConnectionData()
        {
            try
            {
                string query = $"DELETE FROM SerialSettings WHERE id={this.idHolder};";
                SQLiteConnection connection = new SQLiteConnection(this.DbConnectionString);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command = new SQLiteCommand(query, connection);
                var response = command.ExecuteNonQuery();
                if (response > 0)
                {
                    MessageBox.Show("Serial port settings deleted successfully");
                }
                else
                {
                    throw new Exception("Couldn't save data into the database.");
                }
                this.idHolder = 0;
                LoadSerialSettings();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete record. Error: {ex.Message}");
            }
        }
        private void DeleteTcpIpConnectionData()
        {
            try
            {
                string query = $"DELETE FROM TcpIpSettings WHERE id={this.idHolder};";
                SQLiteConnection connection = new SQLiteConnection(this.DbConnectionString);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command = new SQLiteCommand(query, connection);
                var response = command.ExecuteNonQuery();
                if (response > 0)
                {
                    MessageBox.Show("TCP/IP connection settings deleted successfully");
                }
                else
                {
                    throw new Exception("Couldn't save data into the database.");
                }
                this.idHolder = 0;
                LoadTcpIpConnections();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete record. Error: {ex.Message}");
            }
        }

        private void deleteConnection_Click(object sender, EventArgs e)
        {
            try
            {
                GetSelectedTcpIpConnectionData(String.Empty);
                DeleteTcpIpConnectionData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldn't delete record. Error: {ex.Message}");
            }
        }

        private void deleteSerialPort_Click(object sender, EventArgs e)
        {
            try
            {
                GetSelectedSerialPortData(String.Empty);
                DeleteSerialConnectionData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldn't delete record. Error: {ex.Message}");
            }
        }

        private void clearLogs_Click(object sender, EventArgs e)
        {
            this.logs.Text = null;
        }

    }
}

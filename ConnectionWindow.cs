using System;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Net;

namespace serialcom
{
    public partial class ConnectionWindow : Form
    {
        public ConnectionWindow()
        {
            InitializeComponent();
        }
        public ConnectionWindow(string ipAddress, int port)
        {
            this.ipAddress = ipAddress;
            this.port = port;
            InitializeComponent();
        }

        private void ConnectionWindow_Load(object sender, EventArgs e)
        {
            AutoStartTcpIpConnection();
        }

        public void createTcpIpConnection()
        {
            try
            {
                tcpConnection = new TcpIpConnection(this.ipAddress, this.port);
                this.connectionStatusLabel.Text = $"Connecting ...";
                this.connectionStatusLabel.Visible = true;
                tcpConnection.connect();
                if (tcpConnection.clientSocket.Connected)
                {
                    this.logs.Text += $"\r\n Connected [{DateTime.Now}]";
                    this.connectionStatusLabel.Text = $"Connected";
                }
                else
                {
                    this.connectionStatusLabel.Text = $"Not Connected";
                }
            }
            catch (Exception ex)
            {
                this.connectionStatusLabel.Text = $"Not Connected";
                this.logs.Text += $"\r\n Error Occured: {ex.Message} [{DateTime.Now}]";
            }
        }

        public void sendConnectionData()
        {
            try
            {
                logs.Text += $"\r\n Sent {tcpConnection.sendData(dataToBeSent)} bytes of data [{DateTime.Now}]";
                logs.Text += $"\r\n Sent {tcpConnection.sendData(new Byte[] { 0x04 })} bytes of data [{DateTime.Now}]";
            }
            catch (Exception ex)
            {
                logs.Text += $"\r\n Can't send data. Error {ex.Message} [{DateTime.Now}]";
            }
        }

        private void sendTestData_Click(object sender, EventArgs e)
        {
            sendConnectionData();
        }
        
        public bool AutoStartTcpIpConnection()
        {
            try
            {
                bool isAutoConnect = false;
                string query = $"SELECT * FROM TcpIpSettings WHERE auto_connect=1;";
                SQLiteConnection connection = new SQLiteConnection(this.DbConnectionString);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if(dataTable.Rows.Count == 1)
                {
                    this.ipAddress = dataTable.Rows[0]["ip_address"].ToString();
                    this.port = 80;
                    if(int.TryParse(dataTable.Rows[0]["port"].ToString(), out int parsedPort))
                    {
                        this.port = parsedPort;
                    }

                    createTcpIpConnection();
                    isAutoConnect = true;
                } else
                {
                    logs.Text += $"\r\n No connection was set for auto start. [{DateTime.Now}]";
                }
                
                connection.Close();
                return isAutoConnect;
            }
            catch (Exception ex)
            {
                logs.Text += $"\r\n Error: {ex.Message} [{DateTime.Now}]";
                return false;
            }

        }

        private void reconnect_Click(object sender, EventArgs e)
        {
            createTcpIpConnection();
        }

        private void clearLogsButton_Click(object sender, EventArgs e)
        {
            this.logs.Text = string.Empty;
        }
    }
}

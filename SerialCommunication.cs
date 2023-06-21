using System;
using System.IO.Ports;
using System.Text;
using System.IO;

namespace serialcom
{
    public class SerialCommunication
    {
        public SerialPort serialPort { get; set; }
        public string receivedData { get; set; }
        public bool _continue { get; set; }
        public string log { get; set; }
        public void startSerialPort(string COMPortName, int baudRate, int transferBits, string stopBit, string parity)
        {
            try
            {
                var parityValue = parity == "None" ? Parity.None :
                    parity == "Odd" ? Parity.Odd :
                    parity == "Even" ? Parity.Even :
                    parity == "Mark" ? Parity.Mark :
                    parity == "Space" ? Parity.Space :
                    Parity.None;
                var stopBitValue = stopBit == "None" ? StopBits.None :
                    stopBit == "One" ? StopBits.One :
                    stopBit == "Two" ? StopBits.Two :
                    stopBit == "One Point Five" ? StopBits.OnePointFive :
                    StopBits.None;
                this.serialPort = new SerialPort(COMPortName, baudRate, parityValue, transferBits, stopBitValue); // Create a new SerialPort object
                this.serialPort.RtsEnable = true;
                if (!serialPort.IsOpen)
                    serialPort.Open(); // Open the serial port
            }
            catch (Exception ex)
            {
                log += $"\r\n Failed to open serial port. Error: {ex.Message} [{DateTime.Now}]";
            }
        }

        public void readSerialPort()
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                }
            }
            catch (Exception ex)
            {
                log += $"\r\n Can't read data from serial port. Error {ex.Message} [{DateTime.Now}]";
            }
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                if (sp.IsOpen)
                {
                    _continue = true;
                    byte[] buffer = new byte[sp.BytesToRead];
                    int bytesRead = sp.Read(buffer, 0, buffer.Length);

                    string hexaString = BitConverter.ToString(buffer);

                    if (hexaString == "05")
                    {
                        log += $"Sender Enquiry [{DateTime.Now}] \n";
                        sp.Write(new byte[] { 0x06 }, 0, 1);
                        log += $"\r\n Acknowledgement sent and ready to receive data. [{DateTime.Now}] \n";
                    }

                    if (hexaString == "04")
                    {
                        log += $"\r\n Sender terminated [{DateTime.Now}]\n";
                        _continue = false;
                    }
                    if (bytesRead > 0 && hexaString != "05" && hexaString != "04" && _continue)
                    {
                        var dataReceived = Encoding.ASCII.GetString(buffer);
                        this.receivedData += dataReceived;
                        log += $"{dataReceived}";
                        sp.Write(new byte[] { 0x06 }, 0, 1);
                    }

                    if (!_continue)
                    {
                        var connectionWindow = new ConnectionWindow();
                        connectionWindow.dataToBeSent = receivedData;
                        connectionWindow.createTcpIpConnection();
                        connectionWindow.sendConnectionData();

                        Console.WriteLine(log);
                        //string path = $@"C:\Abbott-m2000rt_Results_{DateTime.Now}.txt";

                        //using (StreamWriter writer = new StreamWriter(path))
                        //{
                        //    writer.Write(log);
                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't read data. Error {ex.Message}");
            }
        }


        public void stopSerialPort()
        {
            if (serialPort.IsOpen) 
            {
                serialPort.Close();            
            }
        }
    }
}

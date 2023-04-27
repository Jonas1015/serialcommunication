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
            try
            {
                //SerialPort serialPort = new SerialPort("COM3", 9600); // Create a new SerialPort object
                //serialPort.Open(); // Open the serial port

                //string data = serialPort.ReadLine(); // Read a line of data from the serial port
                //Console.WriteLine(data); // Print the data to the console
                //serialPort.Close(); // Close the serial port when you're done
                Console.WriteLine("Here");
                foreach (string port in SerialPort.GetPortNames())
                {
                    Console.WriteLine("==> Ports: ", port);
                }

                //using var sp = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                //sp.Open();

                //sp.WriteLine("Hello!");

                //var readData = sp.ReadLine();
                //Console.WriteLine(readData);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

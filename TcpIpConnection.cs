using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace serialcom
{
    public class TcpIpConnection
    {
        public Socket clientSocket { get; set; }
        public IPAddress ipAddress { get; set; }
        public int port { get; set; }
        public TcpIpConnection(string ipAddress, int port) 
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
        }

        public void connect()
        {
            IPEndPoint remoteEP = new IPEndPoint(this.ipAddress, port);

            // Create a TCP/IP socket.
            this.clientSocket = new Socket(this.ipAddress.AddressFamily,
                                              SocketType.Stream,
                                              ProtocolType.Tcp);

            // Connect to the remote endpoint.
            this.clientSocket.Connect(remoteEP);
        }

        public int sendData(string data) 
        {
            byte[] sendingBuffer = Encoding.ASCII.GetBytes(data);
            int bytesSent = this.clientSocket.Send(sendingBuffer);
            return bytesSent;
        }
        public int sendData(byte[] hexaData) 
        {
            int bytesSent = this.clientSocket.Send(hexaData);
            return bytesSent;
        }

        public string  receiveData()
        {
            // Receive a response from the server.
            byte[] buffer = new byte[1024];
            int bytesReceived = clientSocket.Receive(buffer);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesReceived);

            return response;
        }
        public void disconnect() 
        {
            this.clientSocket.Close();
        }
    }
}

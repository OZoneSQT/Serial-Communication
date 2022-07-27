using System;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace SerialCommunication
{
    internal class Program
    {
        private static int baud = 38400;
        private static Parity parity = Parity.None;
        private static int packetSize = 8;  // number of bits in a data packet
        private static StopBits stopBits = StopBits.Two;


        public static int Main(string[] args)
        {
            SerialCom serialCom = new SerialCom();
            serialCom.SetSerialPort(baud, parity, packetSize, stopBits);
            int i = serialCom.MainAsync(args).GetAwaiter().GetResult();

            serialCom.EndConnection();
            return i;
        }

    }
}


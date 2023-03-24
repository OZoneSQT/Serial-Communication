using System;
using System.IO.Ports;
using Client.Communication;
using Client;

namespace Client
{
    internal class Program
    {
        private static int baud = 38400;
        private static Parity parity = Parity.None;
        private static int packetSize = 8;  // number of bits in a data packet
        private static StopBits stopBits = StopBits.Two;
        private static bool dtr = false;
        private static bool rts = false;

        private static int puKey = 0;
        private static int prKey = 0;

        public static int Main(string[] args)
        {
            Com com = new Com();
            RS232 serialCom = new RS232(baud, parity, packetSize, stopBits, dtr, rts, ref com);

            serialCom.WriteToPort(com);     // Do something

            serialCom.EndConnection();
            return 0;
        }

    }
}
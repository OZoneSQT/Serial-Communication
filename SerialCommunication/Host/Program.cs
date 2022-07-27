using System;
using System.IO.Ports;
using Host.Communication;

namespace Host
{
    internal class Program
    {
        /*
         * RS485: 38400 baud, 2 stopbit and no paritet.
         * Module addresses: 1-255, all units answers at address 0
         * KMP protocole
         * Only able to communicate with: 65-S, MC401 and Ufx4. Rest/Others are only verified
         */
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

            // Do something

            serialCom.EndConnection();
            return 0;
        }

    }
}

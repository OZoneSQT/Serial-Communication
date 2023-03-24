using System.IO.Ports;
using System.Threading.Tasks;

namespace Host.Communication
{
    internal class RS232
    {
        SerialCom serialCom = new SerialCom();

        /**
         * Creat Serialport
         */
        public RS232(int baud, Parity parity, int packetSize, StopBits stopBits, bool dtr, bool rts, ref Com com)
        {
            serialCom = new SerialCom();
            serialCom.SetSerialPort(baud, parity, packetSize, stopBits, dtr, rts, ref com);
        }

        /**
         * Creat Serialport and encryption
         */
        public RS232(int baud, Parity parity, int packetSize, StopBits stopBits, bool dtr, bool rts, int puKey, int prKey, ref Com com)
        {
            serialCom = new SerialCom();
            serialCom.SetSerialPort(baud, parity, packetSize, stopBits, dtr, rts, ref com);
        }

        public void EndConnection()
        {
            serialCom.EndConnection();
        }


        /**
         * OBS on address for RS485
         */
        public void WriteToPort(Com com)
        {
            serialCom.WriteToPort(com);
        }

    }
}
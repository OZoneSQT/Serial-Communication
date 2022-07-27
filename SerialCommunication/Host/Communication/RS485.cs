using System.IO.Ports;
using System.Threading.Tasks;

namespace Host.Communication
{
    internal class RS485
    {
        SerialCom serialCom = new SerialCom();

        /**
         * Creat Serialport with address function
         * Creat function for handeling address
         */
        public RS485(int baud, Parity parity, int packetSize, StopBits stopBits, uint address, bool dtr, bool rts, ref Com com)
        {
            serialCom = new SerialCom();
            serialCom.SetSerialPort(baud, parity, packetSize, stopBits, dtr, rts, ref com);
        }

        /**
         * Creat Serialport with address function and encryption
         * Creat function for handeling address
         */
        public RS485(int baud, Parity parity, int packetSize, StopBits stopBits, uint address, bool dtr, bool rts, int puKey, int prKey, ref Com com)
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
using System;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace Host.Communication
{
    internal class SerialCom
    {
        private String portId = "";
        private int portNumber = 1;
        private SerialPort serialPort = null;
        private bool dtr = false;
        private bool rts = false;

        private bool debug = false;
        private bool init = false;

        private Com com;


        public void SetSerialPort(int baud, Parity parity, int packetSize, StopBits stopBits, bool dsr, bool rts, ref Com com)
        {
            this.com = com;

            if (!init) Console.WriteLine("> Init of Serial communication ...");

            init = true;
            portNumber++;

            if (portNumber > 99) InitErrorHandler(baud, parity, packetSize, stopBits);

            if (debug) Console.WriteLine($"testing port: {portNumber}");
            portId = "COM" + Convert.ToString(portNumber);

            GenerateSerialPort(portId, baud, parity, packetSize, stopBits);
        }

        private void GenerateSerialPort(String portId, int baud, Parity parity, int packetSize, StopBits stopBits)
        {
            try
            {
                serialPort = new SerialPort(portId, baud, parity, packetSize, stopBits);
                serialPort.RtsEnable = rts;
                serialPort.DtrEnable = dtr;
                serialPort.NewLine = "\r";
                serialPort.Open();
                Console.WriteLine($"> Serial communication via {portId} started");
            }
            catch (IOException ioe) // Throws System.IO.Exception (port does not exist) if i = 3 the first port is hit/set/started
            {
                SetSerialPort(baud, parity, packetSize, stopBits, dtr, rts, ref com);
            }
            catch (UnauthorizedAccessException uae)  // Throws System.UnauthorizedAccessException if port is taken by other process
            {
                SetSerialPort(baud, parity, packetSize, stopBits, dtr, rts, ref com);
            }
            catch (Exception e)
            {
                Console.WriteLine($"> Unexpected Exeption thrown:\n{e.StackTrace}");
            }
        }

        public void EndConnection()
        {
            serialPort.Close();
            Console.WriteLine($"> Serial communication via {portId} stopped");
        }

        private void InitErrorHandler(int baud, Parity parity, int packetSize, StopBits stopBits)
        {
            Console.WriteLine("> Troubleshooting:\nRightclick on [Windows start menu] and select [Device manager]");
            Console.WriteLine("  Check for connected serialports under [Ports (COM & LPT)], and enter portnumber in console, and press [enter]:");
            Console.WriteLine("  NOTE: If there not is any serial ports type in \"n\" in the console, and press [enter]:");

            String result = Console.ReadLine();

            if (result == "n") MissingPortGuide();
            if (result == null) InitErrorHandler(baud, parity, packetSize, stopBits);

            String portId = "COM" + result;
            GenerateSerialPort(portId, baud, parity, packetSize, stopBits);
        }

        private void MissingPortGuide()
        {
            Console.WriteLine("> Solution to the issue with missing serialports.");
            Console.WriteLine("  Use 2 pcs. USB to Serial adapters and connect the serialports with a NULL-modem (cross-cabel).");
            Console.WriteLine("  Then connect both USB ports to your computer.");
        }



        // Parse: https://www.youtube.com/watch?v=X5u2qCzcPn8
        // Crypto: https://se.mathworks.com/matlabcentral/answers/217702-need-help-to-encrypt-and-decrypt-the-rs232-serial-port-data
        // Serial: https://www.google.com/search?client=firefox-b-d&q=c%23+write+data+to+serial+port

        // TX
        // DEMO, to be updated, impliment parsing and crypto
        // https://docs.microsoft.com/en-us/dotnet/api/system.io.ports.serialport.write?view=netframework-4.8
        // eks: public void Write(string text);
        public void WriteToPort(Com com)
        {
            serialPort.Write(com.buffer);
        }


        // RX
        // DEMO, to be updated, impliment parsing and crypto
        // https://docs.microsoft.com/en-us/dotnet/api/system.io.ports.serialport.datareceived?view=netframework-4.8
        public void ReadFromPort()
        {
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // update Com (or add interface) to handle data
        }

    }
}
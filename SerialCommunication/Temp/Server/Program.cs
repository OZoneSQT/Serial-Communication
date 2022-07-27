using System;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace SerialCommunicationTestClient
{
    class Program
    {
        /*
         * RS485: 38400 baud, 2 stopbit and no paritet. 
         */
        private static int baud = 38400;
        private static Parity parity = Parity.None;
        private static int packetSize = 8;  // number of bits in a data packet
        private static StopBits stopBits = StopBits.Two;

        private static String portId = "";
        private static int portNumber = 1;
        private static SerialPort serialPort = null;


        public static int Main(string[] args)
        {
            SetSerialPort(baud, parity, packetSize, stopBits);
            int i = MainAsync(args).GetAwaiter().GetResult();
            EndConnection();
            return i;
        }

        private static void SetSerialPort(int baud, Parity parity, int packetSize, StopBits stopBits)
        {
            Console.WriteLine("> Init of Serial communication ...");

            if (portNumber > 99) InitErrorHandler(baud, parity, packetSize, stopBits);

            Console.WriteLine("testing port: " + portNumber);
            portId = "COM" + Convert.ToString(portNumber);

            GenerateSerialPort(portId, baud, parity, packetSize, stopBits);
        }

        private static void GenerateSerialPort(String portId, int baud, Parity parity, int packetSize, StopBits stopBits)
        {
            try
            {
                serialPort = new SerialPort(portId, baud, parity, packetSize, stopBits);
                serialPort.NewLine = "\r";
                serialPort.Open();
                Console.WriteLine("> Serial communication via " + portId + " started");
            }
            catch (IOException e) // Throws System.IO.Exception (port does not exist) if i = 3 the first port is hit/set/started
            {
                portNumber++;
                SetSerialPort(baud, parity, packetSize, stopBits);
            }
            catch (UnauthorizedAccessException e) // Throws System.UnauthorizedAccessException if port is taken by other process
            {
                portNumber++;
                SetSerialPort(baud, parity, packetSize, stopBits);
            }
        }

        private static void EndConnection()
        {
            serialPort.Close();
            Console.WriteLine("> Serial communication via " + portId + " stopped");
        }

        private static void InitErrorHandler(int baud, Parity parity, int packetSize, StopBits stopBits)
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

        private static void MissingPortGuide()
        {
            Console.WriteLine("> Solution to the issue with missing serialports.");
            Console.WriteLine("  Use 2 pcs. USB to Serial adapters and connect the serialports with a NULL-modem (cross-cabel).");
            Console.WriteLine("  Then connect both USB ports to your computer.");
        }


        // TX

        private static async Task<int> MainAsync(string[] args)
        {
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();

            Console.WriteLine("> Connected");

            string[] answer = default(string[]);
            serialPort.WriteLine("CON");
            answer = await ReadDataAsync();
            HandleData(answer);
            serialPort.WriteLine("AUX");
            answer = await ReadDataAsync();
            HandleData(answer);

            bool _continue = true;
            do
            {
                //String input = Console.ReadLine();
                //serialPort.WriteLine(input);
                //answer = await ReadDataAsync(serialPort);
                //HandleData(answer);

                serialPort.WriteLine("NUL");
                answer = await ReadDataAsync();
                HandleData(answer);

                answer = await ReadDataAsync();
                if (answer[0] == "DEV")
                {
                    HandleData(answer);

                    answer = await ReadDataAsync();
                    HandleData(answer);
                }

                System.Threading.Thread.Sleep(1000);

            } while (_continue);
            Console.Write("> Disconnected");
            return 0;
        }

        private static void HandleData(string[] data)
        {
            for (int idx = 0, lgt = data.Length; idx < lgt; idx++)
            {
                if (data[idx] == string.Empty) continue;

                ConsoleColor bgOld = Console.BackgroundColor
                           , fgOld = Console.ForegroundColor;

                Console.BackgroundColor = fgOld;
                Console.ForegroundColor = bgOld;
                Console.WriteLine($"<< {data[idx]}");

                Console.BackgroundColor = bgOld;
                Console.ForegroundColor = fgOld;
            }
        }

        private static async Task<string[]> ReadDataAsync()
        {
            byte[] buffer = new byte[serialPort.ReadBufferSize];

            int bytesRead = await serialPort.BaseStream.ReadAsync(buffer, 0, buffer.Length);
            serialPort.DiscardInBuffer();
            return Encoding.ASCII.GetString(buffer).Substring(0, bytesRead).Split(serialPort.NewLine.ToCharArray());
        }

    }
}

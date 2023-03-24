using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommunication.Client.Util
{
    internal class Parser
	{
		public Parser() { }

		public string PayloadParser(ref byte[] payload)
		{
			return "";
		}

		private string ReadPayload(byte[] payload)
		{
			return "";
		}

		private string EncryptPayload(byte[] payload)
		{
			return null;
		}

		private string DecryptPayload(byte[] payload)
		{
			return null;
		}

		private string GetSubject(byte[] payload, int fromByteNumber, int toByteNumber, int fromNoOfBytes, int toNoOfBytes)
		{
			int startSelectByte = 8 * fromByteNumber;
			int stopSelectByte = 8 * toByteNumber;
			return DataConverter.ConvertStringArrayToChar(payload).Substring(startSelectByte * fromNoOfBytes, stopSelectByte * toNoOfBytes);
		}

		public string ExecuteCommand(byte[] payload, Commands com)
		{
			string command = GetSubject(payload, 0, 0, 0, 1);

			// Description of application commands (hex numbers)
			if (command == "01") return com.TestCommandA(payload);                    // 01h A
			if (command == "02") return com.TestCommandB(payload);                    // 02h B
			if (command == "03") return com.TestCommandC(payload);                    // 03h C
			
			return null;
		}

	}
}

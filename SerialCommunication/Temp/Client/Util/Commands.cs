using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommunication.Client.Util
{
	public class Commands
	{

		// Description of application commands

		// 01h Test Command A
		public string TestCommandA(byte[] payload) { return null; }

		// 02h Test Command B
		public string TestCommandB(byte[] payload) { return null; }

		// 03h Test Command C
		public string TestCommandC(byte[] payload) { return null; }

	}
}

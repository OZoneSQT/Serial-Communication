using System;
using System.Text;

/*
 * Alias:   Type:               Bytes:
 * bool 	System.Boolean      1
 * byte 	System.Byte         1
 * sbyte 	System.SByte        1
 * char 	System.Char         2
 * decimal 	System.Decimal      24
 * double 	System.Double       8
 * float 	System.Single       4
 * int  	System.Int32        4
 * uint 	System.UInt32       4
 * long 	System.Int64        8
 * ulong 	System.UInt64       8
 * short 	System.Int16        2
 * ushort 	System.UInt16       2
 */

namespace SerialCommunication.Client.Util
{
    internal static class DataConverter
    {

        public static byte[] ConvertUIntToBooleanArray(bool value)
        {
            return BitConverter.GetBytes(value);
        }
        public static bool ConvertByteArrayToBoolean(byte[] payload)
        {
            return BitConverter.ToBoolean(payload, 0);
        }


        public static byte[] ConvertDoubleToByteArray(double value)
        {
            return BitConverter.GetBytes(value);
        }

        public static double ConvertByteArrayToDouble(byte[] payload)
        {
            return BitConverter.ToDouble(payload, 0);
        }


        public static byte[] ConvertIntToByteArray(int value)
        {
            return BitConverter.GetBytes(value);
        }

        public static int ConvertByteArrayToInt16(byte[] payload)
        {
            return BitConverter.ToInt16(payload, 0);
        }

        public static int ConvertByteArrayToInt32(byte[] payload)
        {
            return BitConverter.ToInt32(payload, 0);
        }


        public static byte[] ConvertUIntToByteArray(uint value)
        {
            return BitConverter.GetBytes(value);
        }

        public static uint ConvertByteArrayToUint16(byte[] payload)
        {
            return BitConverter.ToUInt16(payload, 0);
        }

        public static uint ConvertByteArrayToUint32(byte[] payload)
        {
            return BitConverter.ToUInt32(payload, 0);
        }


        public static byte[] ConvertCharToByteArray(char value)
        {
            return BitConverter.GetBytes(value);
        }

        public static char ConvertByteArrayToChar(byte[] payload)
        {
            return BitConverter.ToChar(payload, 0);
        }


        public static byte[] ConvertStringToByteArray(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        public static string ConvertStringArrayToChar(byte[] payload)
        {
            return Encoding.ASCII.GetString(payload);
        }

    }
}

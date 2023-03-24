using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommunication.Client.Util
{
    internal static class DataBitwise
    {

        public static byte[] ShiftBitwiseLeft(byte[] payload, int positions)
        {
            return DataConverter.ConvertUIntToByteArray(DataConverter.ConvertByteArrayToUint32(payload) >> positions);
        }

        public static byte[] ShiftBitwiseRight(byte[] payload, int positions)
        {
            return DataConverter.ConvertUIntToByteArray(DataConverter.ConvertByteArrayToUint32(payload) << positions);
        }


        // Set bit at position to 1 (OR)
        public static byte[] SetBitAtPosition(this byte[] payload, int position)
        {
            int byteIndex = position / 8;
            int bitIndex = position % 8;
            byte mask = (byte)(1 << bitIndex);

            payload[byteIndex] = (byte)(true ? (payload[byteIndex] | mask) : (payload[byteIndex] & ~mask));
            return payload;
        }

        // Clear bit / Set bit at position to 0 (NOT)
        public static byte[] ClearBitAtPositiont(this byte[] payload, int position)
        {
            int byteIndex = position / 8;
            int bitIndex = position % 8;
            byte mask = (byte)(1 << bitIndex);

            payload[byteIndex] = (byte)(false ? (payload[byteIndex] | mask) : (payload[byteIndex] & ~mask));
            return payload;
        }

        // Flipping bit at position (XOR)
        public static byte[] FlippingBitAtPositiont(this byte[] payload, int position)
        {
            int byteIndex = position / 8;
            int bitIndex = position % 8;
            byte mask = (byte)(1 << bitIndex);

            payload[byteIndex] ^= mask;
            return payload;
        }

        // Checking bit at position (AND)
        public static bool CheckingBitAtPositiont(this byte[] payload, int position)
        {
            int byteIndex = position / 8;
            int bitIndex = position % 8;
            byte mask = (byte)(1 << bitIndex);

            return (payload[byteIndex] & mask) != 0;
        }

    }
}

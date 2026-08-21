using System;

namespace Encoder.Core.Protocol
{
    public static class ModbusCRC
    {
        public static ushort Calculate(byte[] data)
        {
            ushort crc = 0xFFFF;

            foreach (byte b in data)
            {
                crc ^= b;
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            return crc;
        }
        public static byte[] AppendCRC(byte[] frame)
        {
            ushort crc = Calculate(frame);

            byte[] result = new byte[frame.Length + 2];

            Array.Copy(
                frame,
                result,
                frame.Length);

            // CRC低位在前，高位在後
            result[result.Length - 2] =
                (byte)(crc & 0xFF);
            result[result.Length - 1] =
                (byte)(crc >> 8);

            return result;
        }
    }
}
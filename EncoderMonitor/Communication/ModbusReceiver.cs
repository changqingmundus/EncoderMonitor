using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EncoderMonitor
{
    public static class ModbusReceiver
    {
        public static byte[] ReadResponse()
        {
            List<byte> buffer = new List<byte>();

            // 先收前3 byte
            while (buffer.Count < 3)
            {
                if (SerialPortManager.sp.BytesToRead > 0)
                {
                    buffer.Add((byte)SerialPortManager.sp.ReadByte());
                }
            }
            int length;
            // Modbus讀取
            if (buffer[1] == 0x03)
            {
                length = 3 + buffer[2] + 2;
            }
            // Factory
            else if (buffer[1] == 0x66)
            {
                length = 5;
            }
            // 異常
            else if ((buffer[1] & 0x80) != 0)
            {
                length = 5;
            }
            else
            {
                length = 5;
            }
            while (buffer.Count < length)
            {
                if (SerialPortManager.sp.BytesToRead > 0)
                {
                    buffer.Add((byte)SerialPortManager.sp.ReadByte());
                }
            }
            return buffer.ToArray();
        }
    }
}
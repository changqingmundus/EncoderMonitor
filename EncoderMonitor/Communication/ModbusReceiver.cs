using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace EncoderMonitor
{
    public static class ModbusReceiver
    {
        public static byte[] ReadResponse(int timeout = 500)
        {
            List<byte> buffer = new List<byte>();
            Stopwatch sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeout)
            {
                if (SerialPortManager.sp != null &&
                   SerialPortManager.sp.IsOpen)
                {
                    while (SerialPortManager.sp.BytesToRead > 0)
                    {
                        buffer.Add((byte)SerialPortManager.sp.ReadByte());
                    }

                    // Factory成功
                    if (buffer.Count >= 5)
                    {
                        break;
                    }

                    // Modbus異常
                    if (buffer.Count >= 5 &&
                       (buffer[1] & 0x80) != 0)
                    {
                        break;
                    }
                }
                Thread.Sleep(1);
            }
            if (buffer.Count == 0)
                return null;
            return buffer.ToArray();
        }
    }
}
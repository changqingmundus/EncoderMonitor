using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace EncoderMonitor
{
    public static class SerialPortManager
    {
        public static SerialPort sp;
        public static bool OpenPort(
            string comPort,
            int baudRate,
            Parity parity)
        {
            try
            {
                if (sp != null && sp.IsOpen)
                    sp.Close();
                sp = new SerialPort(comPort, baudRate, parity, 8, StopBits.One);
                sp.Handshake = Handshake.None;   // 统一设置               
                sp.ReadTimeout = 200;  // Modbus RTU超時
                sp.WriteTimeout = 200;
                sp.Open();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("打开串口失败: " + ex.Message);
                return false;
            }
        }
        public static void ClosePort()
        {
            if (sp != null && sp.IsOpen)
            {
                sp.Close();
                sp.Dispose(); // 可选，释放资源
                sp = null;
            }
        }
        public static byte[] ReadData()
        {
            if (sp == null || !sp.IsOpen)
                return null;
            List<byte> rx = new List<byte>();
            Stopwatch sw = Stopwatch.StartNew();
            // 等待第一個byte
            while (sp.BytesToRead == 0)
            {
                if (sw.ElapsedMilliseconds > 200)
                    return null;
            }

            // 先讀頭3byte
            while (rx.Count < 3)
            {
                if (sp.BytesToRead > 0)
                {
                    rx.Add((byte)sp.ReadByte());
                }
            }
            byte function = rx[1];
            int remain = 0;
            switch (function)
            {
                case 0x03:
                    {
                        int byteCount = rx[2];
                        // Data + CRC
                        remain = byteCount + 2;

                        break;
                    }

                case 0x06:
                    {
                        // 固定返回8byte
                        remain = 5;

                        break;
                    }

                case 0x10:
                    {
                        remain = 5;

                        break;
                    }
            }
            while (remain > 0)
            {
                if (sp.BytesToRead > 0)
                {
                    rx.Add((byte)sp.ReadByte());
                    remain--;
                }
                if (sw.ElapsedMilliseconds > 200)
                    break;
            }
            return rx.ToArray();
        }
        public static bool WriteData(byte[] data)
        {
            if (sp == null || !sp.IsOpen)
                return false;
            try
            {
                sp.Write(
                    data,
                    0,
                    data.Length);
                Debug.WriteLine(
                    "Write OK length="
                    + data.Length);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "Write Error:"
                    + ex.Message);
                return false;
            }
        }
    }
}

using System;
using System.IO;
using System.IO.Ports;

namespace Encoder.Core.Communication
{
    public static class SerialPortManager
    {
        public static SerialPort sp;
        public static bool IsOpen
        {
            get
            {
                return sp != null && sp.IsOpen;
            }
        }
        public static bool OpenPort(string portName, int baudRate, Parity parity)
        {
            try
            {
                sp = new SerialPort();

                sp.PortName = portName;
                sp.BaudRate = baudRate;
                sp.DataBits = 8;
                sp.Parity = parity;
                sp.StopBits = StopBits.One;

                sp.ReadTimeout = 150;
                sp.WriteTimeout = 150;

                sp.Open();

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception(
                    $"串口 {portName} 正在被其他程序使用");
            }
            catch (IOException)
            {
                throw new Exception(
                    $"串口 {portName} 不存在或无法访问");
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"打开串口失败: {ex.Message}");
            }
        }

        public static void ClosePort()
        {
            if (sp != null)
            {
                try
                {
                    if (sp.IsOpen)
                        sp.Close();
                }
                catch
                {
                }

                sp.Dispose();
                sp = null;
            }
        }
        public static bool Send(byte[] data)
        {
            try
            {
                if (!IsOpen)
                    return false;


                sp.Write(
                    data,
                    0,
                    data.Length);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static byte[] Read(int timeout = 500)
        {
            try
            {
                if (!IsOpen)
                    return null;


                sp.ReadTimeout = timeout;

                int len = sp.BytesToRead;

                if (len <= 0)
                    return null;

                byte[] buffer = new byte[len];
                sp.Read( buffer, 0, len);
                return buffer;
            }
            catch (TimeoutException)
            {
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
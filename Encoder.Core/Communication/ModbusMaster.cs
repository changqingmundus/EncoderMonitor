using System;
using System.IO.Ports;
using System.Net;
using System.Text;
using System.Threading;

namespace Encoder.Core.Communication
{
    public enum ModbusError
    {
        Timeout,
        ResponseError,
        InvalidLength,
        InvalidSlaveId,
        InvalidFunctionCode,
        InvalidAddress,
        InvalidData,
        CrcError
    }

    public class ModbusException : Exception
    {
        public ModbusError Error { get; }

        public ModbusException(
            ModbusError error,
            Exception innerException = null)
            : base(innerException?.Message, innerException)
        {
            Error = error;
        }
    }

    public class ModbusMaster
    {
        private SerialPort sp;
        private readonly object modbusLock = new object();
        public event Action<string, byte[]> DataLog;
        public bool EnableDataLog { get; set; } = true;
        public ModbusMaster(SerialPort serialPort)
        {
            sp = serialPort;
        }
        public bool IsOpen
        {
            get
            {
                return sp != null && sp.IsOpen;
            }
        }
        public ushort[] ReadHoldingRegisters(byte slaveId, ushort address, ushort count)
        {
            lock (modbusLock)
            {
                byte[] frame =
                    CreateReadCommand(
                        slaveId,
                        address,
                        count);

                ushort crc = ModbusCRC(frame, 6);

                frame[6] = (byte)(crc & 0xff);
                frame[7] = (byte)(crc >> 8);

                sp.DiscardInBuffer();

                if (EnableDataLog)
                {
                    DataLog?.Invoke("TX", frame);
                }

                sp.Write(
                    frame,
                    0,
                    frame.Length);

                byte[] recv = ReceiveFrame();

                if (EnableDataLog)
                {
                    DataLog?.Invoke("RX", recv);
                }

                return ParseResponse(recv, recv.Length, slaveId);
            }
        }
        public byte[] WriteSingleRegister(byte slaveId, ushort address, ushort value)
        {
            byte[] frame = CreateWriteCommand(slaveId, address, value);

            sp.DiscardInBuffer();

            if (EnableDataLog)
            {
                DataLog?.Invoke("TX", frame);
            }

            sp.Write(frame, 0, frame.Length);

            byte[] rx = ReceiveFrame();

            if (EnableDataLog)
            {
                DataLog?.Invoke("RX", rx);
            }

            if (rx.Length != 8)
            {
                throw new ModbusException(
                    ModbusError.InvalidLength);
            }

            if (rx[0] != slaveId)
            {
                throw new ModbusException(
                    ModbusError.InvalidSlaveId);
            }

            if (rx[1] != 0x06)
            {
                throw new ModbusException(
                    ModbusError.InvalidFunctionCode);
            }

            if (rx[2] != (byte)(address >> 8) ||
                rx[3] != (byte)(address & 0xff))
            {
                throw new ModbusException(
                    ModbusError.InvalidAddress);
            }

            if (rx[4] != (byte)(value >> 8) ||
                rx[5] != (byte)(value & 0xff))
            {
                throw new ModbusException(
                    ModbusError.InvalidData);
            }

            ushort crc =
                (ushort)(
                    rx[6] |
                    (rx[7] << 8));

            ushort calc =
                ModbusCRC(rx, 6);

            if (crc != calc)
            {
                throw new ModbusException(
                    ModbusError.CrcError);
            }

            return rx;
        }

        private byte[] ReceiveFrame()
        {
            byte[] rx = new byte[256];
            int len = 0;

            DateTime start = DateTime.Now;
            DateTime lastByteTime = DateTime.Now;

            while (true)
            {if (sp.BytesToRead > 0)
                {
                    int cnt = sp.Read(rx, len, rx.Length - len);
                    len += cnt;
                    lastByteTime = DateTime.Now;
                }
                // 已收到数据，等待T3.5结束
                if (len > 0)
                {
                    double idle = (DateTime.Now - lastByteTime).TotalMilliseconds;
                    if (idle >= CalculateT35())
                    {
                        break;
                    }
                }

                if ((DateTime.Now - start).TotalMilliseconds > 300)
                {
                    throw new ModbusException(ModbusError.Timeout);
                }
                Thread.Sleep(1);
            }

            byte[] recv = new byte[len];
            Array.Copy(rx, recv, len);

            return recv;
        }
        private ushort[] ParseResponse(byte[] data, int len, byte expectedId)
        {
            if (len < 5)
            {
                throw new ModbusException(
                    ModbusError.InvalidLength);
            }

            byte slaveId = data[0];

            if (slaveId != expectedId)
            {
                throw new ModbusException(
                    ModbusError.InvalidSlaveId);
            }

            if (data[1] != 0x03)
            {
                throw new ModbusException(
                    ModbusError.InvalidFunctionCode);
            }

            byte byteCount = data[2];

            if (len != byteCount + 5)
            {
                throw new ModbusException(
                    ModbusError.InvalidLength);
            }

            ushort crc =
                (ushort)(
                    data[len - 2] |
                    (data[len - 1] << 8));

            ushort calc =
                ModbusCRC(
                    data,
                    len - 2);

            if (crc != calc)
            {
                throw new ModbusException(
                    ModbusError.CrcError);
            }

            int regCount = byteCount / 2;

            ushort[] values =
                new ushort[regCount];

            for (int i = 0; i < regCount; i++)
            {
                values[i] =
                    (ushort)(
                        (data[3 + i * 2] << 8) |
                        data[4 + i * 2]);
            }

            return values;
        }

        private byte[] CreateReadCommand(byte slaveId, ushort address, ushort count)
        {
            byte[] frame =
            {
                slaveId,
                0x03,
                // 起始地址
               (byte)(address >> 8),
               (byte)(address & 0xff),

                // 寄存器数量
               (byte)(count >> 8),
               (byte)(count & 0xff),
                0,
                0
            };
            ushort crc = ModbusCRC(frame, 6);
            frame[6] = (byte)(crc & 0xff);
            frame[7] = (byte)(crc >> 8);
            return frame;
        }
        private byte[] CreateWriteCommand(byte slaveId, ushort address, ushort value)
        {
            byte[] frame =
            {
               slaveId,
               0x06,                         // 写单个寄存器
              (byte)(address >> 8),
              (byte)(address & 0xff),
              (byte)(value >> 8),
              (byte)(value & 0xff),
               0,
               0
            };

            ushort crc = ModbusCRC(frame, 6);
            frame[6] = (byte)(crc & 0xff);
            frame[7] = (byte)(crc >> 8);
            return frame;
        }
        private double CalculateT35()
        {
            int baud = sp.BaudRate;

            // baud > 19200，固定1.75ms
            if (baud > 19200)
            {
                return 1.75;
            }
            int bitsPerChar = sp.Parity == Parity.None ? 10 : 11;
            double charTime = (double)bitsPerChar / baud * 1000;
            return charTime * 3.5;
        }

        private ushort ModbusCRC(byte[] data, int length)
        {
            ushort crc = 0xffff;
            for (int i = 0; i < length; i++)
            {
                crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) != 0)
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
    }
}
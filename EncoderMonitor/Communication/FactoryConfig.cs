using System;
using System.Linq;

namespace EncoderMonitor.Communication
{
    public static class FactoryConfig
    {
        public static void WriteEncoder(
              byte slaveID,
              byte singleBits,
              byte multiBits,
              byte crcBits)
        {
            byte[] frame =
            {
                slaveID,0x66,0x50,0x0A, 0x00,0x01,0x00,0x04,0x08,
                0x00,singleBits,
                0x00,multiBits,
                0x00,crcBits,
                0x50,
                0x5A
            };
            Send(frame);
        }
        public static void WriteAllFactoryConfig(
            byte slaveID,
            byte singleBits,
            byte multiBits,
            byte crcBits,
            uint baudRate,
            byte parity)
        {
            WriteEncoderConfig(
                slaveID,
                singleBits,
                multiBits,
                crcBits);
            WriteCommunicationConfig(
                slaveID,
                baudRate,
                parity);
        }
        private static void WriteEncoderConfig(
              byte slaveID,
              byte singleBits,
              byte multiBits,
              byte crcBits)
        {
            byte[] frame =
            {
                slaveID,
                0x66,
                0x50,
                0x0A,
                0x00,
                0x01,
                0x00,
                0x04,
                0x08,
                0x00,
                singleBits,
                0x00,
                multiBits,
                0x00,
                crcBits,
                0x50,
                0x5A
            };
            Send(frame);
        }
        private static void WriteCommunicationConfig(
              byte slaveID,
              uint baudRate,
              byte parity)
        {
            byte[] frame =   //waiting for config
            {
                slaveID,
                0x66,
                0x50,
                0x11,
                0x00,
                0x01,
                0x00,
                0x04,
                0x08,
                0x00,
                (byte)baudRate,
                0x00,
                parity,
                0x00,
                0xFF,
                0x50,
                0x5A
            };
            Send(frame);
        }
        private static void Send(byte[] frame)
        {
            if (frame == null || frame.Length == 0)
            {
                throw new ArgumentException("Modbus frame is empty");
            }


            ushort crc = ModbusCRC.Calculate(frame);


            byte[] crcBytes =
            {
               (byte)(crc & 0xFF),   // CRC Low
               (byte)(crc >> 8)      // CRC High
             };


            byte[] tx = frame
                .Concat(crcBytes)
                .ToArray();

            if (SerialPortManager.sp == null)
            {
                throw new InvalidOperationException(
                    "Serial port is not initialized");
            }
            if (!SerialPortManager.sp.IsOpen)
            {
                throw new InvalidOperationException(
                    "Serial port is not open");
            }
            SerialPortManager.sp.Write(
                tx,
                0,
                tx.Length);
        }
    }
}
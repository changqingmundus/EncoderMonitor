using Encoder.Core.Communication;
using Encoder.Core.Protocol;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EncoderMonitor.Communication
{
    public static class FactoryConfig
    {
        public static ushort FactoryKey = 0x500A;
        public static ushort FactorySaveKey = 0x505A;
        public static void WriteEncoder(
              byte slaveID,
              ushort FactoryKey,
              byte Mode,
              byte STChip,
              byte MTChip,
              byte singleBits,
              byte multiBits,
              byte crcBits,
              byte regmap,
              ushort FactorySaveKey)
        {
            ushort sensorConfig = (ushort)(
                                 (Mode & 0x0F) |
                                 ((STChip & 0x0F) << 4) |
                                 ((MTChip & 0x0F) << 8));

            ushort outputConfig = (ushort)(
                                  (regmap & 0x03) |
                                  ((crcBits & 0x03) << 2) |
                                  ((singleBits & 0x3F) << 4) |
                                  ((multiBits & 0x3F) << 10));
            byte[] frame =
            {slaveID,
             0x66,
             (byte)(FactoryConfig.FactoryKey >> 8),
             (byte)(FactoryConfig.FactoryKey & 0xFF),
             0x00, 0x00,
             0x00, 0x03,
             0x06,
             (byte)(sensorConfig >> 8),
             (byte)(sensorConfig & 0xFF),

             (byte)(outputConfig >> 8),
             (byte)(outputConfig & 0xFF),

            (byte)(FactoryConfig.FactorySaveKey >> 8),
            (byte)(FactoryConfig.FactorySaveKey & 0xFF) };

            ushort crc = ModbusCRC.Calculate(frame);
            frame = frame.Concat(new byte[]
            {(byte)(crc & 0xFF),  // CRC Low
             (byte)(crc >> 8)     // CRC High
            }).ToArray();

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
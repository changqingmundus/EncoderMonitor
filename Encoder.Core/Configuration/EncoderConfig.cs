namespace Encoder.Core.Configuration
{
    public static class EncoderConfig
    {
        public static ModbusConfig Modbus = new ModbusConfig();

        // 單圈位數
        public static int SingleTurnBits = 16;

        // 多圈位數
        public static int MultiTurnBits = 12;
        // 單圈最大值
        public static uint SingleTurnMax
        {
            get
            {
                return (uint)((1UL << SingleTurnBits) - 1);
            }
        }
        // 多圈最大值
        public static uint MultiTurnMax
        {
            get
            {
                return (uint)((1UL << MultiTurnBits) - 1);
            }
        }
    }
    public class ModbusConfig
    {
        public byte SlaveID { get; set; } = 1;

        public byte FunctionCode { get; set; } = 0x03;

        public ushort SingleTurnAddress { get; set; } = 0x0000;
        public ushort SingleTurnCount { get; set; } = 1;

        public ushort MultiTurnAddress { get; set; } = 0x0001;
        public ushort MultiTurnCount { get; set; } = 1;

        public ushort AllAddress { get; set; } = 0x0000;
        public ushort AllCount { get; set; } = 2;

        public byte FreeData1 { get; set; } = 0xAB;
        public byte FreeData2 { get; set; } = 0xCD;
        public byte FreeData3 { get; set; } = 0x3D;
    }
}

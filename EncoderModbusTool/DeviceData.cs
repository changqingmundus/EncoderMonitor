namespace EncoderModbusTool
{
    internal class DeviceData
    {
        // 编码器总值
        public ulong EncoderValue { get; set; }

        // 多圈值
        public ulong MultiTurn { get; set; }

        // 单圈值
        public ulong SingleTurn { get; set; }

        // 旋转方向
        public byte Direction { get; set; }

        // 转速
        public ushort Speed { get; set; }
    }
}
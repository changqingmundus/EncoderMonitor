namespace Encoder.Core.Data
{
    public class EncoderData
    {
        public ulong EncoderValue { get; set; }

        public uint SingleTurn { get; set; }

        public uint MultiTurn { get; set; }

        public byte EnID { get; set; }

        public ushort Speed { get; set; }

        public byte Direction { get; set; }

        public double Angle { get; set; }
    }
}

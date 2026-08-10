namespace EncoderMonitor
{
    public class EncoderData
    {
        public uint SingleTurn { get; set; }

        public uint MultiTurn { get; set; }

        public byte EnID { get; set; }

        public ushort Speed { get; set; }

        public byte Direction { get; set; }

        public bool CRC_OK { get; set; }

        public double Angle { get; set; }
    }
}

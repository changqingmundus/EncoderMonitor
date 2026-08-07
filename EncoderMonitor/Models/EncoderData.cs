namespace EncoderMonitor
{
    public class EncoderData
    {
        public uint SingleTurn { get; set; }

        public uint MultiTurn { get; set; }

        public byte EnID { get; set; }

        public byte Status { get; set; }

        public bool CRC_OK { get; set; }

        public double Angle { get; set; }
    }
}

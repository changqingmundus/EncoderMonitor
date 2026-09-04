namespace Encoder.Core.Configuration
{
    public static class ModbusRegisterMap
    {
        // =========================================================
        // 当前寄存器布局
        // =========================================================
        // Register(1):
        //   SingleTurn / MultiTurn 各占 1 个 16-bit Register
        //
        // Register(2):
        //   SingleTurn / MultiTurn 各占 2 个 16-bit Register
        //
        // 只要单圈或多圈超过 16 bit，就使用 Register(2)
        // =========================================================

        private static bool IsExtended =>
            EncoderConfig.Is32BitMode;


        // =========================================================
        // Encoder Value
        // =========================================================

        // ---------------------------------------------------------
        // Single Turn
        // ---------------------------------------------------------
        //
        // Register(1)
        // 0x0000 = SingleTurn Value
        //
        // Register(2)
        // 0x0000 = SingleTurn Value Low
        // 0x0001 = SingleTurn Value High
        //
        public static ushort SingleTurnStart =>
            (ushort)0x0000;

        public static int SingleTurnRegisterCount =>
            IsExtended ? 2 : 1;


        // ---------------------------------------------------------
        // Multi Turn
        // ---------------------------------------------------------
        //
        // Register(1)
        // 0x0001 = MultiTurn Value
        //
        // Register(2)
        // 0x0002 = MultiTurn Value Low
        // 0x0003 = MultiTurn Value High
        //
        public static ushort MultiTurnStart =>
            IsExtended ? (ushort)0x0002 : (ushort)0x0001;

        public static int MultiTurnRegisterCount =>
            IsExtended ? 2 : 1;


        // =========================================================
        // 基础配置寄存器
        // =========================================================

        // ---------------------------------------------------------
        // Slave ID
        // ---------------------------------------------------------
        // Register(1): 0x0002
        // Register(2): 0x0004
        //
        public static ushort SlaveId =>
            IsExtended ? (ushort)0x0004 : (ushort)0x0002;


        // ---------------------------------------------------------
        // Baud Rate Index
        // ---------------------------------------------------------
        // Register(1): 0x0003
        // Register(2): 0x0005
        //
        public static ushort BaudRate =>
            IsExtended ? (ushort)0x0005 : (ushort)0x0003;


        // ---------------------------------------------------------
        // Parity
        // ---------------------------------------------------------
        // Register(1): 0x0004
        // Register(2): 0x0006
        //
        public static ushort Parity =>
            IsExtended ? (ushort)0x0006 : (ushort)0x0004;


        // ---------------------------------------------------------
        // Encoder Zero
        // ---------------------------------------------------------
        // Register(1): 0x0005
        // Register(2): 0x0007
        //
        public static ushort EncoderZero =>
            IsExtended ? (ushort)0x0007 : (ushort)0x0005;


        // ---------------------------------------------------------
        // Count Direction
        // ---------------------------------------------------------
        // Register(1): 0x0006
        // Register(2): 0x0008
        //
        public static ushort CountDirection =>
            IsExtended ? (ushort)0x0008 : (ushort)0x0006;


        // ---------------------------------------------------------
        // Protocol
        // ---------------------------------------------------------
        // Register(1): 0x0007
        // Register(2): 0x0009
        //
        public static ushort Protocol =>
            IsExtended ? (ushort)0x0009 : (ushort)0x0007;


        // ---------------------------------------------------------
        // Report Interval
        // ---------------------------------------------------------
        // Register(1): 0x0008
        // Register(2): 0x000A
        //
        public static ushort ReportInterval =>
            IsExtended ? (ushort)0x000A : (ushort)0x0008;


        // =========================================================
        // Encoder Value
        // =========================================================

        // ---------------------------------------------------------
        // Register(1)
        //
        // 0x0009 = Encoder Value High
        // 0x000A = Encoder Value Low
        //
        // Register(2)
        //
        // 0x000B = Encoder Value Byte[6~7]
        // 0x000C = Encoder Value Byte[4~5]
        // 0x000D = Encoder Value Byte[2~3]
        // 0x000E = Encoder Value Byte[0~1]
        //
        // ---------------------------------------------------------

        public static ushort EncoderValueStart =>
            IsExtended ? (ushort)0x000B : (ushort)0x0009;

        public static int EncoderValueRegisterCount =>
            IsExtended ? 4 : 2;


        // =========================================================
        // 状态
        // =========================================================

        // ---------------------------------------------------------
        // Rotation Direction
        // ---------------------------------------------------------
        // Register(1): 0x000B
        // Register(2): 0x000F
        //
        public static ushort RotationDirection =>
            IsExtended ? (ushort)0x000F : (ushort)0x000B;


        // ---------------------------------------------------------
        // Speed
        // ---------------------------------------------------------
        // Register(1): 0x000C
        // Register(2): 0x0010
        //
        public static ushort Speed =>
            IsExtended ? (ushort)0x0010 : (ushort)0x000C;


        // =========================================================
        // Zero Position
        // =========================================================

        // Register(1): 0x0023
        // Register(2): 0x0024
        //
        public static ushort ZeroPositionReference =>
            IsExtended ? (ushort)0x0023 : (ushort)0x0023;


        // =========================================================
        // Speed Update Period
        // =========================================================

        // Register(1): 0x0024
        // Register(2): 0x0025
        //
        public static ushort SpeedUpdatePeriod =>
            IsExtended ? (ushort)0x0024 : (ushort)0x0024;


        // =========================================================
        // Write Position
        // =========================================================

        // ---------------------------------------------------------
        // Register(1)
        //
        // 0x0032 = Write Position Low
        // 0x0033 = Write Position High
        //
        // Register(2)
        //
        // 0x0032 = Write Position Byte[0~1]
        // 0x0033 = Write Position Byte[2~3]
        // 0x0034 = Write Position Byte[4~5]
        // 0x0035 = Write Position Byte[6~7]
        //
        // ---------------------------------------------------------

        public static ushort WritePositionStart =>
            (ushort)0x0032;

        public static int WritePositionRegisterCount =>
            IsExtended ? 4 : 2;


        // =========================================================
        // Encoder Value 专用区域 0x0400
        // =========================================================

        // ---------------------------------------------------------
        // Register(1)
        //
        // 0x0400 = Encoder Value Low
        // 0x0401 = Encoder Value High
        //
        // Register(2)
        //
        // 0x0400 = Encoder Value Byte[0~1]
        // 0x0401 = Encoder Value Byte[2~3]
        // 0x0402 = Encoder Value Byte[4~5]
        // 0x0403 = Encoder Value Byte[6~7]
        //
        // ---------------------------------------------------------

        public static ushort EncoderValue0400Start =>
            (ushort)0x0400;

        public static int EncoderValue0400RegisterCount =>
            IsExtended ? 4 : 2;
    }
}
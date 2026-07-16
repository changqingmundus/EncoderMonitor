using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoderMonitor
{
    public static class EncoderConfig
    {
        // 單圈位數
        public static int SingleTurnBits = 19;

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
}

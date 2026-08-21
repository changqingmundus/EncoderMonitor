using System;
using System.Threading;
using System.IO.Ports;

namespace Encoder.Core.Communication
{
    public class ModbusScanner
    {
        private ModbusMaster master;
        private CancellationToken token;
        public event Action<int> ScanProgress;
        public ModbusScanner(ModbusMaster modbusMaster, CancellationToken cancellationToken)
        {
            master = modbusMaster;
            token = cancellationToken;
        }
        public int Scan()
        {
            if (master == null || !master.IsOpen)
            {
                return -1;
            }
            for (byte id = 1; id <= 247; id++)
            {
                if (token.IsCancellationRequested)
                {
                    return -1;
                }
                ScanProgress?.Invoke(id);
                try
                {
                    var result = master.ReadHoldingRegisters(id, 0x0002, 1);
                    if (result != null && result.Length == 1)
                    {
                        return id;
                    }
                }
                catch (TimeoutException)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            return -1;
        }
    }
}
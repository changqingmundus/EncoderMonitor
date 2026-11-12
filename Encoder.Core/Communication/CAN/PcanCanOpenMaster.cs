using Encoder.Core.Configuration;
using Encoder.Core.Data;
using Peak.Can.Basic;

using TPCANHandle = System.UInt16;

namespace Encoder.Core.Communication.CAN
{
    public class PcanCanOpenMaster
    {
        private TPCANHandle _channel;
        private byte _nodeId;
        public bool IsConnected { get; private set; }

        // 默认节点1，500k波特率
        public PcanCanOpenMaster(byte nodeId = 1)
        {
            _nodeId = nodeId;
            IsConnected = false;
        }

        /// <summary>
        /// 初始化并连接 PCAN 设备
        /// </summary>
        public bool Connect(TPCANHandle channel = PCANBasic.PCAN_USBBUS1, TPCANBaudrate baudrate = TPCANBaudrate.PCAN_BAUD_500K)
        {
            _channel = channel;
            TPCANStatus status = PCANBasic.Initialize(_channel, baudrate);

            if (status != TPCANStatus.PCAN_ERROR_OK)
            {
                // 如果初始化失败，可以在这里读取错误信息
                // StringBuilder errorText = new StringBuilder(256);
                // PCANBasic.GetErrorText(status, 0, errorText);
                // Console.WriteLine($"PCAN 初始化失败: {errorText}");
                return false;
            }

            IsConnected = true;
            return true;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void Disconnect()
        {
            if (IsConnected)
            {
                PCANBasic.Uninitialize(_channel);
                IsConnected = false;
            }
        }

        /// <summary>
        /// 从 CAN 总线读取一帧数据并解析
        /// </summary>
        public EncoderData ReadData()
        {
            if (!IsConnected) return null;

            EncoderData data = new EncoderData();
            bool positionReceived = false;

            // 循环读取，直到接收队列为空（防止多帧堆积）
            while (true)
            {
                TPCANMsg msg;
                TPCANTimestamp timestamp;
                TPCANStatus status = PCANBasic.Read(_channel, out msg, out timestamp);

                if (status == TPCANStatus.PCAN_ERROR_QRCVEMPTY)
                {
                    break; // 接收队列为空，退出循环
                }
                else if (status != TPCANStatus.PCAN_ERROR_OK)
                {
                    break; // 其他错误，退出
                }

                // 解析 TPDO1 (181h) - 位置数据
                if (msg.ID == (0x180 + _nodeId) && msg.LEN >= 4)
                {
                    // CANopen 默认小端模式 (Little Endian)
                    uint posValue = (uint)(msg.DATA[0] | (msg.DATA[1] << 8) | (msg.DATA[2] << 16) | (msg.DATA[3] << 24));
                    data.EncoderValue = posValue;

                    // 根据你的 EncoderConfig 换算单圈/多圈
                    uint singleResolution = 1U << EncoderConfig.SingleTurnBits;
                    data.MultiTurn = posValue / singleResolution;
                    data.SingleTurn = posValue % singleResolution;
                    data.Angle = data.SingleTurn * 360.0 / singleResolution;

                    positionReceived = true;
                }
            }

            return positionReceived ? data : null;
        }
    }
}
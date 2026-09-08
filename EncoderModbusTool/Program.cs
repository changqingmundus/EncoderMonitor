using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using System.Threading;

namespace EncoderModbusTool
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string language = Properties.Settings.Default.Language;

            if (string.IsNullOrEmpty(language))
            {
                language = "zh-CN";
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new ModbusMainForm());
        }
    }
}

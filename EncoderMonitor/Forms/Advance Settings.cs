using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncoderMonitor
{
    public partial class Advance_Settings : Form
    {
        public Advance_Settings()
        {
            InitializeComponent();
        }
        private void Advance_Settings_Load(object sender, EventArgs e)
        {
            InitRegisterMap();
            dgvRegisterMap.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegisterMap.Columns["colName"].FillWeight = 70;
            dgvRegisterMap.Columns["colAddress"].FillWeight = 30;
        }

        private void LoadConfig_Click(object sender, EventArgs e)
        {

        }

        private void SaveConfig_Click(object sender, EventArgs e)
        {

        }

        private void SetFunctionCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SlaveID_Click(object sender, EventArgs e)
        {

        }

        private void SetSlaveID_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvRegisterMap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void InitRegisterMap()
        {
            dgvRegisterMap.Rows.Clear();
            dgvRegisterMap.RowHeadersVisible = false;

            dgvRegisterMap.Rows.Add(
                "SingleTurn",
                "0x0000"
            );
            dgvRegisterMap.Rows.Add(
                "MultiTurn",
                "0x0001"
            );
            dgvRegisterMap.Rows.Add(
                "Count Direction",
                "0x0006"
            );
            dgvRegisterMap.Rows.Add(
                "Rotation Direction",
                "0x000B"
            );
            dgvRegisterMap.Rows.Add(
                "Rotation Speed",
                "0x000C"
            );
            // 補空行
            for (int i = 0; i < 15; i++)
            {
                dgvRegisterMap.Rows.Add(
                    "",
                    ""
                );
            }
        }
    }
}

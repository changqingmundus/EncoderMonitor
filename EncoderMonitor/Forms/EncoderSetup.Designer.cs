namespace EncoderMonitor
{
    partial class EncoderSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncoderSetup));
            this.tb_select_setup = new System.Windows.Forms.TabControl();
            this.TabTamagawa = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.TabModBusRTU = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.Factory_MTChip = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Factory_CRC = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Factory_STChip = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Factory_STBits = new System.Windows.Forms.ComboBox();
            this.Factory_MTBits = new System.Windows.Forms.ComboBox();
            this.TabCANopen = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LogShowbox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Factory_Mode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Factory_RegMap = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_select_setup.SuspendLayout();
            this.TabTamagawa.SuspendLayout();
            this.TabModBusRTU.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_select_setup
            // 
            this.tb_select_setup.Controls.Add(this.TabTamagawa);
            this.tb_select_setup.Controls.Add(this.TabModBusRTU);
            this.tb_select_setup.Controls.Add(this.TabCANopen);
            this.tb_select_setup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tb_select_setup.Location = new System.Drawing.Point(0, 0);
            this.tb_select_setup.Margin = new System.Windows.Forms.Padding(2);
            this.tb_select_setup.Name = "tb_select_setup";
            this.tb_select_setup.SelectedIndex = 0;
            this.tb_select_setup.Size = new System.Drawing.Size(342, 302);
            this.tb_select_setup.TabIndex = 10;
            // 
            // TabTamagawa
            // 
            this.TabTamagawa.Controls.Add(this.label4);
            this.TabTamagawa.Location = new System.Drawing.Point(4, 27);
            this.TabTamagawa.Margin = new System.Windows.Forms.Padding(2);
            this.TabTamagawa.Name = "TabTamagawa";
            this.TabTamagawa.Padding = new System.Windows.Forms.Padding(2);
            this.TabTamagawa.Size = new System.Drawing.Size(334, 271);
            this.TabTamagawa.TabIndex = 0;
            this.TabTamagawa.Text = "Tamagawa";
            this.TabTamagawa.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(62, -25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Factory Config Label !!!";
            // 
            // TabModBusRTU
            // 
            this.TabModBusRTU.Controls.Add(this.label3);
            this.TabModBusRTU.Controls.Add(this.Factory_RegMap);
            this.TabModBusRTU.Controls.Add(this.label12);
            this.TabModBusRTU.Controls.Add(this.Factory_Mode);
            this.TabModBusRTU.Controls.Add(this.label9);
            this.TabModBusRTU.Controls.Add(this.label8);
            this.TabModBusRTU.Controls.Add(this.Factory_MTChip);
            this.TabModBusRTU.Controls.Add(this.label7);
            this.TabModBusRTU.Controls.Add(this.Factory_CRC);
            this.TabModBusRTU.Controls.Add(this.label6);
            this.TabModBusRTU.Controls.Add(this.Factory_STChip);
            this.TabModBusRTU.Controls.Add(this.label5);
            this.TabModBusRTU.Controls.Add(this.label2);
            this.TabModBusRTU.Controls.Add(this.label1);
            this.TabModBusRTU.Controls.Add(this.Factory_STBits);
            this.TabModBusRTU.Controls.Add(this.Factory_MTBits);
            this.TabModBusRTU.Controls.Add(this.label13);
            this.TabModBusRTU.Location = new System.Drawing.Point(4, 27);
            this.TabModBusRTU.Margin = new System.Windows.Forms.Padding(2);
            this.TabModBusRTU.Name = "TabModBusRTU";
            this.TabModBusRTU.Padding = new System.Windows.Forms.Padding(2);
            this.TabModBusRTU.Size = new System.Drawing.Size(334, 271);
            this.TabModBusRTU.TabIndex = 1;
            this.TabModBusRTU.Text = "ModBusRTU";
            this.TabModBusRTU.UseVisualStyleBackColor = true;
            this.TabModBusRTU.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label8.Location = new System.Drawing.Point(207, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 25);
            this.label8.TabIndex = 31;
            this.label8.Text = "Default : 6";
            // 
            // Factory_MTChip
            // 
            this.Factory_MTChip.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Factory_MTChip.FormattingEnabled = true;
            this.Factory_MTChip.Items.AddRange(new object[] {
            "None",
            "IC-PVL"});
            this.Factory_MTChip.Location = new System.Drawing.Point(106, 69);
            this.Factory_MTChip.Name = "Factory_MTChip";
            this.Factory_MTChip.Size = new System.Drawing.Size(95, 28);
            this.Factory_MTChip.TabIndex = 30;
            this.Factory_MTChip.Text = "选择芯片";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(15, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 25);
            this.label7.TabIndex = 29;
            this.label7.Text = "MT Chip";
            // 
            // Factory_CRC
            // 
            this.Factory_CRC.Font = new System.Drawing.Font("微软雅黑", 11.25F);
            this.Factory_CRC.FormattingEnabled = true;
            this.Factory_CRC.Items.AddRange(new object[] {
            "6",
            "16"});
            this.Factory_CRC.Location = new System.Drawing.Point(106, 167);
            this.Factory_CRC.Name = "Factory_CRC";
            this.Factory_CRC.Size = new System.Drawing.Size(95, 28);
            this.Factory_CRC.TabIndex = 27;
            this.Factory_CRC.Text = "默认选择6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(15, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "CRCBits";
            // 
            // Factory_STChip
            // 
            this.Factory_STChip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Factory_STChip.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Factory_STChip.FormattingEnabled = true;
            this.Factory_STChip.Items.AddRange(new object[] {
            "None",
            "IC-PZ",
            "IC-MU"});
            this.Factory_STChip.Location = new System.Drawing.Point(106, 36);
            this.Factory_STChip.Margin = new System.Windows.Forms.Padding(2);
            this.Factory_STChip.Name = "Factory_STChip";
            this.Factory_STChip.Size = new System.Drawing.Size(95, 28);
            this.Factory_STChip.TabIndex = 25;
            this.Factory_STChip.Text = "选择芯片";
            this.Factory_STChip.SelectedIndexChanged += new System.EventHandler(this.Factory_BaudRate_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(20, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "ST Chip";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "STBits";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "MTBits";
            // 
            // Factory_STBits
            // 
            this.Factory_STBits.Font = new System.Drawing.Font("微软雅黑", 11.25F);
            this.Factory_STBits.FormattingEnabled = true;
            this.Factory_STBits.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "32",
            "31",
            "32"});
            this.Factory_STBits.Location = new System.Drawing.Point(106, 101);
            this.Factory_STBits.Margin = new System.Windows.Forms.Padding(2);
            this.Factory_STBits.Name = "Factory_STBits";
            this.Factory_STBits.Size = new System.Drawing.Size(95, 28);
            this.Factory_STBits.TabIndex = 19;
            this.Factory_STBits.Text = "單圈位數";
            // 
            // Factory_MTBits
            // 
            this.Factory_MTBits.Font = new System.Drawing.Font("微软雅黑", 11.25F);
            this.Factory_MTBits.FormattingEnabled = true;
            this.Factory_MTBits.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "32",
            "31",
            "32"});
            this.Factory_MTBits.Location = new System.Drawing.Point(106, 133);
            this.Factory_MTBits.Margin = new System.Windows.Forms.Padding(2);
            this.Factory_MTBits.Name = "Factory_MTBits";
            this.Factory_MTBits.Size = new System.Drawing.Size(95, 28);
            this.Factory_MTBits.TabIndex = 18;
            this.Factory_MTBits.Text = "多圈位數";
            // 
            // TabCANopen
            // 
            this.TabCANopen.Location = new System.Drawing.Point(4, 27);
            this.TabCANopen.Margin = new System.Windows.Forms.Padding(2);
            this.TabCANopen.Name = "TabCANopen";
            this.TabCANopen.Size = new System.Drawing.Size(334, 271);
            this.TabCANopen.TabIndex = 2;
            this.TabCANopen.Text = "CANopen";
            this.TabCANopen.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button2.Location = new System.Drawing.Point(225, 302);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 41);
            this.button2.TabIndex = 15;
            this.button2.Text = "Write";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnFactoryWrite_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Location = new System.Drawing.Point(14, 301);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 41);
            this.button1.TabIndex = 14;
            this.button1.Text = "Read";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 344);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Read Config";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(222, 345);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Write Config";
            // 
            // LogShowbox
            // 
            this.LogShowbox.Location = new System.Drawing.Point(4, 365);
            this.LogShowbox.Name = "LogShowbox";
            this.LogShowbox.Size = new System.Drawing.Size(334, 59);
            this.LogShowbox.TabIndex = 21;
            this.LogShowbox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 40);
            this.label3.TabIndex = 32;
            this.label3.Text = "配置写入可多次尝试，出错请重新上电后测试。\r\n若多次失败仍未成功，请联系技术人员！！！";
            // 
            // Factory_Mode
            // 
            this.Factory_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Factory_Mode.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Factory_Mode.FormattingEnabled = true;
            this.Factory_Mode.Items.AddRange(new object[] {
            "None",
            "单圈",
            "多圈"});
            this.Factory_Mode.Location = new System.Drawing.Point(106, 4);
            this.Factory_Mode.Margin = new System.Windows.Forms.Padding(2);
            this.Factory_Mode.Name = "Factory_Mode";
            this.Factory_Mode.Size = new System.Drawing.Size(95, 28);
            this.Factory_Mode.TabIndex = 33;
            this.Factory_Mode.Text = "选择模式";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(29, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 25);
            this.label9.TabIndex = 32;
            this.label9.Text = "Mode";
            // 
            // Factory_RegMap
            // 
            this.Factory_RegMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Factory_RegMap.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Factory_RegMap.FormattingEnabled = true;
            this.Factory_RegMap.Items.AddRange(new object[] {
            "Auto",
            "16Bits",
            "32Bits"});
            this.Factory_RegMap.Location = new System.Drawing.Point(106, 200);
            this.Factory_RegMap.Margin = new System.Windows.Forms.Padding(2);
            this.Factory_RegMap.Name = "Factory_RegMap";
            this.Factory_RegMap.Size = new System.Drawing.Size(95, 28);
            this.Factory_RegMap.TabIndex = 35;
            this.Factory_RegMap.Text = "寄存器表";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(9, 201);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 25);
            this.label12.TabIndex = 34;
            this.label12.Text = "Reg Map";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label13.Location = new System.Drawing.Point(206, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 25);
            this.label13.TabIndex = 36;
            this.label13.Text = "Default : Auto";
            // 
            // EncoderSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 425);
            this.Controls.Add(this.LogShowbox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tb_select_setup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "EncoderSetup";
            this.Text = "EncoderSetup";
            this.Load += new System.EventHandler(this.EncoderSetup_Load);
            this.tb_select_setup.ResumeLayout(false);
            this.TabTamagawa.ResumeLayout(false);
            this.TabTamagawa.PerformLayout();
            this.TabModBusRTU.ResumeLayout(false);
            this.TabModBusRTU.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tb_select_setup;
        private System.Windows.Forms.TabPage TabTamagawa;
        private System.Windows.Forms.TabPage TabModBusRTU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Factory_STBits;
        private System.Windows.Forms.ComboBox Factory_MTBits;
        private System.Windows.Forms.TabPage TabCANopen;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox Factory_STChip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Factory_CRC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Factory_MTChip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox LogShowbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Factory_Mode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Factory_RegMap;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}
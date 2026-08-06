namespace EncoderMonitor
{
    partial class Advance_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Advance_Settings));
            this.SaveConfig = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabTamagawa = new System.Windows.Forms.TabPage();
            this.TabModBusRTU = new System.Windows.Forms.TabPage();
            this.TabCANopen = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabCommandConfig = new System.Windows.Forms.TabPage();
            this.tabRegisterMap = new System.Windows.Forms.TabPage();
            this.dgvRegisterMap = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.TabModBusRTU.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabCommandConfig.SuspendLayout();
            this.tabRegisterMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterMap)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveConfig
            // 
            this.SaveConfig.Location = new System.Drawing.Point(768, 454);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(100, 57);
            this.SaveConfig.TabIndex = 10;
            this.SaveConfig.Text = "Send";
            this.SaveConfig.UseVisualStyleBackColor = true;
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabTamagawa);
            this.tabControl1.Controls.Add(this.TabModBusRTU);
            this.tabControl1.Controls.Add(this.TabCANopen);
            this.tabControl1.Font = new System.Drawing.Font("KaiTi", 15F);
            this.tabControl1.Location = new System.Drawing.Point(12, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(928, 639);
            this.tabControl1.TabIndex = 14;
            // 
            // TabTamagawa
            // 
            this.TabTamagawa.Font = new System.Drawing.Font("KaiTi", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabTamagawa.Location = new System.Drawing.Point(4, 30);
            this.TabTamagawa.Name = "TabTamagawa";
            this.TabTamagawa.Padding = new System.Windows.Forms.Padding(3);
            this.TabTamagawa.Size = new System.Drawing.Size(920, 515);
            this.TabTamagawa.TabIndex = 0;
            this.TabTamagawa.Text = "Tamagawa";
            this.TabTamagawa.UseVisualStyleBackColor = true;
            // 
            // TabModBusRTU
            // 
            this.TabModBusRTU.Controls.Add(this.tabControl2);
            this.TabModBusRTU.Font = new System.Drawing.Font("KaiTi", 15F, System.Drawing.FontStyle.Bold);
            this.TabModBusRTU.Location = new System.Drawing.Point(4, 35);
            this.TabModBusRTU.Name = "TabModBusRTU";
            this.TabModBusRTU.Padding = new System.Windows.Forms.Padding(3);
            this.TabModBusRTU.Size = new System.Drawing.Size(920, 600);
            this.TabModBusRTU.TabIndex = 1;
            this.TabModBusRTU.Text = "ModbusRTU";
            this.TabModBusRTU.UseVisualStyleBackColor = true;
            // 
            // TabCANopen
            // 
            this.TabCANopen.Font = new System.Drawing.Font("KaiTi", 15F, System.Drawing.FontStyle.Bold);
            this.TabCANopen.Location = new System.Drawing.Point(4, 30);
            this.TabCANopen.Name = "TabCANopen";
            this.TabCANopen.Padding = new System.Windows.Forms.Padding(3);
            this.TabCANopen.Size = new System.Drawing.Size(920, 515);
            this.TabCANopen.TabIndex = 2;
            this.TabCANopen.Text = "CANopen";
            this.TabCANopen.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabCommandConfig);
            this.tabControl2.Controls.Add(this.tabRegisterMap);
            this.tabControl2.Font = new System.Drawing.Font("KaiTi", 12F);
            this.tabControl2.Location = new System.Drawing.Point(6, 23);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(908, 568);
            this.tabControl2.TabIndex = 0;
            // 
            // tabCommandConfig
            // 
            this.tabCommandConfig.Controls.Add(this.SaveConfig);
            this.tabCommandConfig.Font = new System.Drawing.Font("KaiTi", 10F, System.Drawing.FontStyle.Bold);
            this.tabCommandConfig.Location = new System.Drawing.Point(4, 30);
            this.tabCommandConfig.Name = "tabCommandConfig";
            this.tabCommandConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommandConfig.Size = new System.Drawing.Size(900, 534);
            this.tabCommandConfig.TabIndex = 0;
            this.tabCommandConfig.Text = "Command Config";
            this.tabCommandConfig.UseVisualStyleBackColor = true;
            // 
            // tabRegisterMap
            // 
            this.tabRegisterMap.Controls.Add(this.dgvRegisterMap);
            this.tabRegisterMap.Font = new System.Drawing.Font("KaiTi", 15F);
            this.tabRegisterMap.Location = new System.Drawing.Point(4, 30);
            this.tabRegisterMap.Name = "tabRegisterMap";
            this.tabRegisterMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegisterMap.Size = new System.Drawing.Size(900, 534);
            this.tabRegisterMap.TabIndex = 1;
            this.tabRegisterMap.Text = "Register Map";
            this.tabRegisterMap.UseVisualStyleBackColor = true;
            // 
            // dgvRegisterMap
            // 
            this.dgvRegisterMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegisterMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colAddress});
            this.dgvRegisterMap.Location = new System.Drawing.Point(16, 6);
            this.dgvRegisterMap.Name = "dgvRegisterMap";
            this.dgvRegisterMap.RowHeadersWidth = 51;
            this.dgvRegisterMap.RowTemplate.Height = 24;
            this.dgvRegisterMap.Size = new System.Drawing.Size(494, 522);
            this.dgvRegisterMap.TabIndex = 0;
            this.dgvRegisterMap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegisterMap_CellContentClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 125;
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "Address";
            this.colAddress.MinimumWidth = 6;
            this.colAddress.Name = "colAddress";
            this.colAddress.Width = 125;
            // 
            // Advance_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 645);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("KaiTi", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Advance_Settings";
            this.Text = "Advanced Settings";
            this.Load += new System.EventHandler(this.Advance_Settings_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabModBusRTU.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabCommandConfig.ResumeLayout(false);
            this.tabRegisterMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SaveConfig;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabTamagawa;
        private System.Windows.Forms.TabPage TabModBusRTU;
        private System.Windows.Forms.TabPage TabCANopen;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabCommandConfig;
        private System.Windows.Forms.TabPage tabRegisterMap;
        private System.Windows.Forms.DataGridView dgvRegisterMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
    }
}
namespace EncoderMonitor
{
    partial class DataWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataWindow));
            this.ele_AngleShow = new System.Windows.Forms.Integration.ElementHost();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Binary = new System.Windows.Forms.Label();
            this.label_Resolution = new System.Windows.Forms.Label();
            this.label_Angle = new System.Windows.Forms.Label();
            this.textBox_Binary = new System.Windows.Forms.TextBox();
            this.textBox_Resolution = new System.Windows.Forms.TextBox();
            this.textBox_Angle = new System.Windows.Forms.TextBox();
            this.ele_Dirshow = new System.Windows.Forms.Integration.ElementHost();
            this.directionIndicator2 = new Dashboard.UI.DirectionIndicator();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.directionIndicator3 = new Dashboard.UI.DirectionIndicator();
            this.SuspendLayout();
            // 
            // ele_AngleShow
            // 
            this.ele_AngleShow.Location = new System.Drawing.Point(28, 64);
            this.ele_AngleShow.Name = "ele_AngleShow";
            this.ele_AngleShow.Size = new System.Drawing.Size(320, 320);
            this.ele_AngleShow.TabIndex = 0;
            this.ele_AngleShow.Text = "elementHost1";
            this.ele_AngleShow.Child = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("隶书", 24.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(84, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data Window";
            // 
            // label_Binary
            // 
            this.label_Binary.AutoSize = true;
            this.label_Binary.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Binary.Location = new System.Drawing.Point(12, 427);
            this.label_Binary.Name = "label_Binary";
            this.label_Binary.Size = new System.Drawing.Size(75, 20);
            this.label_Binary.TabIndex = 3;
            this.label_Binary.Text = "Binary";
            // 
            // label_Resolution
            // 
            this.label_Resolution.AutoSize = true;
            this.label_Resolution.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Resolution.Location = new System.Drawing.Point(10, 476);
            this.label_Resolution.Name = "label_Resolution";
            this.label_Resolution.Size = new System.Drawing.Size(119, 20);
            this.label_Resolution.TabIndex = 4;
            this.label_Resolution.Text = "Resolution";
            // 
            // label_Angle
            // 
            this.label_Angle.AutoSize = true;
            this.label_Angle.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Angle.Location = new System.Drawing.Point(12, 521);
            this.label_Angle.Name = "label_Angle";
            this.label_Angle.Size = new System.Drawing.Size(64, 20);
            this.label_Angle.TabIndex = 5;
            this.label_Angle.Text = "Angle";
            // 
            // textBox_Binary
            // 
            this.textBox_Binary.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.textBox_Binary.Location = new System.Drawing.Point(135, 427);
            this.textBox_Binary.Name = "textBox_Binary";
            this.textBox_Binary.ReadOnly = true;
            this.textBox_Binary.Size = new System.Drawing.Size(233, 26);
            this.textBox_Binary.TabIndex = 6;
            this.textBox_Binary.Text = "0000000000000000000";
            this.textBox_Binary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Resolution
            // 
            this.textBox_Resolution.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_Resolution.Location = new System.Drawing.Point(135, 473);
            this.textBox_Resolution.Name = "textBox_Resolution";
            this.textBox_Resolution.ReadOnly = true;
            this.textBox_Resolution.Size = new System.Drawing.Size(233, 30);
            this.textBox_Resolution.TabIndex = 7;
            this.textBox_Resolution.Text = "Max Resolution";
            this.textBox_Resolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Angle
            // 
            this.textBox_Angle.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_Angle.Location = new System.Drawing.Point(134, 518);
            this.textBox_Angle.Name = "textBox_Angle";
            this.textBox_Angle.ReadOnly = true;
            this.textBox_Angle.Size = new System.Drawing.Size(234, 30);
            this.textBox_Angle.TabIndex = 8;
            this.textBox_Angle.Text = "000.000 deg";
            this.textBox_Angle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ele_Dirshow
            // 
            this.ele_Dirshow.Location = new System.Drawing.Point(282, -1);
            this.ele_Dirshow.Name = "ele_Dirshow";
            this.ele_Dirshow.Size = new System.Drawing.Size(110, 89);
            this.ele_Dirshow.TabIndex = 9;
            this.ele_Dirshow.Text = "elementHost2";
            this.ele_Dirshow.Child = this.directionIndicator2;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(282, -1);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(110, 89);
            this.elementHost1.TabIndex = 9;
            this.elementHost1.Text = "elementHost2";
            this.elementHost1.Child = this.directionIndicator3;
            // 
            // DataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 557);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.ele_Dirshow);
            this.Controls.Add(this.textBox_Angle);
            this.Controls.Add(this.textBox_Resolution);
            this.Controls.Add(this.textBox_Binary);
            this.Controls.Add(this.label_Angle);
            this.Controls.Add(this.label_Resolution);
            this.Controls.Add(this.label_Binary);
            this.Controls.Add(this.ele_AngleShow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataWindow";
            this.Text = "DataWindow";
            this.Load += new System.EventHandler(this.DataWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost ele_AngleShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Binary;
        private System.Windows.Forms.Label label_Resolution;
        private System.Windows.Forms.Label label_Angle;
        private System.Windows.Forms.TextBox textBox_Binary;
        private System.Windows.Forms.TextBox textBox_Resolution;
        private System.Windows.Forms.TextBox textBox_Angle;
        private Dashboard.UI.DirectionIndicator directionIndicator1;
        private System.Windows.Forms.Integration.ElementHost ele_Dirshow;
        private Dashboard.UI.DirectionIndicator directionIndicator2;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Dashboard.UI.DirectionIndicator directionIndicator3;
    }
}
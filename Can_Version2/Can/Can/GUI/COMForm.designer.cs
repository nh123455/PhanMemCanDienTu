
namespace Can.GUI
{
    partial class COMForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COMForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBaudRate = new DevExpress.XtraEditors.TextEdit();
            this.txtParity = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataBits = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStopBits = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.cbComPort = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaudRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStopBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComPort.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(115, 71);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaudRate.Properties.Appearance.Options.UseFont = true;
            this.txtBaudRate.Size = new System.Drawing.Size(248, 28);
            this.txtBaudRate.TabIndex = 3;
            // 
            // txtParity
            // 
            this.txtParity.Location = new System.Drawing.Point(115, 124);
            this.txtParity.Name = "txtParity";
            this.txtParity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParity.Properties.Appearance.Options.UseFont = true;
            this.txtParity.Size = new System.Drawing.Size(248, 28);
            this.txtParity.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parity";
            // 
            // txtDataBits
            // 
            this.txtDataBits.Location = new System.Drawing.Point(115, 179);
            this.txtDataBits.Name = "txtDataBits";
            this.txtDataBits.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataBits.Properties.Appearance.Options.UseFont = true;
            this.txtDataBits.Size = new System.Drawing.Size(248, 28);
            this.txtDataBits.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data Bits";
            // 
            // txtStopBits
            // 
            this.txtStopBits.Location = new System.Drawing.Point(115, 235);
            this.txtStopBits.Name = "txtStopBits";
            this.txtStopBits.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStopBits.Properties.Appearance.Options.UseFont = true;
            this.txtStopBits.Size = new System.Drawing.Size(248, 28);
            this.txtStopBits.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stop Bits";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = global::Can.Properties.Resources.save_16x16;
            this.btnSave.Location = new System.Drawing.Point(254, 288);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 29);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            // 
            // cbComPort
            // 
            this.cbComPort.Location = new System.Drawing.Point(115, 19);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbComPort.Properties.Appearance.Options.UseFont = true;
            this.cbComPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbComPort.Size = new System.Drawing.Size(248, 28);
            this.cbComPort.TabIndex = 11;
            // 
            // COMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 338);
            this.Controls.Add(this.cbComPort);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtStopBits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDataBits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtParity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBaudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "COMForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt cổng COM";
            ((System.ComponentModel.ISupportInitialize)(this.txtBaudRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStopBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComPort.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtBaudRate;
        private DevExpress.XtraEditors.TextEdit txtParity;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtDataBits;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtStopBits;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.ComboBoxEdit cbComPort;
    }
}

namespace Can.GUI
{
    partial class CameraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtRstp1 = new DevExpress.XtraEditors.TextEdit();
            this.txtRstp2 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRstp3 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtRstp1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRstp2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRstp3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "RTSP Camera 1";
            // 
            // txtRstp1
            // 
            this.txtRstp1.Location = new System.Drawing.Point(194, 31);
            this.txtRstp1.Name = "txtRstp1";
            this.txtRstp1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRstp1.Properties.Appearance.Options.UseFont = true;
            this.txtRstp1.Size = new System.Drawing.Size(508, 28);
            this.txtRstp1.TabIndex = 1;
            // 
            // txtRstp2
            // 
            this.txtRstp2.Location = new System.Drawing.Point(194, 88);
            this.txtRstp2.Name = "txtRstp2";
            this.txtRstp2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRstp2.Properties.Appearance.Options.UseFont = true;
            this.txtRstp2.Size = new System.Drawing.Size(508, 28);
            this.txtRstp2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "RTSP Camera 2";
            // 
            // txtRstp3
            // 
            this.txtRstp3.Location = new System.Drawing.Point(194, 145);
            this.txtRstp3.Name = "txtRstp3";
            this.txtRstp3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRstp3.Properties.Appearance.Options.UseFont = true;
            this.txtRstp3.Size = new System.Drawing.Size(508, 28);
            this.txtRstp3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "RTSP Camera 3";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = global::Can.Properties.Resources.save_16x16;
            this.btnSave.Location = new System.Drawing.Point(539, 201);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(163, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 259);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRstp3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRstp2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRstp1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông số Camera";
            ((System.ComponentModel.ISupportInitialize)(this.txtRstp1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRstp2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRstp3.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtRstp1;
        private DevExpress.XtraEditors.TextEdit txtRstp2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtRstp3;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
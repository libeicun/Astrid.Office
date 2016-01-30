namespace Astrid.OfficeHelper {
    partial class MergerSetting {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cmdExcute = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtFiles = new System.Windows.Forms.TextBox();
            this.cmdSelectFiles = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // cmdExcute
            // 
            this.cmdExcute.Location = new System.Drawing.Point(141, 6);
            this.cmdExcute.Name = "cmdExcute";
            this.cmdExcute.Size = new System.Drawing.Size(75, 23);
            this.cmdExcute.TabIndex = 0;
            this.cmdExcute.Text = "开始合并";
            this.cmdExcute.UseVisualStyleBackColor = true;
            this.cmdExcute.Click += new System.EventHandler(this.cmdExcute_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(276, 6);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtFiles
            // 
            this.txtFiles.Location = new System.Drawing.Point(2, 35);
            this.txtFiles.Multiline = true;
            this.txtFiles.Name = "txtFiles";
            this.txtFiles.ReadOnly = true;
            this.txtFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFiles.Size = new System.Drawing.Size(349, 129);
            this.txtFiles.TabIndex = 2;
            // 
            // cmdSelectFiles
            // 
            this.cmdSelectFiles.Location = new System.Drawing.Point(2, 6);
            this.cmdSelectFiles.Name = "cmdSelectFiles";
            this.cmdSelectFiles.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectFiles.TabIndex = 3;
            this.cmdSelectFiles.Text = "选择文件";
            this.cmdSelectFiles.UseVisualStyleBackColor = true;
            this.cmdSelectFiles.Click += new System.EventHandler(this.cmdSelectFiles_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Visio文档(*.vsdx)|*.vsdx|Visio2003文档(*.vsd)|*.vsd";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.ShowReadOnly = true;
            // 
            // MergerSetting
            // 
            this.AcceptButton = this.cmdExcute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(353, 166);
            this.Controls.Add(this.cmdSelectFiles);
            this.Controls.Add(this.txtFiles);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdExcute);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MergerSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MergerSetting";
            this.Load += new System.EventHandler(this.MergerSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdExcute;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtFiles;
        private System.Windows.Forms.Button cmdSelectFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
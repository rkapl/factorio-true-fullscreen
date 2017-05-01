namespace factorio_patcher
{
    partial class FactorioPatcher
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
            this.file = new System.Windows.Forms.TextBox();
            this.selectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.TextBox();
            this.height = new System.Windows.Forms.TextBox();
            this.patch = new System.Windows.Forms.Button();
            this.modes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.restore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // file
            // 
            this.file.Location = new System.Drawing.Point(13, 13);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(286, 26);
            this.file.TabIndex = 0;
            this.file.Text = "c:\\Program Files (x86)\\Steam\\steamapps\\common\\Factorio\\bin\\x64\\factorio.exe";
            this.file.TextChanged += new System.EventHandler(this.file_TextChanged);
            // 
            // selectFile
            // 
            this.selectFile.AutoSize = true;
            this.selectFile.Location = new System.Drawing.Point(305, 11);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(101, 30);
            this.selectFile.TabIndex = 1;
            this.selectFile.Text = "Select EXE";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height:";
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(112, 45);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(187, 26);
            this.width.TabIndex = 4;
            this.width.Text = "1280";
            this.width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(112, 77);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(187, 26);
            this.height.TabIndex = 5;
            this.height.Text = "1024";
            this.height.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // patch
            // 
            this.patch.AutoSize = true;
            this.patch.Location = new System.Drawing.Point(306, 45);
            this.patch.Name = "patch";
            this.patch.Size = new System.Drawing.Size(100, 30);
            this.patch.TabIndex = 6;
            this.patch.Text = "Patch";
            this.patch.UseVisualStyleBackColor = true;
            this.patch.Click += new System.EventHandler(this.patch_Click);
            // 
            // modes
            // 
            this.modes.FormattingEnabled = true;
            this.modes.Location = new System.Drawing.Point(112, 109);
            this.modes.Name = "modes";
            this.modes.Size = new System.Drawing.Size(187, 28);
            this.modes.TabIndex = 8;
            this.modes.SelectedIndexChanged += new System.EventHandler(this.modes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Or choose:";
            // 
            // restore
            // 
            this.restore.AutoSize = true;
            this.restore.Enabled = false;
            this.restore.Location = new System.Drawing.Point(306, 80);
            this.restore.Name = "restore";
            this.restore.Size = new System.Drawing.Size(100, 30);
            this.restore.TabIndex = 10;
            this.restore.Text = "Restore";
            this.restore.UseVisualStyleBackColor = true;
            this.restore.Click += new System.EventHandler(this.restore_Click);
            // 
            // FactorioPatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 156);
            this.Controls.Add(this.restore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modes);
            this.Controls.Add(this.patch);
            this.Controls.Add(this.height);
            this.Controls.Add(this.width);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.file);
            this.Name = "FactorioPatcher";
            this.Text = "FactorioPatcher";
            this.Load += new System.EventHandler(this.FactorioPatcher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox file;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.Button patch;
        private System.Windows.Forms.ComboBox modes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button restore;
    }
}


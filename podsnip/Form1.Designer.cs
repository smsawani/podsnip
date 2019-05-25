namespace podsnip
{
    partial class podsnip
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
            this.btnSnip = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartFile = new System.Windows.Forms.Label();
            this.txtOpenFilename = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.startMinutes = new System.Windows.Forms.NumericUpDown();
            this.startSeconds = new System.Windows.Forms.NumericUpDown();
            this.endMinutes = new System.Windows.Forms.NumericUpDown();
            this.endSeconds = new System.Windows.Forms.NumericUpDown();
            this.startHour = new System.Windows.Forms.NumericUpDown();
            this.endHour = new System.Windows.Forms.NumericUpDown();
            this.lblDone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.startMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endHour)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSnip
            // 
            this.btnSnip.Location = new System.Drawing.Point(202, 167);
            this.btnSnip.Name = "btnSnip";
            this.btnSnip.Size = new System.Drawing.Size(75, 23);
            this.btnSnip.TabIndex = 2;
            this.btnSnip.Text = "snip mp3";
            this.btnSnip.UseVisualStyleBackColor = true;
            this.btnSnip.Click += new System.EventHandler(this.btnSnip_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(16, 100);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(102, 13);
            this.lblStartTime.TabIndex = 4;
            this.lblStartTime.Text = "start time (hh:mm:ss)";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(16, 127);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(100, 13);
            this.lblEndTime.TabIndex = 5;
            this.lblEndTime.Text = "end time (hh:mm:ss)";
            // 
            // lblStartFile
            // 
            this.lblStartFile.AutoSize = true;
            this.lblStartFile.Location = new System.Drawing.Point(18, 38);
            this.lblStartFile.Name = "lblStartFile";
            this.lblStartFile.Size = new System.Drawing.Size(61, 13);
            this.lblStartFile.TabIndex = 7;
            this.lblStartFile.Text = "podcast file";
            // 
            // txtOpenFilename
            // 
            this.txtOpenFilename.Location = new System.Drawing.Point(97, 35);
            this.txtOpenFilename.Name = "txtOpenFilename";
            this.txtOpenFilename.Size = new System.Drawing.Size(353, 20);
            this.txtOpenFilename.TabIndex = 8;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(96, 60);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 9;
            this.btnOpenFile.Text = "open file";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // startMinutes
            // 
            this.startMinutes.Location = new System.Drawing.Point(158, 100);
            this.startMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.startMinutes.Name = "startMinutes";
            this.startMinutes.Size = new System.Drawing.Size(35, 20);
            this.startMinutes.TabIndex = 10;
            // 
            // startSeconds
            // 
            this.startSeconds.Location = new System.Drawing.Point(195, 100);
            this.startSeconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.startSeconds.Name = "startSeconds";
            this.startSeconds.Size = new System.Drawing.Size(33, 20);
            this.startSeconds.TabIndex = 11;
            // 
            // endMinutes
            // 
            this.endMinutes.Location = new System.Drawing.Point(158, 123);
            this.endMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.endMinutes.Name = "endMinutes";
            this.endMinutes.Size = new System.Drawing.Size(35, 20);
            this.endMinutes.TabIndex = 12;
            // 
            // endSeconds
            // 
            this.endSeconds.Location = new System.Drawing.Point(195, 123);
            this.endSeconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.endSeconds.Name = "endSeconds";
            this.endSeconds.Size = new System.Drawing.Size(33, 20);
            this.endSeconds.TabIndex = 13;
            // 
            // startHour
            // 
            this.startHour.Location = new System.Drawing.Point(121, 100);
            this.startHour.Name = "startHour";
            this.startHour.Size = new System.Drawing.Size(35, 20);
            this.startHour.TabIndex = 14;
            // 
            // endHour
            // 
            this.endHour.Location = new System.Drawing.Point(121, 123);
            this.endHour.Name = "endHour";
            this.endHour.Size = new System.Drawing.Size(35, 20);
            this.endHour.TabIndex = 15;
            // 
            // lblDone
            // 
            this.lblDone.AutoSize = true;
            this.lblDone.Location = new System.Drawing.Point(295, 172);
            this.lblDone.Name = "lblDone";
            this.lblDone.Size = new System.Drawing.Size(75, 13);
            this.lblDone.TabIndex = 16;
            this.lblDone.Text = "snip complete!";
            this.lblDone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDone.Visible = false;
            // 
            // podsnip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 211);
            this.Controls.Add(this.lblDone);
            this.Controls.Add(this.endHour);
            this.Controls.Add(this.startHour);
            this.Controls.Add(this.endSeconds);
            this.Controls.Add(this.endMinutes);
            this.Controls.Add(this.startSeconds);
            this.Controls.Add(this.startMinutes);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtOpenFilename);
            this.Controls.Add(this.lblStartFile);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.btnSnip);
            this.Name = "podsnip";
            this.Text = "podsnip";
            ((System.ComponentModel.ISupportInitialize)(this.startMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSnip;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartFile;
        private System.Windows.Forms.TextBox txtOpenFilename;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.NumericUpDown startMinutes;
        private System.Windows.Forms.NumericUpDown startSeconds;
        private System.Windows.Forms.NumericUpDown endMinutes;
        private System.Windows.Forms.NumericUpDown endSeconds;
        private System.Windows.Forms.NumericUpDown startHour;
        private System.Windows.Forms.NumericUpDown endHour;
        private System.Windows.Forms.Label lblDone;
    }
}


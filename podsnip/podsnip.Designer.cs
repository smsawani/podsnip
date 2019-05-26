﻿using System.Windows.Forms;
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
            this.displayStartHour = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.displayStartMinutes = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.displayStartSeconds = new System.Windows.Forms.Label();
            this.displayEndSeconds = new System.Windows.Forms.Label();
            this.displayEndMinutes = new System.Windows.Forms.Label();
            this.displayEndHour = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblOptionalTag = new System.Windows.Forms.Label();
            this.txtOptionalTag = new System.Windows.Forms.TextBox();
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
            this.btnSnip.Location = new System.Drawing.Point(202, 199);
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
            this.lblStartTime.Location = new System.Drawing.Point(16, 101);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(102, 13);
            this.lblStartTime.TabIndex = 4;
            this.lblStartTime.Text = "start time (hh:mm:ss)";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(16, 128);
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
            this.txtOpenFilename.Size = new System.Drawing.Size(430, 20);
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
            this.startMinutes.Location = new System.Drawing.Point(167, 101);
            this.startMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.startMinutes.Name = "startMinutes";
            this.startMinutes.Size = new System.Drawing.Size(46, 20);
            this.startMinutes.TabIndex = 10;
            this.startMinutes.ValueChanged += new System.EventHandler(this.startMinutes_ValueChanged);
            // 
            // startSeconds
            // 
            this.startSeconds.Location = new System.Drawing.Point(214, 101);
            this.startSeconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.startSeconds.Name = "startSeconds";
            this.startSeconds.Size = new System.Drawing.Size(43, 20);
            this.startSeconds.TabIndex = 11;
            this.startSeconds.ValueChanged += new System.EventHandler(this.startSeconds_ValueChanged);
            // 
            // endMinutes
            // 
            this.endMinutes.Location = new System.Drawing.Point(167, 124);
            this.endMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.endMinutes.Name = "endMinutes";
            this.endMinutes.Size = new System.Drawing.Size(46, 20);
            this.endMinutes.TabIndex = 12;
            this.endMinutes.ValueChanged += new System.EventHandler(this.endMinutes_ValueChanged);
            // 
            // endSeconds
            // 
            this.endSeconds.Location = new System.Drawing.Point(213, 124);
            this.endSeconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.endSeconds.Name = "endSeconds";
            this.endSeconds.Size = new System.Drawing.Size(43, 20);
            this.endSeconds.TabIndex = 13;
            this.endSeconds.ValueChanged += new System.EventHandler(this.endSeconds_ValueChanged);
            // 
            // startHour
            // 
            this.startHour.Location = new System.Drawing.Point(121, 101);
            this.startHour.Name = "startHour";
            this.startHour.Size = new System.Drawing.Size(45, 20);
            this.startHour.TabIndex = 14;
            this.startHour.ValueChanged += new System.EventHandler(this.startHour_ValueChanged);
            // 
            // endHour
            // 
            this.endHour.Location = new System.Drawing.Point(121, 124);
            this.endHour.Name = "endHour";
            this.endHour.Size = new System.Drawing.Size(45, 20);
            this.endHour.TabIndex = 15;
            this.endHour.ValueChanged += new System.EventHandler(this.endHour_ValueChanged);
            // 
            // lblDone
            // 
            this.lblDone.AutoSize = true;
            this.lblDone.Location = new System.Drawing.Point(295, 204);
            this.lblDone.Name = "lblDone";
            this.lblDone.Size = new System.Drawing.Size(75, 13);
            this.lblDone.TabIndex = 16;
            this.lblDone.Text = "snip complete!";
            this.lblDone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDone.Visible = false;
            // 
            // displayStartHour
            // 
            this.displayStartHour.AutoSize = true;
            this.displayStartHour.Location = new System.Drawing.Point(262, 107);
            this.displayStartHour.Name = "displayStartHour";
            this.displayStartHour.Size = new System.Drawing.Size(19, 13);
            this.displayStartHour.TabIndex = 17;
            this.displayStartHour.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = ":";
            // 
            // displayStartMinutes
            // 
            this.displayStartMinutes.AutoSize = true;
            this.displayStartMinutes.Location = new System.Drawing.Point(283, 107);
            this.displayStartMinutes.Name = "displayStartMinutes";
            this.displayStartMinutes.Size = new System.Drawing.Size(19, 13);
            this.displayStartMinutes.TabIndex = 19;
            this.displayStartMinutes.Text = "00";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(299, 107);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(10, 13);
            this.label66.TabIndex = 20;
            this.label66.Text = ":";
            // 
            // displayStartSeconds
            // 
            this.displayStartSeconds.AutoSize = true;
            this.displayStartSeconds.Location = new System.Drawing.Point(306, 107);
            this.displayStartSeconds.Name = "displayStartSeconds";
            this.displayStartSeconds.Size = new System.Drawing.Size(19, 13);
            this.displayStartSeconds.TabIndex = 21;
            this.displayStartSeconds.Text = "00";
            // 
            // displayEndSeconds
            // 
            this.displayEndSeconds.AutoSize = true;
            this.displayEndSeconds.Location = new System.Drawing.Point(306, 126);
            this.displayEndSeconds.Name = "displayEndSeconds";
            this.displayEndSeconds.Size = new System.Drawing.Size(19, 13);
            this.displayEndSeconds.TabIndex = 24;
            this.displayEndSeconds.Text = "00";
            // 
            // displayEndMinutes
            // 
            this.displayEndMinutes.AutoSize = true;
            this.displayEndMinutes.Location = new System.Drawing.Point(284, 126);
            this.displayEndMinutes.Name = "displayEndMinutes";
            this.displayEndMinutes.Size = new System.Drawing.Size(19, 13);
            this.displayEndMinutes.TabIndex = 23;
            this.displayEndMinutes.Text = "00";
            // 
            // displayEndHour
            // 
            this.displayEndHour.AutoSize = true;
            this.displayEndHour.Location = new System.Drawing.Point(262, 126);
            this.displayEndHour.Name = "displayEndHour";
            this.displayEndHour.Size = new System.Drawing.Size(19, 13);
            this.displayEndHour.TabIndex = 22;
            this.displayEndHour.Text = "00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(299, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = ":";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(277, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = ":";
            // 
            // lblOptionalTag
            // 
            this.lblOptionalTag.AutoSize = true;
            this.lblOptionalTag.Location = new System.Drawing.Point(16, 158);
            this.lblOptionalTag.Name = "lblOptionalTag";
            this.lblOptionalTag.Size = new System.Drawing.Size(117, 13);
            this.lblOptionalTag.TabIndex = 27;
            this.lblOptionalTag.Text = "tag output file (optional)";
            // 
            // txtOptionalTag
            // 
            this.txtOptionalTag.Location = new System.Drawing.Point(139, 155);
            this.txtOptionalTag.Name = "txtOptionalTag";
            this.txtOptionalTag.Size = new System.Drawing.Size(100, 20);
            this.txtOptionalTag.TabIndex = 28;
            this.txtOptionalTag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOptionalTag_KeyPress);
            // 
            // podsnip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 255);
            this.Controls.Add(this.txtOptionalTag);
            this.Controls.Add(this.lblOptionalTag);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.displayEndSeconds);
            this.Controls.Add(this.displayEndMinutes);
            this.Controls.Add(this.displayEndHour);
            this.Controls.Add(this.displayStartSeconds);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.displayStartMinutes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.displayStartHour);
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
        private System.Windows.Forms.Label displayStartHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label displayStartMinutes;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label displayStartSeconds;
        private System.Windows.Forms.Label displayEndSeconds;
        private System.Windows.Forms.Label displayEndMinutes;
        private System.Windows.Forms.Label displayEndHour;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblOptionalTag;
        private System.Windows.Forms.TextBox txtOptionalTag;
    }
}


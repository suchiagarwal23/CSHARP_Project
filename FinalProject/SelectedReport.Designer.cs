namespace FinalProject
{
    partial class SelectedReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnshowreport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbarea4 = new System.Windows.Forms.ComboBox();
            this.cmbarea3 = new System.Windows.Forms.ComboBox();
            this.cmbarea2 = new System.Windows.Forms.ComboBox();
            this.cmbarea1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 112);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1021, 471);
            this.reportViewer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnshowreport);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbarea4);
            this.groupBox1.Controls.Add(this.cmbarea3);
            this.groupBox1.Controls.Add(this.cmbarea2);
            this.groupBox1.Controls.Add(this.cmbarea1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1021, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnshowreport
            // 
            this.btnshowreport.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnshowreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnshowreport.ForeColor = System.Drawing.SystemColors.Window;
            this.btnshowreport.Location = new System.Drawing.Point(811, 26);
            this.btnshowreport.Name = "btnshowreport";
            this.btnshowreport.Size = new System.Drawing.Size(194, 59);
            this.btnshowreport.TabIndex = 2;
            this.btnshowreport.Text = "SHOW REPORT";
            this.btnshowreport.UseVisualStyleBackColor = false;
            this.btnshowreport.Click += new System.EventHandler(this.btnshowreport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(667, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "AREA 4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(470, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "AREA 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(260, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "AREA 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(60, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "AREA 1";
            // 
            // cmbarea4
            // 
            this.cmbarea4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbarea4.FormattingEnabled = true;
            this.cmbarea4.Location = new System.Drawing.Point(614, 57);
            this.cmbarea4.Name = "cmbarea4";
            this.cmbarea4.Size = new System.Drawing.Size(180, 28);
            this.cmbarea4.TabIndex = 3;
            // 
            // cmbarea3
            // 
            this.cmbarea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbarea3.FormattingEnabled = true;
            this.cmbarea3.Location = new System.Drawing.Point(416, 57);
            this.cmbarea3.Name = "cmbarea3";
            this.cmbarea3.Size = new System.Drawing.Size(176, 28);
            this.cmbarea3.TabIndex = 2;
            // 
            // cmbarea2
            // 
            this.cmbarea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbarea2.FormattingEnabled = true;
            this.cmbarea2.Location = new System.Drawing.Point(219, 57);
            this.cmbarea2.Name = "cmbarea2";
            this.cmbarea2.Size = new System.Drawing.Size(174, 28);
            this.cmbarea2.TabIndex = 1;
            // 
            // cmbarea1
            // 
            this.cmbarea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbarea1.FormattingEnabled = true;
            this.cmbarea1.Location = new System.Drawing.Point(6, 57);
            this.cmbarea1.Name = "cmbarea1";
            this.cmbarea1.Size = new System.Drawing.Size(189, 28);
            this.cmbarea1.TabIndex = 0;
            // 
            // SelectedReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1045, 595);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SelectedReport";
            this.Text = "SELECTIVE REPORT";
                   this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbarea4;
        private System.Windows.Forms.ComboBox cmbarea3;
        private System.Windows.Forms.ComboBox cmbarea2;
        private System.Windows.Forms.ComboBox cmbarea1;
        private System.Windows.Forms.Button btnshowreport;
    }
}
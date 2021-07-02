namespace Stereo_Vision
{
    partial class Export_files_form
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Abort = new System.Windows.Forms.Button();
            this.L_CurrentProgress = new System.Windows.Forms.Label();
            this.ProgB_Export = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Timer_for_Closing = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.B_Abort, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.L_CurrentProgress, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProgB_Export, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 85);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // B_Abort
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.B_Abort, 4);
            this.B_Abort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Abort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Abort.ForeColor = System.Drawing.Color.White;
            this.B_Abort.Location = new System.Drawing.Point(1, 43);
            this.B_Abort.Margin = new System.Windows.Forms.Padding(1);
            this.B_Abort.Name = "B_Abort";
            this.B_Abort.Size = new System.Drawing.Size(438, 41);
            this.B_Abort.TabIndex = 1;
            this.B_Abort.Text = "Прервать";
            this.B_Abort.UseVisualStyleBackColor = true;
            this.B_Abort.Click += new System.EventHandler(this.B_Abort_Click);
            // 
            // L_CurrentProgress
            // 
            this.L_CurrentProgress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L_CurrentProgress.AutoSize = true;
            this.L_CurrentProgress.BackColor = System.Drawing.Color.Black;
            this.L_CurrentProgress.ForeColor = System.Drawing.Color.White;
            this.L_CurrentProgress.Location = new System.Drawing.Point(374, 14);
            this.L_CurrentProgress.Name = "L_CurrentProgress";
            this.L_CurrentProgress.Size = new System.Drawing.Size(21, 13);
            this.L_CurrentProgress.TabIndex = 1;
            this.L_CurrentProgress.Text = "0%";
            // 
            // ProgB_Export
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ProgB_Export, 3);
            this.ProgB_Export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgB_Export.Location = new System.Drawing.Point(3, 3);
            this.ProgB_Export.Name = "ProgB_Export";
            this.ProgB_Export.Size = new System.Drawing.Size(324, 36);
            this.ProgB_Export.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Timer_for_Closing
            // 
            this.Timer_for_Closing.Tick += new System.EventHandler(this.Timer_for_Closing_Tick);
            // 
            // Export_files_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(440, 85);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Export_files_form";
            this.Text = "Экспорт...";
            this.Load += new System.EventHandler(this.Export_files_form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button B_Abort;
        private System.Windows.Forms.Label L_CurrentProgress;
        private System.Windows.Forms.ProgressBar ProgB_Export;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer Timer_for_Closing;
    }
}
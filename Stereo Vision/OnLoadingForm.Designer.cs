namespace Stereo_Vision
{
    partial class OnLoadingForm
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
            this.TLP_LoadMain = new System.Windows.Forms.TableLayoutPanel();
            this.PB_LoadingPicture = new System.Windows.Forms.PictureBox();
            this.BGW_onLoadWindowInit = new System.ComponentModel.BackgroundWorker();
            this.PrB_LoadingProgress = new System.Windows.Forms.ProgressBar();
            this.L_LoadingProgress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.L_DevInfo = new System.Windows.Forms.Label();
            this.TLP_LoadMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LoadingPicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_LoadMain
            // 
            this.TLP_LoadMain.ColumnCount = 1;
            this.TLP_LoadMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_LoadMain.Controls.Add(this.PrB_LoadingProgress, 0, 1);
            this.TLP_LoadMain.Controls.Add(this.L_LoadingProgress, 0, 2);
            this.TLP_LoadMain.Controls.Add(this.panel1, 0, 0);
            this.TLP_LoadMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_LoadMain.Location = new System.Drawing.Point(0, 0);
            this.TLP_LoadMain.Name = "TLP_LoadMain";
            this.TLP_LoadMain.RowCount = 3;
            this.TLP_LoadMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_LoadMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TLP_LoadMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_LoadMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_LoadMain.Size = new System.Drawing.Size(554, 415);
            this.TLP_LoadMain.TabIndex = 0;
            // 
            // PB_LoadingPicture
            // 
            this.PB_LoadingPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_LoadingPicture.Location = new System.Drawing.Point(0, 0);
            this.PB_LoadingPicture.Name = "PB_LoadingPicture";
            this.PB_LoadingPicture.Size = new System.Drawing.Size(554, 345);
            this.PB_LoadingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_LoadingPicture.TabIndex = 0;
            this.PB_LoadingPicture.TabStop = false;
            // 
            // BGW_onLoadWindowInit
            // 
            this.BGW_onLoadWindowInit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_onLoadWindowInit_DoWork);
            // 
            // PrB_LoadingProgress
            // 
            this.PrB_LoadingProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrB_LoadingProgress.Location = new System.Drawing.Point(3, 348);
            this.PrB_LoadingProgress.Name = "PrB_LoadingProgress";
            this.PrB_LoadingProgress.Size = new System.Drawing.Size(548, 44);
            this.PrB_LoadingProgress.TabIndex = 1;
            // 
            // L_LoadingProgress
            // 
            this.L_LoadingProgress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.L_LoadingProgress.AutoSize = true;
            this.L_LoadingProgress.Location = new System.Drawing.Point(3, 398);
            this.L_LoadingProgress.Name = "L_LoadingProgress";
            this.L_LoadingProgress.Size = new System.Drawing.Size(63, 13);
            this.L_LoadingProgress.TabIndex = 2;
            this.L_LoadingProgress.Text = "Загрузка...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.L_DevInfo);
            this.panel1.Controls.Add(this.PB_LoadingPicture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 345);
            this.panel1.TabIndex = 3;
            // 
            // L_DevInfo
            // 
            this.L_DevInfo.AutoSize = true;
            this.L_DevInfo.BackColor = System.Drawing.Color.Transparent;
            this.L_DevInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.L_DevInfo.Location = new System.Drawing.Point(445, 273);
            this.L_DevInfo.Name = "L_DevInfo";
            this.L_DevInfo.Size = new System.Drawing.Size(25, 13);
            this.L_DevInfo.TabIndex = 1;
            this.L_DevInfo.Text = "Info";
            // 
            // OnLoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(554, 415);
            this.Controls.Add(this.TLP_LoadMain);
            this.Name = "OnLoadingForm";
            this.Text = "OnLoadingForm";
            this.Load += new System.EventHandler(this.OnLoadingForm_Load);
            this.TLP_LoadMain.ResumeLayout(false);
            this.TLP_LoadMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LoadingPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_LoadMain;
        private System.Windows.Forms.PictureBox PB_LoadingPicture;
        private System.ComponentModel.BackgroundWorker BGW_onLoadWindowInit;
        private System.Windows.Forms.ProgressBar PrB_LoadingProgress;
        private System.Windows.Forms.Label L_LoadingProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label L_DevInfo;
    }
}
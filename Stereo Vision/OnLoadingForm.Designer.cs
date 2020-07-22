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
            this.TLP_LoadMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LoadingPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP_LoadMain
            // 
            this.TLP_LoadMain.ColumnCount = 1;
            this.TLP_LoadMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_LoadMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_LoadMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_LoadMain.Controls.Add(this.PB_LoadingPicture, 0, 0);
            this.TLP_LoadMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_LoadMain.Location = new System.Drawing.Point(0, 0);
            this.TLP_LoadMain.Name = "TLP_LoadMain";
            this.TLP_LoadMain.RowCount = 4;
            this.TLP_LoadMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLP_LoadMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_LoadMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_LoadMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_LoadMain.Size = new System.Drawing.Size(622, 488);
            this.TLP_LoadMain.TabIndex = 0;
            // 
            // PB_LoadingPicture
            // 
            this.PB_LoadingPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_LoadingPicture.Location = new System.Drawing.Point(3, 3);
            this.PB_LoadingPicture.Name = "PB_LoadingPicture";
            this.PB_LoadingPicture.Size = new System.Drawing.Size(616, 352);
            this.PB_LoadingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_LoadingPicture.TabIndex = 0;
            this.PB_LoadingPicture.TabStop = false;
            // 
            // BGW_onLoadWindowInit
            // 
            this.BGW_onLoadWindowInit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_onLoadWindowInit_DoWork);
            // 
            // OnLoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 488);
            this.Controls.Add(this.TLP_LoadMain);
            this.Name = "OnLoadingForm";
            this.Text = "OnLoadingForm";
            this.Load += new System.EventHandler(this.OnLoadingForm_Load);
            this.TLP_LoadMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_LoadingPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_LoadMain;
        private System.Windows.Forms.PictureBox PB_LoadingPicture;
        private System.ComponentModel.BackgroundWorker BGW_onLoadWindowInit;
    }
}
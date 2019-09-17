
namespace Stereo_Vision
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.TLP_MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Pan_BackgroundPanel = new System.Windows.Forms.Panel();
            this.Pan_UserMain = new System.Windows.Forms.Panel();
            this.TLP_UserMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.B_Browse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.B_Photo_or_PauseRec = new System.Windows.Forms.Button();
            this.B_SwitchRec = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Quit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.B_Settings = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Pan_Export = new System.Windows.Forms.Panel();
            this.TBL_ExportTable = new System.Windows.Forms.TableLayoutPanel();
            this.B_Ex_BackToMain = new System.Windows.Forms.Button();
            this.B_Ex_MinusCount = new System.Windows.Forms.Button();
            this.B_Ex_StartExport = new System.Windows.Forms.Button();
            this.B_Ex_PhotoMode = new System.Windows.Forms.Button();
            this.TB_Ex_PathTo = new System.Windows.Forms.TextBox();
            this.B_Ex_VideoMode = new System.Windows.Forms.Button();
            this.L_Ex_Mode = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_Ex_PathFrom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CB_Ex_ChooseExportMode = new System.Windows.Forms.ComboBox();
            this.B_Ex_Search_PathFrom = new System.Windows.Forms.Button();
            this.B_Ex_Search_PathTo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.B_Ex_PlusCount = new System.Windows.Forms.Button();
            this.TB_Ex_Count = new System.Windows.Forms.TextBox();
            this.Pan_Settings = new System.Windows.Forms.Panel();
            this.TLP_Settings = new System.Windows.Forms.TableLayoutPanel();
            this.B_BackBut = new System.Windows.Forms.Button();
            this.TABC_Settings = new System.Windows.Forms.TabControl();
            this.TPAGE_VidSettings = new System.Windows.Forms.TabPage();
            this.TLP_Settings_Vid = new System.Windows.Forms.TableLayoutPanel();
            this.TB_Settings_VidSavePath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.B_Settings_FindVidPath = new System.Windows.Forms.Button();
            this.TPAGE_PhotoSettings = new System.Windows.Forms.TabPage();
            this.TLP_Settings_Photo = new System.Windows.Forms.TableLayoutPanel();
            this.TB_Settings_PhotoSavePath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.B_Settings_FindPhotoPath = new System.Windows.Forms.Button();
            this.TPAGE_CameraSettings = new System.Windows.Forms.TabPage();
            this.TLP_Settings_Camera = new System.Windows.Forms.TableLayoutPanel();
            this.TrBContrast = new System.Windows.Forms.TrackBar();
            this.L_Settings_l1 = new System.Windows.Forms.Label();
            this.TrBBrightness = new System.Windows.Forms.TrackBar();
            this.LBrigthnessValue = new System.Windows.Forms.Label();
            this.LContrastValue = new System.Windows.Forms.Label();
            this.L_Settings_l2 = new System.Windows.Forms.Label();
            this.LSaturationValue = new System.Windows.Forms.Label();
            this.TrBSaturation = new System.Windows.Forms.TrackBar();
            this.L_Settings_l3 = new System.Windows.Forms.Label();
            this.L_Settings_l4 = new System.Windows.Forms.Label();
            this.L_Settings_l5 = new System.Windows.Forms.Label();
            this.TrBGamma = new System.Windows.Forms.TrackBar();
            this.TrBGain = new System.Windows.Forms.TrackBar();
            this.LGammaValue = new System.Windows.Forms.Label();
            this.LGainValue = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.Pan_Video = new System.Windows.Forms.Panel();
            this.P_ChargeLev = new System.Windows.Forms.Panel();
            this.TLP_ChargeLev = new System.Windows.Forms.TableLayoutPanel();
            this.PB_ChargeVal = new System.Windows.Forms.PictureBox();
            this.L_ChargeLev = new System.Windows.Forms.Label();
            this.PB_Indicator = new System.Windows.Forms.PictureBox();
            this.LBConsole = new System.Windows.Forms.ListBox();
            this.CV_ImBox_Capture = new Emgu.CV.UI.ImageBox();
            this.BGWR_ChargeLev = new System.ComponentModel.BackgroundWorker();
            this.TLP_MainPanel.SuspendLayout();
            this.Pan_BackgroundPanel.SuspendLayout();
            this.Pan_UserMain.SuspendLayout();
            this.TLP_UserMainPanel.SuspendLayout();
            this.Pan_Export.SuspendLayout();
            this.TBL_ExportTable.SuspendLayout();
            this.Pan_Settings.SuspendLayout();
            this.TLP_Settings.SuspendLayout();
            this.TABC_Settings.SuspendLayout();
            this.TPAGE_VidSettings.SuspendLayout();
            this.TLP_Settings_Vid.SuspendLayout();
            this.TPAGE_PhotoSettings.SuspendLayout();
            this.TLP_Settings_Photo.SuspendLayout();
            this.TPAGE_CameraSettings.SuspendLayout();
            this.TLP_Settings_Camera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrBContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBGain)).BeginInit();
            this.Pan_Video.SuspendLayout();
            this.P_ChargeLev.SuspendLayout();
            this.TLP_ChargeLev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ChargeVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Indicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CV_ImBox_Capture)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP_MainPanel
            // 
            this.TLP_MainPanel.ColumnCount = 1;
            this.TLP_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_MainPanel.Controls.Add(this.Pan_BackgroundPanel, 0, 0);
            this.TLP_MainPanel.Controls.Add(this.Pan_Video, 0, 1);
            this.TLP_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_MainPanel.Location = new System.Drawing.Point(0, 0);
            this.TLP_MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_MainPanel.Name = "TLP_MainPanel";
            this.TLP_MainPanel.RowCount = 2;
            this.TLP_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.TLP_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_MainPanel.Size = new System.Drawing.Size(986, 506);
            this.TLP_MainPanel.TabIndex = 1;
            // 
            // Pan_BackgroundPanel
            // 
            this.Pan_BackgroundPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Pan_BackgroundPanel.Controls.Add(this.Pan_UserMain);
            this.Pan_BackgroundPanel.Controls.Add(this.Pan_Export);
            this.Pan_BackgroundPanel.Controls.Add(this.Pan_Settings);
            this.Pan_BackgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_BackgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.Pan_BackgroundPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Pan_BackgroundPanel.Name = "Pan_BackgroundPanel";
            this.Pan_BackgroundPanel.Size = new System.Drawing.Size(986, 118);
            this.Pan_BackgroundPanel.TabIndex = 5;
            // 
            // Pan_UserMain
            // 
            this.Pan_UserMain.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Pan_UserMain.Controls.Add(this.TLP_UserMainPanel);
            this.Pan_UserMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_UserMain.Location = new System.Drawing.Point(0, 0);
            this.Pan_UserMain.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_UserMain.Name = "Pan_UserMain";
            this.Pan_UserMain.Size = new System.Drawing.Size(986, 118);
            this.Pan_UserMain.TabIndex = 4;
            // 
            // TLP_UserMainPanel
            // 
            this.TLP_UserMainPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TLP_UserMainPanel.ColumnCount = 5;
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_UserMainPanel.Controls.Add(this.label5, 2, 1);
            this.TLP_UserMainPanel.Controls.Add(this.B_Browse, 2, 0);
            this.TLP_UserMainPanel.Controls.Add(this.label2, 1, 1);
            this.TLP_UserMainPanel.Controls.Add(this.B_Photo_or_PauseRec, 1, 0);
            this.TLP_UserMainPanel.Controls.Add(this.B_SwitchRec, 0, 0);
            this.TLP_UserMainPanel.Controls.Add(this.label1, 0, 1);
            this.TLP_UserMainPanel.Controls.Add(this.B_Quit, 4, 0);
            this.TLP_UserMainPanel.Controls.Add(this.label4, 4, 1);
            this.TLP_UserMainPanel.Controls.Add(this.B_Settings, 3, 0);
            this.TLP_UserMainPanel.Controls.Add(this.label3, 3, 1);
            this.TLP_UserMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_UserMainPanel.Location = new System.Drawing.Point(0, 0);
            this.TLP_UserMainPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.TLP_UserMainPanel.Name = "TLP_UserMainPanel";
            this.TLP_UserMainPanel.RowCount = 2;
            this.TLP_UserMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLP_UserMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_UserMainPanel.Size = new System.Drawing.Size(986, 118);
            this.TLP_UserMainPanel.TabIndex = 2;
            this.TLP_UserMainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TLP_UserMainPanel_MouseMove);
            this.TLP_UserMainPanel.Resize += new System.EventHandler(this.TLP_UserMainPanel_Resize);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(452, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Экспорт";
            // 
            // B_Browse
            // 
            this.B_Browse.BackColor = System.Drawing.Color.Black;
            this.B_Browse.BackgroundImage = global::Stereo_Vision.Properties.Resources.bro;
            this.B_Browse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Browse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Browse.Location = new System.Drawing.Point(397, 3);
            this.B_Browse.Name = "B_Browse";
            this.B_Browse.Size = new System.Drawing.Size(191, 88);
            this.B_Browse.TabIndex = 10;
            this.B_Browse.UseVisualStyleBackColor = false;
            this.B_Browse.Click += new System.EventHandler(this.B_Browse_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(259, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Снимок";
            // 
            // B_Photo_or_PauseRec
            // 
            this.B_Photo_or_PauseRec.BackColor = System.Drawing.Color.Black;
            this.B_Photo_or_PauseRec.BackgroundImage = global::Stereo_Vision.Properties.Resources.pho;
            this.B_Photo_or_PauseRec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Photo_or_PauseRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Photo_or_PauseRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Photo_or_PauseRec.Location = new System.Drawing.Point(200, 3);
            this.B_Photo_or_PauseRec.Name = "B_Photo_or_PauseRec";
            this.B_Photo_or_PauseRec.Size = new System.Drawing.Size(191, 88);
            this.B_Photo_or_PauseRec.TabIndex = 1;
            this.B_Photo_or_PauseRec.UseVisualStyleBackColor = false;
            this.B_Photo_or_PauseRec.Click += new System.EventHandler(this.B_Photo_or_PauseRec_Click);
            this.B_Photo_or_PauseRec.MouseMove += new System.Windows.Forms.MouseEventHandler(this.B_Photo_or_PauseRec_MouseMove);
            // 
            // B_SwitchRec
            // 
            this.B_SwitchRec.BackColor = System.Drawing.Color.Black;
            this.B_SwitchRec.BackgroundImage = global::Stereo_Vision.Properties.Resources.rec;
            this.B_SwitchRec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_SwitchRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_SwitchRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_SwitchRec.Location = new System.Drawing.Point(3, 3);
            this.B_SwitchRec.Name = "B_SwitchRec";
            this.B_SwitchRec.Size = new System.Drawing.Size(191, 88);
            this.B_SwitchRec.TabIndex = 0;
            this.B_SwitchRec.UseVisualStyleBackColor = false;
            this.B_SwitchRec.Click += new System.EventHandler(this.B_SwitchRec_Click);
            this.B_SwitchRec.MouseMove += new System.Windows.Forms.MouseEventHandler(this.B_SwitchRec_MouseMove);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(63, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Запись";
            // 
            // B_Quit
            // 
            this.B_Quit.BackColor = System.Drawing.Color.Black;
            this.B_Quit.BackgroundImage = global::Stereo_Vision.Properties.Resources.off;
            this.B_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Quit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Quit.Location = new System.Drawing.Point(791, 3);
            this.B_Quit.Name = "B_Quit";
            this.B_Quit.Size = new System.Drawing.Size(192, 88);
            this.B_Quit.TabIndex = 9;
            this.B_Quit.UseVisualStyleBackColor = false;
            this.B_Quit.Click += new System.EventHandler(this.B_Quit_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(829, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Выключение";
            // 
            // B_Settings
            // 
            this.B_Settings.BackColor = System.Drawing.Color.Black;
            this.B_Settings.BackgroundImage = global::Stereo_Vision.Properties.Resources.set;
            this.B_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Settings.Location = new System.Drawing.Point(594, 3);
            this.B_Settings.Name = "B_Settings";
            this.B_Settings.Size = new System.Drawing.Size(191, 88);
            this.B_Settings.TabIndex = 2;
            this.B_Settings.UseVisualStyleBackColor = false;
            this.B_Settings.Click += new System.EventHandler(this.B_Settings_Click);
            this.B_Settings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.B_Settings_MouseMove);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(639, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Настройки";
            // 
            // Pan_Export
            // 
            this.Pan_Export.BackColor = System.Drawing.Color.Black;
            this.Pan_Export.Controls.Add(this.TBL_ExportTable);
            this.Pan_Export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_Export.Location = new System.Drawing.Point(0, 0);
            this.Pan_Export.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_Export.Name = "Pan_Export";
            this.Pan_Export.Size = new System.Drawing.Size(986, 118);
            this.Pan_Export.TabIndex = 6;
            // 
            // TBL_ExportTable
            // 
            this.TBL_ExportTable.ColumnCount = 7;
            this.TBL_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TBL_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TBL_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.TBL_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TBL_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TBL_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TBL_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TBL_ExportTable.Controls.Add(this.B_Ex_BackToMain, 6, 4);
            this.TBL_ExportTable.Controls.Add(this.B_Ex_MinusCount, 4, 6);
            this.TBL_ExportTable.Controls.Add(this.B_Ex_StartExport, 6, 0);
            this.TBL_ExportTable.Controls.Add(this.B_Ex_PhotoMode, 0, 4);
            this.TBL_ExportTable.Controls.Add(this.TB_Ex_PathTo, 2, 4);
            this.TBL_ExportTable.Controls.Add(this.B_Ex_VideoMode, 0, 0);
            this.TBL_ExportTable.Controls.Add(this.L_Ex_Mode, 2, 0);
            this.TBL_ExportTable.Controls.Add(this.label8, 1, 4);
            this.TBL_ExportTable.Controls.Add(this.TB_Ex_PathFrom, 2, 2);
            this.TBL_ExportTable.Controls.Add(this.label9, 1, 6);
            this.TBL_ExportTable.Controls.Add(this.CB_Ex_ChooseExportMode, 2, 6);
            this.TBL_ExportTable.Controls.Add(this.B_Ex_Search_PathFrom, 3, 2);
            this.TBL_ExportTable.Controls.Add(this.B_Ex_Search_PathTo, 3, 4);
            this.TBL_ExportTable.Controls.Add(this.label7, 1, 2);
            this.TBL_ExportTable.Controls.Add(this.B_Ex_PlusCount, 5, 6);
            this.TBL_ExportTable.Controls.Add(this.TB_Ex_Count, 3, 6);
            this.TBL_ExportTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBL_ExportTable.Location = new System.Drawing.Point(0, 0);
            this.TBL_ExportTable.Margin = new System.Windows.Forms.Padding(0);
            this.TBL_ExportTable.Name = "TBL_ExportTable";
            this.TBL_ExportTable.RowCount = 8;
            this.TBL_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TBL_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TBL_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TBL_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TBL_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TBL_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TBL_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TBL_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TBL_ExportTable.Size = new System.Drawing.Size(986, 118);
            this.TBL_ExportTable.TabIndex = 0;
            // 
            // B_Ex_BackToMain
            // 
            this.B_Ex_BackToMain.BackColor = System.Drawing.Color.Black;
            this.B_Ex_BackToMain.BackgroundImage = global::Stereo_Vision.Properties.Resources.back;
            this.B_Ex_BackToMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Ex_BackToMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_BackToMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_BackToMain.ForeColor = System.Drawing.Color.Black;
            this.B_Ex_BackToMain.Location = new System.Drawing.Point(860, 56);
            this.B_Ex_BackToMain.Margin = new System.Windows.Forms.Padding(0);
            this.B_Ex_BackToMain.Name = "B_Ex_BackToMain";
            this.TBL_ExportTable.SetRowSpan(this.B_Ex_BackToMain, 4);
            this.B_Ex_BackToMain.Size = new System.Drawing.Size(126, 62);
            this.B_Ex_BackToMain.TabIndex = 8;
            this.B_Ex_BackToMain.UseVisualStyleBackColor = false;
            this.B_Ex_BackToMain.Click += new System.EventHandler(this.TBL_ExportPanel_Click);
            // 
            // B_Ex_MinusCount
            // 
            this.B_Ex_MinusCount.BackColor = System.Drawing.Color.Black;
            this.B_Ex_MinusCount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Ex_MinusCount.BackgroundImage")));
            this.B_Ex_MinusCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Ex_MinusCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_MinusCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_MinusCount.ForeColor = System.Drawing.Color.White;
            this.B_Ex_MinusCount.Location = new System.Drawing.Point(779, 85);
            this.B_Ex_MinusCount.Margin = new System.Windows.Forms.Padding(1, 1, 1, 4);
            this.B_Ex_MinusCount.Name = "B_Ex_MinusCount";
            this.TBL_ExportTable.SetRowSpan(this.B_Ex_MinusCount, 2);
            this.B_Ex_MinusCount.Size = new System.Drawing.Size(39, 29);
            this.B_Ex_MinusCount.TabIndex = 7;
            this.B_Ex_MinusCount.UseVisualStyleBackColor = false;
            this.B_Ex_MinusCount.Click += new System.EventHandler(this.B_Ex_MinusCount_Click);
            // 
            // B_Ex_StartExport
            // 
            this.B_Ex_StartExport.BackColor = System.Drawing.Color.Black;
            this.B_Ex_StartExport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Ex_StartExport.BackgroundImage")));
            this.B_Ex_StartExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Ex_StartExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_StartExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_StartExport.ForeColor = System.Drawing.Color.Black;
            this.B_Ex_StartExport.Location = new System.Drawing.Point(860, 0);
            this.B_Ex_StartExport.Margin = new System.Windows.Forms.Padding(0);
            this.B_Ex_StartExport.Name = "B_Ex_StartExport";
            this.TBL_ExportTable.SetRowSpan(this.B_Ex_StartExport, 4);
            this.B_Ex_StartExport.Size = new System.Drawing.Size(126, 56);
            this.B_Ex_StartExport.TabIndex = 7;
            this.B_Ex_StartExport.UseVisualStyleBackColor = false;
            this.B_Ex_StartExport.Click += new System.EventHandler(this.B_Ex_StartExport_Click);
            // 
            // B_Ex_PhotoMode
            // 
            this.B_Ex_PhotoMode.BackColor = System.Drawing.Color.Black;
            this.B_Ex_PhotoMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Ex_PhotoMode.BackgroundImage")));
            this.B_Ex_PhotoMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Ex_PhotoMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_PhotoMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_PhotoMode.ForeColor = System.Drawing.Color.Black;
            this.B_Ex_PhotoMode.Location = new System.Drawing.Point(0, 56);
            this.B_Ex_PhotoMode.Margin = new System.Windows.Forms.Padding(0);
            this.B_Ex_PhotoMode.Name = "B_Ex_PhotoMode";
            this.TBL_ExportTable.SetRowSpan(this.B_Ex_PhotoMode, 4);
            this.B_Ex_PhotoMode.Size = new System.Drawing.Size(123, 62);
            this.B_Ex_PhotoMode.TabIndex = 7;
            this.B_Ex_PhotoMode.UseVisualStyleBackColor = false;
            this.B_Ex_PhotoMode.Click += new System.EventHandler(this.B_Ex_PhotoMode_Click);
            // 
            // TB_Ex_PathTo
            // 
            this.TB_Ex_PathTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Ex_PathTo.BackColor = System.Drawing.Color.Black;
            this.TB_Ex_PathTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Ex_PathTo.ForeColor = System.Drawing.Color.White;
            this.TB_Ex_PathTo.Location = new System.Drawing.Point(283, 57);
            this.TB_Ex_PathTo.Margin = new System.Windows.Forms.Padding(0);
            this.TB_Ex_PathTo.Name = "TB_Ex_PathTo";
            this.TBL_ExportTable.SetRowSpan(this.TB_Ex_PathTo, 2);
            this.TB_Ex_PathTo.Size = new System.Drawing.Size(454, 26);
            this.TB_Ex_PathTo.TabIndex = 13;
            // 
            // B_Ex_VideoMode
            // 
            this.B_Ex_VideoMode.BackColor = System.Drawing.Color.Black;
            this.B_Ex_VideoMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Ex_VideoMode.BackgroundImage")));
            this.B_Ex_VideoMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Ex_VideoMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_VideoMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_VideoMode.ForeColor = System.Drawing.Color.Black;
            this.B_Ex_VideoMode.Location = new System.Drawing.Point(0, 0);
            this.B_Ex_VideoMode.Margin = new System.Windows.Forms.Padding(0);
            this.B_Ex_VideoMode.Name = "B_Ex_VideoMode";
            this.TBL_ExportTable.SetRowSpan(this.B_Ex_VideoMode, 4);
            this.B_Ex_VideoMode.Size = new System.Drawing.Size(123, 56);
            this.B_Ex_VideoMode.TabIndex = 9;
            this.B_Ex_VideoMode.UseVisualStyleBackColor = false;
            this.B_Ex_VideoMode.Click += new System.EventHandler(this.B_Ex_VideoMode_Click);
            // 
            // L_Ex_Mode
            // 
            this.L_Ex_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Ex_Mode.AutoSize = true;
            this.L_Ex_Mode.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.L_Ex_Mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Ex_Mode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.L_Ex_Mode.Location = new System.Drawing.Point(286, 4);
            this.L_Ex_Mode.Name = "L_Ex_Mode";
            this.TBL_ExportTable.SetRowSpan(this.L_Ex_Mode, 2);
            this.L_Ex_Mode.Size = new System.Drawing.Size(448, 20);
            this.L_Ex_Mode.TabIndex = 7;
            this.L_Ex_Mode.Text = "Экспорт видео";
            this.L_Ex_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L_Ex_Mode.Click += new System.EventHandler(this.L_Ex_Mode_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(161, 60);
            this.label8.Name = "label8";
            this.TBL_ExportTable.SetRowSpan(this.label8, 2);
            this.label8.Size = new System.Drawing.Size(119, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Сохранить в:";
            // 
            // TB_Ex_PathFrom
            // 
            this.TB_Ex_PathFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Ex_PathFrom.BackColor = System.Drawing.Color.Black;
            this.TB_Ex_PathFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Ex_PathFrom.ForeColor = System.Drawing.Color.White;
            this.TB_Ex_PathFrom.Location = new System.Drawing.Point(283, 29);
            this.TB_Ex_PathFrom.Margin = new System.Windows.Forms.Padding(0);
            this.TB_Ex_PathFrom.Name = "TB_Ex_PathFrom";
            this.TBL_ExportTable.SetRowSpan(this.TB_Ex_PathFrom, 2);
            this.TB_Ex_PathFrom.Size = new System.Drawing.Size(454, 26);
            this.TB_Ex_PathFrom.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(207, 91);
            this.label9.Name = "label9";
            this.TBL_ExportTable.SetRowSpan(this.label9, 2);
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Файлы:";
            // 
            // CB_Ex_ChooseExportMode
            // 
            this.CB_Ex_ChooseExportMode.BackColor = System.Drawing.Color.Black;
            this.CB_Ex_ChooseExportMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_Ex_ChooseExportMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Ex_ChooseExportMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CB_Ex_ChooseExportMode.ForeColor = System.Drawing.Color.White;
            this.CB_Ex_ChooseExportMode.FormattingEnabled = true;
            this.CB_Ex_ChooseExportMode.Items.AddRange(new object[] {
            "С момента последнего включения",
            "За время (укажите время в часах)",
            "Последние несколько (укажите количество)",
            "Все"});
            this.CB_Ex_ChooseExportMode.Location = new System.Drawing.Point(283, 86);
            this.CB_Ex_ChooseExportMode.Margin = new System.Windows.Forms.Padding(0, 2, 1, 0);
            this.CB_Ex_ChooseExportMode.Name = "CB_Ex_ChooseExportMode";
            this.TBL_ExportTable.SetRowSpan(this.CB_Ex_ChooseExportMode, 2);
            this.CB_Ex_ChooseExportMode.Size = new System.Drawing.Size(453, 28);
            this.CB_Ex_ChooseExportMode.TabIndex = 15;
            this.CB_Ex_ChooseExportMode.SelectedIndexChanged += new System.EventHandler(this.CB_Ex_ChooseExportMode_SelectedIndexChanged);
            // 
            // B_Ex_Search_PathFrom
            // 
            this.B_Ex_Search_PathFrom.BackColor = System.Drawing.Color.Black;
            this.B_Ex_Search_PathFrom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TBL_ExportTable.SetColumnSpan(this.B_Ex_Search_PathFrom, 3);
            this.B_Ex_Search_PathFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_Search_PathFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_Search_PathFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Ex_Search_PathFrom.ForeColor = System.Drawing.Color.White;
            this.B_Ex_Search_PathFrom.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_Ex_Search_PathFrom.Location = new System.Drawing.Point(737, 29);
            this.B_Ex_Search_PathFrom.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.B_Ex_Search_PathFrom.Name = "B_Ex_Search_PathFrom";
            this.TBL_ExportTable.SetRowSpan(this.B_Ex_Search_PathFrom, 2);
            this.B_Ex_Search_PathFrom.Size = new System.Drawing.Size(122, 26);
            this.B_Ex_Search_PathFrom.TabIndex = 7;
            this.B_Ex_Search_PathFrom.Text = "Обзор...";
            this.B_Ex_Search_PathFrom.UseVisualStyleBackColor = false;
            this.B_Ex_Search_PathFrom.Click += new System.EventHandler(this.B_Ex_Search_PathFrom_Click);
            // 
            // B_Ex_Search_PathTo
            // 
            this.B_Ex_Search_PathTo.BackColor = System.Drawing.Color.Black;
            this.TBL_ExportTable.SetColumnSpan(this.B_Ex_Search_PathTo, 3);
            this.B_Ex_Search_PathTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_Search_PathTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_Search_PathTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Ex_Search_PathTo.ForeColor = System.Drawing.Color.White;
            this.B_Ex_Search_PathTo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_Ex_Search_PathTo.Location = new System.Drawing.Point(737, 57);
            this.B_Ex_Search_PathTo.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.B_Ex_Search_PathTo.Name = "B_Ex_Search_PathTo";
            this.TBL_ExportTable.SetRowSpan(this.B_Ex_Search_PathTo, 2);
            this.B_Ex_Search_PathTo.Size = new System.Drawing.Size(122, 26);
            this.B_Ex_Search_PathTo.TabIndex = 8;
            this.B_Ex_Search_PathTo.Text = "Обзор...";
            this.B_Ex_Search_PathTo.UseVisualStyleBackColor = false;
            this.B_Ex_Search_PathTo.Click += new System.EventHandler(this.B_Ex_Search_PathTo_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label7.Location = new System.Drawing.Point(131, 32);
            this.label7.Name = "label7";
            this.TBL_ExportTable.SetRowSpan(this.label7, 2);
            this.label7.Size = new System.Drawing.Size(149, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Скопировать из:";
            // 
            // B_Ex_PlusCount
            // 
            this.B_Ex_PlusCount.BackColor = System.Drawing.Color.Black;
            this.B_Ex_PlusCount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Ex_PlusCount.BackgroundImage")));
            this.B_Ex_PlusCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Ex_PlusCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_PlusCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_PlusCount.ForeColor = System.Drawing.Color.White;
            this.B_Ex_PlusCount.Location = new System.Drawing.Point(820, 85);
            this.B_Ex_PlusCount.Margin = new System.Windows.Forms.Padding(1, 1, 1, 4);
            this.B_Ex_PlusCount.Name = "B_Ex_PlusCount";
            this.TBL_ExportTable.SetRowSpan(this.B_Ex_PlusCount, 2);
            this.B_Ex_PlusCount.Size = new System.Drawing.Size(39, 29);
            this.B_Ex_PlusCount.TabIndex = 8;
            this.B_Ex_PlusCount.UseVisualStyleBackColor = false;
            this.B_Ex_PlusCount.Click += new System.EventHandler(this.B_Ex_PlusCount_Click);
            // 
            // TB_Ex_Count
            // 
            this.TB_Ex_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Ex_Count.BackColor = System.Drawing.Color.Black;
            this.TB_Ex_Count.Cursor = System.Windows.Forms.Cursors.Default;
            this.TB_Ex_Count.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Ex_Count.ForeColor = System.Drawing.Color.White;
            this.TB_Ex_Count.Location = new System.Drawing.Point(737, 85);
            this.TB_Ex_Count.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.TB_Ex_Count.Name = "TB_Ex_Count";
            this.TB_Ex_Count.ReadOnly = true;
            this.TBL_ExportTable.SetRowSpan(this.TB_Ex_Count, 2);
            this.TB_Ex_Count.Size = new System.Drawing.Size(41, 29);
            this.TB_Ex_Count.TabIndex = 14;
            this.TB_Ex_Count.Text = "1";
            this.TB_Ex_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Pan_Settings
            // 
            this.Pan_Settings.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Pan_Settings.Controls.Add(this.TLP_Settings);
            this.Pan_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_Settings.Location = new System.Drawing.Point(0, 0);
            this.Pan_Settings.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_Settings.Name = "Pan_Settings";
            this.Pan_Settings.Size = new System.Drawing.Size(986, 118);
            this.Pan_Settings.TabIndex = 3;
            // 
            // TLP_Settings
            // 
            this.TLP_Settings.ColumnCount = 2;
            this.TLP_Settings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLP_Settings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_Settings.Controls.Add(this.B_BackBut, 1, 0);
            this.TLP_Settings.Controls.Add(this.TABC_Settings, 0, 0);
            this.TLP_Settings.Controls.Add(this.label6, 1, 1);
            this.TLP_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Settings.Location = new System.Drawing.Point(0, 0);
            this.TLP_Settings.Name = "TLP_Settings";
            this.TLP_Settings.RowCount = 2;
            this.TLP_Settings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLP_Settings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_Settings.Size = new System.Drawing.Size(986, 118);
            this.TLP_Settings.TabIndex = 0;
            // 
            // B_BackBut
            // 
            this.B_BackBut.BackColor = System.Drawing.Color.Black;
            this.B_BackBut.BackgroundImage = global::Stereo_Vision.Properties.Resources.back;
            this.B_BackBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_BackBut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_BackBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_BackBut.Location = new System.Drawing.Point(791, 3);
            this.B_BackBut.Name = "B_BackBut";
            this.B_BackBut.Size = new System.Drawing.Size(192, 88);
            this.B_BackBut.TabIndex = 8;
            this.B_BackBut.UseVisualStyleBackColor = false;
            this.B_BackBut.Click += new System.EventHandler(this.B_BackBut_Click);
            // 
            // TABC_Settings
            // 
            this.TABC_Settings.Controls.Add(this.TPAGE_VidSettings);
            this.TABC_Settings.Controls.Add(this.TPAGE_PhotoSettings);
            this.TABC_Settings.Controls.Add(this.TPAGE_CameraSettings);
            this.TABC_Settings.Controls.Add(this.tabPage3);
            this.TABC_Settings.Controls.Add(this.tabPage5);
            this.TABC_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TABC_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TABC_Settings.Location = new System.Drawing.Point(0, 0);
            this.TABC_Settings.Margin = new System.Windows.Forms.Padding(0);
            this.TABC_Settings.Name = "TABC_Settings";
            this.TLP_Settings.SetRowSpan(this.TABC_Settings, 2);
            this.TABC_Settings.SelectedIndex = 0;
            this.TABC_Settings.Size = new System.Drawing.Size(788, 118);
            this.TABC_Settings.TabIndex = 0;
            // 
            // TPAGE_VidSettings
            // 
            this.TPAGE_VidSettings.BackColor = System.Drawing.Color.Black;
            this.TPAGE_VidSettings.Controls.Add(this.TLP_Settings_Vid);
            this.TPAGE_VidSettings.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TPAGE_VidSettings.Location = new System.Drawing.Point(4, 25);
            this.TPAGE_VidSettings.Margin = new System.Windows.Forms.Padding(0);
            this.TPAGE_VidSettings.Name = "TPAGE_VidSettings";
            this.TPAGE_VidSettings.Size = new System.Drawing.Size(780, 89);
            this.TPAGE_VidSettings.TabIndex = 0;
            this.TPAGE_VidSettings.Text = "Запись видео";
            // 
            // TLP_Settings_Vid
            // 
            this.TLP_Settings_Vid.BackColor = System.Drawing.Color.Black;
            this.TLP_Settings_Vid.ColumnCount = 3;
            this.TLP_Settings_Vid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TLP_Settings_Vid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Settings_Vid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Settings_Vid.Controls.Add(this.TB_Settings_VidSavePath, 1, 0);
            this.TLP_Settings_Vid.Controls.Add(this.label11, 0, 0);
            this.TLP_Settings_Vid.Controls.Add(this.B_Settings_FindVidPath, 2, 0);
            this.TLP_Settings_Vid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Settings_Vid.Location = new System.Drawing.Point(0, 0);
            this.TLP_Settings_Vid.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Settings_Vid.Name = "TLP_Settings_Vid";
            this.TLP_Settings_Vid.RowCount = 2;
            this.TLP_Settings_Vid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Settings_Vid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Settings_Vid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Settings_Vid.Size = new System.Drawing.Size(780, 89);
            this.TLP_Settings_Vid.TabIndex = 15;
            this.TLP_Settings_Vid.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // TB_Settings_VidSavePath
            // 
            this.TB_Settings_VidSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Settings_VidSavePath.BackColor = System.Drawing.Color.Black;
            this.TB_Settings_VidSavePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Settings_VidSavePath.ForeColor = System.Drawing.Color.White;
            this.TB_Settings_VidSavePath.Location = new System.Drawing.Point(160, 9);
            this.TB_Settings_VidSavePath.Margin = new System.Windows.Forms.Padding(0);
            this.TB_Settings_VidSavePath.Name = "TB_Settings_VidSavePath";
            this.TB_Settings_VidSavePath.Size = new System.Drawing.Size(310, 26);
            this.TB_Settings_VidSavePath.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label11.Location = new System.Drawing.Point(38, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "Сохранить в:";
            // 
            // B_Settings_FindVidPath
            // 
            this.B_Settings_FindVidPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Settings_FindVidPath.BackColor = System.Drawing.Color.Black;
            this.B_Settings_FindVidPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Settings_FindVidPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Settings_FindVidPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Settings_FindVidPath.ForeColor = System.Drawing.Color.White;
            this.B_Settings_FindVidPath.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_Settings_FindVidPath.Location = new System.Drawing.Point(470, 9);
            this.B_Settings_FindVidPath.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.B_Settings_FindVidPath.Name = "B_Settings_FindVidPath";
            this.B_Settings_FindVidPath.Size = new System.Drawing.Size(309, 26);
            this.B_Settings_FindVidPath.TabIndex = 8;
            this.B_Settings_FindVidPath.Text = "Обзор...";
            this.B_Settings_FindVidPath.UseVisualStyleBackColor = false;
            this.B_Settings_FindVidPath.Click += new System.EventHandler(this.B_Settings_FindVidPath_Click);
            // 
            // TPAGE_PhotoSettings
            // 
            this.TPAGE_PhotoSettings.BackColor = System.Drawing.Color.Black;
            this.TPAGE_PhotoSettings.Controls.Add(this.TLP_Settings_Photo);
            this.TPAGE_PhotoSettings.Location = new System.Drawing.Point(4, 25);
            this.TPAGE_PhotoSettings.Margin = new System.Windows.Forms.Padding(0);
            this.TPAGE_PhotoSettings.Name = "TPAGE_PhotoSettings";
            this.TPAGE_PhotoSettings.Size = new System.Drawing.Size(780, 89);
            this.TPAGE_PhotoSettings.TabIndex = 1;
            this.TPAGE_PhotoSettings.Text = "Запись фото";
            // 
            // TLP_Settings_Photo
            // 
            this.TLP_Settings_Photo.BackColor = System.Drawing.Color.Black;
            this.TLP_Settings_Photo.ColumnCount = 3;
            this.TLP_Settings_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TLP_Settings_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Settings_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Settings_Photo.Controls.Add(this.TB_Settings_PhotoSavePath, 1, 0);
            this.TLP_Settings_Photo.Controls.Add(this.label10, 0, 0);
            this.TLP_Settings_Photo.Controls.Add(this.B_Settings_FindPhotoPath, 2, 0);
            this.TLP_Settings_Photo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Settings_Photo.Location = new System.Drawing.Point(0, 0);
            this.TLP_Settings_Photo.Name = "TLP_Settings_Photo";
            this.TLP_Settings_Photo.RowCount = 2;
            this.TLP_Settings_Photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Settings_Photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Settings_Photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Settings_Photo.Size = new System.Drawing.Size(780, 89);
            this.TLP_Settings_Photo.TabIndex = 6;
            this.TLP_Settings_Photo.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // TB_Settings_PhotoSavePath
            // 
            this.TB_Settings_PhotoSavePath.AcceptsReturn = true;
            this.TB_Settings_PhotoSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Settings_PhotoSavePath.BackColor = System.Drawing.Color.Black;
            this.TB_Settings_PhotoSavePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Settings_PhotoSavePath.ForeColor = System.Drawing.Color.White;
            this.TB_Settings_PhotoSavePath.Location = new System.Drawing.Point(160, 9);
            this.TB_Settings_PhotoSavePath.Margin = new System.Windows.Forms.Padding(0);
            this.TB_Settings_PhotoSavePath.Name = "TB_Settings_PhotoSavePath";
            this.TB_Settings_PhotoSavePath.Size = new System.Drawing.Size(310, 26);
            this.TB_Settings_PhotoSavePath.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label10.Location = new System.Drawing.Point(38, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Сохранить в:";
            // 
            // B_Settings_FindPhotoPath
            // 
            this.B_Settings_FindPhotoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Settings_FindPhotoPath.BackColor = System.Drawing.Color.Black;
            this.B_Settings_FindPhotoPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Settings_FindPhotoPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Settings_FindPhotoPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Settings_FindPhotoPath.ForeColor = System.Drawing.Color.White;
            this.B_Settings_FindPhotoPath.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_Settings_FindPhotoPath.Location = new System.Drawing.Point(470, 9);
            this.B_Settings_FindPhotoPath.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.B_Settings_FindPhotoPath.Name = "B_Settings_FindPhotoPath";
            this.B_Settings_FindPhotoPath.Size = new System.Drawing.Size(309, 26);
            this.B_Settings_FindPhotoPath.TabIndex = 8;
            this.B_Settings_FindPhotoPath.Text = "Обзор...";
            this.B_Settings_FindPhotoPath.UseVisualStyleBackColor = false;
            this.B_Settings_FindPhotoPath.Click += new System.EventHandler(this.B_Settings_FindPhotoPath_Click);
            // 
            // TPAGE_CameraSettings
            // 
            this.TPAGE_CameraSettings.BackColor = System.Drawing.Color.Black;
            this.TPAGE_CameraSettings.Controls.Add(this.TLP_Settings_Camera);
            this.TPAGE_CameraSettings.Location = new System.Drawing.Point(4, 25);
            this.TPAGE_CameraSettings.Name = "TPAGE_CameraSettings";
            this.TPAGE_CameraSettings.Size = new System.Drawing.Size(780, 89);
            this.TPAGE_CameraSettings.TabIndex = 3;
            this.TPAGE_CameraSettings.Text = "Настройки камеры";
            // 
            // TLP_Settings_Camera
            // 
            this.TLP_Settings_Camera.AutoScroll = true;
            this.TLP_Settings_Camera.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TLP_Settings_Camera.ColumnCount = 6;
            this.TLP_Settings_Camera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.TLP_Settings_Camera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Settings_Camera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TLP_Settings_Camera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.TLP_Settings_Camera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Settings_Camera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TLP_Settings_Camera.Controls.Add(this.TrBContrast, 1, 1);
            this.TLP_Settings_Camera.Controls.Add(this.L_Settings_l1, 0, 0);
            this.TLP_Settings_Camera.Controls.Add(this.TrBBrightness, 1, 0);
            this.TLP_Settings_Camera.Controls.Add(this.LBrigthnessValue, 2, 0);
            this.TLP_Settings_Camera.Controls.Add(this.LContrastValue, 2, 1);
            this.TLP_Settings_Camera.Controls.Add(this.L_Settings_l2, 0, 1);
            this.TLP_Settings_Camera.Controls.Add(this.LSaturationValue, 2, 2);
            this.TLP_Settings_Camera.Controls.Add(this.TrBSaturation, 1, 2);
            this.TLP_Settings_Camera.Controls.Add(this.L_Settings_l3, 0, 2);
            this.TLP_Settings_Camera.Controls.Add(this.L_Settings_l4, 3, 0);
            this.TLP_Settings_Camera.Controls.Add(this.L_Settings_l5, 3, 1);
            this.TLP_Settings_Camera.Controls.Add(this.TrBGamma, 4, 0);
            this.TLP_Settings_Camera.Controls.Add(this.TrBGain, 4, 1);
            this.TLP_Settings_Camera.Controls.Add(this.LGammaValue, 5, 0);
            this.TLP_Settings_Camera.Controls.Add(this.LGainValue, 5, 1);
            this.TLP_Settings_Camera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Settings_Camera.Location = new System.Drawing.Point(0, 0);
            this.TLP_Settings_Camera.Name = "TLP_Settings_Camera";
            this.TLP_Settings_Camera.RowCount = 3;
            this.TLP_Settings_Camera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_Settings_Camera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_Settings_Camera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_Settings_Camera.Size = new System.Drawing.Size(780, 89);
            this.TLP_Settings_Camera.TabIndex = 16;
            this.TLP_Settings_Camera.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // TrBContrast
            // 
            this.TrBContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrBContrast.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TrBContrast.Location = new System.Drawing.Point(158, 32);
            this.TrBContrast.Maximum = 100;
            this.TrBContrast.Name = "TrBContrast";
            this.TrBContrast.Size = new System.Drawing.Size(179, 23);
            this.TrBContrast.TabIndex = 29;
            this.TrBContrast.TickFrequency = 5;
            this.TrBContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBContrast.Scroll += new System.EventHandler(this.TrBContrast_Scroll);
            // 
            // L_Settings_l1
            // 
            this.L_Settings_l1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L_Settings_l1.AutoSize = true;
            this.L_Settings_l1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.L_Settings_l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Settings_l1.ForeColor = System.Drawing.Color.White;
            this.L_Settings_l1.Location = new System.Drawing.Point(67, 4);
            this.L_Settings_l1.Name = "L_Settings_l1";
            this.L_Settings_l1.Size = new System.Drawing.Size(85, 20);
            this.L_Settings_l1.TabIndex = 28;
            this.L_Settings_l1.Text = "Яркость:";
            // 
            // TrBBrightness
            // 
            this.TrBBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrBBrightness.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TrBBrightness.Location = new System.Drawing.Point(158, 3);
            this.TrBBrightness.Maximum = 50;
            this.TrBBrightness.Minimum = -50;
            this.TrBBrightness.Name = "TrBBrightness";
            this.TrBBrightness.Size = new System.Drawing.Size(179, 23);
            this.TrBBrightness.TabIndex = 26;
            this.TrBBrightness.TickFrequency = 5;
            this.TrBBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBBrightness.Scroll += new System.EventHandler(this.TrBBrightness_Scroll);
            // 
            // LBrigthnessValue
            // 
            this.LBrigthnessValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBrigthnessValue.AutoSize = true;
            this.LBrigthnessValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBrigthnessValue.ForeColor = System.Drawing.Color.White;
            this.LBrigthnessValue.Location = new System.Drawing.Point(357, 6);
            this.LBrigthnessValue.Name = "LBrigthnessValue";
            this.LBrigthnessValue.Size = new System.Drawing.Size(16, 16);
            this.LBrigthnessValue.TabIndex = 27;
            this.LBrigthnessValue.Text = "0";
            // 
            // LContrastValue
            // 
            this.LContrastValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LContrastValue.AutoSize = true;
            this.LContrastValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContrastValue.ForeColor = System.Drawing.Color.White;
            this.LContrastValue.Location = new System.Drawing.Point(357, 35);
            this.LContrastValue.Name = "LContrastValue";
            this.LContrastValue.Size = new System.Drawing.Size(16, 16);
            this.LContrastValue.TabIndex = 30;
            this.LContrastValue.Text = "0";
            // 
            // L_Settings_l2
            // 
            this.L_Settings_l2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L_Settings_l2.AutoSize = true;
            this.L_Settings_l2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Settings_l2.ForeColor = System.Drawing.Color.White;
            this.L_Settings_l2.Location = new System.Drawing.Point(58, 33);
            this.L_Settings_l2.Name = "L_Settings_l2";
            this.L_Settings_l2.Size = new System.Drawing.Size(94, 20);
            this.L_Settings_l2.TabIndex = 31;
            this.L_Settings_l2.Text = "Контраст:";
            // 
            // LSaturationValue
            // 
            this.LSaturationValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LSaturationValue.AutoSize = true;
            this.LSaturationValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSaturationValue.ForeColor = System.Drawing.Color.White;
            this.LSaturationValue.Location = new System.Drawing.Point(357, 65);
            this.LSaturationValue.Name = "LSaturationValue";
            this.LSaturationValue.Size = new System.Drawing.Size(16, 16);
            this.LSaturationValue.TabIndex = 45;
            this.LSaturationValue.Text = "0";
            // 
            // TrBSaturation
            // 
            this.TrBSaturation.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TrBSaturation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrBSaturation.Location = new System.Drawing.Point(158, 61);
            this.TrBSaturation.Maximum = 130;
            this.TrBSaturation.Name = "TrBSaturation";
            this.TrBSaturation.Size = new System.Drawing.Size(179, 25);
            this.TrBSaturation.TabIndex = 50;
            this.TrBSaturation.TickFrequency = 5;
            this.TrBSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBSaturation.Scroll += new System.EventHandler(this.TrBSaturation_Scroll);
            // 
            // L_Settings_l3
            // 
            this.L_Settings_l3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L_Settings_l3.AutoSize = true;
            this.L_Settings_l3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Settings_l3.ForeColor = System.Drawing.Color.White;
            this.L_Settings_l3.Location = new System.Drawing.Point(11, 63);
            this.L_Settings_l3.Name = "L_Settings_l3";
            this.L_Settings_l3.Size = new System.Drawing.Size(141, 20);
            this.L_Settings_l3.TabIndex = 40;
            this.L_Settings_l3.Text = "Насыщенность:";
            // 
            // L_Settings_l4
            // 
            this.L_Settings_l4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L_Settings_l4.AutoSize = true;
            this.L_Settings_l4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Settings_l4.ForeColor = System.Drawing.Color.White;
            this.L_Settings_l4.Location = new System.Drawing.Point(396, 4);
            this.L_Settings_l4.Name = "L_Settings_l4";
            this.L_Settings_l4.Size = new System.Drawing.Size(146, 20);
            this.L_Settings_l4.TabIndex = 42;
            this.L_Settings_l4.Text = "Осветленность:";
            // 
            // L_Settings_l5
            // 
            this.L_Settings_l5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L_Settings_l5.AutoSize = true;
            this.L_Settings_l5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Settings_l5.ForeColor = System.Drawing.Color.White;
            this.L_Settings_l5.Location = new System.Drawing.Point(447, 33);
            this.L_Settings_l5.Name = "L_Settings_l5";
            this.L_Settings_l5.Size = new System.Drawing.Size(95, 20);
            this.L_Settings_l5.TabIndex = 43;
            this.L_Settings_l5.Text = "Усиление:";
            // 
            // TrBGamma
            // 
            this.TrBGamma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrBGamma.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TrBGamma.Location = new System.Drawing.Point(548, 3);
            this.TrBGamma.Maximum = 500;
            this.TrBGamma.Name = "TrBGamma";
            this.TrBGamma.Size = new System.Drawing.Size(179, 23);
            this.TrBGamma.TabIndex = 51;
            this.TrBGamma.TickFrequency = 5;
            this.TrBGamma.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBGamma.Scroll += new System.EventHandler(this.TrBGamma_Scroll);
            // 
            // TrBGain
            // 
            this.TrBGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrBGain.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TrBGain.Location = new System.Drawing.Point(548, 32);
            this.TrBGain.Maximum = 100;
            this.TrBGain.Name = "TrBGain";
            this.TrBGain.Size = new System.Drawing.Size(179, 23);
            this.TrBGain.TabIndex = 53;
            this.TrBGain.TickFrequency = 5;
            this.TrBGain.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBGain.Scroll += new System.EventHandler(this.TrBGain_Scroll);
            // 
            // LGammaValue
            // 
            this.LGammaValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LGammaValue.AutoSize = true;
            this.LGammaValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGammaValue.ForeColor = System.Drawing.Color.White;
            this.LGammaValue.Location = new System.Drawing.Point(747, 6);
            this.LGammaValue.Name = "LGammaValue";
            this.LGammaValue.Size = new System.Drawing.Size(16, 16);
            this.LGammaValue.TabIndex = 48;
            this.LGammaValue.Text = "0";
            // 
            // LGainValue
            // 
            this.LGainValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LGainValue.AutoSize = true;
            this.LGainValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGainValue.ForeColor = System.Drawing.Color.White;
            this.LGainValue.Location = new System.Drawing.Point(747, 35);
            this.LGainValue.Name = "LGainValue";
            this.LGainValue.Size = new System.Drawing.Size(16, 16);
            this.LGainValue.TabIndex = 49;
            this.LGainValue.Text = "0";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(780, 89);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Настройки приложения";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(780, 89);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Прочие";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(855, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Назад";
            // 
            // Pan_Video
            // 
            this.Pan_Video.Controls.Add(this.P_ChargeLev);
            this.Pan_Video.Controls.Add(this.PB_Indicator);
            this.Pan_Video.Controls.Add(this.LBConsole);
            this.Pan_Video.Controls.Add(this.CV_ImBox_Capture);
            this.Pan_Video.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_Video.Location = new System.Drawing.Point(0, 120);
            this.Pan_Video.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_Video.Name = "Pan_Video";
            this.Pan_Video.Size = new System.Drawing.Size(986, 386);
            this.Pan_Video.TabIndex = 1;
            // 
            // P_ChargeLev
            // 
            this.P_ChargeLev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.P_ChargeLev.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.P_ChargeLev.Controls.Add(this.TLP_ChargeLev);
            this.P_ChargeLev.Location = new System.Drawing.Point(870, 1);
            this.P_ChargeLev.Name = "P_ChargeLev";
            this.P_ChargeLev.Size = new System.Drawing.Size(116, 29);
            this.P_ChargeLev.TabIndex = 5;
            // 
            // TLP_ChargeLev
            // 
            this.TLP_ChargeLev.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TLP_ChargeLev.ColumnCount = 2;
            this.TLP_ChargeLev.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ChargeLev.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ChargeLev.Controls.Add(this.PB_ChargeVal, 0, 0);
            this.TLP_ChargeLev.Controls.Add(this.L_ChargeLev, 1, 0);
            this.TLP_ChargeLev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_ChargeLev.Location = new System.Drawing.Point(0, 0);
            this.TLP_ChargeLev.Name = "TLP_ChargeLev";
            this.TLP_ChargeLev.RowCount = 1;
            this.TLP_ChargeLev.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ChargeLev.Size = new System.Drawing.Size(116, 29);
            this.TLP_ChargeLev.TabIndex = 6;
            // 
            // PB_ChargeVal
            // 
            this.PB_ChargeVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_ChargeVal.Location = new System.Drawing.Point(0, 0);
            this.PB_ChargeVal.Margin = new System.Windows.Forms.Padding(0);
            this.PB_ChargeVal.Name = "PB_ChargeVal";
            this.PB_ChargeVal.Size = new System.Drawing.Size(58, 29);
            this.PB_ChargeVal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_ChargeVal.TabIndex = 4;
            this.PB_ChargeVal.TabStop = false;
            // 
            // L_ChargeLev
            // 
            this.L_ChargeLev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L_ChargeLev.AutoSize = true;
            this.L_ChargeLev.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_ChargeLev.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.L_ChargeLev.Location = new System.Drawing.Point(62, 5);
            this.L_ChargeLev.Name = "L_ChargeLev";
            this.L_ChargeLev.Size = new System.Drawing.Size(49, 18);
            this.L_ChargeLev.TabIndex = 5;
            this.L_ChargeLev.Text = "777%";
            // 
            // PB_Indicator
            // 
            this.PB_Indicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Indicator.BackColor = System.Drawing.Color.Transparent;
            this.PB_Indicator.ImageLocation = "";
            this.PB_Indicator.InitialImage = ((System.Drawing.Image)(resources.GetObject("PB_Indicator.InitialImage")));
            this.PB_Indicator.Location = new System.Drawing.Point(842, 1);
            this.PB_Indicator.Name = "PB_Indicator";
            this.PB_Indicator.Size = new System.Drawing.Size(29, 29);
            this.PB_Indicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Indicator.TabIndex = 3;
            this.PB_Indicator.TabStop = false;
            this.PB_Indicator.Visible = false;
            // 
            // LBConsole
            // 
            this.LBConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LBConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LBConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LBConsole.ForeColor = System.Drawing.Color.Lime;
            this.LBConsole.FormattingEnabled = true;
            this.LBConsole.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LBConsole.ItemHeight = 18;
            this.LBConsole.Location = new System.Drawing.Point(0, 1);
            this.LBConsole.Margin = new System.Windows.Forms.Padding(0);
            this.LBConsole.Name = "LBConsole";
            this.LBConsole.Size = new System.Drawing.Size(986, 180);
            this.LBConsole.TabIndex = 0;
            this.LBConsole.Visible = false;
            this.LBConsole.SelectedIndexChanged += new System.EventHandler(this.LBConsole_SelectedIndexChanged);
            // 
            // CV_ImBox_Capture
            // 
            this.CV_ImBox_Capture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CV_ImBox_Capture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CV_ImBox_Capture.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.CV_ImBox_Capture.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            this.CV_ImBox_Capture.Location = new System.Drawing.Point(0, 0);
            this.CV_ImBox_Capture.Name = "CV_ImBox_Capture";
            this.CV_ImBox_Capture.Size = new System.Drawing.Size(986, 386);
            this.CV_ImBox_Capture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CV_ImBox_Capture.TabIndex = 2;
            this.CV_ImBox_Capture.TabStop = false;
            // 
            // BGWR_ChargeLev
            // 
            this.BGWR_ChargeLev.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWR_ChargeLev_DoWork);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 506);
            this.Controls.Add(this.TLP_MainPanel);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.TLP_MainPanel.ResumeLayout(false);
            this.Pan_BackgroundPanel.ResumeLayout(false);
            this.Pan_UserMain.ResumeLayout(false);
            this.TLP_UserMainPanel.ResumeLayout(false);
            this.TLP_UserMainPanel.PerformLayout();
            this.Pan_Export.ResumeLayout(false);
            this.TBL_ExportTable.ResumeLayout(false);
            this.TBL_ExportTable.PerformLayout();
            this.Pan_Settings.ResumeLayout(false);
            this.TLP_Settings.ResumeLayout(false);
            this.TLP_Settings.PerformLayout();
            this.TABC_Settings.ResumeLayout(false);
            this.TPAGE_VidSettings.ResumeLayout(false);
            this.TLP_Settings_Vid.ResumeLayout(false);
            this.TLP_Settings_Vid.PerformLayout();
            this.TPAGE_PhotoSettings.ResumeLayout(false);
            this.TLP_Settings_Photo.ResumeLayout(false);
            this.TLP_Settings_Photo.PerformLayout();
            this.TPAGE_CameraSettings.ResumeLayout(false);
            this.TLP_Settings_Camera.ResumeLayout(false);
            this.TLP_Settings_Camera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrBContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBGain)).EndInit();
            this.Pan_Video.ResumeLayout(false);
            this.P_ChargeLev.ResumeLayout(false);
            this.TLP_ChargeLev.ResumeLayout(false);
            this.TLP_ChargeLev.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ChargeVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Indicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CV_ImBox_Capture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLP_MainPanel;
        private System.Windows.Forms.TableLayoutPanel TLP_UserMainPanel;
        private System.Windows.Forms.Panel Pan_Video;
        private System.Windows.Forms.ListBox LBConsole;
        private Emgu.CV.UI.ImageBox CV_ImBox_Capture;
        private System.Windows.Forms.Button B_Settings;
        private System.Windows.Forms.Button B_Photo_or_PauseRec;
        private System.Windows.Forms.Button B_SwitchRec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Pan_Settings;
        private System.Windows.Forms.TabControl TABC_Settings;
        private System.Windows.Forms.TabPage TPAGE_VidSettings;
        private System.Windows.Forms.TabPage TPAGE_PhotoSettings;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage TPAGE_CameraSettings;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button B_Browse;
        private System.Windows.Forms.Button B_Quit;
        private System.Windows.Forms.TableLayoutPanel TLP_Settings;
        private System.Windows.Forms.Button B_BackBut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel Pan_BackgroundPanel;
        private System.Windows.Forms.Panel Pan_UserMain;
        private System.Windows.Forms.Panel P_ChargeLev;
        private System.ComponentModel.BackgroundWorker BGWR_ChargeLev;
        private System.Windows.Forms.TableLayoutPanel TLP_ChargeLev;
        private System.Windows.Forms.PictureBox PB_ChargeVal;
        private System.Windows.Forms.Label L_ChargeLev;
        private System.Windows.Forms.PictureBox PB_Indicator;
        private System.Windows.Forms.Panel Pan_Export;
        private System.Windows.Forms.TableLayoutPanel TBL_ExportTable;
        private System.Windows.Forms.Button B_Ex_PhotoMode;
        private System.Windows.Forms.Button B_Ex_VideoMode;
        private System.Windows.Forms.Label L_Ex_Mode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_Ex_PathFrom;
        private System.Windows.Forms.TextBox TB_Ex_PathTo;
        private System.Windows.Forms.Button B_Ex_MinusCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CB_Ex_ChooseExportMode;
        private System.Windows.Forms.Button B_Ex_Search_PathFrom;
        private System.Windows.Forms.Button B_Ex_Search_PathTo;
        private System.Windows.Forms.Button B_Ex_PlusCount;
        private System.Windows.Forms.TextBox TB_Ex_Count;
        private System.Windows.Forms.Button B_Ex_StartExport;
        private System.Windows.Forms.Button B_Ex_BackToMain;
        private System.Windows.Forms.TableLayoutPanel TLP_Settings_Photo;
        private System.Windows.Forms.TextBox TB_Settings_PhotoSavePath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button B_Settings_FindPhotoPath;
        private System.Windows.Forms.TableLayoutPanel TLP_Settings_Vid;
        private System.Windows.Forms.TextBox TB_Settings_VidSavePath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button B_Settings_FindVidPath;
        private System.Windows.Forms.TableLayoutPanel TLP_Settings_Camera;
        private System.Windows.Forms.TrackBar TrBContrast;
        private System.Windows.Forms.Label L_Settings_l1;
        private System.Windows.Forms.TrackBar TrBBrightness;
        private System.Windows.Forms.Label LBrigthnessValue;
        private System.Windows.Forms.Label LContrastValue;
        private System.Windows.Forms.Label L_Settings_l2;
        private System.Windows.Forms.Label L_Settings_l3;
        private System.Windows.Forms.Label L_Settings_l4;
        private System.Windows.Forms.Label L_Settings_l5;
        private System.Windows.Forms.Label LSaturationValue;
        private System.Windows.Forms.Label LGammaValue;
        private System.Windows.Forms.Label LGainValue;
        private System.Windows.Forms.TrackBar TrBSaturation;
        private System.Windows.Forms.TrackBar TrBGamma;
        private System.Windows.Forms.TrackBar TrBGain;
    }
}


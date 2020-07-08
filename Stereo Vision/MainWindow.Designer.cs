﻿
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
            this.TLP_BASE = new System.Windows.Forms.TableLayoutPanel();
            this.Pan_BASE_BackgroundPanel = new System.Windows.Forms.Panel();
            this.Pan_ViewRegion = new System.Windows.Forms.Panel();
            this.Pan_Pl_3D = new System.Windows.Forms.Panel();
            this.TLP_Pl_3D = new System.Windows.Forms.TableLayoutPanel();
            this.L_Pl_Models_Cur = new System.Windows.Forms.Label();
            this.L_Pl_Models_All = new System.Windows.Forms.Label();
            this.TRB_Pl_ModelsLister = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.B_Pl_ModelPrevious = new System.Windows.Forms.Button();
            this.B_Pl_ModelNext = new System.Windows.Forms.Button();
            this.Pan_3D_Building = new System.Windows.Forms.Panel();
            this.TLP_3D_Building = new System.Windows.Forms.TableLayoutPanel();
            this.PrB_3D_Building = new System.Windows.Forms.ProgressBar();
            this.B_3D_CancelBuilding = new System.Windows.Forms.Button();
            this.Pan_Pl_Photo = new System.Windows.Forms.Panel();
            this.TLP_Pl_Photo = new System.Windows.Forms.TableLayoutPanel();
            this.B_Pl_Photo_Measure = new System.Windows.Forms.Button();
            this.L_Pl_Photo_Cur = new System.Windows.Forms.Label();
            this.L_Pl_Photo_All = new System.Windows.Forms.Label();
            this.TRB_Pl_PhotoLister = new System.Windows.Forms.TrackBar();
            this.L_Pl_PhotoPlayerName = new System.Windows.Forms.Label();
            this.B_Pl_PhotoPrevious = new System.Windows.Forms.Button();
            this.B_Pl_PhotoNext = new System.Windows.Forms.Button();
            this.Pan_Pl_Video = new System.Windows.Forms.Panel();
            this.TLP_Pl_Video = new System.Windows.Forms.TableLayoutPanel();
            this.B_Pl_VideoNext = new System.Windows.Forms.Button();
            this.L_Pl_VideoPlayerName = new System.Windows.Forms.Label();
            this.L_Pl_Video_TimeLeft = new System.Windows.Forms.Label();
            this.B_Pl_VideoStop = new System.Windows.Forms.Button();
            this.L_Pl_Video_TimeCur = new System.Windows.Forms.Label();
            this.TRB_Pl_VideoTimer = new System.Windows.Forms.TrackBar();
            this.B_Pl_VideoPlayPause = new System.Windows.Forms.Button();
            this.B_Pl_VideoPrevious = new System.Windows.Forms.Button();
            this.L_SnapShotSaved = new System.Windows.Forms.Label();
            this.P_ChargeLev = new System.Windows.Forms.Panel();
            this.TLP_ChargeLev = new System.Windows.Forms.TableLayoutPanel();
            this.PB_ChargeVal = new System.Windows.Forms.PictureBox();
            this.L_ChargeLev = new System.Windows.Forms.Label();
            this.PB_Indicator = new System.Windows.Forms.PictureBox();
            this.LBConsole = new System.Windows.Forms.ListBox();
            this.CV_ImBox_Capture = new Emgu.CV.UI.ImageBox();
            this.Pan_Player = new System.Windows.Forms.Panel();
            this.TLP_Pl_PlayerMain = new System.Windows.Forms.TableLayoutPanel();
            this.B_Pl_GoToMain = new System.Windows.Forms.Button();
            this.Pan_Pl_Base_forAnyPLCtrls = new System.Windows.Forms.Panel();
            this.B_Pl_VideoMode = new System.Windows.Forms.Button();
            this.B_Pl_PhotoMode = new System.Windows.Forms.Button();
            this.B_Pl_3DMode = new System.Windows.Forms.Button();
            this.Pan_Export = new System.Windows.Forms.Panel();
            this.TLP_ExportTable = new System.Windows.Forms.TableLayoutPanel();
            this.B_Ex_BackToMain = new System.Windows.Forms.Button();
            this.B_Ex_MinusCount = new System.Windows.Forms.Button();
            this.B_Ex_StartExport = new System.Windows.Forms.Button();
            this.TB_Ex_PathTo = new System.Windows.Forms.TextBox();
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
            this.B_Ex_VideoMode = new System.Windows.Forms.Button();
            this.B_Ex_PhotoMode = new System.Windows.Forms.Button();
            this.B_Ex_3DMode = new System.Windows.Forms.Button();
            this.Pan_Settings = new System.Windows.Forms.Panel();
            this.TLP_Settings = new System.Windows.Forms.TableLayoutPanel();
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
            this.TPAGE_WB = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.B_WB_LowerFrames = new System.Windows.Forms.Button();
            this.B_WB_HigherFrames = new System.Windows.Forms.Button();
            this.L_WB_NumOfImages = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.L_WB_CorPower = new System.Windows.Forms.Label();
            this.TrB_WB_CorPower = new System.Windows.Forms.TrackBar();
            this.B_WB_Calculate = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TB_Set_CalibStereoFilePath = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TB_Set_CalibWBFilePath = new System.Windows.Forms.TextBox();
            this.B_Set_FindWBCalibFile = new System.Windows.Forms.Button();
            this.B_Set_FindStereoCalibFile = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.B_BackBut = new System.Windows.Forms.Button();
            this.Pan_MainMenu = new System.Windows.Forms.Panel();
            this.TLP_UserMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.B_ViewMode = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.B_ExportMode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.B_Photo_or_PauseRec = new System.Windows.Forms.Button();
            this.B_SwitchRec = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Quit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.B_Settings = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.B_MeasureMode = new System.Windows.Forms.Button();
            this.Pan_Measurements = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ChB_Mes_Area = new System.Windows.Forms.CheckBox();
            this.ChB_Mes_Perimeter = new System.Windows.Forms.CheckBox();
            this.ChB_Mes_LenghtOfBroken = new System.Windows.Forms.CheckBox();
            this.ChB_Mes_p2pl = new System.Windows.Forms.CheckBox();
            this.ChB_Mes_p2l = new System.Windows.Forms.CheckBox();
            this.ChB_Mes_p2p = new System.Windows.Forms.CheckBox();
            this.B_Mes_DeleteAll = new System.Windows.Forms.Button();
            this.B_Mes_Reconstruct3D = new System.Windows.Forms.Button();
            this.B_Mes_Back = new System.Windows.Forms.Button();
            this.CV_ImBox_VidPhoto_Player = new Emgu.CV.UI.ImageBox();
            this.PB_MeasurementPB = new System.Windows.Forms.PictureBox();
            this.OTK_3D_Control = new OpenTK.GLControl();
            this.BGWR_ChargeLev = new System.ComponentModel.BackgroundWorker();
            this.WakeUpTimer = new System.Windows.Forms.Timer(this.components);
            this.Timer_InvalidateAfter_EnteringMes = new System.Windows.Forms.Timer(this.components);
            this.Timer_3DRenderer = new System.Windows.Forms.Timer(this.components);
            this.BGW_3DRotator = new System.ComponentModel.BackgroundWorker();
            this.BWorkerForLoad3D = new System.ComponentModel.BackgroundWorker();
            this.T_3DCancellingChecker = new System.Windows.Forms.Timer(this.components);
            this.BGW_StereoInitializer = new System.ComponentModel.BackgroundWorker();
            this.TLP_BASE.SuspendLayout();
            this.Pan_ViewRegion.SuspendLayout();
            this.Pan_Pl_3D.SuspendLayout();
            this.TLP_Pl_3D.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_Pl_ModelsLister)).BeginInit();
            this.Pan_3D_Building.SuspendLayout();
            this.TLP_3D_Building.SuspendLayout();
            this.Pan_Pl_Photo.SuspendLayout();
            this.TLP_Pl_Photo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_Pl_PhotoLister)).BeginInit();
            this.Pan_Pl_Video.SuspendLayout();
            this.TLP_Pl_Video.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_Pl_VideoTimer)).BeginInit();
            this.P_ChargeLev.SuspendLayout();
            this.TLP_ChargeLev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ChargeVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Indicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CV_ImBox_Capture)).BeginInit();
            this.Pan_Player.SuspendLayout();
            this.TLP_Pl_PlayerMain.SuspendLayout();
            this.Pan_Export.SuspendLayout();
            this.TLP_ExportTable.SuspendLayout();
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
            this.TPAGE_WB.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrB_WB_CorPower)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.TB_Set_CalibStereoFilePath.SuspendLayout();
            this.Pan_MainMenu.SuspendLayout();
            this.TLP_UserMainPanel.SuspendLayout();
            this.Pan_Measurements.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CV_ImBox_VidPhoto_Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MeasurementPB)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP_BASE
            // 
            this.TLP_BASE.ColumnCount = 1;
            this.TLP_BASE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_BASE.Controls.Add(this.Pan_BASE_BackgroundPanel, 0, 0);
            this.TLP_BASE.Controls.Add(this.Pan_ViewRegion, 0, 1);
            this.TLP_BASE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_BASE.Location = new System.Drawing.Point(0, 0);
            this.TLP_BASE.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_BASE.Name = "TLP_BASE";
            this.TLP_BASE.RowCount = 2;
            this.TLP_BASE.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.TLP_BASE.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_BASE.Size = new System.Drawing.Size(1278, 685);
            this.TLP_BASE.TabIndex = 1;
            // 
            // Pan_BASE_BackgroundPanel
            // 
            this.Pan_BASE_BackgroundPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Pan_BASE_BackgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_BASE_BackgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.Pan_BASE_BackgroundPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Pan_BASE_BackgroundPanel.Name = "Pan_BASE_BackgroundPanel";
            this.Pan_BASE_BackgroundPanel.Size = new System.Drawing.Size(1278, 118);
            this.Pan_BASE_BackgroundPanel.TabIndex = 5;
            // 
            // Pan_ViewRegion
            // 
            this.Pan_ViewRegion.Controls.Add(this.Pan_Pl_3D);
            this.Pan_ViewRegion.Controls.Add(this.Pan_Pl_Photo);
            this.Pan_ViewRegion.Controls.Add(this.Pan_Pl_Video);
            this.Pan_ViewRegion.Controls.Add(this.L_SnapShotSaved);
            this.Pan_ViewRegion.Controls.Add(this.P_ChargeLev);
            this.Pan_ViewRegion.Controls.Add(this.PB_Indicator);
            this.Pan_ViewRegion.Controls.Add(this.LBConsole);
            this.Pan_ViewRegion.Controls.Add(this.CV_ImBox_Capture);
            this.Pan_ViewRegion.Controls.Add(this.Pan_Player);
            this.Pan_ViewRegion.Controls.Add(this.Pan_Export);
            this.Pan_ViewRegion.Controls.Add(this.Pan_Settings);
            this.Pan_ViewRegion.Controls.Add(this.Pan_MainMenu);
            this.Pan_ViewRegion.Controls.Add(this.Pan_Measurements);
            this.Pan_ViewRegion.Controls.Add(this.CV_ImBox_VidPhoto_Player);
            this.Pan_ViewRegion.Controls.Add(this.PB_MeasurementPB);
            this.Pan_ViewRegion.Controls.Add(this.OTK_3D_Control);
            this.Pan_ViewRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_ViewRegion.Location = new System.Drawing.Point(0, 120);
            this.Pan_ViewRegion.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_ViewRegion.Name = "Pan_ViewRegion";
            this.Pan_ViewRegion.Size = new System.Drawing.Size(1278, 565);
            this.Pan_ViewRegion.TabIndex = 1;
            // 
            // Pan_Pl_3D
            // 
            this.Pan_Pl_3D.BackColor = System.Drawing.Color.Black;
            this.Pan_Pl_3D.Controls.Add(this.TLP_Pl_3D);
            this.Pan_Pl_3D.Location = new System.Drawing.Point(135, 337);
            this.Pan_Pl_3D.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_Pl_3D.Name = "Pan_Pl_3D";
            this.Pan_Pl_3D.Size = new System.Drawing.Size(435, 63);
            this.Pan_Pl_3D.TabIndex = 10;
            // 
            // TLP_Pl_3D
            // 
            this.TLP_Pl_3D.ColumnCount = 8;
            this.TLP_Pl_3D.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_3D.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_3D.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_3D.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_3D.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_3D.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_3D.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_3D.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_3D.Controls.Add(this.L_Pl_Models_Cur, 0, 1);
            this.TLP_Pl_3D.Controls.Add(this.L_Pl_Models_All, 7, 1);
            this.TLP_Pl_3D.Controls.Add(this.TRB_Pl_ModelsLister, 1, 1);
            this.TLP_Pl_3D.Controls.Add(this.label16, 2, 0);
            this.TLP_Pl_3D.Controls.Add(this.B_Pl_ModelPrevious, 0, 2);
            this.TLP_Pl_3D.Controls.Add(this.B_Pl_ModelNext, 6, 2);
            this.TLP_Pl_3D.Controls.Add(this.Pan_3D_Building, 2, 2);
            this.TLP_Pl_3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Pl_3D.Location = new System.Drawing.Point(0, 0);
            this.TLP_Pl_3D.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Pl_3D.Name = "TLP_Pl_3D";
            this.TLP_Pl_3D.RowCount = 4;
            this.TLP_Pl_3D.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_3D.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_3D.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_3D.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_3D.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.TLP_Pl_3D.Size = new System.Drawing.Size(435, 63);
            this.TLP_Pl_3D.TabIndex = 0;
            // 
            // L_Pl_Models_Cur
            // 
            this.L_Pl_Models_Cur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Pl_Models_Cur.AutoSize = true;
            this.L_Pl_Models_Cur.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.L_Pl_Models_Cur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Pl_Models_Cur.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.L_Pl_Models_Cur.Location = new System.Drawing.Point(3, 15);
            this.L_Pl_Models_Cur.Name = "L_Pl_Models_Cur";
            this.L_Pl_Models_Cur.Size = new System.Drawing.Size(48, 15);
            this.L_Pl_Models_Cur.TabIndex = 12;
            this.L_Pl_Models_Cur.Text = "0";
            this.L_Pl_Models_Cur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_Pl_Models_All
            // 
            this.L_Pl_Models_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Pl_Models_All.AutoSize = true;
            this.L_Pl_Models_All.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.L_Pl_Models_All.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Pl_Models_All.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.L_Pl_Models_All.Location = new System.Drawing.Point(381, 15);
            this.L_Pl_Models_All.Name = "L_Pl_Models_All";
            this.L_Pl_Models_All.Size = new System.Drawing.Size(51, 15);
            this.L_Pl_Models_All.TabIndex = 13;
            this.L_Pl_Models_All.Text = "999";
            this.L_Pl_Models_All.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TRB_Pl_ModelsLister
            // 
            this.TRB_Pl_ModelsLister.AutoSize = false;
            this.TLP_Pl_3D.SetColumnSpan(this.TRB_Pl_ModelsLister, 6);
            this.TRB_Pl_ModelsLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TRB_Pl_ModelsLister.Location = new System.Drawing.Point(54, 15);
            this.TRB_Pl_ModelsLister.Margin = new System.Windows.Forms.Padding(0);
            this.TRB_Pl_ModelsLister.Maximum = 100;
            this.TRB_Pl_ModelsLister.Name = "TRB_Pl_ModelsLister";
            this.TRB_Pl_ModelsLister.Size = new System.Drawing.Size(324, 15);
            this.TRB_Pl_ModelsLister.TabIndex = 10;
            this.TRB_Pl_ModelsLister.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TRB_Pl_ModelsLister.Scroll += new System.EventHandler(this.TRB_Pl_ModelsLister_Scroll);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TLP_Pl_3D.SetColumnSpan(this.label16, 4);
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label16.Location = new System.Drawing.Point(108, 0);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(216, 15);
            this.label16.TabIndex = 7;
            this.label16.Text = "Просмотр 3D моделей";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // B_Pl_ModelPrevious
            // 
            this.B_Pl_ModelPrevious.BackColor = System.Drawing.Color.Black;
            this.B_Pl_ModelPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_ModelPrevious.BackgroundImage")));
            this.B_Pl_ModelPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP_Pl_3D.SetColumnSpan(this.B_Pl_ModelPrevious, 2);
            this.B_Pl_ModelPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_ModelPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_ModelPrevious.Location = new System.Drawing.Point(0, 30);
            this.B_Pl_ModelPrevious.Margin = new System.Windows.Forms.Padding(0);
            this.B_Pl_ModelPrevious.Name = "B_Pl_ModelPrevious";
            this.TLP_Pl_3D.SetRowSpan(this.B_Pl_ModelPrevious, 2);
            this.B_Pl_ModelPrevious.Size = new System.Drawing.Size(108, 33);
            this.B_Pl_ModelPrevious.TabIndex = 10;
            this.B_Pl_ModelPrevious.UseVisualStyleBackColor = false;
            this.B_Pl_ModelPrevious.Click += new System.EventHandler(this.B_Pl_ModelPrevious_Click);
            // 
            // B_Pl_ModelNext
            // 
            this.B_Pl_ModelNext.BackColor = System.Drawing.Color.Black;
            this.B_Pl_ModelNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_ModelNext.BackgroundImage")));
            this.B_Pl_ModelNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP_Pl_3D.SetColumnSpan(this.B_Pl_ModelNext, 2);
            this.B_Pl_ModelNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_ModelNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_ModelNext.Location = new System.Drawing.Point(324, 30);
            this.B_Pl_ModelNext.Margin = new System.Windows.Forms.Padding(0);
            this.B_Pl_ModelNext.Name = "B_Pl_ModelNext";
            this.TLP_Pl_3D.SetRowSpan(this.B_Pl_ModelNext, 2);
            this.B_Pl_ModelNext.Size = new System.Drawing.Size(111, 33);
            this.B_Pl_ModelNext.TabIndex = 11;
            this.B_Pl_ModelNext.UseVisualStyleBackColor = false;
            this.B_Pl_ModelNext.Click += new System.EventHandler(this.B_Pl_ModelNext_Click);
            // 
            // Pan_3D_Building
            // 
            this.TLP_Pl_3D.SetColumnSpan(this.Pan_3D_Building, 4);
            this.Pan_3D_Building.Controls.Add(this.TLP_3D_Building);
            this.Pan_3D_Building.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_3D_Building.Location = new System.Drawing.Point(108, 30);
            this.Pan_3D_Building.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_3D_Building.Name = "Pan_3D_Building";
            this.TLP_Pl_3D.SetRowSpan(this.Pan_3D_Building, 2);
            this.Pan_3D_Building.Size = new System.Drawing.Size(216, 33);
            this.Pan_3D_Building.TabIndex = 0;
            // 
            // TLP_3D_Building
            // 
            this.TLP_3D_Building.ColumnCount = 1;
            this.TLP_3D_Building.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_3D_Building.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_3D_Building.Controls.Add(this.PrB_3D_Building, 0, 0);
            this.TLP_3D_Building.Controls.Add(this.B_3D_CancelBuilding, 0, 1);
            this.TLP_3D_Building.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_3D_Building.Location = new System.Drawing.Point(0, 0);
            this.TLP_3D_Building.Name = "TLP_3D_Building";
            this.TLP_3D_Building.RowCount = 2;
            this.TLP_3D_Building.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_3D_Building.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_3D_Building.Size = new System.Drawing.Size(216, 33);
            this.TLP_3D_Building.TabIndex = 0;
            // 
            // PrB_3D_Building
            // 
            this.PrB_3D_Building.BackColor = System.Drawing.Color.Red;
            this.PrB_3D_Building.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrB_3D_Building.ForeColor = System.Drawing.SystemColors.Desktop;
            this.PrB_3D_Building.Location = new System.Drawing.Point(3, 3);
            this.PrB_3D_Building.Name = "PrB_3D_Building";
            this.PrB_3D_Building.Size = new System.Drawing.Size(210, 10);
            this.PrB_3D_Building.TabIndex = 0;
            // 
            // B_3D_CancelBuilding
            // 
            this.B_3D_CancelBuilding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_3D_CancelBuilding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_3D_CancelBuilding.ForeColor = System.Drawing.Color.White;
            this.B_3D_CancelBuilding.Location = new System.Drawing.Point(3, 19);
            this.B_3D_CancelBuilding.Name = "B_3D_CancelBuilding";
            this.B_3D_CancelBuilding.Size = new System.Drawing.Size(210, 11);
            this.B_3D_CancelBuilding.TabIndex = 1;
            this.B_3D_CancelBuilding.Text = "Прервать построение";
            this.B_3D_CancelBuilding.UseVisualStyleBackColor = true;
            this.B_3D_CancelBuilding.Click += new System.EventHandler(this.B_3D_CancelBuilding_Click);
            // 
            // Pan_Pl_Photo
            // 
            this.Pan_Pl_Photo.BackColor = System.Drawing.Color.Black;
            this.Pan_Pl_Photo.Controls.Add(this.TLP_Pl_Photo);
            this.Pan_Pl_Photo.Location = new System.Drawing.Point(135, 484);
            this.Pan_Pl_Photo.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_Pl_Photo.Name = "Pan_Pl_Photo";
            this.Pan_Pl_Photo.Size = new System.Drawing.Size(435, 63);
            this.Pan_Pl_Photo.TabIndex = 9;
            this.Pan_Pl_Photo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // TLP_Pl_Photo
            // 
            this.TLP_Pl_Photo.ColumnCount = 8;
            this.TLP_Pl_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Photo.Controls.Add(this.B_Pl_Photo_Measure, 3, 2);
            this.TLP_Pl_Photo.Controls.Add(this.L_Pl_Photo_Cur, 0, 1);
            this.TLP_Pl_Photo.Controls.Add(this.L_Pl_Photo_All, 7, 1);
            this.TLP_Pl_Photo.Controls.Add(this.TRB_Pl_PhotoLister, 1, 1);
            this.TLP_Pl_Photo.Controls.Add(this.L_Pl_PhotoPlayerName, 2, 0);
            this.TLP_Pl_Photo.Controls.Add(this.B_Pl_PhotoPrevious, 0, 2);
            this.TLP_Pl_Photo.Controls.Add(this.B_Pl_PhotoNext, 5, 2);
            this.TLP_Pl_Photo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Pl_Photo.Location = new System.Drawing.Point(0, 0);
            this.TLP_Pl_Photo.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Pl_Photo.Name = "TLP_Pl_Photo";
            this.TLP_Pl_Photo.RowCount = 4;
            this.TLP_Pl_Photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_Photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_Photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_Photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_Photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.TLP_Pl_Photo.Size = new System.Drawing.Size(435, 63);
            this.TLP_Pl_Photo.TabIndex = 0;
            // 
            // B_Pl_Photo_Measure
            // 
            this.B_Pl_Photo_Measure.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_Photo_Measure.BackgroundImage")));
            this.B_Pl_Photo_Measure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP_Pl_Photo.SetColumnSpan(this.B_Pl_Photo_Measure, 2);
            this.B_Pl_Photo_Measure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_Photo_Measure.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.B_Pl_Photo_Measure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_Photo_Measure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Pl_Photo_Measure.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.B_Pl_Photo_Measure.Location = new System.Drawing.Point(162, 30);
            this.B_Pl_Photo_Measure.Margin = new System.Windows.Forms.Padding(0);
            this.B_Pl_Photo_Measure.Name = "B_Pl_Photo_Measure";
            this.TLP_Pl_Photo.SetRowSpan(this.B_Pl_Photo_Measure, 2);
            this.B_Pl_Photo_Measure.Size = new System.Drawing.Size(108, 33);
            this.B_Pl_Photo_Measure.TabIndex = 11;
            this.B_Pl_Photo_Measure.UseVisualStyleBackColor = true;
            this.B_Pl_Photo_Measure.Click += new System.EventHandler(this.B_Pl_Photo_Measure_Click);
            // 
            // L_Pl_Photo_Cur
            // 
            this.L_Pl_Photo_Cur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Pl_Photo_Cur.AutoSize = true;
            this.L_Pl_Photo_Cur.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.L_Pl_Photo_Cur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Pl_Photo_Cur.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.L_Pl_Photo_Cur.Location = new System.Drawing.Point(3, 15);
            this.L_Pl_Photo_Cur.Name = "L_Pl_Photo_Cur";
            this.L_Pl_Photo_Cur.Size = new System.Drawing.Size(48, 15);
            this.L_Pl_Photo_Cur.TabIndex = 12;
            this.L_Pl_Photo_Cur.Text = "0";
            this.L_Pl_Photo_Cur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_Pl_Photo_All
            // 
            this.L_Pl_Photo_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Pl_Photo_All.AutoSize = true;
            this.L_Pl_Photo_All.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.L_Pl_Photo_All.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Pl_Photo_All.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.L_Pl_Photo_All.Location = new System.Drawing.Point(381, 15);
            this.L_Pl_Photo_All.Name = "L_Pl_Photo_All";
            this.L_Pl_Photo_All.Size = new System.Drawing.Size(51, 15);
            this.L_Pl_Photo_All.TabIndex = 13;
            this.L_Pl_Photo_All.Text = "999";
            this.L_Pl_Photo_All.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TRB_Pl_PhotoLister
            // 
            this.TRB_Pl_PhotoLister.AutoSize = false;
            this.TLP_Pl_Photo.SetColumnSpan(this.TRB_Pl_PhotoLister, 6);
            this.TRB_Pl_PhotoLister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TRB_Pl_PhotoLister.Location = new System.Drawing.Point(54, 15);
            this.TRB_Pl_PhotoLister.Margin = new System.Windows.Forms.Padding(0);
            this.TRB_Pl_PhotoLister.Maximum = 100;
            this.TRB_Pl_PhotoLister.Name = "TRB_Pl_PhotoLister";
            this.TRB_Pl_PhotoLister.Size = new System.Drawing.Size(324, 15);
            this.TRB_Pl_PhotoLister.TabIndex = 10;
            this.TRB_Pl_PhotoLister.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TRB_Pl_PhotoLister.Scroll += new System.EventHandler(this.TRB_Pl_PhotoLister_Scroll);
            // 
            // L_Pl_PhotoPlayerName
            // 
            this.L_Pl_PhotoPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Pl_PhotoPlayerName.AutoSize = true;
            this.L_Pl_PhotoPlayerName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TLP_Pl_Photo.SetColumnSpan(this.L_Pl_PhotoPlayerName, 4);
            this.L_Pl_PhotoPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Pl_PhotoPlayerName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.L_Pl_PhotoPlayerName.Location = new System.Drawing.Point(108, 0);
            this.L_Pl_PhotoPlayerName.Margin = new System.Windows.Forms.Padding(0);
            this.L_Pl_PhotoPlayerName.Name = "L_Pl_PhotoPlayerName";
            this.L_Pl_PhotoPlayerName.Size = new System.Drawing.Size(216, 15);
            this.L_Pl_PhotoPlayerName.TabIndex = 7;
            this.L_Pl_PhotoPlayerName.Text = "Просмотр фото";
            this.L_Pl_PhotoPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // B_Pl_PhotoPrevious
            // 
            this.B_Pl_PhotoPrevious.BackColor = System.Drawing.Color.Black;
            this.B_Pl_PhotoPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_PhotoPrevious.BackgroundImage")));
            this.B_Pl_PhotoPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP_Pl_Photo.SetColumnSpan(this.B_Pl_PhotoPrevious, 3);
            this.B_Pl_PhotoPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_PhotoPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_PhotoPrevious.Location = new System.Drawing.Point(0, 30);
            this.B_Pl_PhotoPrevious.Margin = new System.Windows.Forms.Padding(0);
            this.B_Pl_PhotoPrevious.Name = "B_Pl_PhotoPrevious";
            this.TLP_Pl_Photo.SetRowSpan(this.B_Pl_PhotoPrevious, 2);
            this.B_Pl_PhotoPrevious.Size = new System.Drawing.Size(162, 33);
            this.B_Pl_PhotoPrevious.TabIndex = 10;
            this.B_Pl_PhotoPrevious.UseVisualStyleBackColor = false;
            this.B_Pl_PhotoPrevious.Click += new System.EventHandler(this.B_Pl_PhotoPrevious_Click);
            // 
            // B_Pl_PhotoNext
            // 
            this.B_Pl_PhotoNext.BackColor = System.Drawing.Color.Black;
            this.B_Pl_PhotoNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_PhotoNext.BackgroundImage")));
            this.B_Pl_PhotoNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP_Pl_Photo.SetColumnSpan(this.B_Pl_PhotoNext, 3);
            this.B_Pl_PhotoNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_PhotoNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_PhotoNext.Location = new System.Drawing.Point(270, 30);
            this.B_Pl_PhotoNext.Margin = new System.Windows.Forms.Padding(0);
            this.B_Pl_PhotoNext.Name = "B_Pl_PhotoNext";
            this.TLP_Pl_Photo.SetRowSpan(this.B_Pl_PhotoNext, 2);
            this.B_Pl_PhotoNext.Size = new System.Drawing.Size(165, 33);
            this.B_Pl_PhotoNext.TabIndex = 11;
            this.B_Pl_PhotoNext.UseVisualStyleBackColor = false;
            this.B_Pl_PhotoNext.Click += new System.EventHandler(this.B_Pl_PhotoNext_Click);
            // 
            // Pan_Pl_Video
            // 
            this.Pan_Pl_Video.BackColor = System.Drawing.Color.Black;
            this.Pan_Pl_Video.Controls.Add(this.TLP_Pl_Video);
            this.Pan_Pl_Video.Location = new System.Drawing.Point(135, 414);
            this.Pan_Pl_Video.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_Pl_Video.Name = "Pan_Pl_Video";
            this.Pan_Pl_Video.Size = new System.Drawing.Size(435, 63);
            this.Pan_Pl_Video.TabIndex = 10;
            // 
            // TLP_Pl_Video
            // 
            this.TLP_Pl_Video.ColumnCount = 8;
            this.TLP_Pl_Video.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Video.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Video.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Video.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Video.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Video.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Video.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Video.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_Pl_Video.Controls.Add(this.B_Pl_VideoNext, 6, 2);
            this.TLP_Pl_Video.Controls.Add(this.L_Pl_VideoPlayerName, 2, 0);
            this.TLP_Pl_Video.Controls.Add(this.L_Pl_Video_TimeLeft, 7, 1);
            this.TLP_Pl_Video.Controls.Add(this.B_Pl_VideoStop, 4, 2);
            this.TLP_Pl_Video.Controls.Add(this.L_Pl_Video_TimeCur, 0, 1);
            this.TLP_Pl_Video.Controls.Add(this.TRB_Pl_VideoTimer, 1, 1);
            this.TLP_Pl_Video.Controls.Add(this.B_Pl_VideoPlayPause, 2, 2);
            this.TLP_Pl_Video.Controls.Add(this.B_Pl_VideoPrevious, 0, 2);
            this.TLP_Pl_Video.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Pl_Video.Location = new System.Drawing.Point(0, 0);
            this.TLP_Pl_Video.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Pl_Video.Name = "TLP_Pl_Video";
            this.TLP_Pl_Video.RowCount = 4;
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Pl_Video.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Pl_Video.Size = new System.Drawing.Size(435, 63);
            this.TLP_Pl_Video.TabIndex = 0;
            // 
            // B_Pl_VideoNext
            // 
            this.B_Pl_VideoNext.BackColor = System.Drawing.Color.Black;
            this.B_Pl_VideoNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_VideoNext.BackgroundImage")));
            this.B_Pl_VideoNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP_Pl_Video.SetColumnSpan(this.B_Pl_VideoNext, 2);
            this.B_Pl_VideoNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_VideoNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_VideoNext.Location = new System.Drawing.Point(324, 30);
            this.B_Pl_VideoNext.Margin = new System.Windows.Forms.Padding(0);
            this.B_Pl_VideoNext.Name = "B_Pl_VideoNext";
            this.TLP_Pl_Video.SetRowSpan(this.B_Pl_VideoNext, 2);
            this.B_Pl_VideoNext.Size = new System.Drawing.Size(111, 33);
            this.B_Pl_VideoNext.TabIndex = 15;
            this.B_Pl_VideoNext.UseVisualStyleBackColor = false;
            this.B_Pl_VideoNext.Click += new System.EventHandler(this.B_Pl_VideoNext_Click);
            // 
            // L_Pl_VideoPlayerName
            // 
            this.L_Pl_VideoPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Pl_VideoPlayerName.AutoSize = true;
            this.L_Pl_VideoPlayerName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TLP_Pl_Video.SetColumnSpan(this.L_Pl_VideoPlayerName, 4);
            this.L_Pl_VideoPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Pl_VideoPlayerName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.L_Pl_VideoPlayerName.Location = new System.Drawing.Point(111, 0);
            this.L_Pl_VideoPlayerName.Name = "L_Pl_VideoPlayerName";
            this.L_Pl_VideoPlayerName.Size = new System.Drawing.Size(210, 15);
            this.L_Pl_VideoPlayerName.TabIndex = 7;
            this.L_Pl_VideoPlayerName.Text = "Просмотр видео";
            this.L_Pl_VideoPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_Pl_Video_TimeLeft
            // 
            this.L_Pl_Video_TimeLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Pl_Video_TimeLeft.AutoSize = true;
            this.L_Pl_Video_TimeLeft.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.L_Pl_Video_TimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Pl_Video_TimeLeft.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.L_Pl_Video_TimeLeft.Location = new System.Drawing.Point(381, 15);
            this.L_Pl_Video_TimeLeft.Name = "L_Pl_Video_TimeLeft";
            this.L_Pl_Video_TimeLeft.Size = new System.Drawing.Size(51, 15);
            this.L_Pl_Video_TimeLeft.TabIndex = 11;
            this.L_Pl_Video_TimeLeft.Text = "-01:00";
            this.L_Pl_Video_TimeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // B_Pl_VideoStop
            // 
            this.B_Pl_VideoStop.BackColor = System.Drawing.Color.Black;
            this.B_Pl_VideoStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_VideoStop.BackgroundImage")));
            this.B_Pl_VideoStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP_Pl_Video.SetColumnSpan(this.B_Pl_VideoStop, 2);
            this.B_Pl_VideoStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_VideoStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_VideoStop.Location = new System.Drawing.Point(216, 30);
            this.B_Pl_VideoStop.Margin = new System.Windows.Forms.Padding(0);
            this.B_Pl_VideoStop.Name = "B_Pl_VideoStop";
            this.TLP_Pl_Video.SetRowSpan(this.B_Pl_VideoStop, 2);
            this.B_Pl_VideoStop.Size = new System.Drawing.Size(108, 33);
            this.B_Pl_VideoStop.TabIndex = 14;
            this.B_Pl_VideoStop.UseVisualStyleBackColor = false;
            this.B_Pl_VideoStop.Click += new System.EventHandler(this.B_Pl_VideoStop_Click);
            // 
            // L_Pl_Video_TimeCur
            // 
            this.L_Pl_Video_TimeCur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Pl_Video_TimeCur.AutoSize = true;
            this.L_Pl_Video_TimeCur.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.L_Pl_Video_TimeCur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Pl_Video_TimeCur.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.L_Pl_Video_TimeCur.Location = new System.Drawing.Point(3, 15);
            this.L_Pl_Video_TimeCur.Name = "L_Pl_Video_TimeCur";
            this.L_Pl_Video_TimeCur.Size = new System.Drawing.Size(48, 15);
            this.L_Pl_Video_TimeCur.TabIndex = 10;
            this.L_Pl_Video_TimeCur.Text = "00:00";
            this.L_Pl_Video_TimeCur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TRB_Pl_VideoTimer
            // 
            this.TRB_Pl_VideoTimer.AutoSize = false;
            this.TLP_Pl_Video.SetColumnSpan(this.TRB_Pl_VideoTimer, 6);
            this.TRB_Pl_VideoTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TRB_Pl_VideoTimer.Location = new System.Drawing.Point(54, 15);
            this.TRB_Pl_VideoTimer.Margin = new System.Windows.Forms.Padding(0);
            this.TRB_Pl_VideoTimer.Maximum = 100;
            this.TRB_Pl_VideoTimer.Name = "TRB_Pl_VideoTimer";
            this.TRB_Pl_VideoTimer.Size = new System.Drawing.Size(324, 15);
            this.TRB_Pl_VideoTimer.TabIndex = 8;
            this.TRB_Pl_VideoTimer.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TRB_Pl_VideoTimer.Scroll += new System.EventHandler(this.TRB_Pl_VideoTimer_Scroll);
            // 
            // B_Pl_VideoPlayPause
            // 
            this.B_Pl_VideoPlayPause.BackColor = System.Drawing.Color.Black;
            this.B_Pl_VideoPlayPause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_VideoPlayPause.BackgroundImage")));
            this.B_Pl_VideoPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP_Pl_Video.SetColumnSpan(this.B_Pl_VideoPlayPause, 2);
            this.B_Pl_VideoPlayPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_VideoPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_VideoPlayPause.Location = new System.Drawing.Point(108, 30);
            this.B_Pl_VideoPlayPause.Margin = new System.Windows.Forms.Padding(0);
            this.B_Pl_VideoPlayPause.Name = "B_Pl_VideoPlayPause";
            this.TLP_Pl_Video.SetRowSpan(this.B_Pl_VideoPlayPause, 2);
            this.B_Pl_VideoPlayPause.Size = new System.Drawing.Size(108, 33);
            this.B_Pl_VideoPlayPause.TabIndex = 13;
            this.B_Pl_VideoPlayPause.UseVisualStyleBackColor = false;
            this.B_Pl_VideoPlayPause.Click += new System.EventHandler(this.B_Pl_VideoPlayPause_Click);
            // 
            // B_Pl_VideoPrevious
            // 
            this.B_Pl_VideoPrevious.BackColor = System.Drawing.Color.Black;
            this.B_Pl_VideoPrevious.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_VideoPrevious.BackgroundImage")));
            this.B_Pl_VideoPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP_Pl_Video.SetColumnSpan(this.B_Pl_VideoPrevious, 2);
            this.B_Pl_VideoPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_VideoPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_VideoPrevious.Location = new System.Drawing.Point(0, 30);
            this.B_Pl_VideoPrevious.Margin = new System.Windows.Forms.Padding(0);
            this.B_Pl_VideoPrevious.Name = "B_Pl_VideoPrevious";
            this.TLP_Pl_Video.SetRowSpan(this.B_Pl_VideoPrevious, 2);
            this.B_Pl_VideoPrevious.Size = new System.Drawing.Size(108, 33);
            this.B_Pl_VideoPrevious.TabIndex = 12;
            this.B_Pl_VideoPrevious.UseVisualStyleBackColor = false;
            this.B_Pl_VideoPrevious.Click += new System.EventHandler(this.B_Pl_VideoPrevious_Click);
            // 
            // L_SnapShotSaved
            // 
            this.L_SnapShotSaved.AutoSize = true;
            this.L_SnapShotSaved.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.L_SnapShotSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_SnapShotSaved.ForeColor = System.Drawing.Color.Lime;
            this.L_SnapShotSaved.Location = new System.Drawing.Point(0, 3);
            this.L_SnapShotSaved.Margin = new System.Windows.Forms.Padding(0);
            this.L_SnapShotSaved.Name = "L_SnapShotSaved";
            this.L_SnapShotSaved.Size = new System.Drawing.Size(152, 25);
            this.L_SnapShotSaved.TabIndex = 7;
            this.L_SnapShotSaved.Text = "Сохранение...";
            // 
            // P_ChargeLev
            // 
            this.P_ChargeLev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.P_ChargeLev.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.P_ChargeLev.Controls.Add(this.TLP_ChargeLev);
            this.P_ChargeLev.Location = new System.Drawing.Point(1162, 1);
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
            this.PB_Indicator.Location = new System.Drawing.Point(1134, 1);
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
            this.LBConsole.Size = new System.Drawing.Size(1278, 90);
            this.LBConsole.TabIndex = 0;
            this.LBConsole.Visible = false;
            this.LBConsole.SelectedIndexChanged += new System.EventHandler(this.LBConsole_SelectedIndexChanged);
            // 
            // CV_ImBox_Capture
            // 
            this.CV_ImBox_Capture.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CV_ImBox_Capture.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.CV_ImBox_Capture.Location = new System.Drawing.Point(0, 0);
            this.CV_ImBox_Capture.Name = "CV_ImBox_Capture";
            this.CV_ImBox_Capture.Size = new System.Drawing.Size(445, 242);
            this.CV_ImBox_Capture.TabIndex = 2;
            this.CV_ImBox_Capture.TabStop = false;
            this.CV_ImBox_Capture.Click += new System.EventHandler(this.CV_ImBox_Capture_Click);
            // 
            // Pan_Player
            // 
            this.Pan_Player.BackColor = System.Drawing.Color.Black;
            this.Pan_Player.Controls.Add(this.TLP_Pl_PlayerMain);
            this.Pan_Player.Location = new System.Drawing.Point(621, 484);
            this.Pan_Player.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_Player.Name = "Pan_Player";
            this.Pan_Player.Size = new System.Drawing.Size(623, 63);
            this.Pan_Player.TabIndex = 8;
            // 
            // TLP_Pl_PlayerMain
            // 
            this.TLP_Pl_PlayerMain.ColumnCount = 5;
            this.TLP_Pl_PlayerMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_Pl_PlayerMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_Pl_PlayerMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_Pl_PlayerMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TLP_Pl_PlayerMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_Pl_PlayerMain.Controls.Add(this.B_Pl_GoToMain, 4, 0);
            this.TLP_Pl_PlayerMain.Controls.Add(this.Pan_Pl_Base_forAnyPLCtrls, 3, 0);
            this.TLP_Pl_PlayerMain.Controls.Add(this.B_Pl_VideoMode, 0, 0);
            this.TLP_Pl_PlayerMain.Controls.Add(this.B_Pl_PhotoMode, 1, 0);
            this.TLP_Pl_PlayerMain.Controls.Add(this.B_Pl_3DMode, 2, 0);
            this.TLP_Pl_PlayerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Pl_PlayerMain.Location = new System.Drawing.Point(0, 0);
            this.TLP_Pl_PlayerMain.Margin = new System.Windows.Forms.Padding(0);
            this.TLP_Pl_PlayerMain.Name = "TLP_Pl_PlayerMain";
            this.TLP_Pl_PlayerMain.RowCount = 2;
            this.TLP_Pl_PlayerMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Pl_PlayerMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Pl_PlayerMain.Size = new System.Drawing.Size(623, 63);
            this.TLP_Pl_PlayerMain.TabIndex = 0;
            // 
            // B_Pl_GoToMain
            // 
            this.B_Pl_GoToMain.BackColor = System.Drawing.Color.Black;
            this.B_Pl_GoToMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_GoToMain.BackgroundImage")));
            this.B_Pl_GoToMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Pl_GoToMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_GoToMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_GoToMain.ForeColor = System.Drawing.Color.Black;
            this.B_Pl_GoToMain.Location = new System.Drawing.Point(530, 5);
            this.B_Pl_GoToMain.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.B_Pl_GoToMain.Name = "B_Pl_GoToMain";
            this.TLP_Pl_PlayerMain.SetRowSpan(this.B_Pl_GoToMain, 2);
            this.B_Pl_GoToMain.Size = new System.Drawing.Size(92, 53);
            this.B_Pl_GoToMain.TabIndex = 8;
            this.B_Pl_GoToMain.UseVisualStyleBackColor = false;
            this.B_Pl_GoToMain.Click += new System.EventHandler(this.B_Pl_GoToMain_Click);
            // 
            // Pan_Pl_Base_forAnyPLCtrls
            // 
            this.Pan_Pl_Base_forAnyPLCtrls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pan_Pl_Base_forAnyPLCtrls.Location = new System.Drawing.Point(93, 0);
            this.Pan_Pl_Base_forAnyPLCtrls.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_Pl_Base_forAnyPLCtrls.Name = "Pan_Pl_Base_forAnyPLCtrls";
            this.TLP_Pl_PlayerMain.SetRowSpan(this.Pan_Pl_Base_forAnyPLCtrls, 2);
            this.Pan_Pl_Base_forAnyPLCtrls.Size = new System.Drawing.Size(436, 63);
            this.Pan_Pl_Base_forAnyPLCtrls.TabIndex = 10;
            // 
            // B_Pl_VideoMode
            // 
            this.B_Pl_VideoMode.BackColor = System.Drawing.Color.Black;
            this.B_Pl_VideoMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_VideoMode.BackgroundImage")));
            this.B_Pl_VideoMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Pl_VideoMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_VideoMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_VideoMode.ForeColor = System.Drawing.Color.Black;
            this.B_Pl_VideoMode.Location = new System.Drawing.Point(2, 0);
            this.B_Pl_VideoMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.B_Pl_VideoMode.Name = "B_Pl_VideoMode";
            this.TLP_Pl_PlayerMain.SetRowSpan(this.B_Pl_VideoMode, 2);
            this.B_Pl_VideoMode.Size = new System.Drawing.Size(27, 63);
            this.B_Pl_VideoMode.TabIndex = 9;
            this.B_Pl_VideoMode.UseVisualStyleBackColor = false;
            this.B_Pl_VideoMode.Click += new System.EventHandler(this.B_Pl_VideoMode_Click);
            // 
            // B_Pl_PhotoMode
            // 
            this.B_Pl_PhotoMode.BackColor = System.Drawing.Color.Black;
            this.B_Pl_PhotoMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_PhotoMode.BackgroundImage")));
            this.B_Pl_PhotoMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Pl_PhotoMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_PhotoMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_PhotoMode.ForeColor = System.Drawing.Color.Black;
            this.B_Pl_PhotoMode.Location = new System.Drawing.Point(33, 2);
            this.B_Pl_PhotoMode.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.B_Pl_PhotoMode.Name = "B_Pl_PhotoMode";
            this.TLP_Pl_PlayerMain.SetRowSpan(this.B_Pl_PhotoMode, 2);
            this.B_Pl_PhotoMode.Size = new System.Drawing.Size(29, 59);
            this.B_Pl_PhotoMode.TabIndex = 7;
            this.B_Pl_PhotoMode.UseVisualStyleBackColor = false;
            this.B_Pl_PhotoMode.Click += new System.EventHandler(this.B_Pl_PhotoMode_Click);
            // 
            // B_Pl_3DMode
            // 
            this.B_Pl_3DMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Pl_3DMode.BackgroundImage")));
            this.B_Pl_3DMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Pl_3DMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Pl_3DMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pl_3DMode.Location = new System.Drawing.Point(62, 2);
            this.B_Pl_3DMode.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.B_Pl_3DMode.Name = "B_Pl_3DMode";
            this.TLP_Pl_PlayerMain.SetRowSpan(this.B_Pl_3DMode, 2);
            this.B_Pl_3DMode.Size = new System.Drawing.Size(31, 59);
            this.B_Pl_3DMode.TabIndex = 11;
            this.B_Pl_3DMode.UseVisualStyleBackColor = true;
            this.B_Pl_3DMode.Click += new System.EventHandler(this.B_Pl_3DMode_Click);
            // 
            // Pan_Export
            // 
            this.Pan_Export.BackColor = System.Drawing.Color.Black;
            this.Pan_Export.Controls.Add(this.TLP_ExportTable);
            this.Pan_Export.Location = new System.Drawing.Point(621, 405);
            this.Pan_Export.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_Export.Name = "Pan_Export";
            this.Pan_Export.Size = new System.Drawing.Size(623, 72);
            this.Pan_Export.TabIndex = 6;
            // 
            // TLP_ExportTable
            // 
            this.TLP_ExportTable.ColumnCount = 9;
            this.TLP_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TLP_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.TLP_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.TLP_ExportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TLP_ExportTable.Controls.Add(this.B_Ex_BackToMain, 8, 4);
            this.TLP_ExportTable.Controls.Add(this.B_Ex_MinusCount, 6, 6);
            this.TLP_ExportTable.Controls.Add(this.B_Ex_StartExport, 8, 0);
            this.TLP_ExportTable.Controls.Add(this.TB_Ex_PathTo, 4, 4);
            this.TLP_ExportTable.Controls.Add(this.L_Ex_Mode, 4, 0);
            this.TLP_ExportTable.Controls.Add(this.label8, 3, 4);
            this.TLP_ExportTable.Controls.Add(this.TB_Ex_PathFrom, 4, 2);
            this.TLP_ExportTable.Controls.Add(this.label9, 3, 6);
            this.TLP_ExportTable.Controls.Add(this.CB_Ex_ChooseExportMode, 4, 6);
            this.TLP_ExportTable.Controls.Add(this.B_Ex_Search_PathFrom, 5, 2);
            this.TLP_ExportTable.Controls.Add(this.B_Ex_Search_PathTo, 5, 4);
            this.TLP_ExportTable.Controls.Add(this.label7, 3, 2);
            this.TLP_ExportTable.Controls.Add(this.B_Ex_PlusCount, 7, 6);
            this.TLP_ExportTable.Controls.Add(this.TB_Ex_Count, 5, 6);
            this.TLP_ExportTable.Controls.Add(this.B_Ex_VideoMode, 0, 0);
            this.TLP_ExportTable.Controls.Add(this.B_Ex_PhotoMode, 1, 0);
            this.TLP_ExportTable.Controls.Add(this.B_Ex_3DMode, 2, 0);
            this.TLP_ExportTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_ExportTable.Location = new System.Drawing.Point(0, 0);
            this.TLP_ExportTable.Margin = new System.Windows.Forms.Padding(2);
            this.TLP_ExportTable.Name = "TLP_ExportTable";
            this.TLP_ExportTable.RowCount = 8;
            this.TLP_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_ExportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TLP_ExportTable.Size = new System.Drawing.Size(623, 72);
            this.TLP_ExportTable.TabIndex = 0;
            // 
            // B_Ex_BackToMain
            // 
            this.B_Ex_BackToMain.BackColor = System.Drawing.Color.Black;
            this.B_Ex_BackToMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Ex_BackToMain.BackgroundImage")));
            this.B_Ex_BackToMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Ex_BackToMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_BackToMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_BackToMain.ForeColor = System.Drawing.Color.Black;
            this.B_Ex_BackToMain.Location = new System.Drawing.Point(552, 36);
            this.B_Ex_BackToMain.Margin = new System.Windows.Forms.Padding(0);
            this.B_Ex_BackToMain.Name = "B_Ex_BackToMain";
            this.TLP_ExportTable.SetRowSpan(this.B_Ex_BackToMain, 4);
            this.B_Ex_BackToMain.Size = new System.Drawing.Size(71, 36);
            this.B_Ex_BackToMain.TabIndex = 8;
            this.B_Ex_BackToMain.UseVisualStyleBackColor = false;
            this.B_Ex_BackToMain.Click += new System.EventHandler(this.B_Ex_BackToMain_Click);
            // 
            // B_Ex_MinusCount
            // 
            this.B_Ex_MinusCount.BackColor = System.Drawing.Color.Black;
            this.B_Ex_MinusCount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Ex_MinusCount.BackgroundImage")));
            this.B_Ex_MinusCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Ex_MinusCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_MinusCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_MinusCount.ForeColor = System.Drawing.Color.White;
            this.B_Ex_MinusCount.Location = new System.Drawing.Point(507, 55);
            this.B_Ex_MinusCount.Margin = new System.Windows.Forms.Padding(1, 1, 1, 4);
            this.B_Ex_MinusCount.Name = "B_Ex_MinusCount";
            this.TLP_ExportTable.SetRowSpan(this.B_Ex_MinusCount, 2);
            this.B_Ex_MinusCount.Size = new System.Drawing.Size(21, 13);
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
            this.B_Ex_StartExport.Location = new System.Drawing.Point(552, 0);
            this.B_Ex_StartExport.Margin = new System.Windows.Forms.Padding(0);
            this.B_Ex_StartExport.Name = "B_Ex_StartExport";
            this.TLP_ExportTable.SetRowSpan(this.B_Ex_StartExport, 4);
            this.B_Ex_StartExport.Size = new System.Drawing.Size(71, 36);
            this.B_Ex_StartExport.TabIndex = 7;
            this.B_Ex_StartExport.UseVisualStyleBackColor = false;
            this.B_Ex_StartExport.Click += new System.EventHandler(this.B_Ex_StartExport_Click);
            // 
            // TB_Ex_PathTo
            // 
            this.TB_Ex_PathTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Ex_PathTo.BackColor = System.Drawing.Color.Black;
            this.TB_Ex_PathTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Ex_PathTo.ForeColor = System.Drawing.Color.White;
            this.TB_Ex_PathTo.Location = new System.Drawing.Point(229, 36);
            this.TB_Ex_PathTo.Margin = new System.Windows.Forms.Padding(0);
            this.TB_Ex_PathTo.Name = "TB_Ex_PathTo";
            this.TLP_ExportTable.SetRowSpan(this.TB_Ex_PathTo, 2);
            this.TB_Ex_PathTo.Size = new System.Drawing.Size(254, 26);
            this.TB_Ex_PathTo.TabIndex = 13;
            // 
            // L_Ex_Mode
            // 
            this.L_Ex_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Ex_Mode.AutoSize = true;
            this.L_Ex_Mode.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.L_Ex_Mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Ex_Mode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.L_Ex_Mode.Location = new System.Drawing.Point(232, 0);
            this.L_Ex_Mode.Name = "L_Ex_Mode";
            this.TLP_ExportTable.SetRowSpan(this.L_Ex_Mode, 2);
            this.L_Ex_Mode.Size = new System.Drawing.Size(248, 18);
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
            this.label8.Location = new System.Drawing.Point(107, 36);
            this.label8.Name = "label8";
            this.TLP_ExportTable.SetRowSpan(this.label8, 2);
            this.label8.Size = new System.Drawing.Size(119, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "Сохранить в:";
            // 
            // TB_Ex_PathFrom
            // 
            this.TB_Ex_PathFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Ex_PathFrom.BackColor = System.Drawing.Color.Black;
            this.TB_Ex_PathFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Ex_PathFrom.ForeColor = System.Drawing.Color.White;
            this.TB_Ex_PathFrom.Location = new System.Drawing.Point(229, 18);
            this.TB_Ex_PathFrom.Margin = new System.Windows.Forms.Padding(0);
            this.TB_Ex_PathFrom.Name = "TB_Ex_PathFrom";
            this.TLP_ExportTable.SetRowSpan(this.TB_Ex_PathFrom, 2);
            this.TB_Ex_PathFrom.Size = new System.Drawing.Size(254, 26);
            this.TB_Ex_PathFrom.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(153, 54);
            this.label9.Name = "label9";
            this.TLP_ExportTable.SetRowSpan(this.label9, 2);
            this.label9.Size = new System.Drawing.Size(73, 18);
            this.label9.TabIndex = 14;
            this.label9.Text = "Файлы:";
            // 
            // CB_Ex_ChooseExportMode
            // 
            this.CB_Ex_ChooseExportMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_Ex_ChooseExportMode.BackColor = System.Drawing.Color.Black;
            this.CB_Ex_ChooseExportMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Ex_ChooseExportMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CB_Ex_ChooseExportMode.ForeColor = System.Drawing.Color.White;
            this.CB_Ex_ChooseExportMode.FormattingEnabled = true;
            this.CB_Ex_ChooseExportMode.Items.AddRange(new object[] {
            "С момента последнего включения",
            "За время (укажите время в часах)",
            "Последние несколько (укажите количество)",
            "Все"});
            this.CB_Ex_ChooseExportMode.Location = new System.Drawing.Point(229, 55);
            this.CB_Ex_ChooseExportMode.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.CB_Ex_ChooseExportMode.Name = "CB_Ex_ChooseExportMode";
            this.TLP_ExportTable.SetRowSpan(this.CB_Ex_ChooseExportMode, 2);
            this.CB_Ex_ChooseExportMode.Size = new System.Drawing.Size(253, 28);
            this.CB_Ex_ChooseExportMode.TabIndex = 15;
            this.CB_Ex_ChooseExportMode.SelectedIndexChanged += new System.EventHandler(this.CB_Ex_ChooseExportMode_SelectedIndexChanged);
            // 
            // B_Ex_Search_PathFrom
            // 
            this.B_Ex_Search_PathFrom.BackColor = System.Drawing.Color.Black;
            this.B_Ex_Search_PathFrom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TLP_ExportTable.SetColumnSpan(this.B_Ex_Search_PathFrom, 3);
            this.B_Ex_Search_PathFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_Search_PathFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_Search_PathFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Ex_Search_PathFrom.ForeColor = System.Drawing.Color.White;
            this.B_Ex_Search_PathFrom.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_Ex_Search_PathFrom.Location = new System.Drawing.Point(483, 19);
            this.B_Ex_Search_PathFrom.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.B_Ex_Search_PathFrom.Name = "B_Ex_Search_PathFrom";
            this.TLP_ExportTable.SetRowSpan(this.B_Ex_Search_PathFrom, 2);
            this.B_Ex_Search_PathFrom.Size = new System.Drawing.Size(68, 16);
            this.B_Ex_Search_PathFrom.TabIndex = 7;
            this.B_Ex_Search_PathFrom.Text = "Обзор...";
            this.B_Ex_Search_PathFrom.UseVisualStyleBackColor = false;
            this.B_Ex_Search_PathFrom.Click += new System.EventHandler(this.B_Ex_Search_PathFrom_Click);
            // 
            // B_Ex_Search_PathTo
            // 
            this.B_Ex_Search_PathTo.BackColor = System.Drawing.Color.Black;
            this.TLP_ExportTable.SetColumnSpan(this.B_Ex_Search_PathTo, 3);
            this.B_Ex_Search_PathTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_Search_PathTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_Search_PathTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Ex_Search_PathTo.ForeColor = System.Drawing.Color.White;
            this.B_Ex_Search_PathTo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_Ex_Search_PathTo.Location = new System.Drawing.Point(483, 37);
            this.B_Ex_Search_PathTo.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.B_Ex_Search_PathTo.Name = "B_Ex_Search_PathTo";
            this.TLP_ExportTable.SetRowSpan(this.B_Ex_Search_PathTo, 2);
            this.B_Ex_Search_PathTo.Size = new System.Drawing.Size(68, 16);
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
            this.label7.Location = new System.Drawing.Point(77, 18);
            this.label7.Name = "label7";
            this.TLP_ExportTable.SetRowSpan(this.label7, 2);
            this.label7.Size = new System.Drawing.Size(149, 18);
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
            this.B_Ex_PlusCount.Location = new System.Drawing.Point(530, 55);
            this.B_Ex_PlusCount.Margin = new System.Windows.Forms.Padding(1, 1, 1, 4);
            this.B_Ex_PlusCount.Name = "B_Ex_PlusCount";
            this.TLP_ExportTable.SetRowSpan(this.B_Ex_PlusCount, 2);
            this.B_Ex_PlusCount.Size = new System.Drawing.Size(21, 13);
            this.B_Ex_PlusCount.TabIndex = 8;
            this.B_Ex_PlusCount.UseVisualStyleBackColor = false;
            this.B_Ex_PlusCount.Click += new System.EventHandler(this.B_Ex_PlusCount_Click);
            // 
            // TB_Ex_Count
            // 
            this.TB_Ex_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Ex_Count.BackColor = System.Drawing.Color.Black;
            this.TB_Ex_Count.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Ex_Count.ForeColor = System.Drawing.Color.White;
            this.TB_Ex_Count.Location = new System.Drawing.Point(483, 54);
            this.TB_Ex_Count.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.TB_Ex_Count.Name = "TB_Ex_Count";
            this.TB_Ex_Count.ReadOnly = true;
            this.TLP_ExportTable.SetRowSpan(this.TB_Ex_Count, 2);
            this.TB_Ex_Count.Size = new System.Drawing.Size(23, 29);
            this.TB_Ex_Count.TabIndex = 14;
            this.TB_Ex_Count.Text = "1";
            this.TB_Ex_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.TLP_ExportTable.SetRowSpan(this.B_Ex_VideoMode, 8);
            this.B_Ex_VideoMode.Size = new System.Drawing.Size(23, 72);
            this.B_Ex_VideoMode.TabIndex = 9;
            this.B_Ex_VideoMode.UseVisualStyleBackColor = false;
            this.B_Ex_VideoMode.Click += new System.EventHandler(this.B_Ex_VideoMode_Click);
            // 
            // B_Ex_PhotoMode
            // 
            this.B_Ex_PhotoMode.BackColor = System.Drawing.Color.Black;
            this.B_Ex_PhotoMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Ex_PhotoMode.BackgroundImage")));
            this.B_Ex_PhotoMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Ex_PhotoMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_PhotoMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_PhotoMode.ForeColor = System.Drawing.Color.Black;
            this.B_Ex_PhotoMode.Location = new System.Drawing.Point(23, 0);
            this.B_Ex_PhotoMode.Margin = new System.Windows.Forms.Padding(0);
            this.B_Ex_PhotoMode.Name = "B_Ex_PhotoMode";
            this.TLP_ExportTable.SetRowSpan(this.B_Ex_PhotoMode, 8);
            this.B_Ex_PhotoMode.Size = new System.Drawing.Size(23, 72);
            this.B_Ex_PhotoMode.TabIndex = 7;
            this.B_Ex_PhotoMode.UseVisualStyleBackColor = false;
            this.B_Ex_PhotoMode.Click += new System.EventHandler(this.B_Ex_PhotoMode_Click);
            // 
            // B_Ex_3DMode
            // 
            this.B_Ex_3DMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Ex_3DMode.BackgroundImage")));
            this.B_Ex_3DMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Ex_3DMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Ex_3DMode.Enabled = false;
            this.B_Ex_3DMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Ex_3DMode.Location = new System.Drawing.Point(46, 0);
            this.B_Ex_3DMode.Margin = new System.Windows.Forms.Padding(0);
            this.B_Ex_3DMode.Name = "B_Ex_3DMode";
            this.TLP_ExportTable.SetRowSpan(this.B_Ex_3DMode, 8);
            this.B_Ex_3DMode.Size = new System.Drawing.Size(23, 72);
            this.B_Ex_3DMode.TabIndex = 16;
            this.B_Ex_3DMode.UseVisualStyleBackColor = true;
            this.B_Ex_3DMode.Click += new System.EventHandler(this.B_Ex_3DMode_Click);
            // 
            // Pan_Settings
            // 
            this.Pan_Settings.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Pan_Settings.Controls.Add(this.TLP_Settings);
            this.Pan_Settings.Location = new System.Drawing.Point(619, 324);
            this.Pan_Settings.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_Settings.Name = "Pan_Settings";
            this.Pan_Settings.Size = new System.Drawing.Size(626, 77);
            this.Pan_Settings.TabIndex = 3;
            // 
            // TLP_Settings
            // 
            this.TLP_Settings.ColumnCount = 2;
            this.TLP_Settings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLP_Settings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_Settings.Controls.Add(this.TABC_Settings, 0, 0);
            this.TLP_Settings.Controls.Add(this.label6, 1, 1);
            this.TLP_Settings.Controls.Add(this.B_BackBut, 1, 0);
            this.TLP_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Settings.Location = new System.Drawing.Point(0, 0);
            this.TLP_Settings.Name = "TLP_Settings";
            this.TLP_Settings.RowCount = 2;
            this.TLP_Settings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLP_Settings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_Settings.Size = new System.Drawing.Size(626, 77);
            this.TLP_Settings.TabIndex = 0;
            // 
            // TABC_Settings
            // 
            this.TABC_Settings.Controls.Add(this.TPAGE_VidSettings);
            this.TABC_Settings.Controls.Add(this.TPAGE_PhotoSettings);
            this.TABC_Settings.Controls.Add(this.TPAGE_CameraSettings);
            this.TABC_Settings.Controls.Add(this.TPAGE_WB);
            this.TABC_Settings.Controls.Add(this.tabPage3);
            this.TABC_Settings.Controls.Add(this.tabPage5);
            this.TABC_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TABC_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TABC_Settings.Location = new System.Drawing.Point(0, 0);
            this.TABC_Settings.Margin = new System.Windows.Forms.Padding(0);
            this.TABC_Settings.Name = "TABC_Settings";
            this.TLP_Settings.SetRowSpan(this.TABC_Settings, 2);
            this.TABC_Settings.SelectedIndex = 0;
            this.TABC_Settings.Size = new System.Drawing.Size(500, 77);
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
            this.TPAGE_VidSettings.Size = new System.Drawing.Size(492, 48);
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
            this.TLP_Settings_Vid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TLP_Settings_Vid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TLP_Settings_Vid.Size = new System.Drawing.Size(492, 48);
            this.TLP_Settings_Vid.TabIndex = 15;
            this.TLP_Settings_Vid.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // TB_Settings_VidSavePath
            // 
            this.TB_Settings_VidSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Settings_VidSavePath.BackColor = System.Drawing.Color.Black;
            this.TB_Settings_VidSavePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Settings_VidSavePath.ForeColor = System.Drawing.Color.White;
            this.TB_Settings_VidSavePath.Location = new System.Drawing.Point(160, 0);
            this.TB_Settings_VidSavePath.Margin = new System.Windows.Forms.Padding(0);
            this.TB_Settings_VidSavePath.Name = "TB_Settings_VidSavePath";
            this.TB_Settings_VidSavePath.Size = new System.Drawing.Size(166, 35);
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
            this.label11.Location = new System.Drawing.Point(38, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "Сохранить в:";
            // 
            // B_Settings_FindVidPath
            // 
            this.B_Settings_FindVidPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Settings_FindVidPath.AutoSize = true;
            this.B_Settings_FindVidPath.BackColor = System.Drawing.Color.Black;
            this.B_Settings_FindVidPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Settings_FindVidPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Settings_FindVidPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Settings_FindVidPath.ForeColor = System.Drawing.Color.White;
            this.B_Settings_FindVidPath.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_Settings_FindVidPath.Location = new System.Drawing.Point(326, 1);
            this.B_Settings_FindVidPath.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.B_Settings_FindVidPath.Name = "B_Settings_FindVidPath";
            this.B_Settings_FindVidPath.Size = new System.Drawing.Size(165, 31);
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
            this.TPAGE_PhotoSettings.Size = new System.Drawing.Size(492, 48);
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
            this.TLP_Settings_Photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TLP_Settings_Photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TLP_Settings_Photo.Size = new System.Drawing.Size(492, 48);
            this.TLP_Settings_Photo.TabIndex = 6;
            this.TLP_Settings_Photo.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // TB_Settings_PhotoSavePath
            // 
            this.TB_Settings_PhotoSavePath.AcceptsReturn = true;
            this.TB_Settings_PhotoSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Settings_PhotoSavePath.BackColor = System.Drawing.Color.Black;
            this.TB_Settings_PhotoSavePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Settings_PhotoSavePath.ForeColor = System.Drawing.Color.White;
            this.TB_Settings_PhotoSavePath.Location = new System.Drawing.Point(160, 0);
            this.TB_Settings_PhotoSavePath.Margin = new System.Windows.Forms.Padding(0);
            this.TB_Settings_PhotoSavePath.Name = "TB_Settings_PhotoSavePath";
            this.TB_Settings_PhotoSavePath.Size = new System.Drawing.Size(166, 35);
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
            this.label10.Location = new System.Drawing.Point(38, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Сохранить в:";
            // 
            // B_Settings_FindPhotoPath
            // 
            this.B_Settings_FindPhotoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Settings_FindPhotoPath.AutoSize = true;
            this.B_Settings_FindPhotoPath.BackColor = System.Drawing.Color.Black;
            this.B_Settings_FindPhotoPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Settings_FindPhotoPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Settings_FindPhotoPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Settings_FindPhotoPath.ForeColor = System.Drawing.Color.White;
            this.B_Settings_FindPhotoPath.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_Settings_FindPhotoPath.Location = new System.Drawing.Point(326, 1);
            this.B_Settings_FindPhotoPath.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.B_Settings_FindPhotoPath.Name = "B_Settings_FindPhotoPath";
            this.B_Settings_FindPhotoPath.Size = new System.Drawing.Size(165, 31);
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
            this.TPAGE_CameraSettings.Size = new System.Drawing.Size(492, 48);
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
            this.TLP_Settings_Camera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
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
            this.TLP_Settings_Camera.Size = new System.Drawing.Size(492, 48);
            this.TLP_Settings_Camera.TabIndex = 16;
            this.TLP_Settings_Camera.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // TrBContrast
            // 
            this.TrBContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrBContrast.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TrBContrast.Location = new System.Drawing.Point(158, 19);
            this.TrBContrast.Maximum = 100;
            this.TrBContrast.Name = "TrBContrast";
            this.TrBContrast.Size = new System.Drawing.Size(29, 10);
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
            this.L_Settings_l1.Location = new System.Drawing.Point(67, 0);
            this.L_Settings_l1.Name = "L_Settings_l1";
            this.L_Settings_l1.Size = new System.Drawing.Size(85, 16);
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
            this.TrBBrightness.Size = new System.Drawing.Size(29, 10);
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
            this.LBrigthnessValue.Location = new System.Drawing.Point(207, 0);
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
            this.LContrastValue.Location = new System.Drawing.Point(207, 16);
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
            this.L_Settings_l2.Location = new System.Drawing.Point(58, 16);
            this.L_Settings_l2.Name = "L_Settings_l2";
            this.L_Settings_l2.Size = new System.Drawing.Size(94, 16);
            this.L_Settings_l2.TabIndex = 31;
            this.L_Settings_l2.Text = "Контраст:";
            // 
            // LSaturationValue
            // 
            this.LSaturationValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LSaturationValue.AutoSize = true;
            this.LSaturationValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSaturationValue.ForeColor = System.Drawing.Color.White;
            this.LSaturationValue.Location = new System.Drawing.Point(207, 32);
            this.LSaturationValue.Name = "LSaturationValue";
            this.LSaturationValue.Size = new System.Drawing.Size(16, 16);
            this.LSaturationValue.TabIndex = 45;
            this.LSaturationValue.Text = "0";
            // 
            // TrBSaturation
            // 
            this.TrBSaturation.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TrBSaturation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrBSaturation.Location = new System.Drawing.Point(158, 35);
            this.TrBSaturation.Maximum = 130;
            this.TrBSaturation.Name = "TrBSaturation";
            this.TrBSaturation.Size = new System.Drawing.Size(29, 10);
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
            this.L_Settings_l3.Location = new System.Drawing.Point(11, 32);
            this.L_Settings_l3.Name = "L_Settings_l3";
            this.L_Settings_l3.Size = new System.Drawing.Size(141, 16);
            this.L_Settings_l3.TabIndex = 40;
            this.L_Settings_l3.Text = "Насыщенность:";
            // 
            // L_Settings_l4
            // 
            this.L_Settings_l4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L_Settings_l4.AutoSize = true;
            this.L_Settings_l4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Settings_l4.ForeColor = System.Drawing.Color.White;
            this.L_Settings_l4.Location = new System.Drawing.Point(246, 0);
            this.L_Settings_l4.Name = "L_Settings_l4";
            this.L_Settings_l4.Size = new System.Drawing.Size(146, 16);
            this.L_Settings_l4.TabIndex = 42;
            this.L_Settings_l4.Text = "Осветленность:";
            // 
            // L_Settings_l5
            // 
            this.L_Settings_l5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.L_Settings_l5.AutoSize = true;
            this.L_Settings_l5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Settings_l5.ForeColor = System.Drawing.Color.White;
            this.L_Settings_l5.Location = new System.Drawing.Point(297, 16);
            this.L_Settings_l5.Name = "L_Settings_l5";
            this.L_Settings_l5.Size = new System.Drawing.Size(95, 16);
            this.L_Settings_l5.TabIndex = 43;
            this.L_Settings_l5.Text = "Усиление:";
            // 
            // TrBGamma
            // 
            this.TrBGamma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrBGamma.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TrBGamma.Location = new System.Drawing.Point(398, 3);
            this.TrBGamma.Maximum = 500;
            this.TrBGamma.Name = "TrBGamma";
            this.TrBGamma.Size = new System.Drawing.Size(29, 10);
            this.TrBGamma.TabIndex = 51;
            this.TrBGamma.TickFrequency = 5;
            this.TrBGamma.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBGamma.Scroll += new System.EventHandler(this.TrBGamma_Scroll);
            // 
            // TrBGain
            // 
            this.TrBGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrBGain.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TrBGain.Location = new System.Drawing.Point(398, 19);
            this.TrBGain.Maximum = 100;
            this.TrBGain.Name = "TrBGain";
            this.TrBGain.Size = new System.Drawing.Size(29, 10);
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
            this.LGammaValue.Location = new System.Drawing.Point(453, 0);
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
            this.LGainValue.Location = new System.Drawing.Point(453, 16);
            this.LGainValue.Name = "LGainValue";
            this.LGainValue.Size = new System.Drawing.Size(16, 16);
            this.LGainValue.TabIndex = 49;
            this.LGainValue.Text = "0";
            // 
            // TPAGE_WB
            // 
            this.TPAGE_WB.BackColor = System.Drawing.Color.Black;
            this.TPAGE_WB.Controls.Add(this.tableLayoutPanel1);
            this.TPAGE_WB.Location = new System.Drawing.Point(4, 25);
            this.TPAGE_WB.Margin = new System.Windows.Forms.Padding(2);
            this.TPAGE_WB.Name = "TPAGE_WB";
            this.TPAGE_WB.Padding = new System.Windows.Forms.Padding(2);
            this.TPAGE_WB.Size = new System.Drawing.Size(492, 48);
            this.TPAGE_WB.TabIndex = 5;
            this.TPAGE_WB.Text = "Баланс Белого";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.B_WB_LowerFrames, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.B_WB_HigherFrames, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.L_WB_NumOfImages, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label17, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.L_WB_CorPower, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.TrB_WB_CorPower, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.B_WB_Calculate, 7, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 44);
            this.tableLayoutPanel1.TabIndex = 16;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(4, 6);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 32);
            this.label15.TabIndex = 0;
            this.label15.Text = "Количество изображений";
            // 
            // B_WB_LowerFrames
            // 
            this.B_WB_LowerFrames.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_WB_LowerFrames.BackgroundImage")));
            this.B_WB_LowerFrames.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_WB_LowerFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_WB_LowerFrames.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.B_WB_LowerFrames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_WB_LowerFrames.ForeColor = System.Drawing.Color.White;
            this.B_WB_LowerFrames.Location = new System.Drawing.Point(119, 2);
            this.B_WB_LowerFrames.Margin = new System.Windows.Forms.Padding(2);
            this.B_WB_LowerFrames.Name = "B_WB_LowerFrames";
            this.B_WB_LowerFrames.Size = new System.Drawing.Size(43, 40);
            this.B_WB_LowerFrames.TabIndex = 1;
            this.B_WB_LowerFrames.UseVisualStyleBackColor = false;
            this.B_WB_LowerFrames.Click += new System.EventHandler(this.B_WB_LowerFrames_Click);
            // 
            // B_WB_HigherFrames
            // 
            this.B_WB_HigherFrames.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_WB_HigherFrames.BackgroundImage")));
            this.B_WB_HigherFrames.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_WB_HigherFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_WB_HigherFrames.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.B_WB_HigherFrames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_WB_HigherFrames.ForeColor = System.Drawing.Color.White;
            this.B_WB_HigherFrames.Location = new System.Drawing.Point(213, 2);
            this.B_WB_HigherFrames.Margin = new System.Windows.Forms.Padding(2);
            this.B_WB_HigherFrames.Name = "B_WB_HigherFrames";
            this.B_WB_HigherFrames.Size = new System.Drawing.Size(43, 40);
            this.B_WB_HigherFrames.TabIndex = 2;
            this.B_WB_HigherFrames.UseVisualStyleBackColor = true;
            this.B_WB_HigherFrames.Click += new System.EventHandler(this.B_WB_HigherFrames_Click);
            // 
            // L_WB_NumOfImages
            // 
            this.L_WB_NumOfImages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L_WB_NumOfImages.AutoSize = true;
            this.L_WB_NumOfImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_WB_NumOfImages.ForeColor = System.Drawing.Color.White;
            this.L_WB_NumOfImages.Location = new System.Drawing.Point(174, 7);
            this.L_WB_NumOfImages.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_WB_NumOfImages.Name = "L_WB_NumOfImages";
            this.L_WB_NumOfImages.Size = new System.Drawing.Size(27, 29);
            this.L_WB_NumOfImages.TabIndex = 3;
            this.L_WB_NumOfImages.Tag = "1";
            this.L_WB_NumOfImages.Text = "2";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(261, 6);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 32);
            this.label17.TabIndex = 4;
            this.label17.Text = "Степень коррекции";
            // 
            // L_WB_CorPower
            // 
            this.L_WB_CorPower.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.L_WB_CorPower.AutoSize = true;
            this.L_WB_CorPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_WB_CorPower.ForeColor = System.Drawing.Color.White;
            this.L_WB_CorPower.Location = new System.Drawing.Point(324, 7);
            this.L_WB_CorPower.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_WB_CorPower.Name = "L_WB_CorPower";
            this.L_WB_CorPower.Size = new System.Drawing.Size(27, 29);
            this.L_WB_CorPower.TabIndex = 5;
            this.L_WB_CorPower.Text = "1";
            // 
            // TrB_WB_CorPower
            // 
            this.TrB_WB_CorPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrB_WB_CorPower.AutoSize = false;
            this.TrB_WB_CorPower.Location = new System.Drawing.Point(353, 10);
            this.TrB_WB_CorPower.Margin = new System.Windows.Forms.Padding(2);
            this.TrB_WB_CorPower.Maximum = 100;
            this.TrB_WB_CorPower.Name = "TrB_WB_CorPower";
            this.TrB_WB_CorPower.Size = new System.Drawing.Size(1, 23);
            this.TrB_WB_CorPower.TabIndex = 6;
            this.TrB_WB_CorPower.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrB_WB_CorPower.Value = 100;
            this.TrB_WB_CorPower.Scroll += new System.EventHandler(this.TrB_WB_CorPower_Scroll);
            // 
            // B_WB_Calculate
            // 
            this.B_WB_Calculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_WB_Calculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_WB_Calculate.ForeColor = System.Drawing.Color.White;
            this.B_WB_Calculate.Location = new System.Drawing.Point(388, 0);
            this.B_WB_Calculate.Margin = new System.Windows.Forms.Padding(0);
            this.B_WB_Calculate.Name = "B_WB_Calculate";
            this.B_WB_Calculate.Size = new System.Drawing.Size(100, 44);
            this.B_WB_Calculate.TabIndex = 7;
            this.B_WB_Calculate.Text = "Вычислить";
            this.B_WB_Calculate.UseVisualStyleBackColor = true;
            this.B_WB_Calculate.Click += new System.EventHandler(this.B_WB_Calculate_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Black;
            this.tabPage3.Controls.Add(this.TB_Set_CalibStereoFilePath);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(492, 48);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Настройки приложения";
            // 
            // TB_Set_CalibStereoFilePath
            // 
            this.TB_Set_CalibStereoFilePath.ColumnCount = 3;
            this.TB_Set_CalibStereoFilePath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.TB_Set_CalibStereoFilePath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TB_Set_CalibStereoFilePath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TB_Set_CalibStereoFilePath.Controls.Add(this.label18, 0, 1);
            this.TB_Set_CalibStereoFilePath.Controls.Add(this.label14, 0, 0);
            this.TB_Set_CalibStereoFilePath.Controls.Add(this.textBox1, 1, 0);
            this.TB_Set_CalibStereoFilePath.Controls.Add(this.TB_Set_CalibWBFilePath, 1, 1);
            this.TB_Set_CalibStereoFilePath.Controls.Add(this.B_Set_FindWBCalibFile, 2, 1);
            this.TB_Set_CalibStereoFilePath.Controls.Add(this.B_Set_FindStereoCalibFile, 2, 0);
            this.TB_Set_CalibStereoFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Set_CalibStereoFilePath.Location = new System.Drawing.Point(0, 0);
            this.TB_Set_CalibStereoFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.TB_Set_CalibStereoFilePath.Name = "TB_Set_CalibStereoFilePath";
            this.TB_Set_CalibStereoFilePath.RowCount = 2;
            this.TB_Set_CalibStereoFilePath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TB_Set_CalibStereoFilePath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TB_Set_CalibStereoFilePath.Size = new System.Drawing.Size(492, 48);
            this.TB_Set_CalibStereoFilePath.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label18.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label18.Location = new System.Drawing.Point(92, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(198, 20);
            this.label18.TabIndex = 18;
            this.label18.Text = "Файл калибровки WB:";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label14.Location = new System.Drawing.Point(61, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(229, 20);
            this.label14.TabIndex = 14;
            this.label14.Text = "Файл калибровки стерео:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(293, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 35);
            this.textBox1.TabIndex = 13;
            // 
            // TB_Set_CalibWBFilePath
            // 
            this.TB_Set_CalibWBFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Set_CalibWBFilePath.BackColor = System.Drawing.Color.Black;
            this.TB_Set_CalibWBFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Set_CalibWBFilePath.ForeColor = System.Drawing.Color.White;
            this.TB_Set_CalibWBFilePath.Location = new System.Drawing.Point(293, 24);
            this.TB_Set_CalibWBFilePath.Margin = new System.Windows.Forms.Padding(0);
            this.TB_Set_CalibWBFilePath.Name = "TB_Set_CalibWBFilePath";
            this.TB_Set_CalibWBFilePath.Size = new System.Drawing.Size(99, 35);
            this.TB_Set_CalibWBFilePath.TabIndex = 17;
            // 
            // B_Set_FindWBCalibFile
            // 
            this.B_Set_FindWBCalibFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Set_FindWBCalibFile.AutoSize = true;
            this.B_Set_FindWBCalibFile.BackColor = System.Drawing.Color.Black;
            this.B_Set_FindWBCalibFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Set_FindWBCalibFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Set_FindWBCalibFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Set_FindWBCalibFile.ForeColor = System.Drawing.Color.White;
            this.B_Set_FindWBCalibFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_Set_FindWBCalibFile.Location = new System.Drawing.Point(392, 25);
            this.B_Set_FindWBCalibFile.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.B_Set_FindWBCalibFile.Name = "B_Set_FindWBCalibFile";
            this.B_Set_FindWBCalibFile.Size = new System.Drawing.Size(99, 22);
            this.B_Set_FindWBCalibFile.TabIndex = 16;
            this.B_Set_FindWBCalibFile.Text = "Обзор...";
            this.B_Set_FindWBCalibFile.UseVisualStyleBackColor = false;
            this.B_Set_FindWBCalibFile.Click += new System.EventHandler(this.B_Set_FindWBCalibFile_Click);
            // 
            // B_Set_FindStereoCalibFile
            // 
            this.B_Set_FindStereoCalibFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Set_FindStereoCalibFile.AutoSize = true;
            this.B_Set_FindStereoCalibFile.BackColor = System.Drawing.Color.Black;
            this.B_Set_FindStereoCalibFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Set_FindStereoCalibFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Set_FindStereoCalibFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Set_FindStereoCalibFile.ForeColor = System.Drawing.Color.White;
            this.B_Set_FindStereoCalibFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_Set_FindStereoCalibFile.Location = new System.Drawing.Point(392, 1);
            this.B_Set_FindStereoCalibFile.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.B_Set_FindStereoCalibFile.Name = "B_Set_FindStereoCalibFile";
            this.B_Set_FindStereoCalibFile.Size = new System.Drawing.Size(99, 22);
            this.B_Set_FindStereoCalibFile.TabIndex = 15;
            this.B_Set_FindStereoCalibFile.Text = "Обзор...";
            this.B_Set_FindStereoCalibFile.UseVisualStyleBackColor = false;
            this.B_Set_FindStereoCalibFile.Click += new System.EventHandler(this.B_Set_FindStereoCalibFile_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(492, 48);
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
            this.label6.Location = new System.Drawing.Point(531, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Назад";
            // 
            // B_BackBut
            // 
            this.B_BackBut.BackColor = System.Drawing.Color.Black;
            this.B_BackBut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_BackBut.BackgroundImage")));
            this.B_BackBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_BackBut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_BackBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_BackBut.Location = new System.Drawing.Point(503, 3);
            this.B_BackBut.Name = "B_BackBut";
            this.B_BackBut.Size = new System.Drawing.Size(120, 55);
            this.B_BackBut.TabIndex = 8;
            this.B_BackBut.UseVisualStyleBackColor = false;
            this.B_BackBut.Click += new System.EventHandler(this.B_BackBut_Click);
            // 
            // Pan_MainMenu
            // 
            this.Pan_MainMenu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Pan_MainMenu.Controls.Add(this.TLP_UserMainPanel);
            this.Pan_MainMenu.Location = new System.Drawing.Point(619, 171);
            this.Pan_MainMenu.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_MainMenu.Name = "Pan_MainMenu";
            this.Pan_MainMenu.Size = new System.Drawing.Size(626, 71);
            this.Pan_MainMenu.TabIndex = 4;
            // 
            // TLP_UserMainPanel
            // 
            this.TLP_UserMainPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TLP_UserMainPanel.ColumnCount = 7;
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.TLP_UserMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.TLP_UserMainPanel.Controls.Add(this.label13, 3, 1);
            this.TLP_UserMainPanel.Controls.Add(this.B_ViewMode, 2, 0);
            this.TLP_UserMainPanel.Controls.Add(this.label12, 2, 1);
            this.TLP_UserMainPanel.Controls.Add(this.label5, 4, 1);
            this.TLP_UserMainPanel.Controls.Add(this.B_ExportMode, 4, 0);
            this.TLP_UserMainPanel.Controls.Add(this.label2, 1, 1);
            this.TLP_UserMainPanel.Controls.Add(this.B_Photo_or_PauseRec, 1, 0);
            this.TLP_UserMainPanel.Controls.Add(this.B_SwitchRec, 0, 0);
            this.TLP_UserMainPanel.Controls.Add(this.label1, 0, 1);
            this.TLP_UserMainPanel.Controls.Add(this.B_Quit, 6, 0);
            this.TLP_UserMainPanel.Controls.Add(this.label4, 6, 1);
            this.TLP_UserMainPanel.Controls.Add(this.B_Settings, 5, 0);
            this.TLP_UserMainPanel.Controls.Add(this.label3, 5, 1);
            this.TLP_UserMainPanel.Controls.Add(this.B_MeasureMode, 3, 0);
            this.TLP_UserMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_UserMainPanel.Location = new System.Drawing.Point(0, 0);
            this.TLP_UserMainPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.TLP_UserMainPanel.Name = "TLP_UserMainPanel";
            this.TLP_UserMainPanel.RowCount = 2;
            this.TLP_UserMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLP_UserMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_UserMainPanel.Size = new System.Drawing.Size(626, 71);
            this.TLP_UserMainPanel.TabIndex = 2;
            this.TLP_UserMainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TLP_UserMainPanel_Paint);
            this.TLP_UserMainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TLP_UserMainPanel_MouseMove);
            this.TLP_UserMainPanel.Resize += new System.EventHandler(this.TLP_UserMainPanel_Resize);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(270, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "Измерения";
            // 
            // B_ViewMode
            // 
            this.B_ViewMode.BackColor = System.Drawing.Color.Black;
            this.B_ViewMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_ViewMode.BackgroundImage")));
            this.B_ViewMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_ViewMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_ViewMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_ViewMode.Location = new System.Drawing.Point(181, 3);
            this.B_ViewMode.Name = "B_ViewMode";
            this.B_ViewMode.Size = new System.Drawing.Size(83, 50);
            this.B_ViewMode.TabIndex = 10;
            this.B_ViewMode.UseVisualStyleBackColor = false;
            this.B_ViewMode.Click += new System.EventHandler(this.B_ViewMode_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(181, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 15);
            this.label12.TabIndex = 12;
            this.label12.Text = "Просмотр";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(360, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Экспорт";
            // 
            // B_ExportMode
            // 
            this.B_ExportMode.BackColor = System.Drawing.Color.Black;
            this.B_ExportMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_ExportMode.BackgroundImage")));
            this.B_ExportMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_ExportMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_ExportMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_ExportMode.Location = new System.Drawing.Point(359, 3);
            this.B_ExportMode.Name = "B_ExportMode";
            this.B_ExportMode.Size = new System.Drawing.Size(83, 50);
            this.B_ExportMode.TabIndex = 10;
            this.B_ExportMode.UseVisualStyleBackColor = false;
            this.B_ExportMode.Click += new System.EventHandler(this.B_Export_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(97, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Снимок";
            // 
            // B_Photo_or_PauseRec
            // 
            this.B_Photo_or_PauseRec.BackColor = System.Drawing.Color.Black;
            this.B_Photo_or_PauseRec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Photo_or_PauseRec.BackgroundImage")));
            this.B_Photo_or_PauseRec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Photo_or_PauseRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Photo_or_PauseRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Photo_or_PauseRec.Location = new System.Drawing.Point(92, 3);
            this.B_Photo_or_PauseRec.Name = "B_Photo_or_PauseRec";
            this.B_Photo_or_PauseRec.Size = new System.Drawing.Size(83, 50);
            this.B_Photo_or_PauseRec.TabIndex = 1;
            this.B_Photo_or_PauseRec.UseVisualStyleBackColor = false;
            this.B_Photo_or_PauseRec.Click += new System.EventHandler(this.B_Photo_or_PauseRec_Click);
            this.B_Photo_or_PauseRec.MouseMove += new System.Windows.Forms.MouseEventHandler(this.B_Photo_or_PauseRec_MouseMove);
            // 
            // B_SwitchRec
            // 
            this.B_SwitchRec.BackColor = System.Drawing.Color.Black;
            this.B_SwitchRec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_SwitchRec.BackgroundImage")));
            this.B_SwitchRec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_SwitchRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_SwitchRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_SwitchRec.Location = new System.Drawing.Point(3, 3);
            this.B_SwitchRec.Name = "B_SwitchRec";
            this.B_SwitchRec.Size = new System.Drawing.Size(83, 50);
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
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Запись";
            // 
            // B_Quit
            // 
            this.B_Quit.BackColor = System.Drawing.Color.Black;
            this.B_Quit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Quit.BackgroundImage")));
            this.B_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Quit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Quit.Location = new System.Drawing.Point(537, 3);
            this.B_Quit.Name = "B_Quit";
            this.B_Quit.Size = new System.Drawing.Size(86, 50);
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
            this.label4.Location = new System.Drawing.Point(537, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Выключение";
            // 
            // B_Settings
            // 
            this.B_Settings.BackColor = System.Drawing.Color.Black;
            this.B_Settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Settings.BackgroundImage")));
            this.B_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Settings.Location = new System.Drawing.Point(448, 3);
            this.B_Settings.Name = "B_Settings";
            this.B_Settings.Size = new System.Drawing.Size(83, 50);
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
            this.label3.Location = new System.Drawing.Point(449, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Настройки";
            // 
            // B_MeasureMode
            // 
            this.B_MeasureMode.BackColor = System.Drawing.Color.Black;
            this.B_MeasureMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_MeasureMode.BackgroundImage")));
            this.B_MeasureMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_MeasureMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_MeasureMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_MeasureMode.Location = new System.Drawing.Point(269, 2);
            this.B_MeasureMode.Margin = new System.Windows.Forms.Padding(2);
            this.B_MeasureMode.Name = "B_MeasureMode";
            this.B_MeasureMode.Size = new System.Drawing.Size(85, 52);
            this.B_MeasureMode.TabIndex = 13;
            this.B_MeasureMode.UseVisualStyleBackColor = false;
            this.B_MeasureMode.Click += new System.EventHandler(this.B_MeasureMode_Click);
            // 
            // Pan_Measurements
            // 
            this.Pan_Measurements.BackColor = System.Drawing.Color.Black;
            this.Pan_Measurements.Controls.Add(this.tableLayoutPanel2);
            this.Pan_Measurements.Location = new System.Drawing.Point(619, 246);
            this.Pan_Measurements.Margin = new System.Windows.Forms.Padding(2);
            this.Pan_Measurements.Name = "Pan_Measurements";
            this.Pan_Measurements.Size = new System.Drawing.Size(626, 77);
            this.Pan_Measurements.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.Controls.Add(this.ChB_Mes_Area, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.ChB_Mes_Perimeter, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.ChB_Mes_LenghtOfBroken, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.ChB_Mes_p2pl, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.ChB_Mes_p2l, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ChB_Mes_p2p, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.B_Mes_DeleteAll, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.B_Mes_Reconstruct3D, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.B_Mes_Back, 8, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(626, 77);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ChB_Mes_Area
            // 
            this.ChB_Mes_Area.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_Mes_Area.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChB_Mes_Area.BackgroundImage")));
            this.ChB_Mes_Area.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChB_Mes_Area.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Mes_Area.FlatAppearance.BorderSize = 0;
            this.ChB_Mes_Area.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ChB_Mes_Area.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ChB_Mes_Area.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChB_Mes_Area.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChB_Mes_Area.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ChB_Mes_Area.Location = new System.Drawing.Point(345, 3);
            this.ChB_Mes_Area.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ChB_Mes_Area.Name = "ChB_Mes_Area";
            this.tableLayoutPanel2.SetRowSpan(this.ChB_Mes_Area, 2);
            this.ChB_Mes_Area.Size = new System.Drawing.Size(69, 74);
            this.ChB_Mes_Area.TabIndex = 14;
            this.ChB_Mes_Area.Text = "Площадь";
            this.ChB_Mes_Area.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ChB_Mes_Area.UseVisualStyleBackColor = true;
            this.ChB_Mes_Area.CheckedChanged += new System.EventHandler(this.ChB_Mes_Area_CheckedChanged);
            // 
            // ChB_Mes_Perimeter
            // 
            this.ChB_Mes_Perimeter.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_Mes_Perimeter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChB_Mes_Perimeter.BackgroundImage")));
            this.ChB_Mes_Perimeter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChB_Mes_Perimeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Mes_Perimeter.FlatAppearance.BorderSize = 0;
            this.ChB_Mes_Perimeter.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ChB_Mes_Perimeter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ChB_Mes_Perimeter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChB_Mes_Perimeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChB_Mes_Perimeter.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ChB_Mes_Perimeter.Location = new System.Drawing.Point(276, 3);
            this.ChB_Mes_Perimeter.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ChB_Mes_Perimeter.Name = "ChB_Mes_Perimeter";
            this.tableLayoutPanel2.SetRowSpan(this.ChB_Mes_Perimeter, 2);
            this.ChB_Mes_Perimeter.Size = new System.Drawing.Size(69, 74);
            this.ChB_Mes_Perimeter.TabIndex = 13;
            this.ChB_Mes_Perimeter.Text = "Периметр";
            this.ChB_Mes_Perimeter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ChB_Mes_Perimeter.UseVisualStyleBackColor = true;
            this.ChB_Mes_Perimeter.CheckedChanged += new System.EventHandler(this.ChB_Mes_Perimeter_CheckedChanged);
            // 
            // ChB_Mes_LenghtOfBroken
            // 
            this.ChB_Mes_LenghtOfBroken.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_Mes_LenghtOfBroken.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChB_Mes_LenghtOfBroken.BackgroundImage")));
            this.ChB_Mes_LenghtOfBroken.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChB_Mes_LenghtOfBroken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Mes_LenghtOfBroken.FlatAppearance.BorderSize = 0;
            this.ChB_Mes_LenghtOfBroken.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ChB_Mes_LenghtOfBroken.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ChB_Mes_LenghtOfBroken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChB_Mes_LenghtOfBroken.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChB_Mes_LenghtOfBroken.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ChB_Mes_LenghtOfBroken.Location = new System.Drawing.Point(207, 3);
            this.ChB_Mes_LenghtOfBroken.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ChB_Mes_LenghtOfBroken.Name = "ChB_Mes_LenghtOfBroken";
            this.tableLayoutPanel2.SetRowSpan(this.ChB_Mes_LenghtOfBroken, 2);
            this.ChB_Mes_LenghtOfBroken.Size = new System.Drawing.Size(69, 74);
            this.ChB_Mes_LenghtOfBroken.TabIndex = 12;
            this.ChB_Mes_LenghtOfBroken.Text = "Длина ломаной";
            this.ChB_Mes_LenghtOfBroken.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ChB_Mes_LenghtOfBroken.UseVisualStyleBackColor = true;
            this.ChB_Mes_LenghtOfBroken.CheckedChanged += new System.EventHandler(this.ChB_Mes_LenghtOfBroken_CheckedChanged);
            // 
            // ChB_Mes_p2pl
            // 
            this.ChB_Mes_p2pl.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_Mes_p2pl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChB_Mes_p2pl.BackgroundImage")));
            this.ChB_Mes_p2pl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChB_Mes_p2pl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Mes_p2pl.FlatAppearance.BorderSize = 0;
            this.ChB_Mes_p2pl.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ChB_Mes_p2pl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ChB_Mes_p2pl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChB_Mes_p2pl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChB_Mes_p2pl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ChB_Mes_p2pl.Location = new System.Drawing.Point(138, 3);
            this.ChB_Mes_p2pl.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ChB_Mes_p2pl.Name = "ChB_Mes_p2pl";
            this.tableLayoutPanel2.SetRowSpan(this.ChB_Mes_p2pl, 2);
            this.ChB_Mes_p2pl.Size = new System.Drawing.Size(69, 74);
            this.ChB_Mes_p2pl.TabIndex = 11;
            this.ChB_Mes_p2pl.Text = "Расстояние   до плоскости";
            this.ChB_Mes_p2pl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ChB_Mes_p2pl.UseVisualStyleBackColor = true;
            this.ChB_Mes_p2pl.CheckedChanged += new System.EventHandler(this.ChB_Mes_p2pl_CheckedChanged);
            // 
            // ChB_Mes_p2l
            // 
            this.ChB_Mes_p2l.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_Mes_p2l.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChB_Mes_p2l.BackgroundImage")));
            this.ChB_Mes_p2l.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChB_Mes_p2l.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Mes_p2l.FlatAppearance.BorderSize = 0;
            this.ChB_Mes_p2l.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ChB_Mes_p2l.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ChB_Mes_p2l.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChB_Mes_p2l.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChB_Mes_p2l.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ChB_Mes_p2l.Location = new System.Drawing.Point(69, 3);
            this.ChB_Mes_p2l.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ChB_Mes_p2l.Name = "ChB_Mes_p2l";
            this.tableLayoutPanel2.SetRowSpan(this.ChB_Mes_p2l, 2);
            this.ChB_Mes_p2l.Size = new System.Drawing.Size(69, 74);
            this.ChB_Mes_p2l.TabIndex = 10;
            this.ChB_Mes_p2l.Text = "Расстояние   до прямой";
            this.ChB_Mes_p2l.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ChB_Mes_p2l.UseVisualStyleBackColor = true;
            this.ChB_Mes_p2l.CheckedChanged += new System.EventHandler(this.ChB_Mes_p2l_CheckedChanged);
            // 
            // ChB_Mes_p2p
            // 
            this.ChB_Mes_p2p.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_Mes_p2p.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChB_Mes_p2p.BackgroundImage")));
            this.ChB_Mes_p2p.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChB_Mes_p2p.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Mes_p2p.FlatAppearance.BorderSize = 0;
            this.ChB_Mes_p2p.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.ChB_Mes_p2p.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ChB_Mes_p2p.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChB_Mes_p2p.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChB_Mes_p2p.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ChB_Mes_p2p.Location = new System.Drawing.Point(0, 3);
            this.ChB_Mes_p2p.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ChB_Mes_p2p.Name = "ChB_Mes_p2p";
            this.tableLayoutPanel2.SetRowSpan(this.ChB_Mes_p2p, 2);
            this.ChB_Mes_p2p.Size = new System.Drawing.Size(69, 74);
            this.ChB_Mes_p2p.TabIndex = 0;
            this.ChB_Mes_p2p.Text = "Расстояние   до точки";
            this.ChB_Mes_p2p.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ChB_Mes_p2p.UseVisualStyleBackColor = true;
            this.ChB_Mes_p2p.CheckedChanged += new System.EventHandler(this.ChB_Mes_p2p_CheckedChanged);
            // 
            // B_Mes_DeleteAll
            // 
            this.B_Mes_DeleteAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Mes_DeleteAll.BackgroundImage")));
            this.B_Mes_DeleteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Mes_DeleteAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Mes_DeleteAll.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.B_Mes_DeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Mes_DeleteAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Mes_DeleteAll.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.B_Mes_DeleteAll.Location = new System.Drawing.Point(414, 3);
            this.B_Mes_DeleteAll.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.B_Mes_DeleteAll.Name = "B_Mes_DeleteAll";
            this.tableLayoutPanel2.SetRowSpan(this.B_Mes_DeleteAll, 2);
            this.B_Mes_DeleteAll.Size = new System.Drawing.Size(69, 74);
            this.B_Mes_DeleteAll.TabIndex = 7;
            this.B_Mes_DeleteAll.Text = "Удалить все измерения";
            this.B_Mes_DeleteAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.B_Mes_DeleteAll.UseVisualStyleBackColor = true;
            this.B_Mes_DeleteAll.Click += new System.EventHandler(this.B_Mes_DeleteAll_Click);
            // 
            // B_Mes_Reconstruct3D
            // 
            this.B_Mes_Reconstruct3D.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Mes_Reconstruct3D.BackgroundImage")));
            this.B_Mes_Reconstruct3D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Mes_Reconstruct3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Mes_Reconstruct3D.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.B_Mes_Reconstruct3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Mes_Reconstruct3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Mes_Reconstruct3D.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.B_Mes_Reconstruct3D.Location = new System.Drawing.Point(483, 3);
            this.B_Mes_Reconstruct3D.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.B_Mes_Reconstruct3D.Name = "B_Mes_Reconstruct3D";
            this.tableLayoutPanel2.SetRowSpan(this.B_Mes_Reconstruct3D, 2);
            this.B_Mes_Reconstruct3D.Size = new System.Drawing.Size(69, 74);
            this.B_Mes_Reconstruct3D.TabIndex = 8;
            this.B_Mes_Reconstruct3D.Text = "Восстановить 3D";
            this.B_Mes_Reconstruct3D.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.B_Mes_Reconstruct3D.UseVisualStyleBackColor = true;
            this.B_Mes_Reconstruct3D.Click += new System.EventHandler(this.B_Mes_Reconstruct3D_Click);
            // 
            // B_Mes_Back
            // 
            this.B_Mes_Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("B_Mes_Back.BackgroundImage")));
            this.B_Mes_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Mes_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Mes_Back.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.B_Mes_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Mes_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Mes_Back.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.B_Mes_Back.Location = new System.Drawing.Point(552, 3);
            this.B_Mes_Back.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.B_Mes_Back.Name = "B_Mes_Back";
            this.tableLayoutPanel2.SetRowSpan(this.B_Mes_Back, 2);
            this.B_Mes_Back.Size = new System.Drawing.Size(74, 74);
            this.B_Mes_Back.TabIndex = 9;
            this.B_Mes_Back.Text = "Назад";
            this.B_Mes_Back.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.B_Mes_Back.UseVisualStyleBackColor = true;
            this.B_Mes_Back.Click += new System.EventHandler(this.B_Mes_Back_Click);
            // 
            // CV_ImBox_VidPhoto_Player
            // 
            this.CV_ImBox_VidPhoto_Player.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CV_ImBox_VidPhoto_Player.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.CV_ImBox_VidPhoto_Player.Location = new System.Drawing.Point(0, 0);
            this.CV_ImBox_VidPhoto_Player.Name = "CV_ImBox_VidPhoto_Player";
            this.CV_ImBox_VidPhoto_Player.Size = new System.Drawing.Size(472, 265);
            this.CV_ImBox_VidPhoto_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CV_ImBox_VidPhoto_Player.TabIndex = 8;
            this.CV_ImBox_VidPhoto_Player.TabStop = false;
            this.CV_ImBox_VidPhoto_Player.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CV_ImBox_VidPhoto_Player_MouseUp);
            // 
            // PB_MeasurementPB
            // 
            this.PB_MeasurementPB.BackColor = System.Drawing.Color.Honeydew;
            this.PB_MeasurementPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PB_MeasurementPB.InitialImage = null;
            this.PB_MeasurementPB.Location = new System.Drawing.Point(0, 0);
            this.PB_MeasurementPB.Margin = new System.Windows.Forms.Padding(2);
            this.PB_MeasurementPB.Name = "PB_MeasurementPB";
            this.PB_MeasurementPB.Size = new System.Drawing.Size(494, 290);
            this.PB_MeasurementPB.TabIndex = 10;
            this.PB_MeasurementPB.TabStop = false;
            this.PB_MeasurementPB.DoubleClick += new System.EventHandler(this.PB_MeasurementPB_DoubleClick);
            this.PB_MeasurementPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_MeasurementPB_MouseDown);
            this.PB_MeasurementPB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_MeasurementPB_MouseMove);
            this.PB_MeasurementPB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PB_MeasurementPB_MouseUp);
            // 
            // OTK_3D_Control
            // 
            this.OTK_3D_Control.BackColor = System.Drawing.Color.LemonChiffon;
            this.OTK_3D_Control.Location = new System.Drawing.Point(0, 0);
            this.OTK_3D_Control.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OTK_3D_Control.Name = "OTK_3D_Control";
            this.OTK_3D_Control.Size = new System.Drawing.Size(527, 317);
            this.OTK_3D_Control.TabIndex = 11;
            this.OTK_3D_Control.VSync = false;
            this.OTK_3D_Control.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OTK_3D_Control_MouseDown);
            this.OTK_3D_Control.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OTK_3D_Control_MouseMove);
            this.OTK_3D_Control.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OTK_3D_Control_MouseUp);
            this.OTK_3D_Control.Resize += new System.EventHandler(this.OTK_3D_Control_Resize);
            // 
            // BGWR_ChargeLev
            // 
            this.BGWR_ChargeLev.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWR_ChargeLev_DoWork);
            // 
            // WakeUpTimer
            // 
            this.WakeUpTimer.Interval = 200;
            this.WakeUpTimer.Tick += new System.EventHandler(this.WakeUpTimer_Tick);
            // 
            // Timer_InvalidateAfter_EnteringMes
            // 
            this.Timer_InvalidateAfter_EnteringMes.Interval = 75;
            this.Timer_InvalidateAfter_EnteringMes.Tick += new System.EventHandler(this.Timer_InvalidateAfter_EnteringMes_Tick);
            // 
            // Timer_3DRenderer
            // 
            this.Timer_3DRenderer.Interval = 50;
            this.Timer_3DRenderer.Tick += new System.EventHandler(this.Timer_3DRenderer_Tick);
            // 
            // BGW_3DRotator
            // 
            this.BGW_3DRotator.WorkerSupportsCancellation = true;
            this.BGW_3DRotator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_3DRotator_DoWork);
            // 
            // BWorkerForLoad3D
            // 
            this.BWorkerForLoad3D.WorkerReportsProgress = true;
            this.BWorkerForLoad3D.WorkerSupportsCancellation = true;
            this.BWorkerForLoad3D.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BWorkerForLoad3D_DoWork);
            this.BWorkerForLoad3D.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BWorkerForLoad3D_ProgressChanged);
            this.BWorkerForLoad3D.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BWorkerForLoad3D_RunWorkerCompleted);
            // 
            // T_3DCancellingChecker
            // 
            this.T_3DCancellingChecker.Tick += new System.EventHandler(this.T_3DCancellingChecker_Tick);
            // 
            // BGW_StereoInitializer
            // 
            this.BGW_StereoInitializer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_StereoInitializer_DoWork);
            this.BGW_StereoInitializer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_StereoInitializer_RunWorkerCompleted);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 685);
            this.Controls.Add(this.TLP_BASE);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.TLP_BASE.ResumeLayout(false);
            this.Pan_ViewRegion.ResumeLayout(false);
            this.Pan_ViewRegion.PerformLayout();
            this.Pan_Pl_3D.ResumeLayout(false);
            this.TLP_Pl_3D.ResumeLayout(false);
            this.TLP_Pl_3D.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_Pl_ModelsLister)).EndInit();
            this.Pan_3D_Building.ResumeLayout(false);
            this.TLP_3D_Building.ResumeLayout(false);
            this.Pan_Pl_Photo.ResumeLayout(false);
            this.TLP_Pl_Photo.ResumeLayout(false);
            this.TLP_Pl_Photo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_Pl_PhotoLister)).EndInit();
            this.Pan_Pl_Video.ResumeLayout(false);
            this.TLP_Pl_Video.ResumeLayout(false);
            this.TLP_Pl_Video.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRB_Pl_VideoTimer)).EndInit();
            this.P_ChargeLev.ResumeLayout(false);
            this.TLP_ChargeLev.ResumeLayout(false);
            this.TLP_ChargeLev.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ChargeVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Indicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CV_ImBox_Capture)).EndInit();
            this.Pan_Player.ResumeLayout(false);
            this.TLP_Pl_PlayerMain.ResumeLayout(false);
            this.Pan_Export.ResumeLayout(false);
            this.TLP_ExportTable.ResumeLayout(false);
            this.TLP_ExportTable.PerformLayout();
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
            this.TPAGE_WB.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrB_WB_CorPower)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.TB_Set_CalibStereoFilePath.ResumeLayout(false);
            this.TB_Set_CalibStereoFilePath.PerformLayout();
            this.Pan_MainMenu.ResumeLayout(false);
            this.TLP_UserMainPanel.ResumeLayout(false);
            this.TLP_UserMainPanel.PerformLayout();
            this.Pan_Measurements.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CV_ImBox_VidPhoto_Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MeasurementPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLP_BASE;
        private System.Windows.Forms.TableLayoutPanel TLP_UserMainPanel;
        private System.Windows.Forms.Panel Pan_ViewRegion;
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
        private System.Windows.Forms.Button B_ExportMode;
        private System.Windows.Forms.Button B_Quit;
        private System.Windows.Forms.TableLayoutPanel TLP_Settings;
        private System.Windows.Forms.Button B_BackBut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel Pan_BASE_BackgroundPanel;
        private System.Windows.Forms.Panel Pan_MainMenu;
        private System.Windows.Forms.Panel P_ChargeLev;
        private System.ComponentModel.BackgroundWorker BGWR_ChargeLev;
        private System.Windows.Forms.TableLayoutPanel TLP_ChargeLev;
        private System.Windows.Forms.PictureBox PB_ChargeVal;
        private System.Windows.Forms.Label L_ChargeLev;
        private System.Windows.Forms.PictureBox PB_Indicator;
        private System.Windows.Forms.Panel Pan_Export;
        private System.Windows.Forms.TableLayoutPanel TLP_ExportTable;
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
        private System.Windows.Forms.Timer WakeUpTimer;
        private System.Windows.Forms.Label L_SnapShotSaved;
        private System.Windows.Forms.Panel Pan_Pl_Photo;
        private System.Windows.Forms.Panel Pan_Player;
        private System.Windows.Forms.TableLayoutPanel TLP_Pl_PlayerMain;
        private System.Windows.Forms.Button B_Pl_VideoMode;
        private System.Windows.Forms.Label L_Pl_PhotoPlayerName;
        private System.Windows.Forms.TableLayoutPanel TLP_Pl_Photo;
        private System.Windows.Forms.Panel Pan_Pl_Video;
        private System.Windows.Forms.TableLayoutPanel TLP_Pl_Video;
        private System.Windows.Forms.Label L_Pl_VideoPlayerName;
        private System.Windows.Forms.Button B_Pl_GoToMain;
        private System.Windows.Forms.Button B_Pl_PhotoMode;
        private System.Windows.Forms.TrackBar TRB_Pl_VideoTimer;
        private System.Windows.Forms.Label L_Pl_Photo_Cur;
        private System.Windows.Forms.Label L_Pl_Photo_All;
        private System.Windows.Forms.TrackBar TRB_Pl_PhotoLister;
        private System.Windows.Forms.Button B_Pl_PhotoPrevious;
        private System.Windows.Forms.Button B_Pl_PhotoNext;
        private System.Windows.Forms.Button B_Pl_VideoNext;
        private System.Windows.Forms.Label L_Pl_Video_TimeLeft;
        private System.Windows.Forms.Button B_Pl_VideoStop;
        private System.Windows.Forms.Label L_Pl_Video_TimeCur;
        private System.Windows.Forms.Button B_Pl_VideoPlayPause;
        private System.Windows.Forms.Button B_Pl_VideoPrevious;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button B_ViewMode;
        private System.Windows.Forms.Panel Pan_Pl_Base_forAnyPLCtrls;
        private Emgu.CV.UI.ImageBox CV_ImBox_VidPhoto_Player;
        private System.Windows.Forms.Button B_MeasureMode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button B_Pl_3DMode;
        private System.Windows.Forms.Panel Pan_Pl_3D;
        private System.Windows.Forms.TableLayoutPanel TLP_Pl_3D;
        private System.Windows.Forms.Label L_Pl_Models_Cur;
        private System.Windows.Forms.Label L_Pl_Models_All;
        private System.Windows.Forms.TrackBar TRB_Pl_ModelsLister;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button B_Pl_ModelPrevious;
        private System.Windows.Forms.Button B_Pl_ModelNext;
        private System.Windows.Forms.Panel Pan_Measurements;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button B_Mes_DeleteAll;
        private System.Windows.Forms.Button B_Mes_Reconstruct3D;
        private System.Windows.Forms.Button B_Mes_Back;
        private System.Windows.Forms.Button B_Ex_3DMode;
        private System.Windows.Forms.CheckBox ChB_Mes_Area;
        private System.Windows.Forms.CheckBox ChB_Mes_Perimeter;
        private System.Windows.Forms.CheckBox ChB_Mes_LenghtOfBroken;
        private System.Windows.Forms.CheckBox ChB_Mes_p2pl;
        private System.Windows.Forms.CheckBox ChB_Mes_p2l;
        private System.Windows.Forms.CheckBox ChB_Mes_p2p;
        private System.Windows.Forms.PictureBox PB_MeasurementPB;
        private System.Windows.Forms.Button B_Pl_Photo_Measure;
        private System.Windows.Forms.Button B_Set_FindStereoCalibFile;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer Timer_InvalidateAfter_EnteringMes;
        private OpenTK.GLControl OTK_3D_Control;
        private System.Windows.Forms.Timer Timer_3DRenderer;
        private System.ComponentModel.BackgroundWorker BGW_3DRotator;
        private System.ComponentModel.BackgroundWorker BWorkerForLoad3D;
        private System.Windows.Forms.TabPage TPAGE_WB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button B_WB_LowerFrames;
        private System.Windows.Forms.Button B_WB_HigherFrames;
        private System.Windows.Forms.Label L_WB_NumOfImages;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label L_WB_CorPower;
        private System.Windows.Forms.TrackBar TrB_WB_CorPower;
        private System.Windows.Forms.Button B_WB_Calculate;
        private System.Windows.Forms.TableLayoutPanel TB_Set_CalibStereoFilePath;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TB_Set_CalibWBFilePath;
        private System.Windows.Forms.Button B_Set_FindWBCalibFile;
        private System.Windows.Forms.Panel Pan_3D_Building;
        private System.Windows.Forms.TableLayoutPanel TLP_3D_Building;
        private System.Windows.Forms.ProgressBar PrB_3D_Building;
        private System.Windows.Forms.Button B_3D_CancelBuilding;
        private System.Windows.Forms.Timer T_3DCancellingChecker;
        private System.ComponentModel.BackgroundWorker BGW_StereoInitializer;
    }
}


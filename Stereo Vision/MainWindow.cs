using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using System.IO;
using Microsoft.Win32;
using OpenTK_3DMesh;

namespace Stereo_Vision
{
    public partial class MainWindow : Form
    {
        bool AdminMode = false;
        bool isInTranslation = false;
        bool isPlayingVideoNow = false;
        bool isMeasuring = false;
        bool is3DViewing = false;
        bool throwed_to_hiber = false;
        bool isArduino_closed = true;
        int ticks = 0;
        string User_Name = "MPEI";

        //TODO: убрать следующие переменные отсюда
        int NumOfImages_WB = 2;
        int CurNumOfImages_forWB = 2;

        bool Camulating_isActive = false;
        bool DigitalWB_Active = false;
        double[,,] CMatrix;
        int Width_Current = 1280;
        int Height_Current = 720;


        int Saving_ShowLabel_time = 3;

        public MainWindow()
        {
            InitializeComponent();
            //Additionally and specially for recording
            PB_Indicator.ImageLocation =  
                Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources\\rec_anim.gif");

            // Lock and un lock purpose
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);

            //stand by mode then 
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
          //  SystemEvents.Wake
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*bool isPr = false;
            string img_plane_pre = "pl";
            string img_cilindric_pre = "cil";
            string img_real_pre = "real";
            BuildModel3D(new BackgroundWorker(), new Bitmap("TestImages\\"+ img_plane_pre + "1.tiff"), isPr);
            return;*/
            //Load3DModel("demo.ply"); return;


            this.Visible = false;
            try
            {
                
                Build_Interface();

                MaximizeWindow();
                CreateAttachmentFactor(ref AttachmentFactor, LBConsole);
                PrepareTheCamera();
                SetResolution(1280, 720);
                SwitchAdminMode(AdminMode);
                OpenMainPanel();
                HideSomeThings();
                Read_and_Load_Settings();
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
                BGWR_ChargeLev.WorkerSupportsCancellation = true;
                BGWR_ChargeLev.RunWorkerAsync();
                Set_ChargeBMP(BMP2set_chargelev);
                Set_ChargeTEXT(Text2set);
                WhiteBalance.InitializeMatrix(1, ref CMatrix, Width_Current, Height_Current, 3);
                StartCapture();


                this.DoubleBuffered = true;
                CurrentFrame = new Mat();
                CurrentFrame2 = new Mat();
                CurrentFrame_wb = new Mat();
                resizedim = new Mat();
                if(FullScrin) Size_for_Resizing = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 185);
                else Size_for_Resizing = new Size(this.Width, this.Height - 185);


                myBuffer = currentContext.Allocate(PB_MeasurementPB.CreateGraphics(), PB_MeasurementPB.DisplayRectangle);
                Draw_Base(false);
                myBuffer.Render();
                myBuffer.Dispose();

                Models_view_init();
                Restore_CaptureDirectory();
                // Width_for_Resizing = CV_ImBox_Capture.Width;
                //  Height_for_Resizing = CV_ImBox_Capture.Height;
                // Size_for_Resizing = new Size(Width_for_Resizing, Height_for_Resizing);
            }
            catch(Exception exc) { LogError(exc.Message); }
            finally { this.Visible = true; }
        }
        private void Build_Interface()
        {
            //Pan_pl_Base Restruct
            this.Pan_Pl_Base_forAnyPLCtrls.Controls.Add(this.Pan_Pl_Photo);
            this.Pan_Pl_Base_forAnyPLCtrls.Controls.Add(this.Pan_Pl_3D);
            this.Pan_Pl_Base_forAnyPLCtrls.Controls.Add(this.Pan_Pl_Video);
            Pan_Pl_Photo.Dock = DockStyle.Fill;
            Pan_Pl_Video.Dock = DockStyle.Fill;
            Pan_Pl_3D.Dock = DockStyle.Fill;

            //MainPanel Restruct
            Pan_BASE_BackgroundPanel.Controls.Add(this.Pan_Settings);
            Pan_BASE_BackgroundPanel.Controls.Add(this.Pan_Export);
            Pan_BASE_BackgroundPanel.Controls.Add(this.Pan_Player);
            Pan_BASE_BackgroundPanel.Controls.Add(this.Pan_MainMenu);
            Pan_BASE_BackgroundPanel.Controls.Add(this.Pan_Measurements);
            Pan_Settings.Dock = DockStyle.Fill;
            Pan_Export.Dock = DockStyle.Fill;
            Pan_Player.Dock = DockStyle.Fill;
            Pan_MainMenu.Dock = DockStyle.Fill;
            Pan_Measurements.Dock = DockStyle.Fill;
            Pan_MainMenu.BringToFront();

            //ViewRegion restruct
            this.Pan_ViewRegion.Controls.Add(this.CV_ImBox_VidPhoto_Player);
            this.Pan_ViewRegion.Controls.Add(this.CV_ImBox_Capture);
            this.Pan_ViewRegion.Controls.Add(this.PB_MeasurementPB);
            this.Pan_ViewRegion.Controls.Add(this.OTK_3D_Control);
            this.Pan_ViewRegion.Controls.Add(this.L_SnapShotSaved);
            this.Pan_ViewRegion.Controls.Add(this.P_ChargeLev);
            this.Pan_ViewRegion.Controls.Add(this.PB_Indicator);
            this.Pan_ViewRegion.Controls.Add(this.LBConsole);

            CV_ImBox_VidPhoto_Player.Dock = DockStyle.Fill;
            CV_ImBox_Capture.Dock = DockStyle.Fill;
            PB_MeasurementPB.Dock = DockStyle.Fill;
            OTK_3D_Control.Dock = DockStyle.Fill;
            L_SnapShotSaved.BringToFront();
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Q) && e.Alt)
            {
                // Thread_for_Refreshing_of_ChargeLev.Abort();
                //Thread_for_Refreshing_of_ChargeLev.Join();              
                BGWR_ChargeLev.CancelAsync();
                SaveSettings();
                StopCapture();
                while ((!isArduino_closed)&&(!lastFrame_processed))
                {
                    //we will wait for closing
                }
                Application.Exit();
            }
            else if ((e.KeyCode == Keys.F) && e.Control)
            {
                if (FullScrin) { MinimizeWindow(); }
                else { MaximizeWindow(); }
            }
            else if ((e.KeyCode == Keys.A) && (e.Alt) && (e.Control))
            {
                AdminMode = !AdminMode;
                SwitchAdminMode(AdminMode);
            }
            /*  else if (((e.KeyCode == Keys.W) && e.Control) && (!recordstate))
              {
                  SwitchFullSCRTraslation();
              }*/
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            TLP_UserMainPanel.Refresh() ;

            if (FullScrin) Size_for_Resizing = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 120);
            else Size_for_Resizing = new Size(this.Width, this.Height - 150);
        }

        private void TLP_UserMainPanel_Resize(object sender, EventArgs e)
        {
            TLP_UserMainPanel.Update();
           // LogMessage("Перерисовка!");
        }

        private void B_Quit_Click(object sender, EventArgs e)
        {
            DialogResult a;
            if (!HiberNoAsk)
            {
                a = MessageBox.Show("Перейти в режим гибернации?", "Выход...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }
            else { a = DialogResult.Yes; HiberNoAsk = false; }
            if (a != DialogResult.Cancel)
            {
                if (isRecording) { StopRecording(); }
                if (isInTranslation) { StopCapture(); }
                if(isPlayingVideoNow) { View_Video_Stop(); }
                isInTranslation = false;
                isPlayingVideoNow = false;
                SaveSettings();
                throwed_to_hiber = true;
                WakeUpTimer.Enabled = true;
                BGWR_ChargeLev.CancelAsync();
                // BGWR_ChargeLev.run
                while ((!isArduino_closed) && (!lastFrame_processed))
                {
                    //we will wait for closing
                }
                if (a == DialogResult.Yes) Application.SetSuspendState(PowerState.Hibernate, true, false);
                else Application.Exit();
            }
        }
       
        private void TLP_UserMainPanel_MouseMove(object sender, MouseEventArgs e)
        {
        //    TLP_UserMainPanel.Refresh();
            TLP_UserMainPanel.Update();
           // LogMessage("Перерисовка!");
        }

        private void B_SwitchRec_MouseMove(object sender, MouseEventArgs e)
        {
            TLP_UserMainPanel.Update();
           // LogMessage("Перерисовка!");
        }

        private void B_Photo_or_PauseRec_MouseMove(object sender, MouseEventArgs e)
        {
            TLP_UserMainPanel.Update();
           // LogMessage("Перерисовка!");
        }

        private void B_Settings_MouseMove(object sender, MouseEventArgs e)
        {
            TLP_UserMainPanel.Update();
           // LogMessage("Перерисовка!");
        }

        private void B_Quit_MouseMove(object sender, MouseEventArgs e)
        {
            TLP_UserMainPanel.Update();
           // LogMessage("Перерисовка!");
        }

        private void B_Settings_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }
        private void B_BackBut_Click(object sender, EventArgs e)
        {
            OpenMainPanel();
        }
        private void B_Export_Click(object sender, EventArgs e)
        {
            OpenExportPanel();
        }
        private void B_ViewMode_Click(object sender, EventArgs e)
        {
            OpenPlayPanel();
        }
        private void B_Ex_BackToMain_Click(object sender, EventArgs e)
        {
            OpenMainPanel();
        }

        private void B_Photo_or_PauseRec_Click(object sender, EventArgs e)
        {
            TakeSnapShot();
        }

        private void B_Pl_GoToMain_Click(object sender, EventArgs e)
        {
            OpenMainPanel();
            if (isPlayingVideoNow) View_Video_Stop();
            StartCapture();
        }
        private void B_SwitchRec_Click(object sender, EventArgs e)
        {
            try
            {
                if (isRecording) StopRecording();
                else isRecording = StartRecording();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LBConsole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void BGWR_ChargeLev_DoWork(object sender, DoWorkEventArgs e)
        {
            
            BackgroundWorker worker = sender as BackgroundWorker;
            RefreshChargeControls(ref worker,ref isArduino_closed);
        }

        private void L_Ex_Mode_Click(object sender, EventArgs e)
        {

        }

        private void B_Ex_Search_PathFrom_Click(object sender, EventArgs e)
        {
            Open_Export_DirectoryFrom();
        }

        private void B_Ex_Search_PathTo_Click(object sender, EventArgs e)
        {
            Open_Export_DirectoryTo(false);
        }

        private void B_Ex_VideoMode_Click(object sender, EventArgs e)
        {
            Toogle_Export_Mode(true);
        }

        private void B_Ex_PhotoMode_Click(object sender, EventArgs e)
        {
            Toogle_Export_Mode(false);
        }

        private void CB_Ex_ChooseExportMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = false;
            Export_style = CB_Ex_ChooseExportMode.SelectedIndex;
            if ((Export_style == 1)||(Export_style == 2))
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            TB_Ex_Count.Visible = flag;
            B_Ex_MinusCount.Visible = flag;
            B_Ex_PlusCount.Visible = flag;
        }

        private void B_Ex_PlusCount_Click(object sender, EventArgs e)
        {
            if(Number_of_FilesorHours<99) Number_of_FilesorHours++;
            TB_Ex_Count.Text = Number_of_FilesorHours.ToString();
        }

        private void B_Ex_MinusCount_Click(object sender, EventArgs e)
        {
            if (Number_of_FilesorHours > 1) Number_of_FilesorHours--;
            TB_Ex_Count.Text = Number_of_FilesorHours.ToString();
        }

        private void B_Ex_StartExport_Click(object sender, EventArgs e)
        {
            ExportFiles();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LHueValue_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TrBBrightness_Scroll(object sender, EventArgs e)
        {
            Adjust_Brightness();
        }

        private void TrBContrast_Scroll(object sender, EventArgs e)
        {
            Adjust_Contrast();
        }

        private void TrBSaturation_Scroll(object sender, EventArgs e)
        {
            Adjust_Saturation();
        }

        private void TrBGamma_Scroll(object sender, EventArgs e)
        {
            Adjust_Gamma();
        }

        private void TrBGain_Scroll(object sender, EventArgs e)
        {
            Adjust_Gain();
        }

        private void B_Settings_FindVidPath_Click(object sender, EventArgs e)
        {
            Simple_choose_Directory(ref TB_Settings_VidSavePath);
            Rec_Videos_path = TB_Settings_VidSavePath.Text;
        }

        private void B_Settings_FindPhotoPath_Click(object sender, EventArgs e)
        {
            Simple_choose_Directory(ref TB_Settings_PhotoSavePath);
            Rec_Photos_path = TB_Settings_PhotoSavePath.Text;
        }

        private void WakeUpTimer_Tick(object sender, EventArgs e)
        {
            ticks++;
            if(ticks % 5 ==0)
            {
                LogMessage((ticks/5).ToString());
                try
                {
                    ToDo_OnWakeUp();
                    WakeUpTimer.Enabled = false;
                    ticks = 0;
                }
                catch { }
            }
        }

        private void Timer_Frame_Tick(object sender, EventArgs e)
        {
            lastFrame_processed = false;
            _capture.Grab();
            _capture.Retrieve(CurrentFrame, 0);
            //  Refresh_image_Invoke(CurrentFrame);
            // CV_ImBox_Capture.Image = CurrentFrame;
            FramesGotten++;
            if ((STW.Elapsed.Seconds > 5) && (STW.Elapsed.Seconds % 10 == 0))
            {
                LogMessage(((float)FramesGotten / STW.Elapsed.TotalSeconds).ToString());
                FramesGotten = 0;
                STW.Restart();
            }
            lastFrame_processed = true;
        }

        private void BGWR_RedrawMat_DoWork(object sender, DoWorkEventArgs e)
        {
            
            while (true)
            {
               /* Width_for_Resizing = CV_ImBox_Capture.Width;
                Height_for_Resizing = CV_ImBox_Capture.Height;
                Size_for_Resizing = new Size(Width_for_Resizing, Height_for_Resizing);*/
               /* if (FrameDrawen == false)
                {
                    STW_Resizing.Start();
                    //  Image<Bgr, byte> resizedImage = captureImage.Resize(width, height, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                    //       STW_Resizing.Start();
                    CvInvoke.Resize(CurrentFrame, resizedim, Size_for_Resizing, 0, 0, Inter.Linear);
                //    STW_Resizing.Stop();
                    FramesDrawen++;
                    if ((STW_Draw.Elapsed.Seconds > 5) && (STW_Draw.Elapsed.Seconds % 10 == 0))
                    {
                        LogMessage("Время перерисовки кадра: " + (STW_Resizing.Elapsed.TotalSeconds/FramesDrawen ).ToString());
                        LogMessage("Скорость отрисовки кадров: " + (FramesDrawen / STW_Draw.Elapsed.TotalSeconds).ToString());
                        FramesDrawen = 0;
                        STW_Draw.Restart();
                        STW_Resizing.Reset();
                    }

                    //   Refresh_image_Invoke(resizedim);
                    CV_ImBox_Capture.Image = resizedim;
                    STW_Resizing.Stop();
                    FrameDrawen = true;
                }*/
            }
        }

        private void CV_ImBox_Capture_Click(object sender, EventArgs e)
        {
            LogMessage(CV_ImBox_Capture.Width.ToString() + "x" + CV_ImBox_Capture.Height.ToString());
        }

        private void Timer_SnapshotSaving_Tick(object sender, EventArgs e)
        {
            try
            {
                if (STW_2HideLabel.Elapsed.TotalSeconds > Saving_ShowLabel_time)
                {
                    double RT_Elapsed = STW_2HideLabel.Elapsed.TotalSeconds;
                    L_SnapShotSaved.Hide();
                    STW_2HideLabel.Stop();
                }

            }
            catch(Exception exc)
            {
                LogError(exc.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void B_Pl_VideoPlayPause_Click(object sender, EventArgs e)
        {
            if (isPlayingVideoNow) View_Video_Pause();
            else View_Video_Continue();
        }

        private void B_Pl_VideoMode_Click(object sender, EventArgs e)
        {
            Toogle_Play_Mode(Modes.Video);
        }

        private void B_Pl_PhotoMode_Click(object sender, EventArgs e)
        {
            Toogle_Play_Mode(Modes.Photo);
        }

        private void B_Pl_3DMode_Click(object sender, EventArgs e)
        {
            Toogle_Play_Mode(Modes.Models3D);
        }
        private void B_Pl_PhotoPrevious_Click(object sender, EventArgs e)
        {
            View_Image_Prev();
        }

        private void B_Pl_PhotoNext_Click(object sender, EventArgs e)
        {
            View_Image_Next();
        }

        private void TRB_Pl_PhotoLister_Scroll(object sender, EventArgs e)
        {
            View_Image_byIndex(TRB_Pl_PhotoLister.Value);
            L_Pl_Photo_Cur.Text = (TRB_Pl_PhotoLister.Value + 1).ToString();
            L_Pl_Photo_All.Text = FilesToView.Count.ToString();
        }

        private void B_Pl_VideoPrevious_Click(object sender, EventArgs e)
        {
            View_Video_Prev();
        }

        private void B_Pl_VideoNext_Click(object sender, EventArgs e)
        {
            View_Video_Next();
        }

        private void B_Pl_VideoStop_Click(object sender, EventArgs e)
        {
            View_Video_Stop();
        }

        private void TRB_Pl_VideoTimer_Scroll(object sender, EventArgs e)
        {
            View_Video_Scroll();
        }

        private void TRB_Pl_ModelsLister_Scroll(object sender, EventArgs e)
        {

        }


        float Rrrot = 0;
        private void B_Pl_ModelPrevious_Click(object sender, EventArgs e)
        {
            Rrrot -= (float)(22.5*Math.PI)/180.0f;
            //M3D_BasicMesh.SetGetElementRotation(Rrrot, 0);
            M3D_BasicMesh.SetGetElementRotation(Rrrot, 1);
            // M3D_Figure.TranslationZ = -10;
            Draw_3D_graphics();
        }
        private void B_Pl_ModelNext_Click(object sender, EventArgs e)
        {
            Rrrot += (float)(22.5 * Math.PI) / 180.0f;
            //M3D_BasicMesh.SetGetElementRotation(Rrrot, 0);
            M3D_BasicMesh.SetGetElementRotation(Rrrot, 1);
            // M3D_Figure.TranslationZ = -10;
            Draw_3D_graphics();
        }

        private void ChB_Mes_p2p_CheckedChanged(object sender, EventArgs e)
        {

            if (ChB_Mes_p2p.Checked)
            {
                Toogle_all_measurements_silent(true, false, false, false, false, false);
                Init_Measurements_byType(MeasurementTypes.Distance_2point);
            }
            else
            {
                Toogle_all_measurements_silent(false, false, false, false, false, false);
                Disable_Measurements();
            }
        }

        private void ChB_Mes_p2l_CheckedChanged(object sender, EventArgs e)
        {
            if (ChB_Mes_p2l.Checked)
            {
                Toogle_all_measurements_silent(false, true, false, false, false, false);
                Init_Measurements_byType(MeasurementTypes.Distance_2line);
            }
            else
            {
                Toogle_all_measurements_silent(false, false, false, false, false, false);
                Disable_Measurements();
            }
        }

        private void ChB_Mes_p2pl_CheckedChanged(object sender, EventArgs e)
        {
            if (ChB_Mes_p2pl.Checked)
            {
                Toogle_all_measurements_silent(false, false, true, false, false, false);
                Init_Measurements_byType(MeasurementTypes.Distance_2plane);
            }
            else
            {
                Toogle_all_measurements_silent(false, false, false, false, false, false);
                Disable_Measurements();
            }
        }

        private void ChB_Mes_LenghtOfBroken_CheckedChanged(object sender, EventArgs e)
        {
            if (ChB_Mes_LenghtOfBroken.Checked)
            {
                Toogle_all_measurements_silent(false, false, false, true, false, false);
                Init_Measurements_byType(MeasurementTypes.Polyline);
            }
            else
            {
                Toogle_all_measurements_silent(false, false, false, false, false, false);
                Disable_Measurements();
            }
        }

        private void ChB_Mes_Perimeter_CheckedChanged(object sender, EventArgs e)
        {
            if (ChB_Mes_Perimeter.Checked)
            {
                Toogle_all_measurements_silent(false, false, false, false, true, false);
                Init_Measurements_byType(MeasurementTypes.Perimeter);
            }
            else
            {
                Toogle_all_measurements_silent(false, false, false, false, false, false);
                Disable_Measurements();
            }
        }

        private void ChB_Mes_Area_CheckedChanged(object sender, EventArgs e)
        {
            if (ChB_Mes_Area.Checked)
            {
                Toogle_all_measurements_silent(false, false, false, false, false, true);
                Init_Measurements_byType(MeasurementTypes.Area);
            }
            else
            {
                Toogle_all_measurements_silent(false, false, false, false, false, false);
                Disable_Measurements();
            }
        }

        private void B_Mes_DeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentStereoImage.ClearMEasurements();
                DB_Invalidate();
            }
            catch
            {

            }
        }

        private void B_Mes_Reconstruct3D_Click(object sender, EventArgs e)
        {
            Allow3DInvalidate = false;
            Playing_mode = Modes.Models3D;
            OpenPlayPanel(true);
            
        }
        private void B_Ex_3DMode_Click(object sender, EventArgs e)
        {

        }

        private void B_Mes_Back_Click(object sender, EventArgs e)
        {
            if (ActivatePreviousMode != null) ActivatePreviousMode();
        }

        Action ActivatePreviousMode = null;
        private void B_Pl_Photo_Measure_Click(object sender, EventArgs e)
        {
            //CurrentStereoImage = new StereoImage()
            ActivatePreviousMode = (Action)OpenPlayPanel;
            Init_Stereoimage(FilesToView[CurrentIndex]);
            OpenMeasurementsPanel();
            DB_Invalidate();
        }

        private void B_MeasureMode_Click(object sender, EventArgs e)
        {
            isSnapShot_needed = true;
            Init_Stereoimage(null);
            ActivatePreviousMode = new Action(()=> 
            {   OpenMainPanel();
                if(!isInTranslation) StartCapture();
                });
            OpenMeasurementsPanel();
            DB_Invalidate(); 
        }

        private void PB_MeasurementPB_Click(object sender, EventArgs e)
        {
            DB_Invalidate();
        }

        private void PB_MeasurementPB_Paint(object sender, PaintEventArgs e)
        {
            int a = 0;
        }

        private void PB_MeasurementPB_BackColorChanged(object sender, EventArgs e)
        {
            int b = 0;
        }

        private void Timer_InvalidateAfter_EnteringMes_Tick(object sender, EventArgs e)
        {
            DB_Invalidate();
            Pan_Measurements.Invalidate();
            Timer_InvalidateAfter_EnteringMes.Stop();
        }

        private void CV_ImBox_VidPhoto_Player_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void PB_MeasurementPB_MouseDown(object sender, MouseEventArgs e)
        {
           //
            if (!CurrentStereoImage.isLastMeasureOpened())
            {
                bool PtFound = CurrentStereoImage.FindAnyPointUnderMouse(e.Location);
                if (!PtFound)  CurrentStereoImage.NewMeasurement(CurrentMeasureType);
            }
            else
            {
                //MouseUp will add a new point
            }
        }

        private void PB_MeasurementPB_DoubleClick(object sender, EventArgs e)
        {
            if (CurrentStereoImage.isLastMeasure_supportsClose()) CurrentStereoImage.Make_LastMeasurement_Ready();

        }

        private void PB_MeasurementPB_MouseUp(object sender, MouseEventArgs e)
        {
            if (!CurrentStereoImage.isLastMeasureOpened())
            {
                if(CurrentStereoImage.AnyPointUnderCursor)
                if (CurrentStereoImage.Point_UnderCursor_grabbed) CurrentStereoImage.Point_Ungrab();
            }
            else
            {
                CurrentStereoImage.AddPoint_2NewMeasurement(e.X, e.Y);
            }
            DB_Invalidate();
        }
        private void PB_MeasurementPB_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentStereoImage.Edit_Grabbed_Point(e.Location);
            }
            catch { }
            DB_Invalidate();
        }

        private void TLP_UserMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void Timer_3DRenderer_Tick(object sender, EventArgs e)
        {
            if (Playing_mode == Modes.Models3D)
                try { Draw_3D_graphics(); }
                catch
                { /*RenderTimer.Stop(); */}
        }

        private void OTK_3D_Control_Resize(object sender, EventArgs e)
        {
            if (!M3D_loaded)
                return;
            else OTK_3D_Control.Invalidate();
        }

        Point RV_Start = new Point(); //RV - RotationVector
        Point RV_Finish = new Point();//RV - RotationVector
        bool Rotating = false;
        double Rotation_power = 0;
        double Rotation_powerX = 0;
        double Rotation_powerY = 0;       
        double Power2Angle = ((490.0*Math.PI/180.0)/1.0)/Math.Sqrt(1920 * 1920 + 1080 * 1080); //Максимально - 45гр/с

        private void OTK_3D_Control_MouseDown(object sender, MouseEventArgs e)
        {
            int ObjectN = -1;
            //FindAnObject(e.X, e.Y);
            if(ObjectN==-1)
            {
                RV_Start = new Point(e.X, OTK_3D_Control.Height - e.Y);
                Rotating = true;
                if(!BGW_3DRotator.IsBusy) BGW_3DRotator.RunWorkerAsync();
            }
           
        }

        private void OTK_3D_Control_MouseUp(object sender, MouseEventArgs e)
        {
            if ((M3D_BasicMesh.IsGrabed()) || (M3D_Figure.IsGrabed()))
            {
                M3D_BasicMesh.SetGrabParameters(false, 0, 0);
                M3D_Figure.SetGrabParameters(false, 0, 0);
            }

            RV_Finish = new Point(e.X, OTK_3D_Control.Height - e.Y);

       
            Rotating = false;

        }

        private void OTK_3D_Control_MouseMove(object sender, MouseEventArgs e)
        {
            var Fig = new OpenTK_3DMesh.MyMesh();
            if (MeshesFixedByEachOther)
            {
                Fig = M3D_Figure.IsGrabed() ? M3D_Figure : M3D_BasicMesh;
                trans = 1.925f * (-Fig.TranslationZ) * 0.001f; //эмпирическая формула, коэффициент передвижения в зависимости от удаленности
                Fig.TranslationX += (e.X - remX) * trans;
                Fig.TranslationY -= (e.Y - remY) * trans;
                    
                Fig.TranslationX += (e.X - remX) * trans;
                Fig.TranslationY -= (e.Y - remY) * trans;
                remX = e.X; remY = e.Y;
                
            }
            else
            {

                if ((M3D_BasicMesh.IsGrabed()) || (M3D_Figure.IsGrabed()))
                {
                    Fig = M3D_Figure.IsGrabed() ? M3D_Figure : M3D_BasicMesh;
                    trans = 1.925f * (-Fig.TranslationZ) * 0.001f; //эмпирическая формула
                    Fig.TranslationX += (e.X - remX) * trans; Fig.TranslationY -= (e.Y - remY) * trans;
                    remX = e.X; remY = e.Y;
                }
                else
                {
                    if (Rotating)
                    {
                        RV_Finish = new Point(e.X, OTK_3D_Control.Height - e.Y);
                        double RP_dX = ((double)(RV_Finish.X - RV_Start.X));
                        double RP_dY = ((double)(RV_Finish.Y - RV_Start.Y));
                        Rotation_power = Math.Sqrt(Math.Pow(RP_dX, 2) + Math.Pow(RP_dY, 2));
                        double RP_cos = RP_dX / Rotation_power;
                        double RP_sin = RP_dY / Rotation_power;
                        Rotation_powerY = RP_dX;
                        Rotation_powerX = -RP_dY;


                        RotX = M3D_Figure.GetElementRotationX();
                        RotY = M3D_Figure.GetElementRotationY();
                        double New_RotX = RotX + Rotation_powerX * Power2Angle;
                        double New_RotY = RotY + Rotation_powerY * Power2Angle;
                        this.BeginInvoke((Action)(() => M3D_Figure.SetGetElementRotation(New_RotX, 0)));
                        this.BeginInvoke((Action)(() => M3D_Figure.SetGetElementRotation(New_RotY, 1)));
                        RV_Start = new Point(e.X, OTK_3D_Control.Height - e.Y);
                    }

                }
            }
        }

        private void PB_MeasurementPB_Click_1(object sender, EventArgs e)
        {

        }
        double RotX = 0;
        double RotY = 0;
        private void BGW_3DRotator_DoWork(object sender, DoWorkEventArgs e)
        {
           /* while (Rotating)
            {
                
                // Draw_3D_graphics();
            }*/

        }

        private void BWorkerForLoad3D_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            // Start the time-consuming operation.
            Bitmap dataBMP = CurrentStereoImage.BasicImage as Bitmap;
            BuildModel3D(bw, dataBMP, true);
        }

        private void TrB_WB_CorPower_Scroll(object sender, EventArgs e)
        {
            double realval = (float)TrB_WB_CorPower.Value / 100.0;
            L_WB_CorPower.Text = realval.ToString();
        }

        private void B_WB_LowerFrames_Click(object sender, EventArgs e)
        {
            if (NumOfImages_WB > 2) NumOfImages_WB--;
            L_WB_NumOfImages.Text = NumOfImages_WB.ToString();
            try { NumOfImages_WB = Convert.ToInt16(L_WB_NumOfImages.Text); }
            catch { L_WB_NumOfImages.Text="2" ; NumOfImages_WB = 2; }
        }

        private void B_WB_HigherFrames_Click(object sender, EventArgs e)
        {
            if (NumOfImages_WB < 10) NumOfImages_WB++;
            L_WB_NumOfImages.Text = NumOfImages_WB.ToString();
            try { NumOfImages_WB = Convert.ToInt16(L_WB_NumOfImages.Text); }
            catch { L_WB_NumOfImages.Text = "2"; NumOfImages_WB = 2; }
        }

        private void B_WB_Calculate_Click(object sender, EventArgs e)
        {
            if (!DigitalWB_Active)
            {
                WhiteBalance.InitializeMatrix(1, ref CMatrix, 3, Height_Current, Width_Current);//CMatrix
                CurNumOfImages_forWB = 1; Camulating_isActive = true;
            }
            else
            {
                if (CurNumOfImages_forWB != NumOfImages_WB) WhiteBalance.InitializeMatrix(1, ref CMatrix, 3, Height_Current, Width_Current);
                CurNumOfImages_forWB = NumOfImages_WB; Camulating_isActive = false;
            }
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}


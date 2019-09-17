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

namespace Stereo_Vision
{
    public partial class MainWindow : Form
    {
        bool AdminMode = false;
        bool isInTranslation = false;
        bool isPlayingVideoNow = false;
        bool throwed_to_hiber = false;
        bool isArduino_closed = true;
        int ticks = 0;
        string User_Name = "PNTZ";
        

        int Saving_ShowLabel_time = 3;

        public MainWindow()
        {
            InitializeComponent();
            //Additionally and specially for recording
            PB_Indicator.ImageLocation =  
                Path.Combine(System.Windows.Forms.Application.StartupPath, "rec_anim.gif");

            // Lock and un lock purpose
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);

            //stand by mode then 
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
          //  SystemEvents.Wake
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {


                MaximizeWindow();
                CreateAttachmentFactor(ref AttachmentFactor, LBConsole);
                PrepareTheCamera();
                //SetResolution(1280, 720);
                SwitchAdminMode(AdminMode);
                HideSomeThings();
                Restore_CaptureDirectory();
                Read_and_Load_Settings();
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
                BGWR_ChargeLev.WorkerSupportsCancellation = true;
                BGWR_ChargeLev.RunWorkerAsync();
                Set_ChargeBMP(BMP2set_chargelev);
                Set_ChargeTEXT(Text2set);
                StartCapture();


                this.DoubleBuffered = true;
                CurrentFrame = new Mat();
                CurrentFrame2 = new Mat();
                resizedim = new Mat();
                Size_for_Resizing = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 120);
               /* Width_for_Resizing = CV_ImBox_Capture.Width;
                Height_for_Resizing = CV_ImBox_Capture.Height;
                Size_for_Resizing = new Size(Width_for_Resizing, Height_for_Resizing);*/
            }
            catch { }
            finally { this.Visible = true; }
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

            Size_for_Resizing = new Size(this.Width, this.Height - 120);
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
        private void B_Browse_Click(object sender, EventArgs e)
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
            CV_ImBox_Capture.Visible = true;
            CV_ImBox_VidPhoto_Player.Visible = false;
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
            RecVid_path = TB_Settings_VidSavePath.Text;
        }

        private void B_Settings_FindPhotoPath_Click(object sender, EventArgs e)
        {
            Simple_choose_Directory(ref TB_Settings_PhotoSavePath);
            RecPhotos_path = TB_Settings_PhotoSavePath.Text;
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
            Toogle_Play_Mode(true);
        }

        private void B_Pl_PhotoMode_Click(object sender, EventArgs e)
        {
            Toogle_Play_Mode(false);
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
    }
}


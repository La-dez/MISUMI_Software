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
        bool throwed_to_hiber = false;
        bool isArduino_closed = true;

        string User_Name = "PNTZ";

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateAttachmentFactor(ref AttachmentFactor, LBConsole);
            PrepareTheCamera();
            // SetResolution(640, 480);
            SetResolution(1920, 1080);
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
            MaximizeWindow();
            CurrentFrame = new Mat();
            CurrentFrame2 = new Mat();

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {


            if ((e.KeyCode == Keys.Q) && e.Alt)
            {
                // Thread_for_Refreshing_of_ChargeLev.Abort();
                //Thread_for_Refreshing_of_ChargeLev.Join();
                BGWR_ChargeLev.CancelAsync();
                SaveSettings();
                while (!isArduino_closed)
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
        }

        private void TLP_UserMainPanel_Resize(object sender, EventArgs e)
        {
            TLP_UserMainPanel.Update();
           // LogMessage("Перерисовка!");
        }

        private void B_Quit_Click(object sender, EventArgs e)
        {
            if (isRecording) { StopRecording(); }
            if (isInTranslation) { StopCapture(); }

            SaveSettings();
            throwed_to_hiber = true;
            BGWR_ChargeLev.CancelAsync();
            while (!isArduino_closed)
            {
                //we will wait for closing
            }
            Application.Exit();
           // Application.SetSuspendState(PowerState.Hibernate, true, false);
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

        private void TBL_ExportPanel_Click(object sender, EventArgs e)
        {
            OpenMainPanel();
        }
        private void B_Photo_or_PauseRec_Click(object sender, EventArgs e)
        {
            TakeSnapShot();
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
            Open_Export_DirectoryTo();
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
            RecSnapShot_path = TB_Settings_PhotoSavePath.Text;
        }
    }
}

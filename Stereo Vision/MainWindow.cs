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
using CameraMath.Wrapper;

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
        bool is3DBuilding_cancelled = false;
        int ticks = 0;
        string User_Name = "MPEI";

        //TODO: убрать следующие переменные отсюда
        int NumOfImages_WB_needed = 2;
        int NumOfImages_WB_current = 0;
        int NumOfImages_WB_max= 10;
        int NumOfImages_WB_min = 0;

        bool DWB_Camulating_isActive = false;
        bool DWB_Active = false;
        double[,,] DWB_CorrectionMatrix = null;
        public static int Width_Current = 1280;
        public static int Height_Current = 720;
        public static int WH_global = 1280 * 720;

        int MS_in_cameraChecker = 0;

        int Saving_ShowLabel_time = 3;

        OnLoadingForm newForm = null;
        Action<int, string> ReportProgress = null;

        public const string MEOW_CurrentVerion = "2.71";
        
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
        public void SetReporter(Action<int,string> pReporter)
        {
            ReportProgress = pReporter;
        }
        public string Get_Version()
        {
            return MEOW_CurrentVerion;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

            List<string> ErrorStack = new List<string>();
            this.Visible = false;
            string ErStr = "";
            try
            {
                ReportProgress(0, "Инициализация калибровочных параметров..."); //System.Threading.Thread.Sleep(1000);
                try { Init_calib_worker(); } catch (Exception exc) { ErrorStack.Add("Ошибка инициализации считывателя калибровочных моделей 1"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(5, "Построение интерфейса..."); //System.Threading.Thread.Sleep(1000);
                try { Build_Interface(); } catch (Exception exc) { ErrorStack.Add("Ошибка построения интерфейса"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(10, "Построение интерфейса...");// System.Threading.Thread.Sleep(1000);
                try { MaximizeWindow(); ; } catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 1"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(15, "Построение интерфейса..."); //System.Threading.Thread.Sleep(1000);
                try { CreateAttachmentFactor(ref AttachmentFactor, LBConsole); } catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 2"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(20, "Подготовка камеры..."); //System.Threading.Thread.Sleep(1000);
                try { PrepareTheCamera(ref ErStr); ErrorStack.Add("4CC is: " + ErStr); }                               catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 3"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message);
                    ErrorStack.Add("INNER EXCEPTION 2: " + exc.InnerException.Message);
                    ErrorStack.Add("INNER EXCEPTION 3: " + exc.InnerException.InnerException.Message);
                }//
                ReportProgress(25, "Подготовка камеры...");// System.Threading.Thread.Sleep(1000);
                try { SetResolution(1280, 720); }                         catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 4"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }//
                ReportProgress(30, "Подготовка камеры..."); //System.Threading.Thread.Sleep(1000);
                try { SwitchAdminMode(AdminMode); }                       catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 5"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(35, "Подготовка интерфейса..."); //System.Threading.Thread.Sleep(1000);
                try { OpenMainPanel(); }                                  catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 6"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(40, "Подготовка интерфейса..."); //System.Threading.Thread.Sleep(1000);
                try { HideSomeThings(); }                                 catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 7"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(45, "Подготовка интерфейса...");// System.Threading.Thread.Sleep(1000);
                try { Read_and_Load_Settings(); }                         catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 8"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(50, "Подготовка интерфейса...");// System.Threading.Thread.Sleep(1000);
                try { System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest; } catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 9"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(55, "Подготовка интерфейса...");// System.Threading.Thread.Sleep(1000);
                try { ChargeLevel_preparence(); }                         catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 14"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(60, "Загрузка цветокоррекционной матрицы..."); //System.Threading.Thread.Sleep(1000);
                try { Load_Correction_Matrix(ref DWB_CorrectionMatrix); }              catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 14"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(65, "Запуск камеры...");// System.Threading.Thread.Sleep(1000);
                try { StartCapture(); }                                   catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 15"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }//
                ReportProgress(70, "Запуск камеры...");// System.Threading.Thread.Sleep(1000);
                try { Prepare_frame_objects(); }                        catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 16"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }//
                ReportProgress(80, "Подготовка буферов отрисовки..."); //System.Threading.Thread.Sleep(1000);
                try { Prepare_drawing_buffer(); }                         catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 17"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(85, "Подготовка к просмотру 3D моделей...");// System.Threading.Thread.Sleep(1000);
                try { Models_view_init(); }                               catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 18"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(95, "Инициализация директорий сохранения..."); //System.Threading.Thread.Sleep(1000);
                try { Restore_CaptureDirectory(); }                       catch (Exception exc) { ErrorStack.Add("Ошибка на этапе инициализации 19"); ErrorStack.Add("INNER EXCEPTION: " + exc.Message); }
                ReportProgress(100, "Готово!"); //System.Threading.Thread.Sleep(1000);

            }
            catch (Exception exc) { LogError(exc.Message); }
            finally
            {
                foreach (string exc in ErrorStack)
                    LogError(exc);
                this.Visible = true;
            }
        }
        private void Bgw_load_DoWork(object sender, DoWorkEventArgs e)
        {
            newForm.Show();
         //   this.Invoke(new Action(() => newForm.Show()));
        }

        private void Load_Correction_Matrix(ref double[,,] pMat)
        {
            try
            {
               // pMat = WhiteBalance.CorrectionMatrix_fromImage(RGBCalib_visual_path);
                WhiteBalance.Read_Correction_Matrix(RGBCalib_math_path, out pMat);
                DWB_Active = true;
            }
            catch
            {
                DWB_Active = false;
            }
        }
        
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Q) && e.Alt)
            {
                // Thread_for_Refreshing_of_ChargeLev.Abort();
                //Thread_for_Refreshing_of_ChargeLev.Join(); 
                try
                { SaveSettings(); }
                catch { }
                StopCapture();
                System.Diagnostics.Stopwatch stw_closing = new System.Diagnostics.Stopwatch();
                stw_closing.Start();
                while (/*(!isArduino_closed)&&*/(!lastFrame_processed)&&(stw_closing.Elapsed.TotalMilliseconds<3000))
                {
                    //int a = 0;
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
           /* ActivatePreviousMode = new Action(() =>
                                    {
                                        OpenMainPanel();
                                        if (isPlayingVideoNow) View_Video_Stop();
                                        if (!isInTranslation) StartCapture();
                                    });*/
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
            //   ActivatePreviousMode();
            if (BWorkerForLoad3D.IsBusy)
            {
                is3DBuilding_cancelled = true;
                BWorkerForLoad3D.CancelAsync();
                T_3DCancellingChecker.Start();
            }
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
            
            /*BackgroundWorker worker = sender as BackgroundWorker;
            RefreshChargeControls(ref worker,ref isArduino_closed);*/
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
            if ((STW_FPS.Elapsed.Seconds > 5) && (STW_FPS.Elapsed.Seconds % 10 == 0))
            {
                LogMessage(((float)FramesGotten / STW_FPS.Elapsed.TotalSeconds).ToString());
                FramesGotten = 0;
                STW_FPS.Restart();
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
            CurrentIndex = TRB_Pl_PhotoLister.Value;
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
            CurrentIndex = TRB_Pl_PhotoLister.Value;
            View_Model_byIndex(CurrentIndex);
        }


        float Rrrot = 0;
        private void B_Pl_ModelPrevious_Click(object sender, EventArgs e)
        {
            /* Rrrot -= (float)(22.5*Math.PI)/180.0f;
             //M3D_BasicMesh.SetGetElementRotation(Rrrot, 0);
             M3D_BasicMesh.SetGetElementRotation(Rrrot, 1);
             // M3D_Figure.TranslationZ = -10;
             Draw_3D_graphics();*/
            if (CurrentIndex - 1 == -1) CurrentIndex = FilesToView.Count - 1;
            else CurrentIndex--;
            TRB_Pl_ModelsLister.Value = CurrentIndex;
            View_Model_byIndex(CurrentIndex);
        }
        private void B_Pl_ModelNext_Click(object sender, EventArgs e)
        {
            /* Rrrot += (float)(22.5 * Math.PI) / 180.0f;
             //M3D_BasicMesh.SetGetElementRotation(Rrrot, 0);
             M3D_BasicMesh.SetGetElementRotation(Rrrot, 1);
             // M3D_Figure.TranslationZ = -10;
             Draw_3D_graphics();*/
            if (CurrentIndex + 1 == FilesToView.Count) CurrentIndex = 0;
            else CurrentIndex++;
            TRB_Pl_ModelsLister.Value = CurrentIndex;
            View_Model_byIndex(CurrentIndex);

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
        int index_of_photo_for_3dbuild = 0;
        private void B_Mes_Reconstruct3D_Click(object sender, EventArgs e)
        {
            index_of_photo_for_3dbuild = CurrentIndex;
            Allow3DInvalidate = false;
            Playing_mode = Modes.Models3D;
            Open_3DViewPanel(true);
            Build3D_fromstereo();

         /*   ActivatePreviousMode = new Action(() =>
            {
                Init_Stereoimage(FilesToView[CurrentIndex]);
                OpenMeasurementsPanel();
                DB_Invalidate();
            });*/

        }
        private void B_Ex_3DMode_Click(object sender, EventArgs e)
        {

        }

        private void B_Mes_Back_Click(object sender, EventArgs e)
        {
            Playing_mode = Modes.Photo;
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
                if ((e.Location.X < CurrentStereoImage.ROI_ctrl_left.Right) && (e.Location.X > CurrentStereoImage.ROI_ctrl_left.Left)&&
                    (e.Location.Y< CurrentStereoImage.ROI_ctrl_left.Bottom) &&(e.Location.Y > CurrentStereoImage.ROI_ctrl_left.Top))
                    CurrentStereoImage.AddPoint_2NewMeasurement(e.X, e.Y);
            }
            Cursor.Clip = new Rectangle();
            DB_Invalidate();
        }
        private void PB_MeasurementPB_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                
                CurrentStereoImage.Edit_Grabbed_Point(e.Location);
                if(CurrentStereoImage.Point_UnderCursor_grabbed)
                {
                    if ((e.Location.X < CurrentStereoImage.ROI_ctrl_left.Right) &&(e.Location.X > CurrentStereoImage.ROI_ctrl_left.Left)) Cursor.Clip = PB_MeasurementPB.RectangleToScreen(CurrentStereoImage.ROI_ctrl_left);
                    else if((e.Location.X < CurrentStereoImage.ROI_ctrl_right.Right) && (e.Location.X > CurrentStereoImage.ROI_ctrl_right.Left)) Cursor.Clip = PB_MeasurementPB.RectangleToScreen(CurrentStereoImage.ROI_ctrl_right);
                }
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
            Bitmap dataBMP = new Bitmap(CurrentStereoImage.BasicImage);
            BuildModel3D(bw, dataBMP, true,e);
        }

        private void TrB_WB_CorPower_Scroll(object sender, EventArgs e)
        {
            double realval = (float)TrB_WB_CorPower.Value / 100.0;
            L_WB_CorPower.Text = realval.ToString();
        }

        private void B_WB_LowerFrames_Click(object sender, EventArgs e)
        {
            if (NumOfImages_WB_needed > NumOfImages_WB_min) NumOfImages_WB_needed--;
            L_WB_NumOfImages.Text = NumOfImages_WB_needed.ToString();
            try { NumOfImages_WB_needed = Convert.ToInt16(L_WB_NumOfImages.Text); }
            catch { L_WB_NumOfImages.Text= NumOfImages_WB_min.ToString(); NumOfImages_WB_needed = NumOfImages_WB_min; }
        }

        private void B_WB_HigherFrames_Click(object sender, EventArgs e)
        {
            if (NumOfImages_WB_needed < NumOfImages_WB_max) NumOfImages_WB_needed++;
            L_WB_NumOfImages.Text = NumOfImages_WB_needed.ToString();
            try { NumOfImages_WB_needed = Convert.ToInt16(L_WB_NumOfImages.Text); }
            catch { L_WB_NumOfImages.Text = NumOfImages_WB_min.ToString(); NumOfImages_WB_needed = NumOfImages_WB_min; }
        }

        private void B_WB_Calculate_Click(object sender, EventArgs e)
        {
            if (!DWB_Active)
            {
                WhiteBalance.InitializeMatrix(1, ref DWB_CorrectionMatrix, 3, Height_Current, Width_Current);//CMatrix
                NumOfImages_WB_current = 0;
                DWB_Camulating_isActive = (NumOfImages_WB_needed == 0) ? false:true;
            }
            else
            {
                WhiteBalance.InitializeMatrix(1, ref DWB_CorrectionMatrix, 3, Height_Current, Width_Current);
                NumOfImages_WB_current = 0;
                DWB_Camulating_isActive = (NumOfImages_WB_needed == 0) ? false : true;
            }
            if(NumOfImages_WB_needed == 0) //обычно сохранение происходит после накопления изображений и вычисления матрицы. Поскольку кол-во изобр.=0, сохр.тут
            {
                WhiteBalance.Save_Correction_Matrix(RGBCalib_math_path, DWB_CorrectionMatrix);
            }
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void B_Set_FindStereoCalibFile_Click(object sender, EventArgs e)
        {
            //XMLCalib_path;
        }

        private void B_Set_FindWBCalibFile_Click(object sender, EventArgs e)
        {

        }

        private void BWorkerForLoad3D_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PrB_3D_Building.Value = e.ProgressPercentage;
        }

        private void BWorkerForLoad3D_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            is3DBuilding_cancelled = false;
            if (e.Cancelled == true)
            {
                LogMessage("Отменено пользователем!");

                Pan_3D_Building.Hide();

              //  B_Pl_GoToMain_Click(null, null);
            }
            else if (e.Error != null)
            {

                LogMessage("Ошибка: " + e.Error.Message);

                Pan_3D_Building.Hide();
              //  B_Pl_GoToMain_Click(null, null);
            }
            else
            {
                LogMessage("Успешно!");

                Pan_3D_Building.Hide();
                if (!string.IsNullOrWhiteSpace(Rec_Models_path))
                {
                    Find_and_Resort_Files(Modes.Models3D, Rec_Models_path); //пересортировка по дате
                }
                else { }


                Load_File_onControls(Modes.Models3D); //
            }

            if (BWG_restart)
            {
                BWG_restart = false; BWorkerForLoad3D.RunWorkerAsync();
            }
            else
            {
                B_Pl_ModelNext.BackgroundImage = BMP_PlNext_on;
                B_Pl_ModelPrevious.BackgroundImage = BMP_PlBack_on;
                B_Pl_ModelNext.Enabled = true;
                B_Pl_ModelPrevious.Enabled = true;
            }
         /*   var localmodel = Read3DModel(Model_name_lastbuild_fullpath);
            Load3DModel(localmodel);*/
        }

        private void B_3D_CancelBuilding_Click(object sender, EventArgs e)
        {

            BWorkerForLoad3D.CancelAsync();
            is3DBuilding_cancelled = true;
            if (!string.IsNullOrWhiteSpace(Rec_Photos_path))
            {
                Find_and_Resort_Files(Modes.Photo, Rec_Photos_path); //пересортировка по дате
            }
            else { }
            CurrentIndex = index_of_photo_for_3dbuild;
            Init_Stereoimage(FilesToView[CurrentIndex]);
            OpenMeasurementsPanel();
            DB_Invalidate();
            T_3DCancellingChecker.Start();
            /*OpenMainPanel();
            if (isPlayingVideoNow) View_Video_Stop();
            StartCapture();*/
        }

        private void T_3DCancellingChecker_Tick(object sender, EventArgs e)
        {
            if(BWorkerForLoad3D.IsBusy) //еще занят, держим кнопку 3D некликабельной
            {
                B_Mes_Reconstruct3D.BackgroundImage = BMP_Build3D_off;
                B_Mes_Reconstruct3D.Enabled = false;

            } 
            else
            {
                B_Mes_Reconstruct3D.BackgroundImage = BMP_Build3D_on;
                B_Mes_Reconstruct3D.Enabled = true;
                T_3DCancellingChecker.Stop();

            }
        }

        private void BGW_StereoInitializer_DoWork(object sender, DoWorkEventArgs e)
        {
            Init_calibration_readers(6);
        }

        private void BGW_StereoInitializer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           Action alpha = ( ()=> {
               B_Mes_Reconstruct3D.BackgroundImage = BMP_Build3D_on;
               B_Mes_Reconstruct3D.Enabled = true;
           });
            this.Invoke(alpha);
        }

        private void T_CameraPluggedIn_Checker_Tick(object sender, EventArgs e)
        {
            MS_in_cameraChecker += T_CameraPluggedIn_Checker.Interval;
            if(MS_in_cameraChecker>500 && FramesGotten==0 && isInTranslation)
            {
                Draw_Frame_NoCamera();
            }
        }

        private void TLP_ChargeLev_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


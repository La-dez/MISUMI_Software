using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using System.IO;

namespace Stereo_Vision
{
    public partial class MainWindow
    {
        private VideoCapture _capture = null;
        bool isRecording = false;
        bool isSnapShot_needed = false;
        private Mat CurrentFrame;
        private Mat CurrentFrame2;
        //Var's for Video Translation and recording
        int TotalFramesGotten = 0;
        double CurrentFPS = 0;
        double Fps_toWrite = 10;

        //Var's for videorecord
        double Lenght_secs = 10;
        int FramesToGot = 60 * 30;
        string RecVid_path = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Video");
        string RecSnapShot_path = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Photo");
        string Export_Vid_from = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Video");
        string Export_Photos_from = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Photo");
        string Export_Vid_to = null;
        string Export_Photos_to = null;
        string Current_Extension_video = ".mp4";
        string Current_Extension_photo = ".bmp";
        string Video_name = "Video_";
        string Snapshot_name = "Snapshot_";
        int Brightness_Value = 0;
        int Contrast_Value = 0;
        int Saturation_Value = 0;
        int Gamma_Value = 0;
        int Gain_Value = 0;
        int Loaded_Width = 640;
        int Loaded_Height = 480;
        int Current_FourCC = -1;

        int Export_style = 0; //0 - С момента последнего включения, 
                              //1 - За время(укажите время в часах),
                              //2 - Последние несколько(укажите количество),
                              //3 - Все

        int Number_of_FilesorHours = 0;
        int Count_of_Digits_vid = 2;
        int Count_of_Digits_snap = 3;
        int LastNumber_Vid = 4;
        int LastNumber_Photo = 0;

        DateTime LastNumber_Vid_forExport ;
        DateTime LastNumber_Photo_forExport ;

        bool All_isPrepared_forCapture = false;
        VideoWriter VidWriter = null;
        bool CaptureStoped_byUser = false;
        System.Diagnostics.Stopwatch STW = new System.Diagnostics.Stopwatch();
        int FramesGotten = 0;

       // List<string> Captured_names_Vids = new List<string>(); Вместо этого пишу цифры просто
       // List<string> Captured_names_Photos = new List<string>();

        private void PrepareTheCamera()
        {
            CvInvoke.UseOpenCL = false;
            try
            {

                _capture = new VideoCapture();
                _capture.ImageGrabbed += ProcessFrame;
                // _capture.

            }
            catch (NullReferenceException excpt)
            {
               LogError(excpt.Message);
            }
            CurrentFrame = new Mat();


            int MaxHeight = 1080;
            int MaxWidth = 1920;
            int FourCC_MJPG = VideoWriter.Fourcc('M', 'J', 'P', 'G');
            Current_FourCC = FourCC_MJPG;   
           /* int FourCC_MP4 = VideoWriter.Fourcc('M', 'P', '4', 'V'); 
            int FourCC_LAGS = VideoWriter.Fourcc('L', 'A', 'G', 'S');
            int FourCC_H264 = VideoWriter.Fourcc('H', '2', '6', '4');
            int FourCC_YUY2 = VideoWriter.Fourcc('Y', 'U', 'Y', '2');*/

            /* char[] FourCC_MJPG_str = FourCC_int_2_str(FourCC_MJPG);

             int FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
             char[] FourCC_Current_str = FourCC_int_2_str(FourCC_Current);*/


            /*    _capture.SetCaptureProperty(CapProp.FrameWidth, 1280);
                _capture.SetCaptureProperty(CapProp.FrameHeight, 720);*/
               STW.Start();

            // 
            /*FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
            FourCC_Current_str = FourCC_int_2_str(FourCC_Current);
            int CurFps = (int)_capture.GetCaptureProperty(CapProp.Fps);*/


            /*   _capture.SetCaptureProperty(CapProp.FourCC, FourCC_YUY2);
               _capture.SetCaptureProperty(CapProp.FrameWidth, MaxWidth);
               _capture.SetCaptureProperty(CapProp.FrameHeight, MaxHeight);
               FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
               FourCC_Current_str = FourCC_int_2_str(FourCC_Current);
               _capture = new VideoCapture();*/


        }
        private void SetYUYFHD()
        {
            int FourCC_YUY2 = VideoWriter.Fourcc('Y', 'U', 'Y', '2');
            int FourCC_MJPG = VideoWriter.Fourcc('M', 'J', 'P', 'G');
            char[] FourCC_YUY2_str = FourCC_int_2_str(FourCC_MJPG);
            char[] FourCC_MJPG_str = FourCC_int_2_str(FourCC_MJPG);
            string FCC = "";

            int FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
            char[] FourCC_Current_str = FourCC_int_2_str(FourCC_Current);

            _capture.SetCaptureProperty(CapProp.FourCC, FourCC_MJPG);
            _capture.SetCaptureProperty(CapProp.FrameWidth, 1280);
            _capture.SetCaptureProperty(CapProp.FrameHeight, 720);
            FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
            FourCC_Current_str = FourCC_int_2_str(FourCC_Current);
            FCC = new string(FourCC_Current_str);
            LogMessage("FourCC is " + FCC);

            _capture.SetCaptureProperty(CapProp.FourCC, FourCC_YUY2);
            _capture.SetCaptureProperty(CapProp.FrameWidth, 1920);
            _capture.SetCaptureProperty(CapProp.FrameHeight, 1080);
            //hue
            //monochrome
            //sharpness
            _capture.SetCaptureProperty(CapProp.Hue, 50);
            _capture.SetCaptureProperty(CapProp.Monochrome, 19);
            _capture.SetCaptureProperty(CapProp.Sharpness, 50);
            FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
            FourCC_Current_str = FourCC_int_2_str(FourCC_Current);
            FCC = new string(FourCC_Current_str);
            var CurW = (int)_capture.GetCaptureProperty(CapProp.FrameWidth);
            var CurH = (int)_capture.GetCaptureProperty(CapProp.FrameHeight);
            LogMessage("FourCC now is " + FCC);
            LogMessage("Resolution is " + CurW + "x" + CurH);

            STW.Start();

        }
        private void ProcessFrame(object sender, EventArgs arg) //Все, что происходит при получении кадра
        {

            
            try
            {
                if (_capture != null && _capture.Ptr != IntPtr.Zero)
                {
                    _capture.Retrieve(CurrentFrame,0);
                    Refresh_image_Invoke(CurrentFrame);
                   // CV_ImBox_Capture.Image = CurrentFrame;
                    FramesGotten++;
                    if((STW.Elapsed.Seconds>5) && (STW.Elapsed.Seconds % 10 == 0))
                    {
                        LogMessage(((float)FramesGotten / STW.Elapsed.TotalSeconds).ToString());
                        FramesGotten = 0;
                        STW.Restart();
                    }
                    using (CurrentFrame2 = CurrentFrame.Clone())
                    {
                        if (isRecording)
                        {
                            if (All_isPrepared_forCapture)
                            {
                                if (!CaptureStoped_byUser)
                                {
                                    if (TotalFramesGotten < FramesToGot)
                                    {
                                        VidWriter.Write(CurrentFrame2);
                                        TotalFramesGotten++;
                                    }
                                    else
                                    {
                                        LastNumber_Vid++;
                                        All_isPrepared_forCapture = false;
                                        LogMessage("Временной фрагмент записан! Реинициализация записи...");
                                        if (VidWriter.IsOpened)
                                        {
                                            VidWriter.Dispose();
                                        }
                                        Initialize_VideoWriter();
                                        LogMessage("Запись следующего фрагмента!");
                                    }
                                }
                                else
                                {
                                    LogMessage("Запись остановлена пользователем!");
                                    LastNumber_Vid++;
                                    All_isPrepared_forCapture = false;
                                    try
                                    {
                                        if (VidWriter.IsOpened)
                                        {
                                            VidWriter.Dispose();
                                        }
                                        LogMessage("Фрагмент сохранен успешно!");
                                        CaptureStoped_byUser = false;
                                    }
                                    catch
                                    {
                                        LogMessage("Фрагмент не сохранен. Произошла ошибка.");
                                    }
                                    finally
                                    {
                                        isRecording = false;
                                    }
                                }
                            }
                        }
                        if (isSnapShot_needed)
                        {
                            CurrentFrame2.Save(RecSnapShot_path + "\\" + Snapshot_name + LastNumber_Photo.ToString() + Current_Extension_photo);
                            LastNumber_Photo++;
                            if (LastNumber_Photo > Math.Pow(10, Count_of_Digits_snap) - 1) LastNumber_Photo = 0;
                            isSnapShot_needed = false;
                        }
                    }
                   // if (throwed_to_hiber) System.Windows.Forms.Application.SetSuspendState(System.Windows.Forms.PowerState.Hibernate, true, false);
                }
            }
            catch
            {
                //Попробуем в следующий раз
            }
        }
        private void TakeSnapShot()
        {
            isSnapShot_needed = true;
        }
        private void Restore_CaptureDirectory()
        {
            if (!Directory.Exists("C:\\Video")) Directory.CreateDirectory("C:\\Video");
            if (!Directory.Exists("C:\\Photo")) Directory.CreateDirectory("C:\\Photo");
        }
        private void StartCapture()
        {
            if (_capture != null)
            {
                //start the capture
                _capture.Start();
                isInTranslation = !isInTranslation;
            }
        }
        private void StopCapture()
        {
            if (_capture != null)
            {  //stop the capture  
                               
                _capture.Stop();
                isInTranslation = !isInTranslation;
            }
        }
        private bool StartRecording()
        {
            bool noErrors = true;
            isRecording = true;
            if (_capture != null)
            {

                try { Initialize_VideoWriter(); }
                catch { noErrors = false; }
                Show_Indicator();
                Toogle_Rec_Button(true);
                LogMessage("Video writer is ready!Start of recording...");
            }
            if (noErrors) return true;
            else return false;
        }
        private bool StopRecording()
        {
            bool noErrors = true;
            CaptureStoped_byUser = true;
            Delete_Indicator();
            Toogle_Rec_Button(false);
            if (noErrors) return true;
            else return false;
        }
        private void Initialize_VideoWriter()
        {
            try
            {
                LogMessage("Подготовка к записи...");
                TotalFramesGotten = 0;
                FramesToGot = (int)(Fps_toWrite * Lenght_secs);
                string FullPathAndName = CalculatenName_forNewVideo();
                
                int fWidth = Convert.ToInt32(_capture.GetCaptureProperty(CapProp.FrameWidth));
                int fHeight = Convert.ToInt32(_capture.GetCaptureProperty(CapProp.FrameHeight));
                //int FourCC = Convert.ToInt32(_capture.GetCaptureProperty(CapProp.FourCC));
                // int FourCC = VideoWriter.Fourcc('M', 'P', '4', 'V'); //try this
                int FourCC = VideoWriter.Fourcc('L', 'A', 'G', 'S');
                // int FourCC = VideoWriter.Fourcc('H', '2', '6', '4');

                VidWriter = new VideoWriter(FullPathAndName, FourCC, Fps_toWrite, new System.Drawing.Size(fWidth, fHeight), true);
                All_isPrepared_forCapture = true;
                LogMessage("Подготовка к записи завершена успешно!");
            }
            catch
            {
                LogError("Ошибка при подготовке к записи. Проверьте настойки. ");
            }
        }
        private char[] FourCC_int_2_str(int FourCC)
        {
            char[] st=new char[5];
            st[0] = (char)(FourCC & 0xff);
            st[1] = (char)((FourCC >> 8) & 0xff);
            st[2] = (char)((FourCC >> 16) & 0xff);
            st[3] = (char)((FourCC >> 24) & 0xff);
            st[4] = (char)0;
            return st;
        }
        private string CalculatenName_forNewVideo()
        {
            string Digit_PostFix = "";
            if (LastNumber_Vid > Math.Pow(10, Count_of_Digits_vid) - 1) LastNumber_Vid = 0;
            while (Digit_PostFix.Length < Count_of_Digits_vid) Digit_PostFix += "0";//Заполняем нулями до нужной кондиции
            Digit_PostFix = String.Format(("{0:d"+ Count_of_Digits_vid.ToString()+"}"), LastNumber_Vid);
            string resultivename = RecVid_path + "\\" + Video_name + Digit_PostFix + Current_Extension_video;
            return resultivename;
        }
        
        private void SetResolution(int w,int h)
        {
            _capture.SetCaptureProperty(CapProp.FrameWidth, w);
            _capture.SetCaptureProperty(CapProp.FrameHeight, h);
        }
        private void Adjust_Brightness()
        {

            LBrigthnessValue.Text = TrBBrightness.Value.ToString();
            try
            {
                if (_capture != null) _capture.SetCaptureProperty(CapProp.Brightness, TrBBrightness.Value);
                Brightness_Value = TrBBrightness.Value;
            }
            catch
            {
                LogError("Nope!");
            }
        }
        private void Adjust_Contrast()
        {
            LContrastValue.Text = TrBContrast.Value.ToString();
            try
            {
                if (_capture != null) _capture.SetCaptureProperty(CapProp.Contrast, TrBContrast.Value);
                Contrast_Value = TrBContrast.Value;
            }
            catch
            {
                LogError("Nope!");
            }
        }
        private void Adjust_Saturation()
        {
            LSaturationValue.Text = TrBSaturation.Value.ToString();
            try
            {
                if (_capture != null) _capture.SetCaptureProperty(CapProp.Saturation, TrBSaturation.Value);
                Saturation_Value = TrBSaturation.Value;
            }
            catch
            {
                LogError("Nope!");
            }
        }
        private void Adjust_Gamma()
        {
            LGammaValue.Text = TrBGamma.Value.ToString();
            try
            {
                if (_capture != null) _capture.SetCaptureProperty(CapProp.Gamma, TrBGamma.Value);
                Gamma_Value = TrBGamma.Value;
            }
            catch
            {
                LogError("Nope!");
            }
        }
        private void Adjust_Gain()
        {
            LGainValue.Text = TrBGain.Value.ToString();
            try
            {
                if (_capture != null) _capture.SetCaptureProperty(CapProp.Gain, TrBGain.Value);
                Gain_Value = TrBGain.Value;
            }
            catch
            {
                LogError("Nope!");
            }
        }
        private void DisposeData()
        {
            if (_capture != null)
                _capture.Dispose();
        }

        /* private void Find_All_the_DShowCameras()
         {
             DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
             WebCams = new Video_Device[_SystemCamereas.Length];
             for (int i = 0; i < _SystemCamereas.Length; i++)
             {
                 WebCams[i] = new Video_Device(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID); //fill web cam array
                 Camera_Selection.Items.Add(WebCams[i].ToString());
             }
             if (Camera_Selection.Items.Count > 0)
             {
                 Camera_Selection.SelectedIndex = 0; //Set the selected device the default
                 captureButton.Enabled = true; //Enable the start
             }
         }*/


    }
}

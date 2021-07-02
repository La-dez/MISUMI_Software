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
        bool lastFrame_processed = true;
        private Mat CurrentFrame;
        private Mat CurrentFrame2;
        public Mat CurrentFrame_wb;
        private Mat resizedim;
        int Width_for_Resizing = 1280;
        int Height_for_Resizing = 720;
        System.Drawing.Size Size_for_Resizing = new System.Drawing.Size(1280, 720);
        //Var's for Video Translation and recording
        int TotalFramesGotten = 0;
        double CurrentFPS = 0;
        double Fps_toWrite = 30;
        double FpsMax_toTranslate = 30;

        //Var's for videorecord
        double Lenght_secs = 10;
        int FramesToGot = 60 * 30;
        string Rec_Videos_path = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Video");
        string Rec_Photos_path = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Photo");
        string Rec_Models_path = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\","Models");

        string Rec_Videos_path_def = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Video");
        string Rec_Photos_path_def = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Photo");
        string Rec_Models_path_def = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Models");

        string Export_Vid_from = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Video");
        string Export_Photos_from = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Photo");
        string Export_Models_from = Path.Combine(/*System.Windows.Forms.Application.StartupPath*/"C:\\", "Models");

        string Export_Vid_to = null;
        string Export_Photos_to = null;
        string Export_Models_to = null;

        string Current_Extension_video = ".mp4";
        string Current_Extension_photo = ".jpeg";
        string Current_Extension_model = ".ply";

        string Video_name = "Video_";
        string Snapshot_name = "Snapshot_";
        string Model_name = "Model_";

        string Video_name_lastcaptured = "Video_00.mp4";
        string Photo_name_lastcaptured = "Snapshot_000.jpeg";
        string Model_name_lastcaptured = "Model_000.ply";

        string XMLCalib_path = "M5_chess.xml"; //string cfgFilePath = IsPrism ? "M5_chess.xml" : "M1_chess.xml"
        const string RGBCalib_visual_path = "RGB_calib_matrix.bmp";
        const string RGBCalib_math_path = "RGB_calib_matrix.cm";
        string RGBCalib_path = RGBCalib_visual_path;

        string Photo_name_lastcaptured_fullpath = null;
        string Model_name_lastbuild_fullpath = null;
        int Brightness_Value = 0;
        int Contrast_Value = 0;
        int Saturation_Value = 0;
        int Gamma_Value = 0;
        int Gain_Value = 0;
        int Loaded_Width = 1280;
        int Loaded_Height = 720;
        int Current_FourCC = -1;
        double exposure = 0;

        int Export_style = 0; //0 - С момента последнего включения, 
                              //1 - За время(укажите время в часах),
                              //2 - Последние несколько(укажите количество),
                              //3 - Все

        int Number_of_FilesorHours = 0;
        int Count_of_Digits_vid = 2;
        int Count_of_Digits_snap = 3;
        int Count_of_Digits_mod = 3;

        int LastNumber_Vid = 4;
        int LastNumber_Photo = 0;
        int LastNumber_Model = 0;

        DateTime LastNumber_Vid_forExport ;
        DateTime LastNumber_Photo_forExport ;
        DateTime LastNumber_Models_forExport;

        bool All_isPrepared_forCapture = false;
        VideoWriter VidWriter = null;
        bool CaptureStoped_byUser = false;
        System.Diagnostics.Stopwatch STW_FPS = new System.Diagnostics.Stopwatch();
        System.Diagnostics.Stopwatch STW_Draw = new System.Diagnostics.Stopwatch();
        System.Diagnostics.Stopwatch STW_Resizing = new System.Diagnostics.Stopwatch();
        System.Diagnostics.Stopwatch STW_2HideLabel = new System.Diagnostics.Stopwatch();
        
        int FramesGotten = 0;
        float FramesDrawn = 0;
        bool FrameDrawn = true;
        bool FrameBalanced = false;
      

        // List<string> Captured_names_Vids = new List<string>(); Вместо этого пишу цифры просто
        // List<string> Captured_names_Photos = new List<string>();

        private void PrepareTheCamera(ref string StrErr)
        {
            CvInvoke.UseOpenCL = false;
            try
            {

                _capture = new VideoCapture();
             /*  double Aexp = _capture.GetCaptureProperty(CapProp.AutoExposure);
                _capture.SetCaptureProperty(CapProp.AutoExposure, 0.25);
                Aexp = _capture.GetCaptureProperty(CapProp.AutoExposure);*/

               // _capture.SetCaptureProperty(CapProp.Settings, 1);

                //Не работает, по факту
              /*  exposure = _capture.GetCaptureProperty(CapProp.Exposure);
                _capture.SetCaptureProperty(CapProp.Exposure,-7);
                exposure = _capture.GetCaptureProperty(CapProp.Exposure);*/
                //Тоже не раотает
                //_capture.SetCaptureProperty(CapProp.AutoExposure,  0.25);
                
              
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
               LogError(excpt.Message);
            }
            CurrentFrame = new Mat();

            int FourCC_MJPG = VideoWriter.Fourcc('M', 'J', 'P', 'G'); //с Misumi работает это и 
           // int FourCC_MPEG = VideoWriter.Fourcc('M', 'P', 'E', 'G');
            int FourCC_YUY2 = VideoWriter.Fourcc('Y', 'U', 'Y', '2'); // это
            //int FourCC_MP4 = VideoWriter.Fourcc('M', 'P', '4', 'V');
            //int FourCC_LAGS = VideoWriter.Fourcc('L', 'A', 'G', 'S');
           // int FourCC_H264 = VideoWriter.Fourcc('H', '2', '6', '4');
            int FCC_2set = FourCC_MJPG;

            char[] FourCC_MJPG_str = FourCC_int_2_str(FourCC_MJPG);

             int FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
             char[] FourCC_Current_str = FourCC_int_2_str(FourCC_Current);

            _capture.SetCaptureProperty(CapProp.FourCC, FCC_2set);
            _capture.SetCaptureProperty(CapProp.FrameWidth, 1280);
            _capture.SetCaptureProperty(CapProp.FrameHeight, 720);
          /*  FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
            FourCC_Current_str = FourCC_int_2_str(FourCC_Current);         
            int CurrentWidth = (int)_capture.GetCaptureProperty(CapProp.FrameWidth);*/


            STW_FPS.Start();
            STW_Draw.Start();

            // 
      /*      FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
            FourCC_Current_str = FourCC_int_2_str(FourCC_Current);
            StrErr = new string(FourCC_Current_str);*/

           

            // int CurFps = (int)_capture.GetCaptureProperty(CapProp.Fps);*/


            /*   _capture.SetCaptureProperty(CapProp.FourCC, FourCC_YUY2);
               _capture.SetCaptureProperty(CapProp.FrameWidth, MaxWidth);
               _capture.SetCaptureProperty(CapProp.FrameHeight, MaxHeight);
               FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
               FourCC_Current_str = FourCC_int_2_str(FourCC_Current);
               _capture = new VideoCapture();*/


        }
        private void ProcessFrame2(object sender, EventArgs arg) //Все, что происходит при получении кадра
        {

            lastFrame_processed = false;


            try
            {
                if (_capture != null && _capture.Ptr != IntPtr.Zero)
                {

                    _capture.Retrieve(CurrentFrame, 0); //Получение кадра. Переодический промер FPS
                    FramesGotten++;
                    //ресайз кадра
                    CvInvoke.Resize(CurrentFrame, resizedim, Size_for_Resizing, 0, 0, Inter.Linear);
                    CV_ImBox_Capture.Image = resizedim;

                    //Переодический замер физического FPS
                    if ((STW_FPS.Elapsed.Seconds > 5)) //случается примерно раз в 10 секунд
                    {
                        LogMessage("Скорость получения кадров: " + ((float)FramesGotten / STW_FPS.Elapsed.TotalSeconds).ToString());
                        FramesGotten = 0;
                        STW_FPS.Restart();
                    }

                }
            }
            catch (Exception eee)
            {
                lastFrame_processed = true;
                return;
                //Попробуем в следующий раз
            }
            lastFrame_processed = true;
        }

        private void ProcessFrame(object sender, EventArgs arg) //Все, что происходит при получении кадра
        {

            lastFrame_processed = false;


            try
            {
                if (_capture != null && _capture.Ptr != IntPtr.Zero)
                {

                    _capture.Retrieve(CurrentFrame, 0); //Получение кадра. Переодический промер FPS
                    FrameBalanced = false;
                    //wb
                    using (CurrentFrame_wb = CurrentFrame.Clone())
                    {
                        if (DWB_Camulating_isActive)
                        {
                            if (NumOfImages_WB_current < NumOfImages_WB_needed)
                            {
                                WhiteBalance.CorrectionMatrix_AddImage(ref DWB_CorrectionMatrix, ref CurrentFrame_wb);
                                NumOfImages_WB_current++;
                            }
                            else
                            {
                                DWB_Camulating_isActive = false; DWB_Active = true;

                                System.Diagnostics.Stopwatch STW_WBMatrixCalculation = new System.Diagnostics.Stopwatch();
                                STW_WBMatrixCalculation.Start();
                                try
                                {
                                    double CorrectionPower = Convert.ToDouble(L_WB_CorPower.Text);
                                    WhiteBalance.CorrectionMatrix_AverageFromImages(ref DWB_CorrectionMatrix, NumOfImages_WB_needed, Height_Current, Width_Current);
                                    WhiteBalance.CorrectionMatrix_FromNormilizedMatrix_Fastest(ref DWB_CorrectionMatrix, CorrectionPower, Width_Current, Height_Current);
                                    Mat datamat = new Mat(new System.Drawing.Size(Width_Current, Height_Current), DepthType.Cv8U, 3);
                                    WhiteBalance.Image_InitByValue(ref datamat);
                                    WhiteBalance.CorrectImage_viaCorrectionMatrix_Color_p(DWB_CorrectionMatrix, ref datamat);
                                    datamat.Save(RGBCalib_visual_path);
                                    WhiteBalance.Save_Correction_Matrix(RGBCalib_math_path,DWB_CorrectionMatrix);
                                   // var f = WhiteBalance.Test_convertion_3dm_2_1dm();
                                    //var f2 = WhiteBalance.Test_RW_ofCorrMatrix();                                   
                                }
                                catch (Exception exc) { LogError(exc.Message); }
                                STW_WBMatrixCalculation.Stop();
                                LogMessage("Вычисление коррекционной матрицы Методом Указателей завершено. Прошло времени: " + (STW_WBMatrixCalculation.ElapsedMilliseconds / 1000.0).ToString());
                            }
                        } //если сбор кадров для балансирования активен
                        else //иначе
                        {
                            WhiteBalance.CorrectImage_viaCorrectionMatrix_Color_p(DWB_CorrectionMatrix, ref CurrentFrame_wb);
                            CurrentFrame = CurrentFrame_wb.Clone();
                            FrameBalanced = true;
                        }
                    }


                    FramesGotten++;
                    
                    FrameDrawn = false; 
                    //ресайз кадра
                    STW_Resizing.Start();
                    CvInvoke.Resize(CurrentFrame, resizedim, Size_for_Resizing, 0, 0, Inter.Linear);
                    STW_Resizing.Stop();

                    //Переодический замер скорости отрисовки и физического FPS
                    if ((STW_FPS.Elapsed.Seconds > 5)) //случается примерно раз в 10 секунд
                    {
                        LogMessage("Скорость получения кадров: " + ((float)FramesGotten / STW_FPS.Elapsed.TotalSeconds).ToString());
                        LogMessage("Время изменения размера кадра: " + (STW_Resizing.Elapsed.TotalSeconds / FramesDrawn).ToString());
                        LogMessage("Скорость отрисовки кадров: " + (FramesDrawn / STW_Draw.Elapsed.TotalSeconds).ToString());
                        FramesGotten = 0;
                        FramesDrawn = 0;
                        STW_Draw.Reset();
                        STW_Resizing.Reset();
                        STW_FPS.Restart();
                    }

                    //  Refresh_image_Invoke(resizedim);
                    // отрисовка кадра
                    STW_Draw.Start();
                    CV_ImBox_Capture.Image = resizedim;
                    STW_Draw.Stop();
                    
                    
                    FramesDrawn++;
                    FrameDrawn = true;

                    //захват кадра для видео
                    if (isRecording)
                    {
                        using (CurrentFrame2 = CurrentFrame.Clone())
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
                                    All_isPrepared_forCapture = false;
                                    try
                                    {
                                        if (VidWriter.IsOpened)
                                        {
                                            VidWriter.Dispose();
                                        }

                                        UpdateTextBox("Фрагмент " + Video_name_lastcaptured + " сохранен!", L_SnapShotSaved);
                                        LogMessage("Фрагмент сохранен успешно!");
                                        ToogleLabelVisibility(true, ref L_SnapShotSaved);
                                        LastNumber_Vid++;
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
                    }
                    //захват кадра для фото
                    if (isSnapShot_needed)
                    {
                        /*  using (CurrentFrame2 = resizedim.Clone())
                          {*/
                        Photo_name_lastcaptured = CalculatenName_forNewPhoto_withoutPath();
                        CurrentFrame.Save(Rec_Photos_path + "\\" + Photo_name_lastcaptured);
                        Photo_name_lastcaptured_fullpath = Rec_Photos_path + "\\" + Photo_name_lastcaptured;
                        LastNumber_Photo++;
                        isSnapShot_needed = false;
                        UpdateTextBox("Кадр " + Photo_name_lastcaptured + " сохранен!", L_SnapShotSaved);
                        //  }
                    }
                    //скрывалка лэйбла с подписью о сохранении кадра
                    if (L_SnapShotSaved.Visible)
                    {
                        if (STW_2HideLabel.Elapsed.TotalSeconds > Saving_ShowLabel_time)
                        {
                            double RT_Elapsed = STW_2HideLabel.Elapsed.TotalSeconds;
                            ToogleLabelVisibility(false, ref L_SnapShotSaved);
                            STW_2HideLabel.Stop();
                        }
                    }

                    //if (throwed_to_hiber) System.Windows.Forms.Application.SetSuspendState(System.Windows.Forms.PowerState.Hibernate, true, false);
                }
            }
            catch
            {
                lastFrame_processed = true;
                return;
                //Попробуем в следующий раз
            }
            if (T_CameraPluggedIn_Checker.Enabled == true) T_CameraPluggedIn_Checker.Stop();
            lastFrame_processed = true;
        }
        
        private void TakeSnapShot()
        {
            isSnapShot_needed = true;
            UpdateTextBox("Сохранение...", L_SnapShotSaved);
            ToogleLabelVisibility(true,ref L_SnapShotSaved);
            STW_2HideLabel.Restart();

        }
        private void Restore_CaptureDirectory()
        {
            //сделано через invoke, так как иначе не открывалось окно на весь экран
            try
            {
                if (!String.IsNullOrEmpty(Rec_Models_path))
                {
                    Directory.CreateDirectory(Rec_Models_path);
                }
                else throw new Exception();
            }
            catch
            {
                string data_last_Rec_Models_path = Rec_Models_path;
                this.BeginInvoke(new Action(() =>
                {
                    System.Threading.Thread.Sleep(1000);
                    System.Windows.Forms.MessageBox.Show("Путь " + data_last_Rec_Models_path + " не может быть создан! Сохранение моделей будет производиться в " + Rec_Models_path_def, "Предупреждение",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                }));
                Rec_Models_path = Rec_Models_path_def;
                Directory.CreateDirectory(Rec_Models_path_def);
            }
            //сделано через invoke, так как иначе не открывалось окно на весь экран
            try
            {
                if (!String.IsNullOrEmpty(Rec_Photos_path))
                {
                    Directory.CreateDirectory(Rec_Photos_path);
                }
                else throw new Exception();
            }
            catch
            {
                string data_last_Rec_Photos_path = Rec_Photos_path;
                this.BeginInvoke(new Action(() =>
                {
                    System.Threading.Thread.Sleep(1000);
                    System.Windows.Forms.MessageBox.Show("Путь " + data_last_Rec_Photos_path + " не может быть создан! Сохранение моделей будет производиться в " + Rec_Photos_path_def, "Предупреждение",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                }));
                Rec_Photos_path = Rec_Photos_path_def;
                Directory.CreateDirectory(Rec_Photos_path_def);
            }
            //сделано через invoke, так как иначе не открывалось окно на весь экран
            try
            {
                if (!String.IsNullOrEmpty(Rec_Videos_path))
                {
                    Directory.CreateDirectory(Rec_Videos_path);
                }
                else throw new Exception();
            }
            catch
            {
                string data_last_Rec_Videos_path = Rec_Videos_path;
                this.BeginInvoke(new Action(() =>
                {
                    System.Threading.Thread.Sleep(1000);
                    System.Windows.Forms.MessageBox.Show("Путь " + data_last_Rec_Videos_path + " не может быть создан! Сохранение моделей будет производиться в " + Rec_Videos_path_def, "Предупреждение",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                }));
                Rec_Videos_path = Rec_Videos_path_def;
                Directory.CreateDirectory(Rec_Videos_path_def);
            }
        }
        private void StartCapture()
        {
            if (_capture != null && _capture.Ptr != null)
            {
                //start the capture
                LogMessage("Камера не нуль");
                _capture.Start();
                LogMessage("Запись включена");
                isInTranslation = !isInTranslation;
                T_CameraPluggedIn_Checker.Start();
            }
            else
            {
                string fourcc_cur = "";
                PrepareTheCamera(ref fourcc_cur);
                SetResolution(1280, 720);
                Read_and_Load_Settings();
                _capture.Start();
                isInTranslation = true;
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
            try
            {
                Delete_Indicator();
                Toogle_Rec_Button(false);
                STW_2HideLabel.Restart();
            }
            catch
            {
                noErrors = false;
            }
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
                Video_name_lastcaptured = CalculatenName_forNewVideo();
                string FullPathAndName = Rec_Videos_path + "\\" + Video_name_lastcaptured;

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
            char[] st = new char[5];
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
            string resultivename = Video_name + Digit_PostFix + Current_Extension_video;
            return resultivename;
            
        }
        private string CalculatenName_forNewPhoto_withoutPath()
        {
            string Digit_PostFix = "";
            if (LastNumber_Photo > Math.Pow(10, Count_of_Digits_snap) - 1) LastNumber_Photo = 0;
            while (Digit_PostFix.Length < Count_of_Digits_snap) Digit_PostFix += "0";//Заполняем нулями до нужной кондиции
            Digit_PostFix = String.Format(("{0:d" + Count_of_Digits_snap.ToString() + "}"), LastNumber_Photo);
            string resultivename = Snapshot_name + Digit_PostFix + Current_Extension_photo;
            return resultivename;
        }
        private string CalculatenName_forNewModel()
        {
            string Digit_PostFix = "";
            if (LastNumber_Model > Math.Pow(10, Count_of_Digits_mod) - 1) LastNumber_Model = 0;
            while (Digit_PostFix.Length < Count_of_Digits_mod) Digit_PostFix += "0";//Заполняем нулями до нужной кондиции
            Digit_PostFix = String.Format(("{0:d" + Count_of_Digits_mod.ToString() + "}"), LastNumber_Model);
            string resultivename = Model_name + Digit_PostFix + Current_Extension_model;
            return resultivename;
        }
        private void SetResolution(int w,int h)
        {
            _capture.SetCaptureProperty(CapProp.FrameWidth, w);
            _capture.SetCaptureProperty(CapProp.FrameHeight, h);

            Width_Current = (int)_capture.GetCaptureProperty(CapProp.FrameWidth);
            Height_Current = (int)_capture.GetCaptureProperty(CapProp.FrameHeight);

            WhiteBalance.InitializeMatrix(1, ref DWB_CorrectionMatrix, Width_Current, Height_Current, 3);
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

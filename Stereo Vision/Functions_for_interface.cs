﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using System.IO;

using Microsoft.Win32;

namespace Stereo_Vision
{
    public partial class MainWindow
    {
        int AttachmentFactor = 10;
        bool FullScrin = false;
        TabPage[] adminPages = null;
        int LastChargeLevel = 100;
        Bitmap BMP2set_chargelev = new Bitmap("20-0.png");
        public static Bitmap BMP2set_chargelev_100_80 = new Bitmap("100-80.png");
        public static Bitmap BMP2set_chargelev_80_60 = new Bitmap("80-60.png");
        public static Bitmap BMP2set_chargelev_60_40 = new Bitmap("60-40.png");
        public static Bitmap BMP2set_chargelev_40_20 = new Bitmap("40-20.png");
        public static Bitmap BMP2set_chargelev_20_0 = new Bitmap("20-0.png");
        static Bitmap BMP_ExMode_Video = new Bitmap("ex_video.png");
        static Bitmap BMP_ExMode_Video_off = new Bitmap("ex_video_off.png");
        static Bitmap BMP_ExMode_Photo = new Bitmap("ex_photo2.png");
        static Bitmap BMP_ExMode_Photo_off = new Bitmap("ex_photo2_off.png");
        string Text2set = "?%";

        delegate void DelegateForMessages(string text);
        delegate void DelegateForattachments(string text,int lev);

        bool Export_mode = true; //true if Video, false if Photo
        private void LogMessage(string message)
        {
            if (!LBConsole.InvokeRequired)
            {
                if (null == message)
                {
                    throw new ArgumentNullException("message");
                }
                string data = string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}: {1}", DateTime.Now, message);
                object index;
                if (data.Length <= AttachmentFactor)
                {
                    index = data;
                    LBConsole.Items.Insert(0, index);
                }
                else
                {
                    index = data.Substring(0, AttachmentFactor) + "...";
                    LBConsole.Items.Insert(0, index);
                    LogAttachment(data.Substring(AttachmentFactor), 1);
                }
            }
            else
            {
                DelegateForMessages d = new DelegateForMessages(LogMessage);
                    this.Invoke(d, new object[] { message });
            }

        }
        private void LogMessage(string message,params object[] args)
        {
            LogMessage(String.Format(message, args.ToString()));
        }
        private void LogAttachment(string Addmessage, int level)
        {
            if (!LBConsole.InvokeRequired)
            {
                if (null == Addmessage)
            {
                throw new ArgumentNullException("message");
            }
            string data = Addmessage;
            object index;
            if (data.Length <= AttachmentFactor)
            {
                index = "..." + data;
                LBConsole.Items.Insert(level, index);
            }
            else
            {
                index = "..." + data.Substring(0, AttachmentFactor) + "...";
                LBConsole.Items.Insert(level, index);
                LogAttachment(data.Substring(AttachmentFactor), level + 1);
            }
            }
            else
            {
                DelegateForattachments d = new DelegateForattachments(LogAttachment);
                this.Invoke(d, new object[] { Addmessage , level });
            }
        }
        private void CreateAttachmentFactor(ref int pAF, ListBox pLB)
        {
            const float widthofthesymbol = 5.5f;
            pAF = (int)((float)pLB.Width / widthofthesymbol) - 10;
        }

        /// <summary>
        /// Add an error log message and show an error message box
        /// </summary>
        /// <param name="message">The message</param>
        private void LogError(string message)
        {
            LogMessage("Ошибка: " + message);
        }
        private string Handler(int pValue)
        {
            if (pValue != -1) return pValue.ToString();
            else return "Unknown";
        }
        private string GetDateString()
        {
            string res = DateTime.Today.ToString();
            res = (res.Substring(0, res.IndexOf(' '))).Replace('.', '_');
            return res;
        }
        private string GetTimeString()
        {
            string res = DateTime.Now.ToString();
            res = (res.Substring(res.IndexOf(' ') + 1, res.Length - res.IndexOf(' ') - 1)).Replace(':', '_');
            return res;
        }
        private delegate void UpdateTextBoxDelegate(String Text, Label Control);
        private void UpdateTextBox(String Text, Label Control)
        {
            if (Control.InvokeRequired)
            {
                try
                {
                    UpdateTextBoxDelegate UT = new UpdateTextBoxDelegate(UpdateTextBox);
                    this.BeginInvoke(UT, new object[] { Text, Control });
                }
                catch (Exception ex)
                {
                    LogError("ORIGINAL: " + ex.Message);
                }
            }
            else
            {
                Control.Text = Text;
                this.Refresh();
            }
        }
        private void OpenSettings()
        {
            Pan_Export.Visible = false;
            Pan_UserMain.Visible = false;
            Pan_Settings.Visible = true;
        }
        private void OpenMainPanel()
        {
            Pan_Export.Visible = false;
            Pan_UserMain.Visible = true;
            Pan_Settings.Visible = false;           
        }
        private void OpenExportPanel()
        {
            Pan_Export.Visible = true;
            Pan_UserMain.Visible = false;
            Pan_Settings.Visible = false;
            CB_Ex_ChooseExportMode.SelectedIndex = Export_style;
        }
        private void SwitchAdminMode(bool isAdmin)
        {
            LBConsole.Visible = isAdmin;
            if (!isAdmin)
            {
                adminPages = new TabPage[] { /*TABC_Settings.TabPages[2], */TABC_Settings.TabPages[3], TABC_Settings.TabPages[4] };
                TABC_Settings.TabPages[4].Parent = null;
                TABC_Settings.TabPages[3].Parent = null;
               // TABC_Settings.TabPages[2].Parent = null;
            }
            else
            {
               TABC_Settings.TabPages.Add(adminPages[0]);
                TABC_Settings.TabPages.Add(adminPages[1]);
                /*TABC_Settings.TabPages.Add(adminPages[2]);*/
            }

            LogMessage("AdminMode = " + isAdmin.ToString());
        }
        private void Toogle_Rec_Button(bool recison)
        {
            if(recison)
            {
                B_SwitchRec.BackgroundImage = new Bitmap("stop.png");
                label1.Text = "Стоп";
            }
            else
            {
                B_SwitchRec.BackgroundImage = new Bitmap("rec.png");
                label1.Text = "Запись";
            }
        }
        private void Show_Indicator()
        {
            PB_Indicator.Visible = true;
            PB_Indicator.ImageLocation =
                System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "rec_anim.gif");
            LogMessage("Индикатор показан!");
        }
        private void Delete_Indicator()
        {
            PB_Indicator.Visible = false;
           // PB_Indicator.Image = null;
            LogMessage("Индикатор спрятан!");
        }
        private void Read_and_Load_Settings()
        {
            try
            {
                string FileName = "App_prop.cfg";
                string[] AllLines = System.IO.File.ReadAllLines(FileName);
                for (int i = 0; i < AllLines.Count(); i++)
                {
                    int startind2 = AllLines[i].IndexOf('<');
                    int finishind2 = AllLines[i].IndexOf('>');
                    string data = AllLines[i].Substring(startind2 + 1, finishind2 - startind2 - 1);
                    switch (data)
                    {
                        case "LenghtOfOneFileInSeconds":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Lenght_secs = Convert.ToInt16(toObject);
                                break;
                            }
                        case "FPStoWrite":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Fps_toWrite = Convert.ToInt16(toObject);
                                break;
                            }
                        case "LastFileDigit_vid":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                LastNumber_Vid = Convert.ToInt16(toObject);
                                break;
                            }
                        case "LastFileDigit_Photo":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                LastNumber_Photo = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Count_of_files_Vid":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Count_of_Digits_vid = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Count_of_files_Photo":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Count_of_Digits_snap = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Export_style":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Export_style = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Number_of_FilesorHours":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Number_of_FilesorHours = Convert.ToInt16(toObject);
                                break;
                            }
                        case "LastChargeLevel":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                LastChargeLevel = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Brightness":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Brightness_Value = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Contrast":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Contrast_Value = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Saturation":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Saturation_Value = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Gamma":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Gamma_Value = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Gain":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Gain_Value = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Width":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Loaded_Width = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Height":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Loaded_Height = Convert.ToInt16(toObject);
                                break;
                            }
                        case "Path_2save_Video":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                RecVid_path = toObject;
                                break;
                            }
                        case "Path_2save_Photo":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                RecSnapShot_path = toObject;
                                break;
                            }
                        case "Last_export_path_Video":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Export_Vid_from = toObject;
                                break;
                            }
                        case "Last_export_path_Photo":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Export_Photos_from = toObject;
                                break;
                            }
                        case "Last_export_path_Video_to":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Export_Vid_to = toObject;
                                break;
                            }
                        case "Last_export_path_Photo_to":
                            {
                                string toObject = CutFromEdges(AllLines[i]);
                                Export_Photos_to = toObject;
                                break;
                            }
                    }

                }
                LastNumber_Photo_forExport = DateTime.Now;
                LastNumber_Vid_forExport = DateTime.Now;
                Load_Settings();
            }
            catch
            {
                Read_and_Load_Default_Settings();
            }
        }
        private void Read_and_Load_Default_Settings() //На случай, если что-то пойдет не так
        {
            LastChargeLevel = 100;
            User_Name = "PNTZ";
            Lenght_secs = 60;                           
            Fps_toWrite = 15;
            LastNumber_Vid = 0;
            LastNumber_Photo = 0;
            Count_of_Digits_vid = 2;
            Count_of_Digits_snap = 3;
            Export_style = 3;
            Number_of_FilesorHours = 1;
            Brightness_Value = 0;
            Contrast_Value = 0;
            Saturation_Value = 0;
            Gamma_Value = 0;
            Gain_Value = 0;
            Loaded_Width = 1280;
            Loaded_Height = 720;
            RecVid_path = Path.Combine("C:\\", "Video");
            RecSnapShot_path = Path.Combine("C:\\", "Photo");
            Export_Vid_from = Path.Combine("C:\\", "Video");
            Export_Photos_from = Path.Combine("C:\\", "Photo");
            Export_Vid_to = Path.Combine("C:\\", "Video" + " export " + User_Name); ;
            Export_Photos_to = Path.Combine("C:\\", "Photo" + " export " + User_Name); ;
            LastNumber_Photo_forExport = DateTime.Now;
            LastNumber_Vid_forExport = DateTime.Now;
            Load_Settings();
        }
        private void Load_Settings()
        {
            FramesToGot = (int)(Fps_toWrite * Lenght_secs);


            //Установка свойтсв камеры на контролы
            try
            {
                TrBBrightness.Value = Brightness_Value;
                TrBContrast.Value = Contrast_Value;
                TrBSaturation.Value = Saturation_Value;
                TrBGamma.Value = Gamma_Value;
                TrBGain.Value = Gain_Value;
                Adjust_Brightness();
                Adjust_Contrast();
                Adjust_Saturation();
                Adjust_Gamma();
                Adjust_Gain();

                _capture.SetCaptureProperty(CapProp.FourCC, Current_FourCC);
                _capture.SetCaptureProperty(CapProp.Fps, Fps_toWrite);
                _capture.SetCaptureProperty(CapProp.FrameWidth, Loaded_Width);
                _capture.SetCaptureProperty(CapProp.FrameHeight, Loaded_Height);

                int W = (int)_capture.GetCaptureProperty(CapProp.FrameWidth);
                int FourCC_Current = (int)_capture.GetCaptureProperty(CapProp.FourCC);
                char[] FourCC_Current_str = FourCC_int_2_str(FourCC_Current);
            }
            catch
            {

            }
            TB_Settings_VidSavePath.Text = RecVid_path;
            TB_Settings_PhotoSavePath.Text = RecSnapShot_path;

            if (Export_mode)
            {
                TB_Ex_PathFrom.Text = Export_Vid_from;
                TB_Ex_PathTo.Text = Export_Vid_to;
            }
            else
            {
                TB_Ex_PathFrom.Text = Export_Photos_from;
                TB_Ex_PathTo.Text = Export_Photos_to;
            }

            Charge.ToogleCharge_Level(ref BMP2set_chargelev, ref Text2set, LastChargeLevel);
            CB_Ex_ChooseExportMode.SelectedIndex = Export_style;
            TB_Ex_Count.Text = Number_of_FilesorHours.ToString();
        }
        private string CutFromEdges(string target)
        {
            try
            {
                int startind = target.IndexOf('>');
                int finishind = target.LastIndexOf('<');
                string val = target.Substring(startind + 1, finishind - startind - 1);
                return val;
            }
            catch
            {
                return "1";
            }
        }
        private void SaveSettings()
        {
            string ExactFileName = "App_prop.cfg";
                using (StreamWriter sw = new StreamWriter(new FileStream(ExactFileName, FileMode.Create, FileAccess.Write)))
                {
                    sw.WriteLine("<LenghtOfOneFileInSeconds>" + Lenght_secs+ "</LenghtOfOneFileInSeconds>");
                    sw.WriteLine("<FPStoWrite>" + Fps_toWrite+"</FPStoWrite>");
                    sw.WriteLine("<LastFileDigit_vid>" + LastNumber_Vid+"</LastFileDigit_vid>");
                    sw.WriteLine("<LastFileDigit_Photo>" + LastNumber_Photo + "</LastFileDigit_Photo>");
                    sw.WriteLine("<Count_of_files_Vid>" + Count_of_Digits_vid + "</Count_of_files_Vid>");
                    sw.WriteLine("<Count_of_files_Photo>" + Count_of_Digits_snap + "</Count_of_files_Photo>");
                    sw.WriteLine("<Export_style>" + Export_style + "</Export_style>");
                    sw.WriteLine("<Number_of_FilesorHours>" + Number_of_FilesorHours + "</Number_of_FilesorHours>");
                    sw.WriteLine("<LastChargeLevel>" + LastChargeLevel + "</LastChargeLevel>");

                    sw.WriteLine("<Brightness>" + Brightness_Value + "</Brightness>");
                    sw.WriteLine("<Contrast>" + Contrast_Value + "</Contrast>");
                    sw.WriteLine("<Saturation>" + Saturation_Value + "</Saturation>");
                    sw.WriteLine("<Gamma>" + Gamma_Value + "</Gamma>");
                    sw.WriteLine("<Gain>" + Gain_Value + "</Gain>");
                    sw.WriteLine("<Width>" + (_capture.GetCaptureProperty(CapProp.FrameWidth)).ToString() + "</Width>");
                    sw.WriteLine("<Height>" + (_capture.GetCaptureProperty(CapProp.FrameHeight)).ToString() + "</Height>");

                    sw.WriteLine("<Path_2save_Video>" + RecVid_path + "</Path_2save_Video>");
                    sw.WriteLine("<Path_2save_Photo>" + RecSnapShot_path + "</Path_2save_Photo>");
                    sw.WriteLine("<Last_export_path_Video>" + Export_Vid_from + "</Last_export_path_Video>");
                    sw.WriteLine("<Last_export_path_Photo>" + Export_Photos_from + "</Last_export_path_Photo>");
                    sw.WriteLine("<Last_export_path_Video_to>" + Export_Vid_to + "</Last_export_path_Photo>");
                    sw.WriteLine("<Last_export_path_Photo_to>" + Export_Photos_to + "</Last_export_path_Photo_to>");
                }
        }

        void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                LogMessage("lock");
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                LogMessage("Unlock");
            }
        }


        void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if ((e.Mode == PowerModes.Suspend))
            {              
                LogMessage("standby");
            }
            else if((e.Mode == PowerModes.StatusChange))
            {
                LogMessage("Зарядка включена \\ отключена");

            }
            else if (e.Mode == PowerModes.Resume)
            {
                throwed_to_hiber = false;
                LogMessage("Resumed from standby");               
                if (!isInTranslation) StartCapture();
                try
                {
                    //Thread_for_Refreshing_of_ChargeLev = new System.Threading.Thread(RefreshChargeControls);
                    Set_ChargeBMP(BMP2set_chargelev);
                    Set_ChargeTEXT(Text2set);
                    LastNumber_Photo_forExport = DateTime.Now;
                    LastNumber_Vid_forExport = DateTime.Now;
                    //  Thread_for_Refreshing_of_ChargeLev.Start();
                }
                catch(Exception eeee) { MessageBox.Show(eeee.Message); }
            }
            switch (SystemInformation.PowerStatus.PowerLineStatus)
            {
                case PowerLineStatus.Online:
                    LogMessage("Устройство работает от сети.");
                    break;
                case PowerLineStatus.Offline:
                    LogMessage("Устройство работает от аккумулятора.");
                    switch (SystemInformation.PowerStatus.BatteryChargeStatus)
                    {
                        case System.Windows.Forms.BatteryChargeStatus.Low:
                            LogMessage("Внимание! Малый уровень зарядки.");
                            break;
                        case System.Windows.Forms.BatteryChargeStatus.Critical:
                            LogMessage("Внимание! Критический уровень зарядки.");
                            break;
                        default:
                            LogMessage("Уровень зарядки в норме.");
                            break;
                    }
                    LogMessage("Уровень заряда аккумулятора: " + SystemInformation.PowerStatus.BatteryLifePercent.ToString());
                    break;
                case PowerLineStatus.Unknown:
                    LogMessage("Источник питания устройства неопознан.");
                    break;
            }

        }
        private void MaximizeWindow()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            FullScrin = true;
      
        }
        private void InvalidateAllThis()
        {
            TLP_UserMainPanel.Update();
           // LogMessage("Перерисовка!");
        }
        private void HideSomeThings()
        {
            Pan_Settings.Visible = false;
            Pan_Export.Visible = false;
            
        }
        private void MinimizeWindow()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Size = new Size(1366, 768);
            this.WindowState = FormWindowState.Normal;
           // this.Location = new Point(0, 0);
            FullScrin = false;
        }
        delegate void DelegateForChargeLev_text(string pChargeLev_s);
        delegate void DelegateForChargeLev_BMP(System.Drawing.Bitmap pBMP);
        private void Set_ChargeBMP(Bitmap pBMP2set)
        {

            if (PB_ChargeVal.InvokeRequired)
            {
                DelegateForChargeLev_BMP del = new DelegateForChargeLev_BMP(Set_ChargeBMP);
                this.Invoke(del, new object[] { pBMP2set });
            }
            else { PB_ChargeVal.Image = pBMP2set; }
            
        }
        private void Set_ChargeTEXT(string pTextLevel)
        {
            if (L_ChargeLev.InvokeRequired)
            {
                DelegateForChargeLev_text del = new DelegateForChargeLev_text(Set_ChargeTEXT);
                this.Invoke(del, new object[] { pTextLevel });
            }
            else
            {
                L_ChargeLev.Text = pTextLevel;
            }
            
        }

        delegate void Delegate_setImage(Mat Image);
        private void Refresh_image_Invoke(Mat pImage)
        {
            Delegate_setImage del = new Delegate_setImage(Refresh_image_NOInvoke);
            this.Invoke(del, new object[] { pImage });
        }
        private void Refresh_image_NOInvoke(Mat ppImage)
        {
            CV_ImBox_Capture.Image = CurrentFrame;
        }
        private void RefreshChargeControls(ref System.ComponentModel.BackgroundWorker pWorker,ref bool p_isArdClosed)
        {
            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Lowest;
            while (true)
            {

                float CurVoltage = Charge.GetChargeLevel_Voltage(ref pWorker,false,ref p_isArdClosed);
               
                if (CurVoltage >= 1.0f)
                {
                    LastChargeLevel = Charge.TimeLeft2Percents(Charge.Gained_voltage_2_timeleft(CurVoltage));
                    Charge.ToogleCharge_Level(ref BMP2set_chargelev, ref Text2set, LastChargeLevel);
                    Set_ChargeTEXT(Text2set);
                    Set_ChargeBMP(BMP2set_chargelev);
                    if (LastChargeLevel < 5)
                    {
                        System.Threading.Thread.Sleep(2000);
                        B_Quit_Click(null, null);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(10000);
                    }
                }
            }
            
        }
        private void Open_Export_DirectoryFrom()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if(Export_mode) folderBrowser.SelectedPath = RecVid_path;
            else folderBrowser.SelectedPath = RecSnapShot_path;
            DialogResult result = folderBrowser.ShowDialog();
            
            if (Export_mode) Export_Vid_from = folderBrowser.SelectedPath;
            else Export_Photos_from = folderBrowser.SelectedPath;

            if (result==DialogResult.OK)
            {
                TB_Ex_PathFrom.Text = folderBrowser.SelectedPath;
            }

        }
        private void Simple_choose_Directory(ref TextBox TB)
        {           
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (!string.IsNullOrWhiteSpace(TB.Text)) folderBrowser.SelectedPath = TB.Text;
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                TB.Text = folderBrowser.SelectedPath;
            }

        }
        private void Open_Export_DirectoryTo()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (((Export_mode) && (Export_Vid_to == null)) || ((!Export_mode) && (Export_Photos_to == null)))
            {
                string Non_C_disk = "C:\\";
                if (Export_mode) Non_C_disk = Find_another_disk();
                else Non_C_disk = Find_another_disk(); //Стараемся найти флешку

                string Final_directory = " export ";
                if (Export_mode) { Final_directory = Path.Combine(Non_C_disk, "Video"+ Final_directory+ User_Name); }
                else { Final_directory = Path.Combine(Non_C_disk, "Photo"+ Final_directory+ User_Name); } //Создаем на ней папку для экспорта

                try //Проверяем, есть ли такая директория. Если нет - создаем
                {
                    if (!Directory.Exists(Final_directory))
                        Directory.CreateDirectory(Final_directory);
                }
                catch // Если создать не получилось, выбираем аналогичную в корне диска С
                {
                    if (Export_mode) { Final_directory = Path.Combine("C:\\", "Video"+ " export "+ User_Name); }
                    else { Final_directory = Path.Combine("C:\\", "Photo"+ " export "+ User_Name); }
                }
                if (Export_mode) { Export_Vid_to = Final_directory; }
                else { Export_Photos_to = Final_directory; }
            }
            if (Export_mode) folderBrowser.SelectedPath = Export_Vid_to;
            else folderBrowser.SelectedPath = Export_Photos_to;

            DialogResult result = folderBrowser.ShowDialog();

            if (Export_mode) Export_Vid_to = folderBrowser.SelectedPath;
            else Export_Photos_to = folderBrowser.SelectedPath;

            if (result == DialogResult.OK)
            {
                TB_Ex_PathTo.Text = folderBrowser.SelectedPath;
            }
        }
        private string Find_another_disk()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string remDisk = "C:\\";
            foreach (DriveInfo d in allDrives)
            {
                if (d.Name != "C:\\")
                {
                    try
                    {
                        LogMessage("Drive {0}", d.Name);
                        LogMessage("  File type: {0}", d.DriveType);
                        if (d.IsReady == true)
                        {
                            remDisk = d.Name;
                            LogMessage("  Volume label: {0}", d.VolumeLabel);
                            LogMessage("  File system: {0}", d.DriveFormat);
                            LogMessage("  Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);

                            LogMessage("  Total available space:          {0, 15} bytes", d.TotalFreeSpace);

                            LogMessage("  Total size of drive:            {0, 15} bytes ", d.TotalSize);

                            break;
                        }
                    }
                    catch { }             
                }
            }
            return remDisk;
        }
        private void Toogle_Export_Mode(bool ExportMode_2set)
        {
            string L_Ex_mode_text_bkp = L_Ex_Mode.Text;
            string Path_from_bkp = TB_Ex_PathFrom.Text;
            string Path_to_bkp = TB_Ex_PathTo.Text;
            Image BMP_vid = B_Ex_VideoMode.BackgroundImage;
            Image BMP_pho = B_Ex_PhotoMode.BackgroundImage;
            bool exp_m_bkp = Export_mode;
            try
            {
                if (ExportMode_2set)
                {
                    L_Ex_Mode.Text = "Экспорт Видео";
                    if (!string.IsNullOrWhiteSpace(Export_Vid_from))
                    {
                        TB_Ex_PathFrom.Text = Export_Vid_from;
                    }
                    else { TB_Ex_PathFrom.Text = ""; }
                    if (!string.IsNullOrWhiteSpace(Export_Vid_to))
                    {
                        TB_Ex_PathTo.Text = Export_Vid_to;
                    }
                    else { TB_Ex_PathTo.Text = ""; }
                    B_Ex_PhotoMode.BackgroundImage = BMP_ExMode_Photo_off;
                    B_Ex_VideoMode.BackgroundImage = BMP_ExMode_Video;

                    Export_mode = ExportMode_2set;
                }
                else
                {
                    L_Ex_Mode.Text = "Экспорт Фото";
                    if (!string.IsNullOrWhiteSpace(Export_Photos_from))
                    {
                        TB_Ex_PathFrom.Text = Export_Photos_from;
                    }
                    else { TB_Ex_PathFrom.Text = ""; }
                    if (!string.IsNullOrWhiteSpace(Export_Photos_to))
                    {
                        TB_Ex_PathTo.Text = Export_Photos_to;
                    }
                    else { TB_Ex_PathTo.Text = ""; }
                    B_Ex_PhotoMode.BackgroundImage = BMP_ExMode_Photo;
                    B_Ex_VideoMode.BackgroundImage = BMP_ExMode_Video_off;

                    Export_mode = ExportMode_2set;
                }
            }
            catch
            {
                L_Ex_Mode.Text = L_Ex_mode_text_bkp;
                TB_Ex_PathFrom.Text = Path_from_bkp;
                TB_Ex_PathTo.Text =  Path_to_bkp;
                B_Ex_VideoMode.BackgroundImage = BMP_vid;
                B_Ex_PhotoMode.BackgroundImage = BMP_pho;
                Export_mode = exp_m_bkp;
            }
        }
        private void ExportFiles()
        {
            string StartDir = (Export_mode) ? Export_Vid_from : Export_Photos_from;
            string FinishDir = (Export_mode) ? Export_Vid_to : Export_Photos_to;
            DateTime LastWokeUpTime = (Export_mode) ? LastNumber_Vid_forExport: LastNumber_Photo_forExport;
            bool Copying_is_unavaliable = false;
            List<string> files = new List<string>();
            List<string> files_data = new List<string>();
            List < FileInfo> fiArr = new List<FileInfo>();

            if (!string.IsNullOrWhiteSpace(StartDir))
            {
                files = new List<string>(Directory.GetFiles(StartDir)); //Получает полные пути
                files_data = new List<string>(Directory.GetFiles(StartDir));
                DirectoryInfo di = new DirectoryInfo(StartDir);
                fiArr = new List<FileInfo>(di.GetFiles());
            }
            switch (Export_style)
            {
                case 0: //С момента последнего включения
                    {
                        for (int i = 0; i < files.Count(); i++)
                        {
                            DateTime dt = File.GetLastWriteTime(files[i]);
                            if (dt < LastWokeUpTime) { files.RemoveAt(i); fiArr.RemoveAt(i);i--; }
                        }
                        break;
                    }
                case 1: //За время  в часах 
                    {
                        TimeSpan needed_difference = new TimeSpan(0, Number_of_FilesorHours, 0, 0, 0);
                        TimeSpan data_difference;
                        for (int i = 0; i < files.Count(); i++)
                        {
                            DateTime dt = File.GetLastWriteTime(files[i]);
                            data_difference = LastWokeUpTime.Subtract(dt);
                          //  DateTime data_dif = new DateTime(LastWokeUpTime - dt);
                            if ((data_difference) >= needed_difference) { files.RemoveAt(i); fiArr.RemoveAt(i); i--; }
                        }
                        break;
                    }
                case 2: //Самое сложное: последние в штуках
                    {
                        if(files.Count > Number_of_FilesorHours)
                        files.Sort(delegate (string file1, string file2) 
                        { return File.GetLastWriteTime(file1).CompareTo(File.GetLastWriteTime(file2)); });
                        fiArr.Sort(delegate (FileInfo file1_inf, FileInfo file2_inf)
                        { return file1_inf.LastWriteTime.CompareTo(file2_inf.LastWriteTime); });
                        //Самые старые оказываются в начале
                        files.RemoveRange(0, files.Count - Number_of_FilesorHours);
                        fiArr.RemoveRange(0, fiArr.Count - Number_of_FilesorHours);
                        break;
                    }
                case 3: // все
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            try
            {
                long Weight = 0; //Узнаем размер всех файлов
                for (int i = 0; i < files.Count(); i++)
                {
                    Weight += fiArr[i].Length;
                }

                //Weight /= 1048576;
                for (int i = 0; i < files.Count(); i++) // Убираем начальную директорию
                {
                    files_data[i] = CutInitialPath(files[i], StartDir);
                }
                for (int i = 0; i < files.Count(); i++) // и добавляем конечную
                {
                    files_data[i] = Path.Combine(FinishDir, files_data[i]);
                }


                DriveInfo[] allDrives = DriveInfo.GetDrives();
                string remDisk = FinishDir.Substring(0, 3);
                long realFreeSpace = 0;
                foreach (DriveInfo d in allDrives) // Проверяем оставшееся место
                {
                    if (d.Name == remDisk)
                    {
                        try
                        {
                            if (d.IsReady == true)
                            {
                                realFreeSpace = d.AvailableFreeSpace;
                                // remDisk = d.Name;
                                break;
                            }
                        }
                        catch { }
                        break;
                    }
                }
                if (Weight > realFreeSpace * 0.95f)
                {
                    Copying_is_unavaliable = true;
                    MessageBox.Show("Недостаточно места на жестком диске/флеш носителе. Освободите место.",
                      "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!Copying_is_unavaliable) //Копируем, если ок
                {
                    Export_files_form EXP_files_From = new Export_files_form(files, files_data);
                    EXP_files_From.ShowDialog();
                }

            }
            catch(Exception exc)
            {
                MessageBox.Show("Ошибка при копировании файла. Сообщение: " + exc.Message,
                     "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private string CutInitialPath(string TargetString,string MinusString)
        {
            if (TargetString.Contains(MinusString))
            {
                int startIndex = MinusString.Length;
                return TargetString.Substring(startIndex + 1);
            }
            else return TargetString;
        }


    }
}

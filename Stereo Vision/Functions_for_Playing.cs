using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Emgu.CV;

using Emgu.CV.CvEnum;

namespace Stereo_Vision
{
    partial class MainWindow
    {

        enum PlayModes { Photo = 0, Video, Models3D };
        PlayModes Playing_mode = PlayModes.Video;
        List<string> FilesToView;
        int CurrentIndex = 0;
        VideoCapture CurrentVideo;
        int TotalFrames_inCurVid=0;
        int CurrentFrameNo_inCurVid=0;
        int FPS_toPlay;

        private void Initialize_Player_Controls(PlayModes pPlayMode_2set)
        {

            CV_ImBox_Capture.Visible = false;
            CV_ImBox_VidPhoto_Player.Visible = true;
            Toogle_Play_Mode(pPlayMode_2set);

        }
        private void Load_File_onControls(PlayModes pPlayMode_2set)
        {
            string InitialFilePath = null;
            if (FilesToView.Count == 0)
            {               
                CurrentFrame = (new Image<Emgu.CV.Structure.Bgr, byte>(Create_ImageOfEmptyness())).Mat;
                CV_ImBox_VidPhoto_Player.Image = CurrentFrame;
            }
            else
            {
                CurrentIndex = 0;
                InitialFilePath = FilesToView[CurrentIndex];
                Init_Scroll_Slider(pPlayMode_2set);

                if (pPlayMode_2set==PlayModes.Photo) View_Video_byIndex(0);
                else if(pPlayMode_2set == PlayModes.Video) View_Image_byIndex(0);
                else View_Model_byIndex(0);
            }
        }
        private Bitmap Create_ImageOfEmptyness()
        {
            System.Drawing.Bitmap BMP_noFiles = new Bitmap(CV_ImBox_Capture.Width, CV_ImBox_Capture.Height,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(BMP_noFiles))
            {
                g.Clear(Color.Black);
                string text_2draw = "Не найдено файлов для просмотра";
                var drawBrush = new SolidBrush(Color.FromArgb(0, 255, 0));
                var font = new Font("Arial", 18);
                g.DrawString(text_2draw, font, drawBrush, new PointF(5, 5));
            }
            return BMP_noFiles;
        }
        private void Init_Scroll_Slider(PlayModes ppPlayMode_2set)
        {
            switch(ppPlayMode_2set)
            {
                case PlayModes.Photo:
                    {

                        TRB_Pl_PhotoLister.Minimum = 0;
                        TRB_Pl_PhotoLister.Maximum = FilesToView.Count - 1;
                        TRB_Pl_PhotoLister.Value = 0;

                        L_Pl_Photo_All.Text = (FilesToView.Count).ToString();
                        L_Pl_Photo_Cur.Text = (TRB_Pl_PhotoLister.Value + 1).ToString();
                        break;
                    }
                case PlayModes.Video:
                    {
                        TRB_Pl_VideoTimer.Minimum = 0;
                        TRB_Pl_VideoTimer.Maximum = 100;
                        TRB_Pl_VideoTimer.Value = 0;
                        break;
                    }
                case PlayModes.Models3D:
                    {
                        TRB_Pl_ModelsLister.Minimum = 0;
                        TRB_Pl_ModelsLister.Maximum = 0;
                        TRB_Pl_ModelsLister.Value = 0;

                        L_Pl_Models_All.Text = (FilesToView.Count).ToString();
                        L_Pl_Models_Cur.Text = (TRB_Pl_ModelsLister.Value + 1).ToString();
                        break;
                    }
            }

        }

        private void Toogle_Play_Mode(PlayModes ppPlayMode_2set)
        {
            //bkp на случай, если переключиться не получится
            /*string L_Ex_mode_text_bkp = L_Ex_Mode.Text;
            string Path_from_bkp = TB_Ex_PathFrom.Text;
            string Path_to_bkp = TB_Ex_PathTo.Text;*/

            Image Image_3D_bkp = B_Pl_3DMode.BackgroundImage;
            Image Image_vid_bkp = B_Pl_VideoMode.BackgroundImage;
            Image Image_pho_bkp = B_Pl_PhotoMode.BackgroundImage;
            PlayModes Play_m_bkp = Playing_mode;

            try
            {
                string Path_to_files = null;

                switch (ppPlayMode_2set)
                {
                    case PlayModes.Photo:
                        {
                            Path_to_files = Rec_Photos_path;
                            B_Pl_PhotoMode.BackgroundImage = BMP_ExMode_Photo;
                            B_Pl_VideoMode.BackgroundImage = BMP_ExMode_Video_off;
                            B_Pl_3DMode.BackgroundImage = BMP_PlMode_3D_off;
                            break;
                        }
                    case PlayModes.Video:
                        {
                            Path_to_files = Rec_Videos_path;
                            B_Pl_PhotoMode.BackgroundImage = BMP_ExMode_Photo_off;
                            B_Pl_VideoMode.BackgroundImage = BMP_ExMode_Video;
                            B_Pl_3DMode.BackgroundImage = BMP_PlMode_3D_off;
                            break;
                        }
                    case PlayModes.Models3D:
                        {                        
                            Path_to_files = Rec_Models_path;
                            B_Pl_PhotoMode.BackgroundImage = BMP_ExMode_Photo_off;
                            B_Pl_VideoMode.BackgroundImage = BMP_ExMode_Video_off;
                            B_Pl_3DMode.BackgroundImage = BMP_PlMode_3D;
                            break;
                        }
                }

                if (!string.IsNullOrWhiteSpace(Path_to_files))
                {
                    Find_and_Resort_Files(ppPlayMode_2set, Path_to_files);
                }
                else { }
                if ((Playing_mode==PlayModes.Video) && isPlayingVideoNow) View_Video_Stop();


                Load_File_onControls(ppPlayMode_2set);
                Playing_mode = ppPlayMode_2set;
                Pan_Pl_Video.Visible = (ppPlayMode_2set == PlayModes.Video);
                Pan_Pl_Photo.Visible = (ppPlayMode_2set == PlayModes.Photo);
                Pan_Pl_3D.Visible = (ppPlayMode_2set == PlayModes.Models3D);
            }
            catch
            {
                /* L_Ex_Mode.Text = L_Ex_mode_text_bkp;
                 TB_Ex_PathFrom.Text = Path_from_bkp;
                 TB_Ex_PathTo.Text = Path_to_bkp;*/
                B_Pl_VideoMode.BackgroundImage = Image_vid_bkp;
                B_Pl_PhotoMode.BackgroundImage = Image_pho_bkp;
                B_Pl_3DMode.BackgroundImage = Image_3D_bkp;
                Playing_mode = Play_m_bkp;
            }    
        }

        private void Find_and_Resort_Files(PlayModes pPlayMode, string pDirectory)
        {
            string StartDir = pDirectory;
            FilesToView = new List<string>();

            if (!string.IsNullOrWhiteSpace(StartDir))
            {
                FilesToView = new List<string>(Directory.GetFiles(StartDir)); //Получает полные пути
            }
            FilesToView.Sort(delegate (string file2, string file1)
            { return File.GetLastWriteTime(file1).CompareTo(File.GetLastWriteTime(file2)); });
            //Самые старые оказываются в конце
        }
        private void View_Image_Next()
        {
            if (CurrentIndex + 1 == FilesToView.Count) CurrentIndex = 0;
            else CurrentIndex++;
            TRB_Pl_PhotoLister.Value = CurrentIndex;
            View_Image_byIndex(CurrentIndex);

        }

        private void View_Image_Prev()
        {
            if (CurrentIndex - 1 == -1) CurrentIndex = FilesToView.Count - 1 ;
            else CurrentIndex--;
            TRB_Pl_PhotoLister.Value = CurrentIndex;
            View_Image_byIndex(CurrentIndex);
        }
        private void View_Image_byIndex(int pIndex)
        {
            var VisibleImage = new Mat(FilesToView[pIndex]);
            CvInvoke.Resize(VisibleImage, resizedim, Size_for_Resizing, 0, 0, Inter.Linear);
            CV_ImBox_VidPhoto_Player.Image = resizedim;
        }
        private void View_Video_byIndex(int pIndex)
        {
            string CurrentVideo_strway = FilesToView[CurrentIndex];
            //Добавить загрузку времени в контролы
            CurrentVideo = new VideoCapture(CurrentVideo_strway);
            TotalFrames_inCurVid = Convert.ToInt32(CurrentVideo.GetCaptureProperty(CapProp.FrameCount));
            FPS_toPlay = Convert.ToInt32(CurrentVideo.GetCaptureProperty(CapProp.Fps));
            isPlayingVideoNow = false;
            CurrentFrame = new Mat();
            CurrentFrameNo_inCurVid = 0;
            TRB_Pl_VideoTimer.Maximum = TotalFrames_inCurVid-1;
            TRB_Pl_VideoTimer.Minimum = 0;
            TRB_Pl_VideoTimer.Value = 0;

            Get_and_Load_CurrentFrame(CurrentFrameNo_inCurVid);
            CV_ImBox_VidPhoto_Player.Invalidate();
            Refresh_Video_Labels();
        }
        private void View_Model_byIndex(int pIndex)
        {

        }
        private void View_Video_Prev()
        {
            if (isPlayingVideoNow) View_Video_Stop();
            if (CurrentIndex - 1 == -1) CurrentIndex = FilesToView.Count-1;
            else CurrentIndex--;
            View_Video_byIndex(CurrentIndex);
            Refresh_Video_Labels();
        }
        private void View_Video_Next()
        {
            if (isPlayingVideoNow) View_Video_Stop();
            if (CurrentIndex + 1 == FilesToView.Count) CurrentIndex = 0;
            else CurrentIndex++;
            View_Video_byIndex(CurrentIndex);
            Refresh_Video_Labels();
        }
        private void View_Video_Stop()
        {
            View_Video_Pause();
            CurrentFrameNo_inCurVid = 0;
            TRB_Pl_VideoTimer.Value = 0;
            Get_and_Load_CurrentFrame(CurrentFrameNo_inCurVid);
            CV_ImBox_VidPhoto_Player.Invalidate();
            Refresh_Video_Labels();
        }
        private void Refresh_Video_Labels()
        {
            string Text_TimeNow = "00:00";
            string Text_TimeLeft = "-01:00";
            string Mins_now_str = "00";
            string Mins_left_str = "00";
            string Secs_now_str = "00";
            string Secs_left_str = "00";

            int Secs_now = (int)Math.Round((float)CurrentFrameNo_inCurVid / (float)FPS_toPlay);
            int Secs_total = (int)Math.Round((float)TotalFrames_inCurVid / (float)FPS_toPlay);
            int Secs_left = Secs_total - Secs_now;

            int Mins_now = Secs_now / 60;
            Secs_now = Secs_now % 60;
            int Mins_left = Secs_left / 60;
            Secs_left = Secs_left % 60;

            if (Mins_now < 100)
            {
                Mins_now_str = String.Format(("{0:d2}"), Mins_now);
                Mins_left_str = String.Format(("{0:d2}"), Mins_left);
            }
            else
            {
                Mins_now_str = String.Format(("{0:d3}"), Mins_now);
                Mins_left_str = String.Format(("{0:d3}"), Mins_left);
            }

            Secs_now_str = String.Format(("{0:d2}"), Secs_now);
            Secs_left_str = String.Format(("{0:d2}"), Secs_left);

            Text_TimeNow = Mins_now_str + ":" + Secs_now_str;
            Text_TimeLeft ="-"+ Mins_left_str + ":" + Secs_left_str;

            L_Pl_Video_TimeCur.Text = Text_TimeNow;
            L_Pl_Video_TimeLeft.Text = Text_TimeLeft;
        }
        private void Get_and_Load_CurrentFrame(int pFrameNum)
        {
            try
            {
                CurrentVideo.SetCaptureProperty(CapProp.PosFrames, pFrameNum);
                CurrentVideo.Read(CurrentFrame);
                //CV_ImBox_VidPhoto_Player.Image = CurrentFrame;
                CvInvoke.Resize(CurrentFrame, resizedim, Size_for_Resizing, 0, 0, Inter.Linear);
                CV_ImBox_VidPhoto_Player.Image = resizedim;
            }
            catch { CV_ImBox_VidPhoto_Player.Image = null; }
        }
        private void View_Video_Scroll()
        {
            if(CurrentVideo!=null)
            {
                CurrentFrameNo_inCurVid = TRB_Pl_VideoTimer.Value;
                Refresh_Video_Labels();
            }
        }
        private void View_Video_Pause()
        {
            Image Img_Bkp = B_Pl_VideoPlayPause.BackgroundImage;
            bool isPlayingVideoNow_bkp = isPlayingVideoNow;
            try
            {
                isPlayingVideoNow = false;
                B_Pl_VideoPlayPause.BackgroundImage = BMP_Playing_Play;
            }
            catch
            {
                isPlayingVideoNow = isPlayingVideoNow_bkp;
                B_Pl_VideoPlayPause.BackgroundImage = Img_Bkp;
            }
        }
        private async void View_Video_Continue()
        {
            if (CurrentVideo == null)
            {
                isPlayingVideoNow = false;
                return;
            }
            else
            {
                isPlayingVideoNow = true;
            }

            Image Img_Bkp = B_Pl_VideoPlayPause.BackgroundImage;
            bool isPlayingVideoNow_bkp = isPlayingVideoNow;

            try
            {
                B_Pl_VideoPlayPause.BackgroundImage = BMP_Playing_Pause;
                while ((isPlayingVideoNow)&&(CurrentFrameNo_inCurVid<TotalFrames_inCurVid))
                {
                    Get_and_Load_CurrentFrame(CurrentFrameNo_inCurVid);
                    TRB_Pl_VideoTimer.Value = CurrentFrameNo_inCurVid;
                    CurrentFrameNo_inCurVid++;
                    Refresh_Video_Labels();
                    await System.Threading.Tasks.Task.Delay(1000 / FPS_toPlay);
                }
                if(CurrentFrameNo_inCurVid >= TotalFrames_inCurVid)
                {
                    View_Video_Stop();
                }
            }
            catch
            {
                isPlayingVideoNow = false;
                isPlayingVideoNow = isPlayingVideoNow_bkp;
                B_Pl_VideoPlayPause.BackgroundImage = Img_Bkp;
            }

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Stereo_Vision
{
    public partial class MainWindow
    {

        StereoImage CurrentStereoImage = null;
        BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;// Gets a reference to the current BufferedGraphicsContext
        BufferedGraphics myBuffer;
        Pen PencilForDraw2 = new Pen(Color.FromArgb(255, 50, 255, 50));
        Pen PencilForDraw = new Pen(Color.FromArgb(255, 50, 255, 50), 2);
        SolidBrush PencilPodsv = new SolidBrush(Color.FromArgb(100, 50, 255, 50));

        Brush brush_text = new SolidBrush(Color.FromArgb(50, 255, 50));
        System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 18);

        const int GRPX = 25;
        const byte ediam = 24;
        int ediamd2 = ediam / 2;
        int ediam2 = ediam * 2;
        int ediamd4 = ediam / 4;
        int ediam4 = ediam * 4;
        int ediam3 = ediam * 3;
        int eediamd4 = ediam * ediam / 4;

        MeasurementTypes CurrentMeasureType = MeasurementTypes.None;

        public void Init_all_for_Measurements(string PathToImg)
        {
            try { CurrentStereoImage = new StereoImage(new Bitmap(PathToImg), PB_MeasurementPB.Size); }
            catch(Exception exc)
            {
                LogError(exc.Message);
            }
        }
        public void Init_Measurements_byType(MeasurementTypes MesType)
        {
            CurrentMeasureType = MesType;
        }
        public void Disable_Measurements()
        {
            CurrentMeasureType = MeasurementTypes.None;
        }
        public void DB_Invalidate()
        {
            myBuffer = currentContext.Allocate(PB_MeasurementPB.CreateGraphics(), PB_MeasurementPB.DisplayRectangle); //необходимо выделять память каждый раз после dispose
            myBuffer.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Draw_Base(true);
            Draw_closed_Measurements();
            //if()
            myBuffer.Render();
            myBuffer.Dispose();
        }
        public void Draw_Base(bool UseImage)
        {
            int CenterX = PB_MeasurementPB.Width/2;
            int CenterY = PB_MeasurementPB.Height / 2;
            if(UseImage) if (CurrentStereoImage != null) myBuffer.Graphics.DrawImage(CurrentStereoImage.BasicImage, PB_MeasurementPB.DisplayRectangle);
            myBuffer.Graphics.DrawLine(PencilForDraw2, CenterX, 0, CenterX, PB_MeasurementPB.Height);
            for (int i = 0; i < CenterY; i += 20)
            {
                myBuffer.Graphics.DrawLine(PencilForDraw2, CenterX - 5, CenterY - i, CenterX + 5, CenterY - i);
                myBuffer.Graphics.DrawLine(PencilForDraw2, CenterX - 5, CenterY + i, CenterX + 5, CenterY + i);
            }
            myBuffer.Graphics.DrawRectangle(PencilForDraw2, new Rectangle(GRPX, GRPX,
                                        CenterX - 2 * GRPX, PB_MeasurementPB.Height - 2 * GRPX));
            myBuffer.Graphics.DrawRectangle(PencilForDraw2, new Rectangle(CenterX + GRPX, GRPX,
                                        CenterX - 2 * GRPX, PB_MeasurementPB.Height - 2 * GRPX)); 
        }
        public void Draw_closed_Measurements()
        {
            foreach (IMeasurable m in CurrentStereoImage.Measuremets) Draw_Measurement(m);

        }
        private double PerfectRounding(double val, int CharN)
        {
            double mnoj = (float)Math.Pow(10.0, CharN);
            val *= mnoj;
            if ((val - (int)val) > 0.5f) return (((int)val + 1) / mnoj);
            else return ((int)val / mnoj);
        }
        public PointF Get_free_point_forText(Special_3D_pt pt_0, Special_3D_pt pt_1, Special_3D_pt pt_last)
        {
            bool[] quadrants_is_free = new bool[4] { true, true, true, true };
            bool left_busy = (pt_1.P_left_OnCtrl.X - pt_0.P_left_OnCtrl.X < 0); bool right_busy = !left_busy;
            bool top_busy = (pt_1.P_left_OnCtrl.Y - pt_0.P_left_OnCtrl.Y < 0); bool bottom_busy = !top_busy;
            bool I_q_busy = right_busy && top_busy;
            bool II_q_busy = left_busy && top_busy;
            bool III_q_busy = left_busy && bottom_busy;
            bool IV_q_busy = right_busy && bottom_busy;

            quadrants_is_free = new bool[4] {   quadrants_is_free[0] && !I_q_busy,
                                                        quadrants_is_free[1] && !II_q_busy,
                                                        quadrants_is_free[2] && !III_q_busy,
                                                        quadrants_is_free[3] && !IV_q_busy };

            left_busy = (pt_last.P_left_OnCtrl.X - pt_0.P_left_OnCtrl.X < 0); right_busy = !left_busy;
            top_busy = (pt_last.P_left_OnCtrl.Y - pt_0.P_left_OnCtrl.Y < 0); bottom_busy = !top_busy;
            I_q_busy = right_busy && top_busy;
            II_q_busy = left_busy && top_busy;
            III_q_busy = left_busy && bottom_busy;
            IV_q_busy = right_busy && bottom_busy;

            quadrants_is_free = new bool[4] {   quadrants_is_free[0] && !I_q_busy,
                                                        quadrants_is_free[1] && !II_q_busy,
                                                        quadrants_is_free[2] && !III_q_busy,
                                                        quadrants_is_free[3] && !IV_q_busy };
            PointF Point_for_Text;
            if (quadrants_is_free[0])
                Point_for_Text = new PointF((float)pt_0.P_left_OnCtrl.X + (ediamd2) - 10 + 15, (float)pt_0.P_left_OnCtrl.Y - (ediamd2) - 5 - 10);
            else if (quadrants_is_free[1])
                Point_for_Text = new PointF((float)pt_0.P_left_OnCtrl.X + (ediamd2) - 10 - 15, (float)pt_0.P_left_OnCtrl.Y - (ediamd2) - 5 - 10);
            else if (quadrants_is_free[2])
                Point_for_Text = new PointF((float)pt_0.P_left_OnCtrl.X + (ediamd2) - 10 - 15, (float)pt_0.P_left_OnCtrl.Y - (ediamd2) - 5 + 10);
            else
                Point_for_Text = new PointF((float)pt_0.P_left_OnCtrl.X + (ediamd2) - 10 + 15, (float)pt_0.P_left_OnCtrl.Y - (ediamd2) - 5 + 10);

            return Point_for_Text;
        }
        public void Draw_Measurement(IMeasurable pMeasurement, double MeasurementValue = -1)
        {
            double Data = MeasurementValue;
            var Gr = myBuffer.Graphics;
            var ptList = pMeasurement.Points;
            var Mes_T = pMeasurement.TypeOfMeasurement;
            if (Data != -1)
            {
                Data = PerfectRounding(Data, 2);
                String Text = String.Format("{0:D2}", Data);
                Gr.DrawString(Text, drawFont, brush_text, Get_free_point_forText(ptList[0], ptList[1], ptList.Last()));
            }
  
            switch (Mes_T)
            {
                case MeasurementTypes.Distance_2point:
                    {
                        Draw_Polyline_stereo(ptList,false);
                        break;
                    }
                case MeasurementTypes.Distance_2line:
                    {
                        Draw_point_stereo(ptList[0]);
                        Draw_Polyline_stereo(ptList.GetRange(1, ptList.Count-1), false);
                        break;
                    }
                case MeasurementTypes.Distance_2plane:
                    {
                        Draw_point_stereo(ptList[0]);
                        Draw_Polyline_stereo(ptList.GetRange(1, ptList.Count - 1), true);
                        break;
                    }
                case MeasurementTypes.Polyline:
                    {
                        Draw_Polyline_stereo(ptList, false);
                        break;
                    }
                case MeasurementTypes.Perimeter:
                    {
                        Draw_Polyline_stereo(ptList, true);
                        break;
                    }
                case MeasurementTypes.Area:
                    {
                        Draw_Polyline_stereo(ptList, true);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void Draw_point(float tX,float tY)
        {
            myBuffer.Graphics.DrawEllipse(PencilForDraw2, tX - (ediamd2), tY - (ediamd2), ediam, ediam);
            myBuffer.Graphics.DrawLine(PencilForDraw2, tX - ediam, tY, tX + ediam, tY);
            myBuffer.Graphics.DrawLine(PencilForDraw2, tX, tY - ediam, tX, tY + ediam);
        }
        private void Draw_point_stereo(Special_3D_pt pt)
        {
            Draw_point((float)pt.P_left_OnCtrl.X, (float)pt.P_left_OnCtrl.Y);
            Draw_point((float)pt.P_right_OnCtrl.X, (float)pt.P_right_OnCtrl.Y);
        }
        private void Draw_Line(float Start_X,float Start_Y, float Finish_X,float Finish_Y)
        {
            int poprx = 0;
            int popry = 0;
            double absd = ((double)(Finish_X - Start_X));
            if (absd != 0)
            {

                double tgx = (double)Double.MaxValue;
                tgx = ((double)(Finish_Y - Start_Y)) / absd;
                double tgxtgx1 = 1.00 + tgx * tgx;
                if (tgx >= 0)
                {
                    if ((Finish_Y - Start_Y) > 0)
                    {
                        poprx = (int)(Math.Sqrt((eediamd4) / (tgxtgx1)));
                        popry = (int)(tgx * (Math.Sqrt((eediamd4) / (tgxtgx1))));
                    }
                    else if ((Finish_Y - Start_Y) < 0)
                    {
                        poprx = -(int)(Math.Sqrt((eediamd4) / (tgxtgx1)));
                        popry = -(int)(tgx * (Math.Sqrt((eediamd4) / (tgxtgx1))));
                    }
                    else
                    {
                        if ((Finish_X - Start_X) > 0)
                            poprx = (int)(Math.Sqrt((eediamd4) / (tgxtgx1)));
                        else poprx = -(int)(Math.Sqrt((eediamd4) / (tgxtgx1)));
                    }
                }
                else
                {
                    if ((Finish_Y - Start_Y) > 0)
                    {
                        poprx = -(int)(Math.Sqrt((eediamd4) / tgxtgx1));
                        popry = -(int)(tgx * (Math.Sqrt((eediamd4) / tgxtgx1)));
                    }
                    else
                    {
                        poprx = (int)(Math.Sqrt((eediamd4) / tgxtgx1));
                        popry = (int)(tgx * (Math.Sqrt((eediamd4) / tgxtgx1)));
                    }
                }
            }
            else
            {
                poprx = 0;
                if ((Finish_Y - Start_Y) > 0) popry = ediamd2;
                else popry = -ediamd2;
            }
            myBuffer.Graphics.DrawLine(PencilForDraw, new PointF(Start_X + poprx,
                Start_Y + popry),
                new PointF(Finish_X - poprx, Finish_Y - popry));
        }
        private void Draw_Line_stereo(Special_3D_pt pt1, Special_3D_pt pt2)
        {
            Draw_Line((float)pt1.P_left_OnCtrl.X, (float)pt1.P_left_OnCtrl.Y, (float)pt2.P_left_OnCtrl.X, (float)pt2.P_left_OnCtrl.Y);
            Draw_Line((float)pt1.P_right_OnCtrl.X, (float)pt1.P_right_OnCtrl.Y, (float)pt2.P_right_OnCtrl.X, (float)pt2.P_right_OnCtrl.Y);
        }
        private void Draw_Polyline_stereo(List<Special_3D_pt> ptList,bool Looped)
        {
            for(int i =0;i<ptList.Count-1;i++)
            {
                Draw_point_stereo(ptList[i]);
                Draw_Line_stereo(ptList[i], ptList[i + 1]);
                Draw_point_stereo(ptList[i+1]);
            }
            if (Looped) Draw_Line_stereo(ptList.Last(), ptList[0]);
        }
    }
}
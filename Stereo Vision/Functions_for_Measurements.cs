using System;
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
        const int GRPX = 25;
        const byte ediam = 24;
        int ediamd2 = ediam / 2;
        int ediam2 = ediam * 2;
        int ediamd4 = ediam / 4;
        int ediam4 = ediam * 4;
        int ediam3 = ediam * 3;

        public void Init_all_for_Measurements(string PathToImg)
        {
            CurrentStereoImage = new StereoImage(new Bitmap(PathToImg), PB_MeasurementPB.Size);
            myBuffer = currentContext.Allocate(PB_MeasurementPB.CreateGraphics(), PB_MeasurementPB.DisplayRectangle);
        }
        public void Init_Measurements_byType(MeasurementTypes MesType)
        {

        }
        public void Disable_Measurements()
        {

        }
        public void DB_Invalidate()
        {
            myBuffer = currentContext.Allocate(PB_MeasurementPB.CreateGraphics(), PB_MeasurementPB.DisplayRectangle);
            Draw_Base();
            myBuffer.Render();
          //  myBuffer.Dispose();
           // DB_Invalidate();
        }
        public void Draw_Base()
        {
            int CenterX = CurrentStereoImage.CenterOfImg.X;
            int CenterY = CurrentStereoImage.CenterOfImg.Y;
            myBuffer.Graphics.DrawEllipse(new Pen(Color.Black, 10), 100, 100, 100, 100);
            if (CurrentStereoImage != null) myBuffer.Graphics.DrawImage(CurrentStereoImage.BasicImage, PB_MeasurementPB.DisplayRectangle);
            myBuffer.Graphics.DrawLine(PencilForDraw2, CenterX, 0, CenterX, 576);
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
    }
}

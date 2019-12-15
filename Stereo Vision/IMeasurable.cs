using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CameraMath.Wrapper;

namespace Stereo_Vision
{
    public class StereoImage
    {
        public Image BasicImage;
        public Size SizeOfCtrl;
        public List<Measurement> Measuremets { get { return _Measuremets; } }
        private List<Measurement> _Measuremets { get; set; }
        private Measurement LastMeasurement;
        public int Im_Height { get { return BasicImage.Height; } }
        public int Im_Width { get { return BasicImage.Width; } }
        public float X_ration = 1;
        public float Y_ration = 1;
        public Point CenterOfImg;

        public double DetectionRadius_px
        {
            get { return _DetectionRadius_px; }
            private set { _DetectionRadius_px = value;  DetectionRadius_onCtrl = value * X_ration; }
        }
        private double _DetectionRadius_px { get; set; }


        public double DetectionRadius_onCtrl { get; private set; } 
        public dynamic FoundPoint = new { MeasureNumber = -1, PointNumber = -1, isGrabed = false };



    //all the math
    ICameraPair stereoPair = XMLLoader.ReadCameraPair("M1_chess.xml");
        ISimpleCorrPointFinder pointFinder;

        public StereoImage(System.Drawing.Bitmap BMP, Size pSizeOfCtrl)
        {
            BasicImage = BMP;
            SizeOfCtrl = pSizeOfCtrl;
            CenterOfImg = new Point(pSizeOfCtrl.Width / 2, pSizeOfCtrl.Height / 2);
            X_ration = (float)SizeOfCtrl.Width / ((float)BasicImage.Width);
            Y_ration = (float)SizeOfCtrl.Height / ((float)BasicImage.Height);
            _Measuremets = new List<Measurement>();
            pointFinder = CorrPointFactory.GetSimpleCorrPointFinder(stereoPair);
            // Set distance range (mm)
            pointFinder.SetZDiap(10.0, 40.0, 2.0);
            // Set window size for descriptor (pixel)
            pointFinder.SetWindowSize(21, 21);
            // Set search rectangle size
            pointFinder.SetSearchRectAddSize(5, 5);

            DetectionRadius_px = 5;
        }
        public Point2d Transform_Ctrl2Img(float X_ctrl,float Y_ctrl)
        {
            return new Point2d(X_ctrl / X_ration, Y_ctrl / Y_ration);
        }
        public Point2d Transform_Img2Ctrl(double X_img, double Y_img)
        {
            return new Point2d(X_img * X_ration, Y_img * Y_ration);
        }
        public void NewMeasurement(MeasurementTypes MesType)
        {
            switch(MesType)
            {
                case MeasurementTypes.Distance_2point:
                    {
                        LastMeasurement = new Distance_2point();
                        break;
                    }
                case MeasurementTypes.Perimeter:
                    {
                        LastMeasurement = new Perimeter();
                        break;
                    }
                default:
                    {
                        LastMeasurement = new Distance_2point();
                        break;
                    }
            }
        }
        public Point2d FindCorPoint(Point2d PT_left)
        {
            Point2d result = new Point2d(0, 0);
            try
            {
                pointFinder.Find((Bitmap)BasicImage, PT_left, ref result, true);
            }
            catch
            {
                result = new Point2d(PT_left.X + SizeOfCtrl.Width/2, PT_left.Y);
            }
            return result;
        }
        public bool FindAnyPointUnderMouse(Point pCursor_coordinates)
        {
            bool result = false;
            var Pt_omg = Transform_Ctrl2Img(pCursor_coordinates.X, pCursor_coordinates.Y);
            var Pt_2d = new Point2d(pCursor_coordinates.X, pCursor_coordinates.Y);
            for (int i = 0; i < Measuremets.Count(); i++)
            {
                var found_ind = Measuremets[i].Find_Pt_inRadiusOfPt(Pt_2d, DetectionRadius_px);
                if(found_ind != -1)
                {
                    FoundPoint = new { MeasureNumber = i, PointNumber = found_ind, isGrabed = false };
                }
            }

            return result;
        }
        public void AddPoint_2NewMeasurement(int X_onCtrl_left, int Y_onCtrl_left)
        {
            if (LastMeasurement != null)
            {
                Point2d Data_left_onCtrl = new Point2d(X_onCtrl_left, Y_onCtrl_left);
                Point2d Data_left_onImage = Transform_Ctrl2Img(X_onCtrl_left, Y_onCtrl_left);
                
                Point2d Data_right_onImage = FindCorPoint(Data_left_onImage);
                Point2d Data_right_onCtrl = Transform_Img2Ctrl(Data_right_onImage.X, Data_right_onImage.Y);

                Point3d Data3D = new Point3d(0,0,0);
                try { stereoPair.Transform(Data_left_onImage, Data_left_onImage, ref Data3D); } catch { }

                Special_3D_pt NewPoint = new Special_3D_pt(Data_left_onCtrl, Data_right_onCtrl, Data_left_onImage, Data_right_onImage, Data3D);
                LastMeasurement.Add_Point(NewPoint);

                if (LastMeasurement.Ready)
                {
                    Measuremets.Add(LastMeasurement);
                    LastMeasurement = null; //Возможно, будет херь
                }
            }
        }
        public void AddPoint_2NewMeasurement(int X_onCtrl_left,int Y_onCtrl_left, int X_onCtrl_right, int Y_onCtrl_right)
        {
            if (LastMeasurement != null)
            {
                Point2d Data_left_onCtrl = new Point2d(X_onCtrl_left, Y_onCtrl_left);
                Point2d Data_right_onCtrl = new Point2d(X_onCtrl_right, Y_onCtrl_right);
                Point2d Data_left_onImage = Transform_Ctrl2Img(X_onCtrl_left, Y_onCtrl_left);
                Point2d Data_right_onImage = Transform_Ctrl2Img(X_onCtrl_right, Y_onCtrl_right);
                Point3d Data3D = null;
                stereoPair.Transform(Data_left_onImage, Data_left_onImage, ref Data3D);

                Special_3D_pt NewPoint = new Special_3D_pt(Data_left_onCtrl, Data_right_onCtrl, Data_left_onImage, Data_right_onImage, Data3D);
                LastMeasurement.Add_Point(NewPoint);

                if (LastMeasurement.Ready)
                {
                    Measuremets.Add(LastMeasurement);
                    LastMeasurement = null; //Возможно, будет херь
                }
            }
        }
        public bool isLastMeasureOpened()
        {
            return (LastMeasurement != null);
        }
        public bool isLastMeasure_supportsClose()
        {
            return LastMeasurement.GetType().GetInterfaces().Contains(typeof(IMeasurementClosable));
        }
        public void Edit_Point_inMeasurement_byIndex(int Mes_index, uint Pt_index, int X_onCtrl_left, int Y_onCtrl_left, int X_onCtrl_right, int Y_onCtrl_right)
        {
            Point2d Data_left_onCtrl = new Point2d(X_onCtrl_left, Y_onCtrl_left);
            Point2d Data_right_onCtrl = new Point2d(X_onCtrl_right, Y_onCtrl_right);
            Point2d Data_left_onImage = Transform_Ctrl2Img(X_onCtrl_left, Y_onCtrl_left);
            Point2d Data_right_onImage = Transform_Ctrl2Img(X_onCtrl_right, Y_onCtrl_right);
            Point3d Data3D = null;
            stereoPair.Transform(Data_left_onImage, Data_left_onImage, ref Data3D);

            Special_3D_pt NewPoint = new Special_3D_pt(Data_left_onCtrl, Data_right_onCtrl, Data_left_onImage, Data_right_onImage, Data3D);
            Measuremets[Mes_index].Edit_Point_byIndex(Pt_index, NewPoint);
        }
        public void Edit_Grabbed_Point(int Mes_index, uint Pt_index, int X_onCtrl_left, int Y_onCtrl_left, int X_onCtrl_right, int Y_onCtrl_right)
        {
           //TODO: 1) Определение, левая или правая координата 2) Автокорреляция , если левая
        }

        public void Make_LastMeasurement_Ready()
        {
            if(isLastMeasure_supportsClose()) //Эта строка узнает, реализует ли данное измерение интерфейс IMeasurementClosable
            {
                (LastMeasurement as IMeasurementClosable).CloseMeasurement();
            }
            else
            {
                throw new Exception("Measurement is not closable by user. Please, finish it by adding one or several points.");
            }
        }
        public double Get_Measurement_byIndex(int pIndex)
        {
            return Measuremets[pIndex].Get_Measure();
        }
        public void ClearMEasurements()
        {
            Measuremets.Clear();
        }
        
    }
    public class Special_3D_pt
    {
        public Point2d P_left_OnCtrl { get { return _P_left_OnCtrl; } }
        private Point2d _P_left_OnCtrl { set; get; }
        public Point2d P_right_OnCtrl { get { return _P_right_OnCtrl; } }
        private Point2d _P_right_OnCtrl { set; get; }

        public Point2d P_left_OnImage { get { return _P_left_OnImage; } }
        private Point2d _P_left_OnImage { set; get; }
        public Point2d P_right_OnImage { get { return _P_right_OnImage; } }
        private Point2d _P_right_OnImage { set; get; }

        public Point3d P3D_implementation { get { return _P3D_implementation; } }
        private Point3d _P3D_implementation { set; get; }

        public Special_3D_pt(Point2d pP_left_OnCtrl, Point2d pP_right_OnCtrl, Point2d pP_left_OnImage, Point2d pP_right_OnImage, Point3d pP3D_Implementation)
        {
            _P_left_OnCtrl = pP_left_OnCtrl;
            _P_right_OnCtrl = pP_right_OnCtrl;
            _P_left_OnImage = pP_left_OnImage;
            _P_right_OnImage = pP_right_OnImage;
            _P3D_implementation = pP3D_Implementation;
        }
    }
    public enum MeasurementTypes { None=0, Distance_2point, Distance_2line, Distance_2plane, Polyline, Perimeter, Area}
    public abstract class Measurement
    {
        public virtual List<Special_3D_pt> Points { get { return _Points; } }
        protected virtual List<Special_3D_pt> _Points { get; set; }

        public abstract MeasurementTypes TypeOfMeasurement { get; }

        public virtual bool Ready { get { return _Ready; } }
        protected virtual bool _Ready { set; get; }

        public virtual double CurrentMeasureValue { get { return _CurrentMeasureValue; } }
        protected virtual double _CurrentMeasureValue { get; set; }

        public abstract double Get_Measure();

        public abstract int Point_MAX { get; }

        public virtual bool Add_Point(Special_3D_pt pPoint3D) // true - Measure is closed now, false - Measure is not closed
        {
            if (!Ready)
            {
                _Points.Add(pPoint3D);
            }
            else return Ready;

            if (Points.Count == Point_MAX)
            {
                _Ready = true;
            }
            return Ready;
        }
        public abstract void Edit_Point_byIndex(uint index, Special_3D_pt newValue);
        public virtual int Find_Pt_inRadiusOfPt(Point2d pt, double Radius) //-1   - no pts found, else - index
        {
            double dist_2_left = -1;
            double dist_2_right = -1;
            for(int i =0;i<Points.Count;i++)
            {
                dist_2_left = Distance_p2p_2D(Points[i].P_left_OnImage, pt);
                dist_2_right = Distance_p2p_2D(Points[i].P_right_OnImage, pt);
                if (dist_2_left < Radius || dist_2_right<Radius) return i;
            }
            return -1;
        }
        protected double Distance_p2p_2D(Point2d pt1, Point2d pt2)
        {
            double result = -1;
            result = Math.Pow(pt2.X - pt1.X, 2) + Math.Pow(pt2.Y - pt1.Y, 2);
            result = Math.Pow(result, 0.5);
            return result;
        }
    }
    interface IMeasurementClosable
    {
        void CloseMeasurement();
    }

    public class Distance_2point : Measurement
    {
        public override MeasurementTypes TypeOfMeasurement { get { return MeasurementTypes.Distance_2point; } }

        public override int Point_MAX { get { return 2; } }

        public Distance_2point()
        {
            _Points = new List<Special_3D_pt>();
        }      
        public override void Edit_Point_byIndex(uint index, Special_3D_pt newValue)
        {
            _Points[(int)index] = newValue;
        }
        public override double Get_Measure()
        {
            if (Ready)
            {
                _CurrentMeasureValue = GeomUtils.Distance(Points[0].P3D_implementation, Points[1].P3D_implementation);
                return CurrentMeasureValue;
            }
            else
                return -1;
        }
    }


    public class Perimeter: Measurement, IMeasurementClosable
    {
        public override MeasurementTypes TypeOfMeasurement { get { return MeasurementTypes.Perimeter; } }

        public override int Point_MAX { get { return 20; } }

        private Polyline3d ThisLine;

        public Perimeter()
        {
            _Points = new List<Special_3D_pt>();
            ThisLine = new Polyline3d();
        }
        public override bool Add_Point(Special_3D_pt pPoint3D)
        {
            ThisLine.AddPoint(pPoint3D.P3D_implementation);
            base.Add_Point(pPoint3D);
            return Ready;
        }
        public override void Edit_Point_byIndex(uint index, Special_3D_pt newValue)
        {
            _Points[(int)index] = newValue;
            ThisLine.ReplacePoint(newValue.P3D_implementation, index);
        }
        public override double Get_Measure()
        {
            if (Ready)
            {
                _CurrentMeasureValue = GeomUtils.Distance(Points[0].P3D_implementation, Points[1].P3D_implementation);
                return CurrentMeasureValue;
            }
            else
                return -1;
        }
        public void CloseMeasurement()
        {
            _Ready = true;
        }
    }
}

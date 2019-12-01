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
        public List<IMeasurable> Measuremets { get { return _Measuremets; } }
        private List<IMeasurable> _Measuremets { get; set; }
        private IMeasurable LastMeasurement;
        public float Im_Height { get { return BasicImage.Height; } }
        public float Im_Width { get { return BasicImage.Width; } }
        public float X_ration = 1;
        public float Y_ration = 1;
        public Point CenterOfImg;
        //all the math
        ICameraPair stereoPair = XMLLoader.ReadCameraPair("CalibRes_Model1_GE250216_chess.xml");
        ISimpleCorrPointFinder pointFinder;

        public StereoImage(System.Drawing.Bitmap BMP, Size pSizeOfCtrl)
        {
            BasicImage = BMP;
            SizeOfCtrl = pSizeOfCtrl;
            CenterOfImg = new Point(pSizeOfCtrl.Width / 2, pSizeOfCtrl.Height / 2);
            X_ration = (float)SizeOfCtrl.Width / ((float)BasicImage.Width);
            Y_ration = (float)SizeOfCtrl.Height / ((float)BasicImage.Height);
            _Measuremets = new List<IMeasurable>();
            pointFinder = CorrPointFactory.GetSimpleCorrPointFinder(stereoPair);
            // Set distance range (mm)
            pointFinder.SetZDiap(10.0, 40.0, 2.0);
            // Set window size for descriptor (pixel)
            pointFinder.SetWindowSize(21, 21);
            // Set search rectangle size
            pointFinder.SetSearchRectAddSize(5, 5);
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
                result = new Point2d(PT_left.X + CenterOfImg.X, PT_left.Y);
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
        public bool isMeasureOpened()
        {
            return (LastMeasurement != null);
        }
        public bool isMeasure_supportsClose()
        {
            return LastMeasurement.GetType().GetInterfaces().Contains(typeof(IMeasurementClosable));
        }
        public void EditPoint_inMeasurement_byIndex(int Mes_index, uint Pt_index, int X_onCtrl_left, int Y_onCtrl_left, int X_onCtrl_right, int Y_onCtrl_right)
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

        public void Make_LastMeasurement_Ready()
        {
            if(isMeasure_supportsClose()) //Эта строка узнает, реализует ли данное измерение интерфейс IMeasurementClosable
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
    public interface IMeasurable
    {
        List<Special_3D_pt> Points { get; }
        MeasurementTypes TypeOfMeasurement { get; }
        bool Ready { get; }
        double CurrentMeasureValue { get; }
        double Get_Measure();
        int Point_MAX { get; }
        bool Add_Point(Special_3D_pt pPoint3D); // true - Measure is closed now, false - Measure is not closed
        void Edit_Point_byIndex(uint index, Special_3D_pt newValue);
        // abstract float 
    }
    interface IMeasurementClosable
    {
        void CloseMeasurement();
    }

    public class Distance_2point : IMeasurable
    {
        public List<Special_3D_pt> Points { get { return _Points; } }
        private List<Special_3D_pt> _Points { get; set; }
        public MeasurementTypes TypeOfMeasurement { get { return MeasurementTypes.Distance_2point; } }

        public bool Ready { get { return _Ready; } }
        private bool _Ready { set; get; }

        public double CurrentMeasureValue { get { return _CurrentMeasureValue; } }
        private double _CurrentMeasureValue { get; set; }

        public int Point_MAX { get { return 2; } }

        public Distance_2point()
        {
            _Points = new List<Special_3D_pt>();
        }
        public bool Add_Point(Special_3D_pt pPoint3D)
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
        public void Edit_Point_byIndex(uint index, Special_3D_pt newValue)
        {
            _Points[(int)index] = newValue;
        }
        public double Get_Measure()
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


    public class Perimeter: IMeasurable, IMeasurementClosable
    {
        public List<Special_3D_pt> Points { get { return _Points; } }
        private List<Special_3D_pt> _Points { get; set; }
        public MeasurementTypes TypeOfMeasurement { get { return MeasurementTypes.Perimeter; } }

        private Polyline3d ThisLine;
        public bool Ready { get { return _Ready; } }
        private bool _Ready { set; get; }

        public double CurrentMeasureValue { get { return _CurrentMeasureValue; } }
        private double _CurrentMeasureValue { get; set; }

        public int Point_MAX { get { return 20; } }

        public Perimeter()
        {
            _Points = new List<Special_3D_pt>();
            ThisLine = new Polyline3d();
        }
        public bool Add_Point(Special_3D_pt pPoint3D)
        {
            if (!Ready)
            {
                _Points.Add(pPoint3D);
                ThisLine.AddPoint(pPoint3D.P3D_implementation);
            }
            else return Ready;

            if (_Points.Count == Point_MAX)
            {
                _Ready = true;
            }
            return Ready;
        }
        public void Edit_Point_byIndex(uint index, Special_3D_pt newValue)
        {
            _Points[(int)index] = newValue;
            ThisLine.ReplacePoint(newValue.P3D_implementation, index);
        }
        public double Get_Measure()
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

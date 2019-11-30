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
        private List<IMeasurable> Measuremets = new List<IMeasurable>();
        private IMeasurable LastMeasurement;
        public float X_ration = 1;
        public float Y_ration = 1;
        public Point CenterOfImg;

        ICameraPair stereoPair = XMLLoader.ReadCameraPair("../Test_data/CamParams1.xml");

        public StereoImage(System.Drawing.Bitmap BMP, Size pSizeOfCtrl)
        {
            BasicImage = BMP;
            SizeOfCtrl = pSizeOfCtrl;
            CenterOfImg = new Point(BasicImage.Width / 2, BasicImage.Height / 2);
            X_ration = (float)SizeOfCtrl.Width / ((float)BasicImage.Width);
            Y_ration = (float)SizeOfCtrl.Height / ((float)BasicImage.Height);
        }
        public Point2d Transform_Ctrl2Img(float X_ctrl,float Y_ctrl)
        {
            return new Point2d(X_ctrl / X_ration, Y_ctrl / Y_ration);
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
        public void AddPoint_2NewMeasurement(int X_onCtrl_left,int Y_onCtrl_left, int X_onCtrl_right, int Y_onCtrl_right)
        {
            Point2d Data_left_onCtrl = new Point2d(X_onCtrl_left, Y_onCtrl_left);
            Point2d Data_right_onCtrl = new Point2d(X_onCtrl_right, Y_onCtrl_right);
            Point2d Data_left_onImage = Transform_Ctrl2Img(X_onCtrl_left, Y_onCtrl_left);
            Point2d Data_right_onImage = Transform_Ctrl2Img(X_onCtrl_right, Y_onCtrl_right);
            Point3d Data3D = null;
            stereoPair.Transform(Data_left_onImage, Data_left_onImage, ref Data3D);

            Special_3D_pt NewPoint = new Special_3D_pt(Data_left_onCtrl, Data_right_onCtrl, Data_left_onImage, Data_right_onImage, Data3D);
            LastMeasurement.Add_Point(NewPoint);
            if (LastMeasurement.Ready) Measuremets.Add(LastMeasurement);
            LastMeasurement = null; //Возможно, будет херь
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
            if(LastMeasurement.GetType().GetInterfaces().Contains(typeof(IMeasurementClosable))) //Эта строка узнает, реализует ли данное измерение интерфейс IMeasurementClosable
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
        Point2d P_left_OnCtrl;
        Point2d P_right_OnCtrl;

        Point2d P_left_OnImage;
        Point2d P_right_OnImage;

        public Point3d P3D_implementation;

        public Special_3D_pt(Point2d pP_left_OnCtrl, Point2d pP_right_OnCtrl, Point2d pP_left_OnImage, Point2d pP_right_OnImage, Point3d pP3D_Implementation)
        {
            P_left_OnCtrl = pP_left_OnCtrl;
            P_right_OnCtrl = pP_right_OnCtrl;
            P_left_OnImage = pP_left_OnImage;
            P_right_OnCtrl = pP_right_OnImage;
            P3D_implementation = pP3D_Implementation;
        }
    }
    public enum MeasurementTypes { Distance_2point = 1, Distance_2line, Distance_2plane, Polyline, Perimeter, Area}
    public interface IMeasurable
    {       
        List<Special_3D_pt> Points { get; set; }
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
        public List<Special_3D_pt> Points { set; get; }
        public MeasurementTypes TypeOfMeasurement { get { return MeasurementTypes.Distance_2point; } }

        public bool Ready { get { return _Ready; } }
        private bool _Ready { set; get; }

        public double CurrentMeasureValue { get { return _CurrentMeasureValue; } }
        private double _CurrentMeasureValue { get; set; }

        public int Point_MAX { get { return 2; } }

        public Distance_2point()
        {
            Points = new List<Special_3D_pt>();
        }
        public bool Add_Point(Special_3D_pt pPoint3D)
        {
            if (!Ready)
            {
                Points.Add(pPoint3D);
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
            Points[(int)index] = newValue;
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
        public List<Special_3D_pt> Points { set; get; }
        public MeasurementTypes TypeOfMeasurement { get { return MeasurementTypes.Perimeter; } }

        private Polyline3d ThisLine;
        public bool Ready { get { return _Ready; } }
        private bool _Ready { set; get; }

        public double CurrentMeasureValue { get { return _CurrentMeasureValue; } }
        private double _CurrentMeasureValue { get; set; }

        public int Point_MAX { get { return 20; } }

        public Perimeter()
        {
            Points = new List<Special_3D_pt>();
            ThisLine = new Polyline3d();
        }
        public bool Add_Point(Special_3D_pt pPoint3D)
        {
            if (!Ready)
            {
                Points.Add(pPoint3D);
                ThisLine.AddPoint(pPoint3D.P3D_implementation);
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
            Points[(int)index] = newValue;
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

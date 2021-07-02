using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using CameraMath.Wrapper;

namespace OpenTK_3DMesh
{
    class MyMesh
    {
        public static int vertexOffsetPosition = 0;
        public static int vertexOffsetColor = 3 * sizeof(float);
        public static int vertexSize = 6 * sizeof(float);
        private float ZoomFactor = 1;
        private int vertexCount = 0; // количество точек на всех плоскостях,  т.е. количество вершин .Для куба 6*4
        private int IndicesCount = 0; // количество точек для задачи всех треугольников. Количество треугольников*3. Куб: (6*2)*3
        public float[] Data = null;
        public float CenterX = 0, CenterY = 0, CenterZ = 0;
        // кол-во информации на вершину. 3 float на координаты, 3 float - на каналы R,G,B
        private float[] Rotation = { 0.0f, 0.0f, 0.0f };
        public float[] remrot = { 0.0f, 0.0f, 0.0f };
        private int axisVertex_count = 0;
        private float topRadius = 0;
        private int topNumber = 0;
        public float TranslationX = 0, TranslationY = 0, TranslationZ = 0;
        public float UserCX = 0, UserCY = 0, UserCZ = 0;
        public float[] modelMatrix = new float[16];
        private PointF grabedpoint = new PointF();
        private string[] TypesOfMesh = new string[6] { "Sphere", "Cilindric", "Plane", "Model", "UserStyle","NULL" };
        private string TypeOfMesh = null;
        public float rTopRadius = 0;
        bool grab = false;
        bool databasewasloaded = false;
        public bool IsRecalculated = true;
        bool AutoCorr = false;
        public static double Grad2Rad = Math.PI / 180.0;
        public static double Rad2Grad = 180.0 / Math.PI;


        public MyMesh()
        {

        }
        public static float NormalizeAngle(double pRad)
        {
            if (pRad >= 2 * Math.PI)
                return (float)(pRad % (2 * Math.PI));
            else return (float)pRad;
        }
        public static float RevertAngle(double pRad)
        {
            return (float)(2 * Math.PI - NormalizeAngle(pRad));
        }
        public MyMesh(float[] InData, float ZoomFact)
        {
            int count = InData.Count();
            vertexCount = count / 6;
            Data = new float[count];
            int i = 0;
            for (i = 0; i < vertexCount; i++)
            {
                CenterX += InData[i * 6];
                CenterY += InData[i * 6 + 1];
                CenterZ += InData[i * 6 + 2];
            }
            CenterX /= vertexCount;
            CenterY /= vertexCount;
            CenterZ /= vertexCount;
            float dataRadius = 0; int i6 = 0;
            for (i = 0; i < vertexCount; i++)
            {
                i6 = i * 6;
                Data[i6] = (InData[i6] - CenterX - UserCX);
                Data[i6 + 1] = (InData[i6 + 1] - CenterY - UserCY);
                Data[i6 + 2] = (InData[i6 + 2] - CenterZ - UserCZ);
                Data[i6 + 3] = InData[i6 + 3];
                Data[i6 + 4] = InData[i6 + 4];
                Data[i6 + 5] = InData[i6 + 5];
                dataRadius = Data[i6] * Data[i6] + Data[i6 + 1] * Data[i6 + 1] + Data[i6 + 2] * Data[i6 + 2];
                if (dataRadius > topRadius) { topRadius = dataRadius; topNumber = i; }
            }
            topRadius = ((float)Math.Sqrt((double)topRadius));
            rTopRadius = topRadius;
            ZoomFactor = ZoomFact;
        }
        public MyMesh(RGBPointOwnType[] points, IndexTriplet[] triangles)
        {
            vertexCount = triangles.Count() * 3;
            Data = new float[vertexCount * 6];
            float dataRadius = 0;
            int i6 = 0;
            CenterX = 0; CenterY = 0; CenterZ = 0; UserCX = 0; UserCY = 0; UserCZ = 0;
            for (int i = 0; i < vertexCount / 3; i++)
            {
                uint Ind1 = triangles[i].Ind1;
                uint Ind3 = triangles[i].Ind3;
                uint Ind2 = triangles[i].Ind2;
                i6 = i * 18;
                Data[i6] = (float)points[Ind1].X - UserCX;
                Data[i6 + 1] = -(float)points[Ind1].Y - UserCY;
                Data[i6 + 2] = (float)points[Ind1].Z - UserCZ;
                Data[i6 + 3] = (float)points[Ind1].R;
                Data[i6 + 4] = (float)points[Ind1].G;
                Data[i6 + 5] = (float)points[Ind1].B;
                dataRadius = Data[i6] * Data[i6] + Data[i6 + 1] * Data[i6 + 1] + Data[i6 + 2] * Data[i6 + 2];
                if (dataRadius > topRadius) { topRadius = dataRadius; topNumber = i; }
                Data[i6 + 6] = (float)points[Ind2].X - UserCX;
                Data[i6 + 7] = -(float)points[Ind2].Y - UserCY;
                Data[i6 + 8] = (float)points[Ind2].Z - UserCZ;
                Data[i6 + 9] = (float)points[Ind2].R;
                Data[i6 + 10] = (float)points[Ind2].G;
                Data[i6 + 11] = (float)points[Ind2].B;
                dataRadius = Data[i6 + 7] * Data[i6 + 7] + Data[i6 + 6] * Data[i6 + 6] + Data[i6 + 8] * Data[i6 + 8];
                if (dataRadius > topRadius) { topRadius = dataRadius; topNumber = i + 1; }
                Data[i6 + 12] = (float)points[Ind3].X - UserCX;
                Data[i6 + 13] = -(float)points[Ind3].Y - UserCY;
                Data[i6 + 14] = (float)points[Ind3].Z - UserCZ;
                Data[i6 + 15] = (float)points[Ind3].R;
                Data[i6 + 16] = (float)points[Ind3].G;
                Data[i6 + 17] = (float)points[Ind3].B;
                dataRadius = Data[i6 + 12] * Data[i6 + 12] + Data[i6 + 13] * Data[i6 + 13] + Data[i6 + 14] * Data[i6 + 14];
                if (dataRadius > topRadius) { topRadius = dataRadius; topNumber = i + 2; }
            }
            // /* 1 вершина, позиция: */ 0.0f, 0.0f, 0.0f,  0.0f, 1.0f, 0.0f, 
            rTopRadius = topRadius;
            ZoomFactor = 1.0f;
            TypeOfMesh = TypesOfMesh[3];
            this.TranslationZ = 0; //Эти преобразования работают именно после бинда текстур. Почему - нет времени разбираться
            this.SetZoomFactor(1);
        }
        public int GetNumberOfVertices() { return vertexCount; }
        public float GetTopRadius() { return topRadius; }
        public float GetZoomFactor() { return ZoomFactor; }
        public int GetAxisVertexCount() { return axisVertex_count; }
        public bool IsGrabed() { return grab; }
        public void SetUserCenter(float XC, float YC, float ZC, MyMesh Fig)
        {
            IsRecalculated = false;
            Matrix4 xr, yr, zr; Matrix3 res; Matrix4 promres; //реализовать поворот для var Fig
            float[] RotationX = { 0.0f, 0.0f, 0.0f };

            if (!((XC == 0.0f) && (YC == 0.0f) && (ZC == 0.0f)))
            {
                remrot = new float[] { this.GetElementRotation(0), this.GetElementRotation(1), this.GetElementRotation(2) };
                xr = Matrix4.Transpose(Matrix4.CreateRotationX(-remrot[0]));
                yr = Matrix4.Transpose(Matrix4.CreateRotationY(-remrot[1]));
                zr = Matrix4.Transpose(Matrix4.CreateRotationZ(-remrot[2]));
                promres = zr * yr * xr;
                res = new Matrix3(promres);
                for (int i = 0; i < vertexCount; i++)
                {
                    int i6 = i * 6;
                    float x = Data[i6], y = Data[i6 + 1], z = Data[i6 + 2];
                    Data[i6] = x * res[0, 0] + y * res[0, 1] + z * res[0, 2];
                    Data[i6 + 1] = x * res[1, 0] + y * res[1, 1] + z * res[1, 2];
                    Data[i6 + 2] = x * res[2, 0] + y * res[2, 1] + z * res[2, 2];
                }
                if (Fig != null)
                {
                    Rotation = new float[3] { 0.0f, 0.0f, 0.0f };
                    RotationX = new float[3] { Fig.GetElementRotation(0), Fig.GetElementRotation(1), Fig.GetElementRotation(2) };
                }
                else
                {
                    Rotation = new float[3] { 0.0f, 0.0f, 0.0f };
                    RotationX = new float[3] { 0.0f, 0.0f, 0.0f };
                }

                Fig.remrot = new float[] { Fig.GetElementRotation(0), Fig.GetElementRotation(1), Fig.GetElementRotation(2) };
                xr = Matrix4.Transpose(Matrix4.CreateRotationX(-Fig.remrot[0]));
                yr = Matrix4.Transpose(Matrix4.CreateRotationY(-Fig.remrot[1]));
                zr = Matrix4.Transpose(Matrix4.CreateRotationZ(-Fig.remrot[2]));
                promres = zr * yr * xr;
                res = new Matrix3(promres);
                for (int i = 0; i < Fig.GetNumberOfVertices(); i++)
                {
                    int i6 = i * 6;
                    float x = Fig.Data[i6], y = Fig.Data[i6 + 1], z = Fig.Data[i6 + 2];
                    Fig.Data[i6] = x * res[0, 0] + y * res[0, 1] + z * res[0, 2];
                    Fig.Data[i6 + 1] = x * res[1, 0] + y * res[1, 1] + z * res[1, 2];
                    Fig.Data[i6 + 2] = x * res[2, 0] + y * res[2, 1] + z * res[2, 2];
                }
                if (Fig != null)
                {
                    Fig.SetGetElementRotation(0.0f, 0); Fig.SetGetElementRotation(0.0f, 1); Fig.SetGetElementRotation(0.0f, 2);
                }
                else
                {
                    Fig.SetGetElementRotation(0.0f, 0); Fig.SetGetElementRotation(0.0f, 1); Fig.SetGetElementRotation(0.0f, 2);
                }
            }
            for (int i = 0; i < vertexCount; i++)
            {
                int i6 = i * 6;
                Data[i6] = (Data[i6] + UserCX);
                Data[i6 + 1] = (Data[i6 + 1] + UserCY);
                Data[i6 + 2] = (Data[i6 + 2] + UserCZ);
                Data[i6 + 3] = Data[i6 + 3];
                Data[i6 + 4] = Data[i6 + 4];
                Data[i6 + 5] = Data[i6 + 5];
            }
            if (!((XC == 0.0f) && (YC == 0.0f) && (ZC == 0.0f)))
            { UserCX = -TranslationX / ZoomFactor + XC; UserCY = -TranslationY / ZoomFactor + YC; UserCZ = -TranslationZ / ZoomFactor + ZC; }
            else { UserCX = 0.0f; UserCY = 0.0f; UserCZ = 0.0f; }
            for (int i = 0; i < vertexCount; i++)
            {
                int i6 = i * 6;
                Data[i6] = (Data[i6] - UserCX);
                Data[i6 + 1] = (Data[i6 + 1] - UserCY);
                Data[i6 + 2] = (Data[i6 + 2] - UserCZ);
                Data[i6 + 3] = Data[i6 + 3];
                Data[i6 + 4] = Data[i6 + 4];
                Data[i6 + 5] = Data[i6 + 5];
            }
            if (((XC == 0.0f) && (YC == 0.0f) && (ZC == 0.0f)))
            {
                Rotation = remrot;
                xr = Matrix4.Transpose(Matrix4.CreateRotationX(-remrot[0]));
                yr = Matrix4.Transpose(Matrix4.CreateRotationY(-remrot[1]));
                zr = Matrix4.Transpose(Matrix4.CreateRotationZ(-remrot[2]));
                promres = zr * yr * xr;
                res = new Matrix3(promres);
                res.Invert();
                for (int i = 0; i < vertexCount; i++)
                {
                    int i6 = i * 6;
                    float x = Data[i6], y = Data[i6 + 1], z = Data[i6 + 2];
                    Data[i6] = (x * res[0, 0] + y * res[0, 1] + z * res[0, 2]);
                    Data[i6 + 1] = (x * res[1, 0] + y * res[1, 1] + z * res[1, 2]);
                    Data[i6 + 2] = (x * res[2, 0] + y * res[2, 1] + z * res[2, 2]);
                }

                Fig.SetGetElementRotation(Fig.remrot[0], 0); Fig.SetGetElementRotation(Fig.remrot[1], 1); Fig.SetGetElementRotation(Fig.remrot[2], 2);
                xr = Matrix4.Transpose(Matrix4.CreateRotationX(-Fig.remrot[0]));
                yr = Matrix4.Transpose(Matrix4.CreateRotationY(-Fig.remrot[1]));
                zr = Matrix4.Transpose(Matrix4.CreateRotationZ(-Fig.remrot[2]));
                promres = zr * yr * xr;
                res = new Matrix3(promres);
                res.Invert();
                for (int i = 0; i < Fig.GetNumberOfVertices(); i++)
                {
                    int i6 = i * 6;
                    float x = Fig.Data[i6], y = Fig.Data[i6 + 1], z = Fig.Data[i6 + 2];
                    Fig.Data[i6] = (x * res[0, 0] + y * res[0, 1] + z * res[0, 2]);
                    Fig.Data[i6 + 1] = (x * res[1, 0] + y * res[1, 1] + z * res[1, 2]);
                    Fig.Data[i6 + 2] = (x * res[2, 0] + y * res[2, 1] + z * res[2, 2]);
                }
            }
            IsRecalculated = true;
        }
        public void SetNullCenter() { SetUserCenter(0.0f, 0.0f, 0.0f, null); }
        public void SetAxisVertexCount(int Vert) { axisVertex_count = Vert; }
        public void SetGrabParameters(bool state, float t1, float t2)
        {
            grabedpoint.X = t1;
            grabedpoint.Y = t2;//судя по всему, это не Х и У. Просто записал пересечения
            grab = state;
        }
        public void SetZoomFactor(float Zoom)
        {
            if (Zoom <= 0) throw new Exception("Увеличение не может быть нулевым");
            else
            {
                ZoomFactor = Zoom;
                topRadius = rTopRadius;
            }
        }
        public float SetGetElementRotation(double pRad, int position)
        {
            if (position <= 2) Rotation[position] = (float)pRad; //в текущем коде оси получились инвертированными. Почему - хз. Поэтому сделал 2*Math.PI - pRad
            else throw new Exception("Несоответствие размеров массивов поворота. Используйте второй параметр как 0,1 или 2");
            return Rotation[position];
        }
        public float GetElementRotation(int position) { return Rotation[position]; }
        public float GetElementRotationX() { return Rotation[0]; }
        public float GetElementRotationY() { return Rotation[1]; }
        public float GetElementRotationZ() { return Rotation[2]; }



        public float GetElementRemRotation(int position) { return remrot[position]; }
        public void SetRealRadius(float radius) { rTopRadius = radius; }
        public float GetRealRadius() { return rTopRadius; }
        public int GetBufferSize() { return vertexCount * vertexSize; }
        public void SetType(int num) { if (num > 5) num = 5; TypeOfMesh = TypesOfMesh[num]; }
        private string GetType() { return TypeOfMesh; }
        public int GetTypeID() { int ID; for (ID = 0; ID < 6; ID++) if (TypeOfMesh == TypesOfMesh[ID]) break; return (ID > 5 ? 5 : ID); }
        public float[] GetMeshData()
        {
            var ptr = Data;
            return ptr;
        }
        private static int right(float num)
        {
            if (num - ((int)num) < 0.5f) return (int)num;
            else return (int)num + 1;
        }
       // public static 
        public static void CreateCilindricMesh(out MyMesh Finalmesh, float radius, float angle, float height, float accuracy, Color color)
        {
            float DrawStep = accuracy;
            //radius/ = 2.0f;
            float realstep = (DrawStep / radius)*(float)Rad2Grad;
            float stepgra = angle * (realstep) / (angle - (angle) % realstep),
                r = color.R / 255.0f, g = color.G / 255.0f, b = color.B / 255.0f;
            int VertexInLine = right(angle / stepgra) + 1;
            int VertCount = VertexInLine * (int)(height / DrawStep + 1);
            float[] DataMass = new float[VertCount * 6 + (int)((height / DrawStep) + 1) * 6];
            int i6 = 0;
            for (int i = 0; i < VertCount; i++) //Cilynder itself
            {
                i6 = i * 6;
                DataMass[i6] = radius * (float)Math.Cos(Grad2Rad * (double)(stepgra * (i % VertexInLine)));
                DataMass[i6 + 1] = radius * (float)Math.Sin(Grad2Rad * (double)(stepgra * (i % VertexInLine)));
                DataMass[i6 + 2] = DrawStep * (int)(i / (right(angle / stepgra) + 1));
                DataMass[i6 + 3] = r;
                DataMass[i6 + 4] = g;
                DataMass[i6 + 5] = b;
            }

            i6 = VertCount * 6; //red pt
            DataMass[i6] = 0;
            DataMass[i6 + 1] = 0;
            DataMass[i6 + 2] = DrawStep * (VertCount - VertCount);
            DataMass[i6 + 3] = 255;
            DataMass[i6 + 4] = 0;
            DataMass[i6 + 5] = 0;

            for (int i = VertCount+1; i < VertCount + (int)((height / DrawStep) + 1); i++) //axis
            {
                i6 = i * 6;
                DataMass[i6] = 0;
                DataMass[i6 + 1] = 0;
                DataMass[i6 + 2] = DrawStep * (i - VertCount);
                DataMass[i6 + 3] = r;
                DataMass[i6 + 4] = g;
                DataMass[i6 + 5] = b;
            }
            Finalmesh = new MyMesh(DataMass, 2);
            Finalmesh.axisVertex_count = (int)((height / DrawStep) + 1);
            Finalmesh.SetType(1);
            Finalmesh.SetRealRadius(radius);
        }
        public static void CreateSphereMesh(out MyMesh Finalmesh, float radius, float accuracy, Color color)
        {           
            float DrawStep = accuracy;
            float realstep = (DrawStep / radius)*(float)Rad2Grad;
            float stepgra = 360.0f * (realstep) / (360.0f - (360.0f) % realstep),
                x = 0, y = 0, z = 0, r = color.R / 255.0f, g = color.G / 255.0f, b = color.B / 255.0f;
            int VertexInLine = right(360.0f / stepgra) + 1;
            int VertCount = VertexInLine * (right(180.0f / stepgra) + 1);
            float[] DataMass = new float[VertCount * 6];
            double factor = 0, factor2 = 0; int i6 = 0;
            for (int i = 0; i < VertCount; i++)
            {
                i6 = i * 6;
                factor = Grad2Rad * (double)(stepgra * (i % VertexInLine));
                factor2 = Grad2Rad * stepgra * (i / VertexInLine);
                DataMass[i6] = radius * (float)Math.Sin(factor2) * (float)Math.Cos(factor);
                DataMass[i6 + 1] = radius * (float)Math.Sin(factor2) * (float)Math.Sin(factor);
                DataMass[i6 + 2] = radius * (float)Math.Cos(factor2);
                DataMass[i6 + 3] = r;
                DataMass[i6 + 4] = g;
                DataMass[i6 + 5] = b;
            }
            Finalmesh = new MyMesh(DataMass, 1);
            Finalmesh.SetType(0);
            Finalmesh.SetRealRadius(radius);
        }
        public static void CreatePlainMesh(out MyMesh Finalmesh, float XYPar, float accuracy, Color color)
        {
            float r = color.R / 255.0f, g = color.G / 255.0f, b = color.B / 255.0f;
            float DrawStep = XYPar * (accuracy / (XYPar - (XYPar % accuracy)));
            int VertexInLine = (int)(XYPar / DrawStep) + 2;
            int VertCount = VertexInLine * VertexInLine + 4;//на каемку
            float[] DataMass = new float[VertCount * 6];
            int j6 = 0, i6 = 0;
            for (int i = 0; i < VertexInLine; i++)
            {
                i6 = i * 6;
                for (int j = 0; j < VertexInLine; j++)
                {
                    j6 = j * 6;
                    DataMass[i6 * VertexInLine + j6] = -XYPar / 2 + DrawStep * i;
                    DataMass[i6 * VertexInLine + j6 + 1] = -XYPar / 2 + DrawStep * j;
                    DataMass[i6 * VertexInLine + j6 + 2] = 0;
                    DataMass[i6 * VertexInLine + j6 + 3] = r;
                    DataMass[i6 * VertexInLine + j6 + 4] = g;
                    DataMass[i6 * VertexInLine + j6 + 5] = b;
                }
            }
            int factX, factY;
            for (int i = -4; i < 0; i++)
            {
                if (i == -4) factX = factY = 1;
                else if (i == -3) { factX = -1; factY = 1; }
                else if (i == -2) { factX = -1; factY = -1; }
                else { factX = 1; factY = -1; }
                DataMass[(VertCount + i) * 6] = factX * XYPar / 2;
                DataMass[(VertCount + i) * 6 + 1] = factY * XYPar / 2;
                DataMass[(VertCount + i) * 6 + 2] = 0;
                DataMass[(VertCount + i) * 6 + 3] = r;
                DataMass[(VertCount + i) * 6 + 4] = g;
                DataMass[(VertCount + i) * 6 + 5] = b;
            }
            Finalmesh = new MyMesh(DataMass, 1);
            Finalmesh.SetType(2);
        }
        public static void CreateNullMesh(out MyMesh Finalmesh)
        {
            float[] DataMass = new float[0];
            Finalmesh = new MyMesh(DataMass, 1);
            Finalmesh.SetType(5);
        }
    }
    public class RGBPointOwnType
    {
        public double X { set; get; }
        public double Y { set; get; }
        public double Z { set; get; }
        public double R { set; get; }
        public double G { set; get; }
        public double B { set; get; }

        public static implicit operator RGBPoint3f(RGBPointOwnType d)
        {
            return new RGBPoint3f() { X = (float)d.X, Y = (float)d.Y, Z = (float)d.Z, R = (byte)(d.R * 255.0), G = (byte)(d.G * 255.0), B = (byte)(d.B * 255.0) };
        }
            
        public static explicit operator RGBPointOwnType(RGBPoint3f b)
        {
            return new RGBPointOwnType() { X = b.X, Y = b.Y, Z = b.Z, R=(double)b.R/255.0, G = (double)b.G / 255.0, B = (double)b.B / 255.0 };
        }

    }


    enum MeshTypes { Sphere = 1, Cilindric, Plane, Model, UserStyle }
    abstract class MyMesh2
    {

    }
}

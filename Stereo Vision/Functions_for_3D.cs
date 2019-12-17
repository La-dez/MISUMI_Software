using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK_3DMesh;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Windows.Forms;
using CameraMath.Wrapper;


namespace Stereo_Vision
{
    partial class MainWindow
    {
        bool M3D_loaded = false;
        int vertex = 0;
        int fragment = 0;
        int program = 0;
        static float[] projectionMatrix = new float[16];
        static float[] dataMatrix2 = new float[16];
        static float[] ViewProjectionMatrix = new float[16];
        static float[] viewMatrix = new float[16];
        static float[] dataMatrix = new float[16];
        static float[] modelMatrix = new float[16];
        static float[] modelViewProjectionMatrix = new float[16];
        static float[] CameraPosition = new float[3] { 0.0f, 0.0f, 0.0f };
        static float[] viewDirection = new float[3] { 0.0f, 0.0f, -1.0f };
        static float[] UPvector = new float[3] { 0.0f, 1.0f, 0.0f };
        bool firstfix = false;
        Matrix4 projectionMatrixi = new Matrix4();
        Matrix4 viewMatrixi = new Matrix4();
        float remX = 0, remY = 0, trans = 0.05f;
        static int modelViewProjectionMatrixLocation = -1, positionLocation = -1, colorLocation = -1;
        float deltaTime = 0.002f;
        static float[] trianeMesh2 = new float[6 * 6] { /* 1 вершина, позиция: */ 0.0f, 0.0f, 0.0f, /* цвет: */ 0.0f, 1.0f, 0.0f, 
                                                                 /* 2 вершина, позиция: */ 1.0f, 0.5f, 0.0f, /* цвет: */ 0.0f, 1.0f, 0.0f, 
                                                                 /* 3 вершина, позиция: */ 1.0f, -0.5f, 0.0f, /* цвет: */ 0.0f, 0.0f, 1.0f , 
                                                                 /* 2 вершина, позиция: */ 0.0f, 0.0f, 0.0f, /* цвет: */ 0.0f, 1.0f, 0.0f, 
                                                                 /* 3 вершина, позиция: */ -1.0f, 0.5f, 0.0f, /* цвет: */ 0.0f, 0.0f, 1.0f  , 
                                                                 /* 2 вершина, позиция: */ -1.0f, -0.5f, 0.0f, /* цвет: */ 0.0f, 1.0f, 0.0f};
        MyMesh Figure = null;
        MyMesh BasicMesh = null;
        static int[] meshVAO = new int[2];
        static int meshVBO = 0;

        bool AllowInvalidate = true;

        bool MeshesFixedByEachOther = false;

        private void MyInit()
        {
            LoadShaders();
            LoadFigures();
            CreateBuffers();
            BindTextures();
            // создадим перспективную матрицу проекции 
            float aspectRatio = (float)OTK_3D_Control.Width / (float)OTK_3D_Control.Height;
            Matrix4Perspective(projectionMatrix, 60.0f, aspectRatio, 0.1f, 200.0f);//перспектива 
            Matrix4Trans(ref viewMatrix, Matrix4.LookAt
             (new Vector3(CameraPosition[0], CameraPosition[1], CameraPosition[2]),
              new Vector3(/*CameraPosition[0] + */viewDirection[0],
                /*CameraPosition[1] + */viewDirection[1],
                /*CameraPosition[2] +*/ viewDirection[2]),
              new Vector3(UPvector[0], UPvector[1], UPvector[2]))); //мировая матрица - зависимость от точки обзора
            Matrix4Mul(ViewProjectionMatrix, projectionMatrix, viewMatrix);// совместим матрицу проекции и матрицу наблюдателя 

            projectionMatrixi = Matrix4.Invert(new Matrix4(
               projectionMatrix[0], projectionMatrix[1], projectionMatrix[2], projectionMatrix[3],
               projectionMatrix[4], projectionMatrix[5], projectionMatrix[6], projectionMatrix[7],
               projectionMatrix[8], projectionMatrix[9], projectionMatrix[10], projectionMatrix[11],
               projectionMatrix[12], projectionMatrix[13], projectionMatrix[14], projectionMatrix[15]));

            float[] viewMatrixFF = new float[16];
            Matrix4Trans(ref viewMatrixFF, Matrix4.LookAt
             (new Vector3(CameraPosition[0], CameraPosition[1], CameraPosition[2]),
              new Vector3(-viewDirection[0], -viewDirection[1], viewDirection[2]),
              new Vector3(UPvector[0], UPvector[1], UPvector[2])));

            viewMatrixi = Matrix4.Invert(new Matrix4(
                    viewMatrixFF[0], viewMatrixFF[1], viewMatrixFF[2], viewMatrixFF[3],
                    viewMatrixFF[4], viewMatrixFF[5], viewMatrixFF[6], viewMatrixFF[7],
                    viewMatrixFF[8], viewMatrixFF[9], viewMatrixFF[10], viewMatrixFF[11],
                    viewMatrixFF[12], viewMatrixFF[13], viewMatrixFF[14], viewMatrixFF[15]));

            M3D_loaded = true;
            GL.ClearColor(Color.White);
            OTK_3D_Control.BackColor = Color.SkyBlue;
        }
        private void LoadShaders()
        {
            try
            {
                int length = 0;
                System.IO.StreamReader sr;
                string[] shadertext1 = new string[1], shadertext2 = new string[1];
                program = GL.CreateProgram();
                vertex = GL.CreateShader(ShaderType.VertexShader);
                fragment = GL.CreateShader(ShaderType.FragmentShader);
                try
                {
                    using (sr = new System.IO.StreamReader("lesson.vs"))
                    {
                        shadertext1[0] = sr.ReadToEnd(); length = shadertext1[0].Count();
                        GL.ShaderSource(vertex, 1, shadertext1, ref length);
                        sr.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                try
                {
                    using (sr = new System.IO.StreamReader("lesson.fs"))
                    {
                        shadertext2[0] = sr.ReadToEnd(); length = shadertext2[0].Count();
                        GL.ShaderSource(fragment, 1, shadertext2, ref length);
                        sr.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Фрагментный шейдер не найден. Ориинальный текст ошибки: " +
                        e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                try
                {
                    int datalenght = 1000, datalenght2 = 1000;
                    // StringBuilder datasbuild = new StringBuilder(1000), datasbuild2 = new StringBuilder(1000);
                    string datasbuild =""; string datasbuild2 = "";
                    GL.GetShaderSource(vertex, 1000, out datalenght, out datasbuild);
                    GL.CompileShader(vertex);
                    GL.GetShaderSource(fragment, 1000, out datalenght2, out datasbuild2);
                    GL.CompileShader(fragment);
                    GL.AttachShader(program, vertex);
                    GL.AttachShader(program, fragment);
                    GL.LinkProgram(program);
                    sr = null;
                    int link_ok;
                    GL.GetProgram(program, GetProgramParameterName.LinkStatus, out link_ok);

                    string error = null;
                    GL.GetProgramInfoLog(program, out error);
                    if (link_ok != (int)All.True) throw new Exception("Ошибка:" + error + "Проверочные значения: Link_ok=" +
                        link_ok + ", True=" + ((int)All.True).ToString());
                    GL.UseProgram(program);
                    GL.ValidateProgram(program);
                    GL.GetProgram(program, GetProgramParameterName.ValidateStatus, out link_ok);
                    if (link_ok != (int)All.True) throw new Exception();
                }
                catch (Exception exceptio)
                {
                    MessageBox.Show("Ошибка: " + exceptio.Message);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка: " + exception.Message);
            }
        }
        private void LoadFigures()
        {
            Figure = new MyMesh();
            BasicMesh = new MyMesh();
            // MyMesh.CreteCilindricMesh(out Figure, 1.5f, 360.0f, 1.0f, 0.1f, Color.FromArgb(0, 255, 0));
            // MyMesh.CreteSphereMesh(out Figure, 2.0f, 0.1f, Color.FromArgb(0, 255, 0));
            MyMesh.CretePlainMesh(out BasicMesh, 2.0f, 0.09f, Color.FromArgb(0, 255, 0));
            MyMesh.CreteSphereMesh(out Figure, 2.0f, 0.1f, Color.FromArgb(0, 255, 0));
            BasicMesh.SetZoomFactor(1.0f);
            Figure.SetZoomFactor(1.0f);
            BasicMesh.MoveX = 0.5f; BasicMesh.MoveY = 0.0f; BasicMesh.MoveZ = -5.0f;
            Figure.MoveX = -0.5f; Figure.MoveY = 0.0f; Figure.MoveZ = -5.0f;
        }
        private void CreateBuffers()
        {
            GL.GenBuffers(1, out meshVBO);
            GL.GenVertexArrays(1, out meshVAO[0]);
            GL.GenVertexArrays(1, out meshVAO[1]);
        }
        private void BindTextures()
        {
            AllowInvalidate = false;
            int bufsize = Figure.GetBufferSize();
            GL.BindBuffer(BufferTarget.ArrayBuffer, meshVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(Figure.GetBufferSize() + BasicMesh.GetBufferSize()),
                new IntPtr(0), BufferUsageHint.StaticDraw);
            GL.BufferSubData(BufferTarget.ArrayBuffer, new IntPtr(0), new IntPtr(Figure.GetBufferSize()), Figure.GetMeshData());
            GL.BufferSubData(BufferTarget.ArrayBuffer, new IntPtr(Figure.GetBufferSize()),
                new IntPtr(BasicMesh.GetBufferSize()), BasicMesh.GetMeshData());

            positionLocation = GL.GetAttribLocation(program, "position");
            colorLocation = GL.GetAttribLocation(program, "color");
            // смещения данных внутри вершинного буфера 

            if (positionLocation == -1) positionLocation = 1;// получим индекс атрибута 'position' из шейдера 
            if (colorLocation == -1) colorLocation = 0;// получим индекс атрибута 'color' из шейдера 

            GL.BindVertexArray(meshVAO[0]);
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            GL.BindBuffer(BufferTarget.ArrayBuffer, meshVBO);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize, MyMesh.vertexOffsetPosition);
            GL.VertexAttribPointer(colorLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize, MyMesh.vertexOffsetColor);

            GL.BindVertexArray(meshVAO[1]);
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            GL.BindBuffer(BufferTarget.ArrayBuffer, meshVBO);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize,
                Figure.GetBufferSize() + MyMesh.vertexOffsetPosition);
            GL.VertexAttribPointer(colorLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize,
                Figure.GetBufferSize() + MyMesh.vertexOffsetColor);

            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize, MyMesh.vertexOffsetPosition);
            GL.VertexAttribPointer(colorLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize, MyMesh.vertexOffsetColor);
            /*  BasicMesh.MoveZ = -(TrBZModifier.Value / 100.0f);
              Figure.MoveZ = -(TrBZModifier.Value / 100.0f);*/
            Figure.MoveZ = -(200 / 100.0f);
            BasicMesh.MoveZ = -(200 / 100.0f);
            AllowInvalidate = true;
        }
        private Vector3 GetNormalizedRayWor(float MouseX3D, int MouseY3D)
        {
            float x = (2.0f * MouseX3D) / OTK_3D_Control.Width - 1.0f;
            float y = 1.0f - (2.0f * MouseY3D) / OTK_3D_Control.Height;
            float z = 1.0f;
            Vector3 ray_nds = new Vector3(x, y, z);
            Vector4 ray_clip = new Vector4(ray_nds.X, ray_nds.Y, -1.0f, 1.0f);
            Vector4 ray_eye = Vector4.Transform(ray_clip, projectionMatrixi);
            ray_eye = new Vector4(ray_eye.X, ray_eye.Y, -1.0f, 0.0f);
            return Vector3.Normalize(new Vector3(Vector4.Transform(ray_eye, viewMatrixi)));
        }
        private void Draw()
        {
            if (AllowInvalidate)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.Enable(EnableCap.DepthTest);
                GL.Viewport(0, 0, OTK_3D_Control.Width, OTK_3D_Control.Height);
                GL.EnableClientState(ArrayCap.VertexArray);
                GL.UseProgram(program);
                Matrix4 xr, yr, zr;
                Matrix4Translation(dataMatrix2, BasicMesh.MoveX, BasicMesh.MoveY, BasicMesh.MoveZ);//перенос        

                xr = Matrix4.CreateRotationX(BasicMesh.GetElementRotation(0));
                yr = Matrix4.CreateRotationY(BasicMesh.GetElementRotation(1));
                zr = Matrix4.CreateRotationZ(BasicMesh.GetElementRotation(2));
                Matrix4Mul(ref dataMatrix2, Matrix4Trans(zr * yr * xr)); // поворот

                float zf = BasicMesh.GetZoomFactor();
                Matrix4Mul(ref dataMatrix2, Matrix4Trans(Matrix4.CreateScale(zf, zf, zf))); // увеличение
                Matrix4Mul(modelViewProjectionMatrix, ViewProjectionMatrix, dataMatrix2);

                modelViewProjectionMatrixLocation = GL.GetUniformLocation(program, "modelViewProjectionMatrix");
                GL.UniformMatrix4(modelViewProjectionMatrixLocation, 1, Convert.ToBoolean(All.True), modelViewProjectionMatrix);
                GL.DrawArrays(PrimitiveType.LineStrip, Figure.GetNumberOfVertices(), BasicMesh.GetNumberOfVertices() - BasicMesh.GetAxis());
                GL.PointSize(2.0f);
                GL.DrawArrays(PrimitiveType.Points, Figure.GetNumberOfVertices() + BasicMesh.GetNumberOfVertices() - BasicMesh.GetAxis(), BasicMesh.GetAxis());

                
                if (!MeshesFixedByEachOther)
                {
                    if (Figure.IsRecalculated)
                    {
                        Matrix4Translation(dataMatrix2, Figure.MoveX, Figure.MoveY, Figure.MoveZ);//перенос
                        xr = Matrix4.CreateRotationX(Figure.GetElementRotation(0));
                        yr = Matrix4.CreateRotationY(Figure.GetElementRotation(1));
                        zr = Matrix4.CreateRotationZ(Figure.GetElementRotation(2));
                    }
                }
                else
                {
                    Figure.SetGetElementRotation(BasicMesh.GetElementRotation(0), 0);
                    Figure.SetGetElementRotation(BasicMesh.GetElementRotation(1), 1);
                    Figure.SetGetElementRotation(BasicMesh.GetElementRotation(2), 2);
                    xr = Matrix4.CreateRotationX(Figure.GetElementRotation(0));
                    yr = Matrix4.CreateRotationY(Figure.GetElementRotation(1));
                    zr = Matrix4.CreateRotationZ(Figure.GetElementRotation(2));
                    Matrix4Translation(dataMatrix2, BasicMesh.MoveX, BasicMesh.MoveY, BasicMesh.MoveZ);//перенос  
                }

                Matrix4Mul(ref dataMatrix2, Matrix4Trans(zr * yr * xr));

                zf = Figure.GetZoomFactor();
                Matrix4Mul(ref dataMatrix2, Matrix4Trans(Matrix4.CreateScale(zf, zf, zf))); // увеличение
                Matrix4Mul(modelViewProjectionMatrix, ViewProjectionMatrix, dataMatrix2);

                modelViewProjectionMatrixLocation = GL.GetUniformLocation(program, "modelViewProjectionMatrix");
                GL.UniformMatrix4(modelViewProjectionMatrixLocation, 1, Convert.ToBoolean(All.True), modelViewProjectionMatrix);
                if (Figure.GetTypeID() != 4)
                    GL.DrawArrays(PrimitiveType.Triangles, 0, Figure.GetNumberOfVertices());
              /*  else //Это отрисовка измерений. Надо переписать под чистую
                {
                    GL.PointSize(3.0f);
                    int i = 0;
                    int[] CountOfPoints = new int[6] { 0, 0, 0, 0, 0, 0 };
                    CountOfPoints[0] = (TransformedP[0].Count - 1) * 2;
                    CountOfPoints[1] = (TransformedP[1].Count - 1) * 3;
                    for (i = 0; i < TransformedP[2].Count - 1; i++)
                    { CountOfPoints[2] += TransformedP[2][i].points.Count; }
                    CountOfPoints[3] = (TransformedP[3].Count - 1) * 4;
                    for (i = 0; i < TransformedP[4].Count - 1; i++)
                    { CountOfPoints[4] += TransformedP[4][i].points.Count; }
                    for (i = 0; i < TransformedP[5].Count - 1; i++)
                    { CountOfPoints[5] += TransformedP[5][i].points.Count; }
                    int Type1Passed = 0, Type2Passed = 0, Type4Passed = 0, Type3Passed = 0, Type5Passed = 0;
                    for (i = 0; i < TransformedP.Count(); i++)
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    GL.DrawArrays(PrimitiveType.Lines, 0, CountOfPoints[0]);
                                    GL.DrawArrays(PrimitiveType.Points, 0, CountOfPoints[0]);
                                    break;
                                }
                            case 1:
                                {
                                    for (int j = 0; j < TransformedP[i].Count; j++)
                                    {
                                        GL.DrawArrays(PrimitiveType.Lines, CountOfPoints[0] + Type1Passed, TransformedP[i][j].points.Count - 1);
                                        GL.DrawArrays(PrimitiveType.Points, CountOfPoints[0] + Type1Passed, TransformedP[i][j].points.Count - 1);
                                        GL.DrawArrays(PrimitiveType.Points, CountOfPoints[0] + Type1Passed + TransformedP[i][j].points.Count - 1, 1);
                                        Type1Passed += TransformedP[i][j].points.Count;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    for (int j = 0; j < TransformedP[i].Count; j++)
                                    {
                                        GL.DrawArrays(PrimitiveType.LineLoop, CountOfPoints[0] + CountOfPoints[1] + Type2Passed, TransformedP[i][j].points.Count);
                                        GL.DrawArrays(PrimitiveType.Points, CountOfPoints[0] + CountOfPoints[1] + Type2Passed, TransformedP[i][j].points.Count);
                                        Type2Passed += TransformedP[i][j].points.Count;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    for (int j = 0; j < TransformedP[i].Count; j++)
                                    {
                                        GL.DrawArrays(PrimitiveType.LineLoop, CountOfPoints[0] + CountOfPoints[1] + CountOfPoints[2] + Type3Passed,
                                            TransformedP[i][j].points.Count - 1);
                                        GL.DrawArrays(PrimitiveType.Points, CountOfPoints[0] + CountOfPoints[1] + CountOfPoints[2] + Type3Passed,
                                            TransformedP[i][j].points.Count - 1);
                                        GL.DrawArrays(PrimitiveType.Points, CountOfPoints[0] + CountOfPoints[1] + CountOfPoints[2]
                                            + Type3Passed + TransformedP[i][j].points.Count - 1, 1);
                                        Type3Passed += TransformedP[i][j].points.Count;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    for (int j = 0; j < TransformedP[i].Count; j++)
                                    {
                                        GL.DrawArrays(PrimitiveType.LineLoop, CountOfPoints[0] + CountOfPoints[1] + CountOfPoints[2] + CountOfPoints[3]
                                            + Type4Passed, TransformedP[i][j].points.Count);
                                        GL.DrawArrays(PrimitiveType.Points, CountOfPoints[0] + CountOfPoints[1] + CountOfPoints[2] + CountOfPoints[3]
                                            + Type4Passed, TransformedP[i][j].points.Count);
                                        Type4Passed += TransformedP[i][j].points.Count;
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    for (int j = 0; j < TransformedP[i].Count; j++)
                                    {
                                        GL.DrawArrays(PrimitiveType.LineStrip, CountOfPoints[0] + CountOfPoints[1] + CountOfPoints[2] + CountOfPoints[3] +
                                        CountOfPoints[4] + Type5Passed, TransformedP[i][j].points.Count);
                                        GL.DrawArrays(PrimitiveType.Points, CountOfPoints[0] + CountOfPoints[1] + CountOfPoints[2] + CountOfPoints[3] +
                                        CountOfPoints[4] + Type5Passed, TransformedP[i][j].points.Count);
                                        Type5Passed += TransformedP[i][j].points.Count;
                                    }
                                    break;
                                }
                        }
                    }
                }*/
                //  if (Triangle.GetTypeID() == 4) BCalculateQD.Enabled = true; else BCalculateQD.Enabled = false;
                OTK_3D_Control.SwapBuffers();
            }
        }
        private void Init3M()
        {
            /*if (Mode == 1)
            {
                try { TransformC(6); LoadMeasurements(); }
                catch
                { }
            }*/
          
            try
            {
              /*  OTK_3D_Control.Visible = true; ExitBut.Visible = true;
                GrBVisibleObjects.Visible = true; GrB3DSettings.Visible = true;
                icImagingControl1.LiveStop(); LSurfaceType.Visible = true; LRadius.Visible = true;
                LAngMX.Visible = true; ChkBFixMesh.Visible = true; ChkBPoints.Visible = true;
                ChkBModel.Visible = true; ChkBRealSurface.Visible = true; LAngles.Visible = true;
                LInfo.Visible = true; LInfo2.Visible = true; LBDataBase.Visible = true;
                TRBarMAngX.Visible = true; TRBarMAngY.Visible = true; TRBarMAngZ.Visible = true;
                TRBarSAngX.Visible = true; TRBarSAngY.Visible = true; TRBarSAngZ.Visible = true;
                TRBarMAngX.Value = 0; os_x = 1; os_y = 0; os_z = 0; LDataBase.Visible = true;
                LModelAngles.Visible = true; BDeleteElement.Visible = true; LSurfaceAngles.Visible = true;
                LZModifier.Visible = true; TrBZModifier.Visible = true; LZDistValue.Visible = true;
                Mode = 2; ChkBRealSurface.Checked = true; ChkBPoints.Checked = true;
                LAngMX.Visible = true; LAngMY.Visible = true; LAngMZ.Visible = true;
                LAngSX.Visible = true; LAngSY.Visible = true; LAngSZ.Visible = true;
                TRBarMAngX.Value = 0; TRBarMAngY.Value = 0; TRBarMAngZ.Value = 0;
                TRBarSAngY.Value = 0; TRBarSAngZ.Value = 0;
                TrBMZoom.Value = 100; BasicMesh.SetZoomFactor(1.0f);
                TrBSZoom.Value = 100; Figure.SetZoomFactor(1.0f);
                TrBZModifier.Value = 500; ModifyZCoord();
                LAngMX.Text = "X: " + TRBarMAngX.Value.ToString(); BasicMesh.SetGetElementRotation(0, 0);
                LAngMY.Text = "Y: " + TRBarMAngY.Value.ToString(); BasicMesh.SetGetElementRotation(0, 1);
                LAngMZ.Text = "Z: " + TRBarMAngZ.Value.ToString(); BasicMesh.SetGetElementRotation(0, 2);
                LAngSX.Text = "X: " + TRBarSAngZ.Value.ToString(); Figure.SetGetElementRotation(0, 0);
                LAngSY.Text = "Y: " + TRBarSAngY.Value.ToString(); Figure.SetGetElementRotation(0, 1);
                LAngSZ.Text = "Z: " + TRBarSAngZ.Value.ToString(); Figure.SetGetElementRotation(0, 2);
                LMZoomX.Text = "x" + (((float)TrBMZoom.Value) / 100.0f).ToString();
                LSZoomX.Text = "x" + (((float)TrBSZoom.Value) / 100.0f).ToString();
                LZDistValue.Text = ((float)(TrBZModifier.Value) / 100.0f).ToString();
                LZoom3D.Visible = true; TrBMZoom.Visible = true; TrBSZoom.Visible = true;
                LMZoomX.Visible = true; LSZoomX.Visible = true;
                BCalculateQD.Visible = true; LDeviance.Visible = true; LDeviance.Text = "СКО(мм):"; TBDeviance.Visible = true;
                TBEtDeviance.Visible = true; LEtDeviance.Visible = true;
                Visual3MChkBox.Visible = true;
                if (BasicMesh.GetTypeID() == 4)
                {
                    LRealDist.Visible = true; string text = null;
                    int countofp = 0;
                    for (int i = 0; i < TransformedP.Count(); i++)
                        for (int j = 0; j < TransformedP[i].Count; j++)
                            for (int k = 0; k < TransformedP[i][j].points.Count; k++)
                            { countofp++; }
                    if (countofp == 0) { text = "не определена,\n так как отсутствуют опорные точки."; BCalculateQD.Enabled = false; }
                    else { text = Math.Abs(PerfectRounding(BasicMesh.CenterZ, 2)).ToString(); BCalculateQD.Enabled = true; }
                    LRealDist.Text = "Дистанция до объекта(мм): " + text;
                }
                LDeviance.Location = new Point(LDeviance.Location.X + 41, LDeviance.Location.Y);
                TBRadius.Visible = true; CBSurfaceType.Visible = true;
                if (TBRadius.Text == "") TBRadius.Text = "1,0";
                var ListBoxDataBase = LBDataBase;
                var List = DataBaseFull;
                if (Figure.GetTypeID() == 2) { TBRadius.Enabled = false; }
                WFunc.LoadDataBase(ref ListBoxDataBase, ref List, "Defects Base\\DataBase.db", ref databaseloaded);*/
            }
            catch (Exception exw)
            {
                MessageBox.Show(exw.Message);
            }
        }

        double sred100X = 0;
        double sred100Y = 0;
        double sred100Z = 0;
        private MyMesh BuildModel3D(System.ComponentModel.BackgroundWorker bw, Image image,bool IsPrism)
        {
            LogMessage("Начало построения 3D...");      
            bool bDenseStereoCorrTestPassed = true;
            ICameraPair stereoPair = null;
            Bitmap img = null;
            IStereoDenseEstimator stereoEstimator = null;
            System.Drawing.Imaging.PixelFormat PxForm = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
            var trPtArray = new TriangPointArray3f();
            IndexTriplet[] TriangleModelMass;
            RGBPointOwnType[] RGBPointsMass;
            string cfgFilePath = IsPrism ? "M5_chess_shiftM11.xml": "M1_chess.xml";
            MyMesh result = null;

            if (!bw.CancellationPending)
            {
                // Load image
                try
                {
                    img = (Bitmap)image;
                    if (img.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                    { img = img.Clone(new Rectangle(0, 0, img.Width, img.Height), PxForm); }
                }
                catch
                {
                   throw new Exception("Ошибка на этапе загрузки изображения.\nПостроение 3D модели завершено с ошибкой.");
                }
                // Read camera pair parameters from XML file

                try
                { stereoPair = XMLLoader.ReadCameraPair(cfgFilePath); }
                catch
                {
                   throw new Exception("Ошибка на этапе чтения калибровочного файла.\nПостроение 3D модели завершено с ошибкой.");
                }
                LogMessage("Загрузка изображения и калибровки успешна!");
               // SetProgress(10);
            }

            if (stereoPair == null)
            {
                throw new Exception("Can't read XML file.");              
            }
            else
            {
                if (!bw.CancellationPending)
                {
                    LogMessage("Загрузка файла stereo_params.xml");
                    // Set ROI (region of interest)

                    int GRPX_x2 = GRPX * 2;

                    int ROI_w = image.Width/2 - GRPX_x2;
                    int ROI_h = image.Height - GRPX_x2;
                 /*   var rectROI1 = new Rect2d(GRPX, GRPX, ROI_w, ROI_h);
                    var rectROI2 = new Rect2d(GRPX, image.Width / 2 + GRPX, ROI_w, ROI_h);*/
                    var rectROI1 = new Rect2d(40.0, 40.0, 560.0, 640.0);
                    var rectROI2 = new Rect2d(40.0, 680.0, 550.0, 640.0);

                    // Initialize stereo correspondence finder
                    if (IsPrism)
                    {
                        var zPlane = new Plane3d(new Point3d(0.0, 0.0, 1.0), -14.0);
                        stereoEstimator = StereoDenseCorrFactory.GetRectifStereoDenseEstimator(stereoPair, rectROI1, rectROI2, zPlane);
                    }
                    else
                    {
                        stereoEstimator = StereoDenseCorrFactory.GetRectifStereoDenseEstimator(stereoPair, rectROI1, rectROI2);
                    }
                    // Load parameters from file
                    bDenseStereoCorrTestPassed = bDenseStereoCorrTestPassed && stereoEstimator.ReadParam("stereo_params.xml");
                    // Set distance range (mm)
                    //  stereoEstimator.SetZDiap(5.0, 15.00);//17+-
                    stereoEstimator.SetZDiap(10.0, 60.00);//17+-
                    System.Threading.Thread.Sleep(200);//little fix
                                                       //  SetProgress(15);
                }
                else return null;

                if (!bw.CancellationPending)
                {
                    // Find triangle mesh
                    LogMessage("Построение триангуляционной модели....");
                    trPtArray = new TriangPointArray3f();
                    try
                    {
                        bDenseStereoCorrTestPassed = bDenseStereoCorrTestPassed && stereoEstimator.Find(img, ref trPtArray);
                        LogMessage("Модель построена!");
                        //SetProgress(30);
                    }//
                    catch (Exception exc)
                    {
                        LogMessage("Ошибка при построении модели");
                        throw exc;
                        //return false;
                    }
                    // Filter
                    // Delete triangles with edges longer than 0.2
                    LogMessage("Применение фильтров...");
                  //  MeshUtils.FilterLongEdge(ref trPtArray, 0.2);
                    LogMessage("Фильтры применены!");
                    // SetProgress(40);
                }
                else return null;

                // Save to ply file
                try
                {
                    LogMessage("Сохранение модели в память...");
                    uint Num_of_Triangles = trPtArray.GetNumberOfTriangles();
                    uint Num_of_Pts = trPtArray.GetNumberOfPoints();
                    TriangleModelMass = new IndexTriplet[Num_of_Triangles];
                    RGBPointsMass = new RGBPointOwnType[Num_of_Pts];

                    RGBPoint3f DataPoint = null;
                    if (!bw.CancellationPending)
                    {
                        for (uint i = 0; i < Num_of_Triangles; i++)
                        {
                            TriangleModelMass[i] = trPtArray.GetTriangle(i);
                        }
                    }
                    else return null;

                    if (!bw.CancellationPending)
                    {
                        LogMessage("Вычисление цветовых и пространственных координат...");
                        for (uint i = 0; i < Num_of_Pts; i++)
                        {
                            //Написал собственный каст типов. По факту, нужен для перегонки rgb из byte в double
                            RGBPointsMass[i] = (RGBPointOwnType)trPtArray.GetPoint(i);
                            RGBPointsMass[i].Z = -RGBPointsMass[i].Z;
                            //попутно вычисляем центр
                            sred100X += RGBPointsMass[i].X;
                            sred100Y += RGBPointsMass[i].Y;
                            sred100Z += RGBPointsMass[i].Z;
                        }
                        //вычисляем....
                        sred100X = sred100X / Num_of_Pts;
                        sred100Y = sred100Y / Num_of_Pts;
                        sred100Z = sred100Z / Num_of_Pts;
                        //центрируем
                        for (uint i = 0; i < Num_of_Pts; i++)
                        {
                            RGBPointsMass[i].X -= sred100X;
                            RGBPointsMass[i].Y -= sred100Y;
                            RGBPointsMass[i].Z -= sred100Z;
                        }
                        LogMessage("Вычисление цветовых и пространственных координат...");
                    }

                    if (!bw.CancellationPending)
                    {
                        LogMessage("Создание модели для отрисовки...");
                        // SetProgress(95);                      
                        result = new MyMesh(RGBPointsMass, TriangleModelMass);
                        LogMessage("Запись файла модели(PLY)");

                        string datename = GetTimeString();
                        PLYWriter.SaveBinary(datename + ".ply", trPtArray);
                        //bDenseStereoCorrTestPassed = bDenseStereoCorrTestPassed; //&&

                        //SetProgress(100);
                    }
                    else return null;
                }
                catch (Exception exc)
                { throw exc; }

                if (bDenseStereoCorrTestPassed)
                {
                    LogMessage("Готово");
                }
                else
                {
                    throw new Exception("Построение 3D модели завершено с ошибкой");
                }
            }
            return result;
        }
        private void Load3DModel(string way)
        {
            var trPtArrayRead = new TriangPointArray3f();

            System.Threading.Thread.Sleep(200);
            bool result = true;
            result = System.IO.File.Exists("demo.ply");
            try
            {
                result = PLYReader.ReadBinary("demo.ply", ref trPtArrayRead);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

           // BCalculateQD.Enabled = false;
           // MeshUtils.FilterLongEdge(ref trPtArrayRead, 0.2);
            IndexTriplet indexTr = null;
            uint localMAX1 = trPtArrayRead.GetNumberOfTriangles();
            uint localMAX2 = trPtArrayRead.GetNumberOfPoints();
            IndexTriplet[] TriangleModelMass = new IndexTriplet[localMAX1];
            RGBPointOwnType[] RGBPointsMass = new RGBPointOwnType[localMAX2];
            RGBPoint3f DataPoint = new RGBPoint3f();

            for (uint i = 0; i < localMAX1; i++)
            {
                indexTr = trPtArrayRead.GetTriangle(i);
                TriangleModelMass[i] = indexTr;
            }

            for (uint i = 0; i < localMAX2; i++)
            {
                RGBPointsMass[i] = new RGBPointOwnType();
                DataPoint = trPtArrayRead.GetPoint(i);
                RGBPointsMass[i].X = DataPoint.X;
                RGBPointsMass[i].Y = DataPoint.Y;
                RGBPointsMass[i].Z = -DataPoint.Z;
                RGBPointsMass[i].R = ((double)DataPoint.R) / 255.0;
                RGBPointsMass[i].G = ((double)DataPoint.G) / 255.0;
                RGBPointsMass[i].B = ((double)DataPoint.B) / 255.0;
                sred100X += RGBPointsMass[i].X;
                sred100Y += RGBPointsMass[i].Y;
                sred100Z += RGBPointsMass[i].Z;
            }
            sred100X = sred100X / localMAX2;
            sred100Y = sred100Y / localMAX2;
            sred100Z = sred100Z / localMAX2;
            for (uint i = 0; i < localMAX2; i++)
            {
                RGBPointsMass[i].X -= sred100X;
                RGBPointsMass[i].Y -= sred100Y;
                RGBPointsMass[i].Z -= sred100Z;
            }
            Figure = new MyMesh(RGBPointsMass, TriangleModelMass);
            BindTextures();
           // NeedLoader = false; ChkBModel.Checked = true;
        }
        private int FindAnObject(float MouseX3D, int MouseY3D)
        {
            Vector3 ray_wor = GetNormalizedRayWor(MouseX3D, MouseY3D);
            Vector3 O_C = new Vector3(-BasicMesh.MoveX + CameraPosition[0],
                                      -BasicMesh.MoveY + CameraPosition[1],
                                      -BasicMesh.MoveZ + CameraPosition[2]);
            float b2 = ray_wor.X * O_C.X + ray_wor.Y * O_C.Y + ray_wor.Z * O_C.Z;
            float TR2 = BasicMesh.GetTopRadius() * BasicMesh.GetZoomFactor();
            float c2 = (float)(O_C.X * O_C.X + O_C.Y * O_C.Y + O_C.Z * O_C.Z) - TR2 * TR2;

            O_C = new Vector3(-Figure.MoveX + CameraPosition[0],
                                      -Figure.MoveY + CameraPosition[1],
                                      -Figure.MoveZ + CameraPosition[2]);

            float b = ray_wor.X * O_C.X + ray_wor.Y * O_C.Y + ray_wor.Z * O_C.Z;
            float TR = Figure.GetTopRadius() * Figure.GetZoomFactor();
            float c = (float)(O_C.X * O_C.X + O_C.Y * O_C.Y + O_C.Z * O_C.Z) - TR * TR;
            float Discr2 = b2 * b2 - c2, Discr1 = b * b - c;
            float sDiscr1 = (float)Math.Sqrt(Discr1), sDiscr2 = (float)Math.Sqrt(Discr2);
            float t1 = -b - sDiscr1, t2 = -b + sDiscr1, t3 = -b2 - sDiscr2, t4 = -b2 + sDiscr2;
            if ((Discr1 < 0) && (Discr2 < 0)) return -1;
            else if ((Discr2 >= 0) && (Discr1 >= 0))
            {
                if ((t1 < t2 ? t1 : t2) < (t3 < t4 ? t3 : t4))
                {
                    var Figu = Figure;
                    Figure.SetGrabParameters(true, t1, t2);
                    // MessageBox.Show("Найдено 2 объекта, первый(треугольник) ближе "
                    //   + Triangle.GetGrabPart().ToString());
                    remX = MouseX3D; remY = MouseY3D;
                    return 1;
                }
                else
                {
                    var Figu = BasicMesh;
                    BasicMesh.SetGrabParameters(true, t3, t4);
                    // MessageBox.Show("Найдено 2 объекта, второй(фигура) ближе "+
                    //     Figure.GetGrabPart().ToString());
                    remX = MouseX3D; remY = MouseY3D;
                    return 2;
                }
            }
            else if (b * b - c >= 0)
            {
                var Figu = Figure;
                Figure.SetGrabParameters(true, t1, t2);
                remX = MouseX3D; remY = MouseY3D;
                return 1;
            }
            else if (b2 * b2 - c2 >= 0)
            {
                var Figu = BasicMesh;
                BasicMesh.SetGrabParameters(true, t3, t4);
                remX = MouseX3D; remY = MouseY3D;
                return 2;
            }

            else return -1;
        }
        #region MatrixShit
        static void Matrix4Perspective(float[] M, float fovy, float aspect, float znear, float zfar)
        {
            float f = 1.00f / (float)Math.Tan(fovy * Math.PI / 360),//конвертация в радианы
                  A = (zfar + znear) / (znear - zfar),
                  B = (2 * zfar * znear) / (znear - zfar);

            M[0] = f / aspect; M[1] = 0; M[2] = 0; M[3] = 0;
            M[4] = 0; M[5] = f; M[6] = 0; M[7] = 0;
            M[8] = 0; M[9] = 0; M[10] = A; M[11] = B;
            M[12] = 0; M[13] = 0; M[14] = -1; M[15] = 0;
        }
        static void Matrix4Translation(float[] M, float x, float y, float z)
        {
            M[0] = 1; M[1] = 0; M[2] = 0; M[3] = x;
            M[4] = 0; M[5] = 1; M[6] = 0; M[7] = y;
            M[8] = 0; M[9] = 0; M[10] = 1; M[11] = z;
            M[12] = 0; M[13] = 0; M[14] = 0; M[15] = 1;
        }
        static void Matrix4Trans(ref float[] res, Matrix4 wM)
        {
            res[0] = wM[0, 0]; res[1] = wM[0, 1]; res[2] = wM[0, 2]; res[3] = wM[0, 3];
            res[4] = wM[1, 0]; res[5] = wM[1, 1]; res[6] = wM[1, 2]; res[7] = wM[1, 3];
            res[8] = wM[2, 0]; res[9] = wM[2, 1]; res[10] = wM[2, 2]; res[11] = wM[2, 3];
            res[12] = wM[3, 0]; res[13] = wM[3, 1]; res[14] = wM[3, 2]; res[15] = wM[3, 3];
        }
        static float[] Matrix4Trans(Matrix4 wM)
        {
            float[] res = new float[16]; Matrix4Trans(ref res, wM); return res;
        }
        static void Matrix4Mul(float[] M, float[] A, float[] B)
        {
            M[0] = A[0] * B[0] + A[1] * B[4] + A[2] * B[8] + A[3] * B[12];
            M[1] = A[0] * B[1] + A[1] * B[5] + A[2] * B[9] + A[3] * B[13];
            M[2] = A[0] * B[2] + A[1] * B[6] + A[2] * B[10] + A[3] * B[14];
            M[3] = A[0] * B[3] + A[1] * B[7] + A[2] * B[11] + A[3] * B[15];
            M[4] = A[4] * B[0] + A[5] * B[4] + A[6] * B[8] + A[7] * B[12];
            M[5] = A[4] * B[1] + A[5] * B[5] + A[6] * B[9] + A[7] * B[13];
            M[6] = A[4] * B[2] + A[5] * B[6] + A[6] * B[10] + A[7] * B[14];
            M[7] = A[4] * B[3] + A[5] * B[7] + A[6] * B[11] + A[7] * B[15];
            M[8] = A[8] * B[0] + A[9] * B[4] + A[10] * B[8] + A[11] * B[12];
            M[9] = A[8] * B[1] + A[9] * B[5] + A[10] * B[9] + A[11] * B[13];
            M[10] = A[8] * B[2] + A[9] * B[6] + A[10] * B[10] + A[11] * B[14];
            M[11] = A[8] * B[3] + A[9] * B[7] + A[10] * B[11] + A[11] * B[15];
            M[12] = A[12] * B[0] + A[13] * B[4] + A[14] * B[8] + A[15] * B[12];
            M[13] = A[12] * B[1] + A[13] * B[5] + A[14] * B[9] + A[15] * B[13];
            M[14] = A[12] * B[2] + A[13] * B[6] + A[14] * B[10] + A[15] * B[14];
            M[15] = A[12] * B[3] + A[13] * B[7] + A[14] * B[11] + A[15] * B[15];
        }
        static void Matrix4Mul(ref float[] A, float[] B)
        {
            float[] M = new float[16]; Matrix4Mul(M, A, B); A = M;
        }
        #endregion
    }
}

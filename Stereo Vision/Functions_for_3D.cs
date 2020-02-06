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
using OpenTK_3DMesh;


namespace Stereo_Vision
{
    partial class MainWindow
    {
        bool M3D_loaded = false;
        int M3D_program = 0;
        static float[] M3D_projectionMatrix_MF4 = new float[16];
        Matrix4 M3D_projectionMatrix_M4 = new Matrix4();
        static float[] M3D_dataMatrix2 = new float[16]; //used for 3D drawing, so global
        static float[] M3D_viewProjectionMatrix = new float[16];
        static float[] M3D_viewMatrix_MF4 = new float[16];
        Matrix4 M3D_viewMatrix_M4 = new Matrix4();
        static float[] M3D_dataMatrix = new float[16];
        static float[] M3D_modelMatrix = new float[16];
        static float[] M3D_modelViewProjectionMatrix = new float[16];
        static float[] M3D_CameraPosition = new float[3] { 0.0f, 0.0f, 0.0f };
        static float[] M3D_viewDirection = new float[3] { 0.0f, 0.0f, -1.0f };
        static float[] M3D_UPvector = new float[3] { 0.0f, 1.0f, 0.0f };
        bool firstfix = false;
        
        float remX = 0, remY = 0, trans = 0.05f;
        static int modelViewProjectionMatrixLocation = -1, positionLocation = -1, colorLocation = -1;
        float deltaTime = 0.002f;
        static float[] trianeMesh2 = new float[6 * 6] { /* 1 вершина, позиция: */ 0.0f, 0.0f, 0.0f, /* цвет: */ 0.0f, 1.0f, 0.0f, 
                                                                 /* 2 вершина, позиция: */ 1.0f, 0.5f, 0.0f, /* цвет: */ 0.0f, 1.0f, 0.0f, 
                                                                 /* 3 вершина, позиция: */ 1.0f, -0.5f, 0.0f, /* цвет: */ 0.0f, 0.0f, 1.0f , 
                                                                 /* 2 вершина, позиция: */ 0.0f, 0.0f, 0.0f, /* цвет: */ 0.0f, 1.0f, 0.0f, 
                                                                 /* 3 вершина, позиция: */ -1.0f, 0.5f, 0.0f, /* цвет: */ 0.0f, 0.0f, 1.0f  , 
                                                                 /* 2 вершина, позиция: */ -1.0f, -0.5f, 0.0f, /* цвет: */ 0.0f, 1.0f, 0.0f};
        MyMesh M3D_Figure = null;
        MyMesh M3D_BasicMesh = null;
        static int[] M3D_meshVAO = new int[2]; //потому что будет базово юзать 2 фигуры. На самом деле одну, поэтому посмотрим.
        static int M3D_meshVBO = 0;

        bool Allow3DInvalidate = true;

        bool MeshesFixedByEachOther = false;

        private void Models_view_init()
        {
            LoadShaders();
            LoadFigures();
            CreateBuffers();
            BindTextures();
            M3D_CreateProjectionMatrix();
            M3D_loaded = true;

            GL.ClearColor(Color.White);
            OTK_3D_Control.BackColor = Color.SkyBlue;
        }
        private void LoadShaders()
        {

            int M3D_vertex = 0;
            int M3D_fragment = 0;

            try
            {
                int length = 0;
                System.IO.StreamReader sr;
                string[] shadertext1 = new string[1], shadertext2 = new string[1];

                M3D_program = GL.CreateProgram();
                M3D_vertex = GL.CreateShader(ShaderType.VertexShader);
                M3D_fragment = GL.CreateShader(ShaderType.FragmentShader);
                //load vertex shader
                try
                {
                    using (sr = new System.IO.StreamReader("lesson.vs"))
                    {
                        shadertext1[0] = sr.ReadToEnd();
                        length = shadertext1[0].Count();
                        GL.ShaderSource(M3D_vertex, 1, shadertext1, ref length);
                        sr.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Vertex шейдер не загружен. Оригинальный текст ошибки: " +
                       e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(e.Message);
                }
                //load fragment shader
                try
                {
                    using (sr = new System.IO.StreamReader("lesson.fs"))
                    {
                        shadertext2[0] = sr.ReadToEnd();
                        length = shadertext2[0].Count();
                        GL.ShaderSource(M3D_fragment, 1, shadertext2, ref length);
                        sr.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Фрагментный шейдер не загружен. Оригинальный текст ошибки: " +
                        e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                try
                {
                    //shaders compiling
                    int datalenght = 1000, datalenght2 = 1000;
                    // StringBuilder datasbuild = new StringBuilder(1000), datasbuild2 = new StringBuilder(1000);
                    string datasbuild =""; string datasbuild2 = "";
                    GL.GetShaderSource(M3D_vertex, 1000, out datalenght, out datasbuild);
                    GL.CompileShader(M3D_vertex);

                    GL.GetShaderSource(M3D_fragment, 1000, out datalenght2, out datasbuild2);
                    GL.CompileShader(M3D_fragment);

                    //attachment and linking the program
                    GL.AttachShader(M3D_program, M3D_vertex);
                    GL.AttachShader(M3D_program, M3D_fragment);
                    GL.LinkProgram(M3D_program);

                    //checking link status
                    sr = null;
                    int link_ok;
                    GL.GetProgram(M3D_program, GetProgramParameterName.LinkStatus, out link_ok);


                    string error_log = null;
                    GL.GetProgramInfoLog(M3D_program, out error_log);
                    if (link_ok != (int)All.True) throw new Exception("Ошибка:" + error_log + "Проверочные значения: Link_ok=" +
                        link_ok + ", isTrue=" + ((int)All.True).ToString());

                    GL.UseProgram(M3D_program);
                    GL.ValidateProgram(M3D_program);
                    GL.GetProgram(M3D_program, GetProgramParameterName.ValidateStatus, out link_ok);

                    if (link_ok != (int)All.True) throw new Exception("Ошибка:" + error_log + "Проверочные значения: Link_ok=" +
                        link_ok + ", isTrue=" + ((int)All.True).ToString());
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка: " + exc.Message);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка: " + exc.Message);
            }
        }
        private void LoadFigures()
        {
            M3D_Figure = new MyMesh();
            M3D_BasicMesh = new MyMesh();
            // MyMesh.CreteCilindricMesh(out Figure, 1.5f, 360.0f, 1.0f, 0.1f, Color.FromArgb(0, 255, 0));
            // MyMesh.CreteSphereMesh(out Figure, 2.0f, 0.1f, Color.FromArgb(0, 255, 0));
            /*MyMesh.CreatePlainMesh(out M3D_BasicMesh, 2.0f, 0.09f, Color.FromArgb(0, 255, 0));
            MyMesh.CreateSphereMesh(out M3D_Figure, 2.0f, 0.1f, Color.FromArgb(0, 255, 0));*/

            M3D_BasicMesh.SetZoomFactor(1.0f);
            M3D_Figure.SetZoomFactor(1.0f);
            M3D_BasicMesh.TranslationX = 0.5f; M3D_BasicMesh.TranslationY = 0.0f; M3D_BasicMesh.TranslationZ = -5.0f;
            M3D_Figure.TranslationX = -0.5f; M3D_Figure.TranslationY = 0.0f; M3D_Figure.TranslationZ = -5.0f;

        }
        private void CreateBuffers()
        {
            GL.GenBuffers(1, out M3D_meshVBO);
            GL.GenVertexArrays(1, out M3D_meshVAO[0]);
            GL.GenVertexArrays(1, out M3D_meshVAO[1]);
        }
        private void BindTextures()
        {
            Allow3DInvalidate = false;
            int bufsize = M3D_Figure.GetBufferSize();
            GL.BindBuffer(BufferTarget.ArrayBuffer, M3D_meshVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(M3D_Figure.GetBufferSize() + M3D_BasicMesh.GetBufferSize()),
                new IntPtr(0), BufferUsageHint.StaticDraw);
            GL.BufferSubData(BufferTarget.ArrayBuffer, new IntPtr(0), new IntPtr(M3D_Figure.GetBufferSize()), M3D_Figure.GetMeshData());
            GL.BufferSubData(BufferTarget.ArrayBuffer, new IntPtr(M3D_Figure.GetBufferSize()),
                new IntPtr(M3D_BasicMesh.GetBufferSize()), M3D_BasicMesh.GetMeshData());

            positionLocation = GL.GetAttribLocation(M3D_program, "position");
            colorLocation = GL.GetAttribLocation(M3D_program, "color");
            // смещения данных внутри вершинного буфера 

            if (positionLocation == -1) positionLocation = 1;// получим индекс атрибута 'position' из шейдера 
            if (colorLocation == -1) colorLocation = 0;// получим индекс атрибута 'color' из шейдера 

            GL.BindVertexArray(M3D_meshVAO[0]);
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            GL.BindBuffer(BufferTarget.ArrayBuffer, M3D_meshVBO);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize, MyMesh.vertexOffsetPosition);
            GL.VertexAttribPointer(colorLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize, MyMesh.vertexOffsetColor);

            GL.BindVertexArray(M3D_meshVAO[1]);
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            GL.BindBuffer(BufferTarget.ArrayBuffer, M3D_meshVBO);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize,
                M3D_Figure.GetBufferSize() + MyMesh.vertexOffsetPosition);
            GL.VertexAttribPointer(colorLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize,
                M3D_Figure.GetBufferSize() + MyMesh.vertexOffsetColor);

            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize, MyMesh.vertexOffsetPosition);
            GL.VertexAttribPointer(colorLocation, 3, VertexAttribPointerType.Float, false, MyMesh.vertexSize, MyMesh.vertexOffsetColor);
            /*  BasicMesh.MoveZ = -(TrBZModifier.Value / 100.0f);
              Figure.MoveZ = -(TrBZModifier.Value / 100.0f);*/
            /*M3D_Figure.TranslationZ = -(20 / 100.0f);
            M3D_BasicMesh.TranslationZ = -(20 / 100.0f);*/

            M3D_Figure.TranslationZ = 0;
            M3D_BasicMesh.TranslationZ = 0;

            Allow3DInvalidate = true;
        }
        private void M3D_CreateProjectionMatrix()
        {// создадим перспективную матрицу проекции 
            float aspectRatio = (float)OTK_3D_Control.Width / (float)OTK_3D_Control.Height;
            MF4_PerspectiveMatrix_Create(M3D_projectionMatrix_MF4, 60.0f, aspectRatio, 0.1f, 200.0f);//перспектива 

            M3D_viewMatrix_MF4 = M4_to_MF4(Matrix4.LookAt
            (new Vector3(M3D_CameraPosition[0], M3D_CameraPosition[1], M3D_CameraPosition[2]),
            new Vector3(  /*CameraPosition[0] + */M3D_viewDirection[0],
                        /*CameraPosition[1] + */M3D_viewDirection[1],
                        /*CameraPosition[2] +*/ M3D_viewDirection[2]),
            new Vector3(M3D_UPvector[0], M3D_UPvector[1], M3D_UPvector[2]))); //мировая матрица - зависимость от точки обзора

            MF4_Multiply(M3D_viewProjectionMatrix, M3D_projectionMatrix_MF4, M3D_viewMatrix_MF4);// совместим матрицу проекции и матрицу наблюдателя 

            M3D_projectionMatrix_M4 = MF4_to_M4(M3D_projectionMatrix_MF4);

            float[] viewMatrixFF = M4_to_MF4(Matrix4.LookAt
             (new Vector3(M3D_CameraPosition[0], M3D_CameraPosition[1], M3D_CameraPosition[2]),
              new Vector3(-M3D_viewDirection[0], -M3D_viewDirection[1], M3D_viewDirection[2]),
              new Vector3(M3D_UPvector[0], M3D_UPvector[1], M3D_UPvector[2])));

            M3D_viewMatrix_M4 = MF4_to_M4(viewMatrixFF);

        }
        private Vector3 GetNormalizedRayWor(float MouseX3D, int MouseY3D)
        {
            float x = (2.0f * MouseX3D) / OTK_3D_Control.Width - 1.0f;
            float y = 1.0f - (2.0f * MouseY3D) / OTK_3D_Control.Height;
            float z = 1.0f;
            Vector3 ray_nds = new Vector3(x, y, z);
            Vector4 ray_clip = new Vector4(ray_nds.X, ray_nds.Y, -1.0f, 1.0f);
            Vector4 ray_eye = Vector4.Transform(ray_clip, M3D_projectionMatrix_M4);
            ray_eye = new Vector4(ray_eye.X, ray_eye.Y, -1.0f, 0.0f);
            return Vector3.Normalize(new Vector3(Vector4.Transform(ray_eye, M3D_viewMatrix_M4)));
        }
        private void Draw_3D_graphics()
        {
            if (Allow3DInvalidate)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.Enable(EnableCap.DepthTest);//убирает херню с наложением 3D моделей
                GL.Viewport(0, 0, OTK_3D_Control.Width, OTK_3D_Control.Height);
                GL.EnableClientState(ArrayCap.VertexArray);
                GL.UseProgram(M3D_program);


                Matrix4 xr, yr, zr;
                M3D_dataMatrix2 = MF4_TranslationMatrix_Create(M3D_BasicMesh.TranslationX, M3D_BasicMesh.TranslationY, M3D_BasicMesh.TranslationZ);//перенос        

                xr = Matrix4.CreateRotationX(MyMesh.RevertAngle(M3D_BasicMesh.GetElementRotationX()));
                yr = Matrix4.CreateRotationY(MyMesh.RevertAngle(M3D_BasicMesh.GetElementRotationY()));
                zr = Matrix4.CreateRotationZ(MyMesh.RevertAngle(M3D_BasicMesh.GetElementRotationZ()));
                var M4_rotation = zr * yr * xr;
                MF4_Multiply(ref M3D_dataMatrix2, M4_to_MF4(M4_rotation)); // поворот

                float zf = M3D_BasicMesh.GetZoomFactor();


                MF4_Multiply(ref M3D_dataMatrix2, M4_to_MF4(Matrix4.CreateScale(zf, zf, zf))); // увеличение
                MF4_Multiply(M3D_modelViewProjectionMatrix, M3D_viewProjectionMatrix, M3D_dataMatrix2); //матрица проекций

                modelViewProjectionMatrixLocation = GL.GetUniformLocation(M3D_program, "modelViewProjectionMatrix");
                //отрисовка опорной модели
                GL.UniformMatrix4(modelViewProjectionMatrixLocation, 1, Convert.ToBoolean(All.True), M3D_modelViewProjectionMatrix);
                //отрисовывает все(что касается опорной фигуры), что в буфере , начиная со следующей вершины после окончания вершин Figure
                GL.DrawArrays(PrimitiveType.LineStrip, M3D_Figure.GetNumberOfVertices(), M3D_BasicMesh.GetNumberOfVertices() - M3D_BasicMesh.GetAxisVertexCount());
                GL.PointSize(2.0f);
                //отрисовывает саму ось
                GL.DrawArrays(PrimitiveType.Points, M3D_Figure.GetNumberOfVertices() + M3D_BasicMesh.GetNumberOfVertices() - M3D_BasicMesh.GetAxisVertexCount(), M3D_BasicMesh.GetAxisVertexCount());

                
                if (!MeshesFixedByEachOther)
                {
                    if (M3D_Figure.IsRecalculated)
                    {
                        M3D_dataMatrix2 = MF4_TranslationMatrix_Create(M3D_Figure.TranslationX, M3D_Figure.TranslationY, M3D_Figure.TranslationZ);//перенос
                    }
                }
                else
                {
                    //В поворот построенной модели записываем поворот опорной
                    M3D_Figure.SetGetElementRotation(M3D_BasicMesh.GetElementRotation(0), 0);
                    M3D_Figure.SetGetElementRotation(M3D_BasicMesh.GetElementRotation(1), 1);
                    M3D_Figure.SetGetElementRotation(M3D_BasicMesh.GetElementRotation(2), 2);
                    M3D_dataMatrix2 = MF4_TranslationMatrix_Create(M3D_BasicMesh.TranslationX, M3D_BasicMesh.TranslationY, M3D_BasicMesh.TranslationZ);//перенос  
                }

                //отрисовка самой модели
                xr = Matrix4.CreateRotationX(MyMesh.RevertAngle(M3D_Figure.GetElementRotationX()));
                yr = Matrix4.CreateRotationY(MyMesh.RevertAngle(M3D_Figure.GetElementRotationY()));
                zr = Matrix4.CreateRotationZ(MyMesh.RevertAngle(M3D_Figure.GetElementRotationZ()));

                MF4_Multiply(ref M3D_dataMatrix2, M4_to_MF4(zr * yr * xr)); //поворот

                zf = M3D_Figure.GetZoomFactor();
                MF4_Multiply(ref M3D_dataMatrix2, M4_to_MF4(Matrix4.CreateScale(zf, zf, zf))); // увеличение
                MF4_Multiply(M3D_modelViewProjectionMatrix, M3D_viewProjectionMatrix, M3D_dataMatrix2); //матрица проекций

                modelViewProjectionMatrixLocation = GL.GetUniformLocation(M3D_program, "modelViewProjectionMatrix");
                GL.UniformMatrix4(modelViewProjectionMatrixLocation, 1, Convert.ToBoolean(All.True), M3D_modelViewProjectionMatrix);
                if (M3D_Figure.GetTypeID() != 4) // если не измерения
                    //посколько Figure находится в конце буфера, рисуем буфер до конца 
                    GL.DrawArrays(PrimitiveType.Triangles, 0, M3D_Figure.GetNumberOfVertices());

              /*  else //а если измерения...//Это отрисовка измерений. Надо переписать под чистую
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
            if (bw == null)
            {
                bw = new System.ComponentModel.BackgroundWorker();
                bw.RunWorkerAsync();
            }
            LogMessage("Начало построения 3D...");      
            bool bDenseStereoCorrTestPassed = true;
            ICameraPair stereoPair = null;
            Bitmap img = null;
            IStereoDenseEstimator stereoEstimator = null;
            System.Drawing.Imaging.PixelFormat PxForm = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
            var trPtArray = new TriangPointArray3f();
            IndexTriplet[] TriangleModelMass;
            RGBPointOwnType[] RGBPointsMass;
            //string cfgFilePath = IsPrism ? "M5_chess_shiftM11.xml": "M1_chess.xml";
            //string cfgFilePath = IsPrism ? "M5_chess.xml" : "M1_chess.xml";
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
                { stereoPair = XMLLoader.ReadCameraPair(XMLCalib_path); }
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
                    LogMessage("Загрузка файла stereo_params_new.xml");
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
                        var zPlane = new Plane3d(new Point3d(0.0, 0.0, 1.0), -17.0);
                        stereoEstimator = StereoDenseCorrFactory.GetPrismRectifStereoDenseEstimator(stereoPair, rectROI1, rectROI2, zPlane);
                    }
                    else
                    {
                        stereoEstimator = StereoDenseCorrFactory.GetProjRectifStereoDenseEstimator(stereoPair, rectROI1, rectROI2);
                    }
                    // Load parameters from file
                    bDenseStereoCorrTestPassed = bDenseStereoCorrTestPassed && stereoEstimator.ReadParam("stereo_params_new.xml");
                    // Set distance range (mm)
                    //  stereoEstimator.SetZDiap(5.0, 15.00);//17+-
                    stereoEstimator.SetZDiap(10.0, 70.00);//17+-
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
                    MeshUtils.FilterLongEdge(ref trPtArray, 0.2);
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
                        MyMesh data;
                        MyMesh.CreateCilindricMesh(out data, 1.5f, 360.0f, 1.0f, 0.1f, Color.FromArgb(0, 255, 0));

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
                        CalculatenName_forNewPhoto_withoutPath();
                        string FileName = CalculatenName_forNewModel();
                        string FullPath = System.IO.Path.Combine(Rec_Models_path, FileName);
                        PLYWriter.SaveBinary(FullPath, trPtArray);
                        Model_name_lastbuild_fullpath = FullPath;
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
            result = System.IO.File.Exists(way);
            try
            {
                result = PLYReader.ReadBinary(way, ref trPtArrayRead);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

           // BCalculateQD.Enabled = false;
            MeshUtils.FilterLongEdge(ref trPtArrayRead, 0.2);
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
            M3D_Figure = new MyMesh(RGBPointsMass, TriangleModelMass);
            BindTextures();
           // NeedLoader = false; ChkBModel.Checked = true;
        }
        private int FindAnObject(float MouseX3D, int MouseY3D)
        {
            bool mB_isNull = (M3D_BasicMesh.GetTypeID() == 5);
            bool mF_isNull = (M3D_Figure.GetTypeID() == 5);
            Vector3 ray_wor = GetNormalizedRayWor(MouseX3D, MouseY3D);
            Vector3 OC_mB = new Vector3(-M3D_BasicMesh.TranslationX + M3D_CameraPosition[0],
                                      -M3D_BasicMesh.TranslationY + M3D_CameraPosition[1],
                                      -M3D_BasicMesh.TranslationZ + M3D_CameraPosition[2]);
            float M_Basic_b = ray_wor.X * OC_mB.X + ray_wor.Y * OC_mB.Y + ray_wor.Z * OC_mB.Z;
            float M_Basic_TR = M3D_BasicMesh.GetTopRadius() * M3D_BasicMesh.GetZoomFactor();
            float M_Basic_c = (float)(OC_mB.X * OC_mB.X + OC_mB.Y * OC_mB.Y + OC_mB.Z * OC_mB.Z) - M_Basic_TR * M_Basic_TR;

            Vector3 OC_mF = new Vector3(-M3D_Figure.TranslationX + M3D_CameraPosition[0],
                                       -M3D_Figure.TranslationY + M3D_CameraPosition[1],
                                       -M3D_Figure.TranslationZ + M3D_CameraPosition[2]);
            float M_Figure_b = ray_wor.X * OC_mF.X + ray_wor.Y * OC_mF.Y + ray_wor.Z * OC_mF.Z;
            float M_Figure_TR = M3D_Figure.GetTopRadius() * M3D_Figure.GetZoomFactor() /5.0f; //top radius
            float M_Figure_c = (float)(OC_mF.X * OC_mF.X + OC_mF.Y * OC_mF.Y + OC_mF.Z * OC_mF.Z) - M_Figure_TR * M_Figure_TR;

            float M_Basic_Discr = M_Basic_b * M_Basic_b - M_Basic_c;
            float M_Basic_sD = (float)Math.Sqrt(M_Basic_Discr);

            float M_Figure_Discr = M_Figure_b * M_Figure_b - M_Figure_c;
            float M_Figure_sD = (float)Math.Sqrt(M_Figure_Discr);

            float t1 = -M_Figure_b - M_Figure_sD, t2 = -M_Figure_b + M_Figure_sD; 
            
            float t3 = -M_Basic_b - M_Basic_sD, t4 = -M_Basic_b + M_Basic_sD;

            if (((M_Figure_Discr < 0) && (M_Basic_Discr < 0))||((mB_isNull)&&(mF_isNull))) return -1; //Пересечений не найдено

            else if ((M_Basic_Discr >= 0) && (M_Figure_Discr >= 0) && (!mB_isNull) && (!mF_isNull))
            {
                if ((t1 < t2 ? t1 : t2) < (t3 < t4 ? t3 : t4))
                {
                    var Figu = M3D_Figure;
                    M3D_Figure.SetGrabParameters(true, t1, t2);
                    // MessageBox.Show("Найдено 2 объекта, первый(треугольник) ближе "
                    //   + Triangle.GetGrabPart().ToString());
                    remX = MouseX3D; remY = MouseY3D;
                    return 1;
                }
                else
                {
                    var Figu = M3D_BasicMesh;
                    M3D_BasicMesh.SetGrabParameters(true, t3, t4);
                    // MessageBox.Show("Найдено 2 объекта, второй(фигура) ближе "+
                    //     Figure.GetGrabPart().ToString());
                    remX = MouseX3D; remY = MouseY3D;
                    return 2;
                }
            }
            else if ((M_Figure_Discr >= 0)&&(!mF_isNull))
            {
                var Figu = M3D_Figure;
                M3D_Figure.SetGrabParameters(true, t1, t2);
                remX = MouseX3D; remY = MouseY3D;
                return 1;
            }
            else if ((M_Basic_Discr >= 0)&&(!mB_isNull))
            {
                var Figu = M3D_BasicMesh;
                M3D_BasicMesh.SetGrabParameters(true, t3, t4);
                remX = MouseX3D; remY = MouseY3D;
                return 2;
            }

            else return -1;
        }
        #region MatrixShit
        static void MF4_PerspectiveMatrix_Create(float[] M, float fovy, float aspect, float znear, float zfar)
        {
            float f = 1.00f / (float)Math.Tan(fovy * Math.PI / 360),//конвертация в радианы
                  A = (zfar + znear) / (znear - zfar),
                  B = (2 * zfar * znear) / (znear - zfar);

            M[0] = f / aspect; M[1] = 0; M[2] = 0; M[3] = 0;
            M[4] = 0; M[5] = f; M[6] = 0; M[7] = 0;
            M[8] = 0; M[9] = 0; M[10] = A; M[11] = B;
            M[12] = 0; M[13] = 0; M[14] = -1; M[15] = 0;
        }
        static float[] MF4_TranslationMatrix_Create(float x, float y, float z)
        {
            float[] M = new float[16];
            M[0] = 1; M[1] = 0; M[2] = 0; M[3] = x;
            M[4] = 0; M[5] = 1; M[6] = 0; M[7] = y;
            M[8] = 0; M[9] = 0; M[10] = 1; M[11] = z;
            M[12] = 0; M[13] = 0; M[14] = 0; M[15] = 1;
            return M;
        }
        static void M4_to_MF4(ref float[] res, Matrix4 pM4)
        {
            res[0] = pM4[0, 0]; res[1] = pM4[0, 1]; res[2] = pM4[0, 2]; res[3] = pM4[0, 3];
            res[4] = pM4[1, 0]; res[5] = pM4[1, 1]; res[6] = pM4[1, 2]; res[7] = pM4[1, 3];
            res[8] = pM4[2, 0]; res[9] = pM4[2, 1]; res[10] = pM4[2, 2]; res[11] = pM4[2, 3];
            res[12] = pM4[3, 0]; res[13] = pM4[3, 1]; res[14] = pM4[3, 2]; res[15] = pM4[3, 3];
        }
        static float[] M4_to_MF4(Matrix4 pM4)
        {
            float[] res = new float[16]; M4_to_MF4(ref res, pM4); return res;
        }
        static Matrix4 MF4_to_M4(float[] pFloat_Matrix_4x4)
        {
            return Matrix4.Invert(new Matrix4(
                    pFloat_Matrix_4x4[0],  pFloat_Matrix_4x4[1],  pFloat_Matrix_4x4[2],  pFloat_Matrix_4x4[3],
                    pFloat_Matrix_4x4[4],  pFloat_Matrix_4x4[5],  pFloat_Matrix_4x4[6],  pFloat_Matrix_4x4[7],
                    pFloat_Matrix_4x4[8],  pFloat_Matrix_4x4[9],  pFloat_Matrix_4x4[10], pFloat_Matrix_4x4[11],
                    pFloat_Matrix_4x4[12], pFloat_Matrix_4x4[13], pFloat_Matrix_4x4[14], pFloat_Matrix_4x4[15]));
        }
        static void MF4_Multiply(float[] M, float[] A, float[] B)
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
        static void MF4_Multiply(ref float[] A, float[] B)
        {
            float[] M = new float[16]; MF4_Multiply(M, A, B); A = M;
        }
        #endregion
    }
}

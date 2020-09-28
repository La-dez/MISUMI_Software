using System;
//using OSGeo.GDAL;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Linq;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;


namespace Stereo_Vision
{
    public unsafe class WhiteBalance
    {

        private double percentForBalance = 0.6;
        const byte BYTE_MAX = (byte)255;
        const double DOUBLE_BYTE_MAX = 255.0;
        

        [DllImport("Multiply_BMP_DLL.dll")]
        public static extern System.Text.StringBuilder EI_GetName();

        public static void InitializeMatrix(dynamic value, ref double[,,] M, int iM, int jM, int kM)
        {
            M = new double[iM, jM, kM];
            try
            {
                for (int i = 0; i < iM; i++)
                    for (int j = 0; j < jM; j++)
                        for (int k = 0; k < kM; k++)
                            M[i, j, k] = (double)value;
            }
            catch { throw new Exception("Ошибка инициализации матрицы значением " + value.ToString()); }
        }
        public static double FindMax(double[,,] M, int iM, int jM, int kM)
        {
            double result = M[0, 0, 0];
            try
            {
                for (int i = 0; i < iM; i++)
                    for (int j = 0; j < jM; j++)
                        for (int k = 0; k < kM; k++)
                        {
                            result = result < M[i, j, k] ? M[i, j, k] : result;
                        }
                return result;
            }
            catch { return 1; }
        }
        public int[] WhiteBalanceBand(int[] band)
        {
            int[] sortedBand = new int[band.Length];
            Array.Copy(band, sortedBand, band.Length);
            Array.Sort(sortedBand);

            double perc05 = Percentile(sortedBand, percentForBalance);
            double perc95 = Percentile(sortedBand, 100.0 - percentForBalance);

            int[] bandBalanced = new int[band.Length];

            for (int i = 0; i < band.Length; i++)
            {

                double valueBalanced = (band[i] - perc05) * 255.0 / (perc95 - perc05);
                bandBalanced[i] = LimitToByte(valueBalanced);
            }

            return bandBalanced;
        }

        public double Percentile(int[] sequence, double percentile)
        {

            int nSequence = sequence.Length;
            double nPercent = (nSequence + 1) * percentile / 100d;
            if (nPercent == 1d)
            {
                return sequence[0];
            }
            else if (nPercent == nSequence)
            {
                return sequence[nSequence - 1];
            }
            else
            {
                int intNPercent = (int)nPercent;
                double d = nPercent - intNPercent;
                return sequence[intNPercent - 1] + d * (sequence[intNPercent] - sequence[intNPercent - 1]);
            }
        }

        private static byte LimitToByte(double value)
        {
            return (byte)value;
            //return (byte)(((value > 255) ? DOUBLE_BYTE_MAX : value)); //не рассматривается случай с 0, так как этого не бывает
        }
        private unsafe static byte LimitToByte(double* value)
        {
            return (byte)(*value);
           // return (byte)(((*value > DOUBLE_BYTE_MAX) ? DOUBLE_BYTE_MAX : *value)); //не рассматривается случай с 0, так как этого не бывает
        }
        /**
      * Returns the band for an color (red, green, blue or alpha)
      * The dataset should have 4 bands
      * */
        /*  public static Band GetBand(Dataset ImageDataSet, ColorInterp colorInterp)
          {
              if (colorInterp.Equals(ImageDataSet.GetRasterBand(1).GetRasterColorInterpretation()))
              {
                  return ImageDataSet.GetRasterBand(1);
              }
              else if (colorInterp.Equals(ImageDataSet.GetRasterBand(2).GetRasterColorInterpretation()))
              {
                  return ImageDataSet.GetRasterBand(2);
              }
              else if (colorInterp.Equals(ImageDataSet.GetRasterBand(3).GetRasterColorInterpretation()))
              {
                  return ImageDataSet.GetRasterBand(3);
              }
              else
              {
                  return ImageDataSet.GetRasterBand(4);
              }
          }*/

        public static double[,,] GetCorrectionMatrixFromWhiteImage(Bitmap BMP)
        {
            int W = BMP.Width, H = BMP.Height;
            Color datacol; double sred=0;
            double[,,] ResMas = new double[W,H,3];
            for (int i = 0; i < W; i++)
                for (int j = 0; j < H; j++)
                {
                    ResMas[i, j, 0] = 0;
                    ResMas[i, j, 1] = 0;
                    ResMas[i, j, 2] = 0;
                    try { datacol = BMP.GetPixel(i, j); }
                    catch (Exception e) { datacol = Color.FromArgb(125, 125, 125);/*LogError(e.Message);*/ }
                    sred = Math.Min((Math.Min(datacol.R, datacol.G)),datacol.B);//была по среднему, стала по минимуму //(datacol.R + datacol.G + datacol.B) / 3.0;
                    ResMas[i, j, 0] = sred / datacol.R;
                    ResMas[i, j, 1] = sred / datacol.G;
                    ResMas[i, j, 2] = sred / datacol.B;
                }
            return ResMas;
        }
        public unsafe static double[,,] GetCorrectionMatrixFromWhiteImage_Fast(Bitmap bmp)
        {
            int width = bmp.Width,
                height = bmp.Height;
            double sred = 0;
            double[,,] res = new double[width, height, 3];
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);
            try
            {
                byte* curpos;
                for (int h = 0; h < height; h++)
                {
                    curpos = ((byte*)bd.Scan0) + h * bd.Stride;
                    for (int w = 0; w < width; w++)
                    {
                        res[w, h, 2] = *(curpos++);
                        res[w, h, 1] = *(curpos++);
                        res[w, h, 0] = *(curpos++);
                        sred = TripleMin(res[w, h, 2], res[w, h, 1], res[w, h, 0]);
                        res[w, h, 2] = sred / res[w, h, 2];
                        res[w, h, 1] = sred / res[w, h, 1];
                        res[w, h, 0] = sred / res[w, h, 0];
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
            return res;
        }
       
        public unsafe static double[,,] GetCorrectionMatrixFromWhiteImage_Fastest_Mine(Bitmap bmp)
        {
            int width = bmp.Width, height = bmp.Height, WH = width * height;
            double[,,] res = new double[width, height, 3]; double* sred = (double*)0;
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);
            try
            {
                byte* curpos;
                fixed (double* _res = res)
                {
                    byte* startpix = ((byte*)bd.Scan0);
                    double* _r = _res, _g = _res + 1, _b = _res + 2;
                    for (int h = 0; h < height; h++)
                    {
                        curpos = startpix + h * bd.Stride;
                        for (int w = 0; w < width; w++)
                        {
                            *_b = *(curpos++); 
                            *_g = *(curpos++); 
                            *_r = *(curpos++); 
                            sred = TripleMin(_b, _g, _r);
                            *_b = *sred / *_b; _b += 3;
                            *_g = *sred / *_g; _g += 3;
                            *_r = *sred / *_r; _r += 3;

                        }
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
          /*  double[] b31 = new double[3]; b31[0] = res[1, 1000, 0]; b31[1] = res[1, 1000, 1]; b31[2] = res[1, 1000, 2];
            double[] b32 = new double[3]; b32[0] = res[1919, 1079, 0]; b32[1]= res[1919, 1079, 1]; b32[2] = res[1919, 1079, 2];
            double[] b34 = new double[3]; b34[0] = bmp.GetPixel(1919,1079).R; b34[0]= bmp.GetPixel(1919, 1079).G; b34[2] = bmp.GetPixel(1919, 1079).B;
            double[] b33 = new double[3]; b33[0] = res[1919, 1078, 0]; b33[1] = res[1919, 1078, 1]; b33[2] = res[1919, 1078, 2];*/
            return res;
        }
        public static void Convert_CorM2BMP(double[,,] CM, ref Bitmap pBMP)
        {
            int W = pBMP.Width, H = pBMP.Height;
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    try
                    {
                        pBMP.SetPixel(i, j, Color.FromArgb(LimitToByte(255 * CM[i, j, 0]),
                                                           LimitToByte(255 * CM[i, j, 1]),
                                                            LimitToByte(255 * CM[i, j, 2])));

                    }
                    catch (Exception e)
                    {
                        pBMP.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }
        }
        public static T[] Convert_mass_to_linear<T>(T[,,] mass)
        {
            Int64 l1 = mass.GetLength(0);
            Int64 l2 = mass.GetLength(1);
            Int64 l3 = mass.GetLength(2);

            T[] result = new T[l1*l2*l3];
            T[,] data = new T[l1*l3,l2];

            //3 dimensional -> 2 dimensional
            for(int i =0;i<l1;i++)
            {
                for(int j=0;j<l2;j++)
                {
                    for (int k = 0; k < l3; k++)
                        data[i + k * l1, j] = mass[i, j, k];
                }
            }
            //2 dimensional - > 1 dimensional
            Buffer.BlockCopy(data, 0, result, 0, data.Length* sizeof(double)); //[4,3] => [1,12] = [12]

            return result;
        }
        public static T[,,] Convert_mass_to_3DM<T>(T[] linear,Int64 l1,Int64 l2, Int64 l3)
        {
            T[,,] result = new T[l1,l2,l3];
            T[,] data = new T[l1 * l3, l2];

            //1 dimensional - > 2 dimensional
            for (int i = 0; i < l1*l3; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    data[i, j] = linear[i*l2 + j];
                }
            }

            //2 dimensional -> 3 dimensional
            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    for (int k = 0; k < l3; k++)
                        result[i, j, k] = data[i + k * l1, j];
                }
            }
            return result;
        }
        public static void Save_Correction_Matrix(string FilePath, double[,,] array)
        {
            //запоминаем размерности
            Int64 l1 = array.GetLength(0);
            Int64 l2 = array.GetLength(1);
            Int64 l3 = array.GetLength(2);
            //конвертим в линейный
            var linear = Convert_mass_to_linear(array);
            //дописываем размерности в конце и конвертим в массив double 
            List<double> DoubleList = linear.ToList();
            DoubleList.Add(l1);
            DoubleList.Add(l2);
            DoubleList.Add(l3);           
            List<string> finalList = new List<string>();
            foreach (double element in DoubleList)
            {
                finalList.Add(element.ToString());
            }
            //пишем
            LDZ_code.MiniHelp.Files.Write_txt(FilePath, finalList);
        }
        public static void Read_Correction_Matrix(string FilePath,out double[,,] array)
        {
            //читаем
            var ListfromDisk = LDZ_code.MiniHelp.Files.Read_txt(FilePath);
            List<double> LinearList = new List<double>();
            //читаем лист с диска, конвертируя в double
            double data = 0;
            foreach (string element in ListfromDisk)
            {               
                double.TryParse((element.Replace(',', '.')), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out data);
                LinearList.Add(data);
            }
            //запоминаем размерности и удаляем ненужные данные
            Int64 l1 = Convert.ToInt64(LinearList[LinearList.Count - 3]);
            Int64 l2 = Convert.ToInt64(LinearList[LinearList.Count - 2]);
            Int64 l3 = Convert.ToInt64(LinearList[LinearList.Count - 1]);
            LinearList.RemoveRange(LinearList.Count - 3, 3);
            //конвертим в массив нужной размерности
            array = Convert_mass_to_3DM(LinearList.ToArray(), l1, l2, l3);
        }
        public static bool Test_RW_ofCorrMatrix()
        {
            double[,,] data_test = new double[4, 2, 3]
                                   {
                                        {  {1,2,3 },  {4,5,6 } },
                                        {  {7,8,9 },  {10,11,12 } },
                                        {  {13,14,15 },  {16,17,18 } },
                                        {  {19,20,21 },  {22,23,24 } }
                                   };
            Save_Correction_Matrix("CorMatrix.cm",data_test);

            double[,,] resultmass;
            Read_Correction_Matrix("CorMatrix.cm",out resultmass);
            return (CompareMassives(data_test, resultmass) == "true");


        }
        public static bool Test_convertion_3dm_2_1dm()
        {
            bool testpassed = true;
            double[,,] data_test = new double[4, 2, 3]
                                   {
                                        {  {1,2,3 },  {4,5,6 } },
                                        {  {7,8,9 },  {10,11,12 } },
                                        {  {13,14,15 },  {16,17,18 } },
                                        {  {19,20,21 },  {22,23,24 } }
                                   };


            var a = WhiteBalance.Convert_mass_to_linear<double>(data_test);
            var b = WhiteBalance.Convert_mass_to_3DM<double>(a, 4, 2, 3);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 3; k++)
                        testpassed = testpassed && (data_test[i, j, k] == b[i, j, k]);
                }
            }
            return testpassed;
        }

        public static string CompareMassives(Bitmap bmp, double[,,] m1, double[,,] m2)
        {
            string res = "true";
            int width = bmp.Width, height = bmp.Height;
            for (int i=0;i< width;i++)
                for(int j=0;j<height;j++)
                    for(int k =0;k<3;k++)
                    {
                        if (m1[i, j, k] != m2[i, j, k])
                        { res = string.Format("false. Index:{0},{1},{2}",i,j,k); return res; } 
                    }
            return res;
        }
        public static string CompareMassives(double[,,] m1, double[,,] m2)
        {
            string res = "true";
            int d3 = m1.GetLength(2);
            int d1 = m1.GetLength(0), d2 = m1.GetLength(1);
            for (int i = 0; i < d1; i++)
                for (int j = 0; j < d2; j++)
                    for (int k = 0; k < d3; k++)
                    {
                        if (m1[i, j, k] != m2[i, j, k])
                        { res = string.Format("false. Index:{0},{1},{2}", i, j, k); return res; }
                    }
            return res;
        }
        public static string CompareMassives_special(double[,,] m1, double[,,] m2)
        {
            string res = "true";
            int d3 = m1.GetLength(2);
            int d1 = m1.GetLength(0), d2 = m1.GetLength(1);
            for (int i = 0; i < d1; i++)
                for (int j = 0; j < d2; j++)
                    for (int k = 0; k < d3; k++)
                    {
                        if (m1[i, j, k] != m2[k, j, i])
                        { res = string.Format("false. Index:{0},{1},{2}", i, j, k); return res; }
                    }
            return res;
        }
        public static unsafe void CorrectBMP_viaCorrectionMatrix(double[,,] res, ref Bitmap bmp)
        {
            int width = bmp.Width, height = bmp.Height, WH = width * height;
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            try
            {
                byte* curpos;
                fixed (double* _res = res)
                {
                    byte* startpix = (byte*)bd.Scan0;
                    double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                    for (int h = 0; h < height; h++)
                    {
                        curpos = startpix + h * bd.Stride;
                        for (int w = 0; w < width; w++)
                        {
                            *(curpos) = (byte)((*(curpos)) * (*_b)); curpos++; ++_b;
                            *(curpos) = (byte)((*(curpos)) * (*_g)); curpos++; ++_g;
                            *(curpos) = (byte)((*(curpos)) * (*_r)); curpos++; ++_r;
                        }
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
          //  double[] b32 = new double[3]; b32[0] = res[0, 1000, 1]; b32[1] = res[1, 1000, 1]; b32[2] = res[2, 1000, 1];
        }
        private unsafe static double* TripleMin(double* a, double* b, double* c)
        {
            double d = ((*(a) < *(b)) ? *(a) : *(b));
            return (d < *(c)) ? &d : c;
        }
        private unsafe static double TripleMin(double a, double b, double c)
        {
            double d = ((a < b) ? a : b);
            return (d < c) ? d : c;
        }
        private unsafe static double TripleMax(double a, double b, double c)
        {
            double d = ((a > b) ? a : b);
            return (d > c) ? d : c;
        }
        private unsafe static double TripleMax(double* a, double* b, double* c)
        {
            double d = ((*(a) > *(b)) ? *(a) : *(b));
            return (d > *(c)) ? d : *c;
        }
        public unsafe static double[,,] CorrectionMatrix_FromWhiteImage_Fastest(Bitmap bmp,double CPower)
        {
            int width = bmp.Width, height = bmp.Height, WH = width * height;
            double[,,] res = new double[3, height, width]; double sred = 0.0;
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);
          /*  double Minimum = 0;
            double Maximum = 0;
            double CurMaximum = 0;*/
            try
            {
                byte* curpos;
                fixed (double* _res = res)
                {
                    byte* startpix = (byte*)bd.Scan0;
                    double RevCPower = 1 - CPower;
                    double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                    for (int h = 0; h < height; h++)
                    {
                        curpos = startpix + h * bd.Stride;
                        for (int w = 0; w < width; w++)
                        {
                            *_b = *(curpos++);
                            *_g = *(curpos++);
                            *_r = *(curpos++);
                             // sred = TripleMin(_b, _g, _r);
                            sred = (((*_b)+(*_g)+(*_r))/ 3.0);
                            *_b = RevCPower + CPower*(sred / (*_b+1));  // Самая упрощенная интерпритация выражения
                            *_g = RevCPower + CPower *(sred / (*_g+1)); //(sred / (*_b+1)) + (1-(sred / (*_b+1)))*(1-CPower)
                            *_r = RevCPower + CPower * (sred / (*_r+1)); 
                            
                         /*   CurMaximum = TripleMax(_b, _g, _r);
                            if (CurMaximum > Maximum)
                                Maximum = CurMaximum;*/
                            ++_b; ++_g; ++_r;
                            // *_b = *sred / *_b; 
                        }
                    }
                    //if (Maximum > 3) Maximum = 1.1;
                  /*  for (int h = 0; h < height; h++)
                    {
                        for (int w = 0; w < width; w++)
                        {
                            res[0, h, w] /= Maximum;
                            res[1, h, w] /= Maximum;
                            res[2, h, w] /= Maximum;
                        }
                    }*/
                }
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
 //           double[] b32 = new double[3]; b32[0] = res[0, 0, 0]; b32[1] = res[1, 0, 0]; b32[2] = res[2, 0,0];
            return res;
        }
        public static unsafe void CorrectImage_viaCorrectionMatrix_Color(double[,,] res, ref Mat pframe)
        {
           // System.Diagnostics.Stopwatch STW = new System.Diagnostics.Stopwatch();
            byte* curpos;

           // STW.Restart();
            byte[,,] data = pframe.ToImage<Bgr, Byte>().Data;
           // STW.Stop();
           // var aa = STW.Elapsed.TotalMilliseconds;

           // STW.Restart();
            int height = pframe.Height;
            int width = pframe.Width;
            int WH = width * height;
          //  STW.Stop();
           // var b = STW.Elapsed.TotalMilliseconds;
          /*  double dval = 0;
            double* _pdval = &dval;
            double DBM = 255.0;
            double* _DBM = &DBM;*/

          //  STW.Restart();
            try
            {
                fixed (double* _res = res)
                {
                    fixed (byte* pData = data)
                    {
                        curpos = pData;
                        double* _r = _res, _g = _res + WH, _b = _res + 2*WH;
                        for (int i = 0; i < WH; i++)
                        {
                           /* *(_pdval) = *(curpos) * (*_b++); *(curpos) = (byte)((*(_pdval)> *_DBM) ? *_DBM : *(_pdval)); curpos++; //fastest
                            *(_pdval) = *(curpos) * (*_g++); *(curpos) = (byte)((*(_pdval) > *_DBM) ? *_DBM : *(_pdval)); curpos++;
                            *(_pdval) = *(curpos) * (*_r++); *(curpos) = (byte)((*(_pdval) > *_DBM) ? *_DBM : *(_pdval)); curpos++;*/

                            *(curpos) = LimitToByte(*(curpos) * (*_b++)); curpos++;
                            *(curpos) = LimitToByte(*(curpos) * (*_g++)); curpos++;
                            *(curpos) = LimitToByte(*(curpos) * (*_r++)); curpos++;

                            /* *(_pdval) = *(curpos) * (*_b++); *(curpos) = LimitToByte(_pdval); curpos++;
                             *(_pdval) = *(curpos) * (*_g++); *(curpos) = LimitToByte(_pdval); curpos++;
                             *(_pdval) = *(curpos) * (*_r++); *(curpos) = LimitToByte(_pdval); curpos++;*/
                            //(byte)(((value > 255) ? DOUBLE_BYTE_MAX : value))


                        }                       
                    }
                }
                var dat = new Image<Bgr, Byte>(data);
                pframe = dat.Mat;
            }
            catch
            {
                fixed (byte* pData = data)
                {
                    for (int i = 0; i < 255 * width; i += 4)
                        *(pData + i) = (byte)(i % width);
                }
            }
           // STW.Stop();
           // var c = STW.Elapsed.TotalMilliseconds;
        }
        public static  void Save_double_mass_2xml(double[,,] source, string pPath)
        {
            int Width_Current = source.GetLength(2);
            int Height_Current = source.GetLength(1);
            Mat datamat2 = new Mat(new System.Drawing.Size(Width_Current, Height_Current), Emgu.CV.CvEnum.DepthType.Cv64F, 3);
            WhiteBalance.Convert_DoubleMass2Mat(source, ref datamat2);
            Matrix<Double> datamat3 = new Matrix<Double>(Width_Current, Height_Current, 3);
            datamat2.CopyTo(datamat3);
            System.Xml.Linq.XDocument alpha = Emgu.Util.Toolbox.XmlSerialize<Matrix<Double>>(datamat3);
            alpha.Save(pPath);

        }
    /*    public static void Read_double_mass_from_xml(out double[,,] source, string pPath)
        {
            System.Xml.XmlDocument xDoc_rd = new System.Xml.XmlDocument();
            using (System.IO.FileStream fs = new System.IO.FileStream("shit.xml", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                xDoc_rd.Load(fs);
            }

            Matrix<Double> matrix = (Matrix<Double>)
                (new System.Xml.Serialization.XmlSerializer(typeof(Matrix<Double>))).Deserialize(new System.Xml.XmlNodeReader(xDoc_rd));

            datamat3.Mat.CopyTo(datamat2);
            WhiteBalance.Convert_Mat2DoubleMass(out test_mass, datamat2);
        }*/
        public static unsafe void Convert_DoubleMass2Mat(double[,,] source,ref Mat result_frame)
        {
           

            double[,,] result = result_frame.ToImage<Bgr, Double>().Data;
            int height = result_frame.Height;
            int width = result_frame.Width;
            int WH = width * height;

            double* curpos;
            try
            {
                fixed (double* _source = source)
                {
                    fixed (double* _result = result)
                    {
                        curpos = _result;
                        double* _r = _source, _g = _source + WH, _b = _source + 2 * WH;
                        for (int i = 0; i < WH; i++)
                        {
                            *(curpos) = (*_b); curpos++; _b++;
                            *(curpos) = (*_g); curpos++; _g++;
                            *(curpos) = (*_r); curpos++; _r++;
                        }
                    }
                }
                var a = new Image<Bgr, Double>(result);
                result_frame = a.Mat;
            }
            catch
            {
                fixed (double* pData = result)
                {
                    for (int i = 0; i < 255 * width; i += 4)
                        *(pData + i) = (double)(i % width);
                }
            }
        }

        public static unsafe void Convert_Mat2DoubleMass(out double[,,] res, Mat source_frame)
        {
            double* curpos; //счетчик для data, чтобы удобнее было
          //  int IMISS = 0;
            int height = source_frame.Height;
            int width = source_frame.Width;
            int WH = width * height;

            double[,,] source = source_frame.ToImage<Bgr, Double>().Data;
            res = new double[3, height, width];
            try
            {
                fixed (double* _res = res)
                {
                    fixed (double* _source = source)
                    {
                        curpos = _source;
                        double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                        for (int i = 0; i < WH; i++)
                        {
                            *(_b) = *(curpos); curpos++; _b++;
                            *(_g) = *(curpos); curpos++; _g++;
                            *(_r) = *(curpos); curpos++; _r++;
                        }
                    }
                }
            }
            catch
            {
                fixed (double* _res = res)
                {
                    for (int i = 0; i < 255 * width; i += 4)
                        *(_res + i) = (double)(i % width);
                }
            }
        }
        public static unsafe void Image_InitByValue(ref Mat pframe,byte value = 255)
        {
            byte* curpos;
            int IMISS = 0;

            byte[,,] data = pframe.ToImage<Bgr, Byte>().Data;
            int height = pframe.Height;
            int width = pframe.Width;
            int WH = width * height;
            try
            {

                    fixed (byte* pData = data)
                    {
                        curpos = pData;
                        for (int i = 0; i < WH; i++)
                        {
                            *(curpos) = value; curpos++; IMISS++;
                            *(curpos) = value; curpos++; IMISS++;
                            *(curpos) = value; curpos++; IMISS++;
                        }
                    }
                
                var a = new Image<Bgr, Byte>(data);
                pframe = a.Mat;
            }
            catch
            {
                fixed (byte* pData = data)
                {
                    for (int i = 0; i < 255 * width; i += 4)
                        *(pData + i) = (byte)(i % width);
                }
            }
        }
        public static unsafe void CorrectImage_viaCorrectionMatrix_Color(double[,,] res, ref dynamic pframe)
        {
            byte* curpos;
            byte[,,] data = pframe.Data;
            int height = pframe.Height;
            int width =/* pframe.MIplImage.widthStep;*/ pframe.Width;
            int WH = width * height;
            try
            {
                fixed (double* _res = res)
                {
                    fixed (byte* pData = data)
                    {
                        curpos = pData;
                        double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                        for (int i = 0; i < WH; i++)
                        {
                            *(curpos) = LimitToByte(*(curpos) * (*_b++)); curpos++; 
                            *(curpos) = LimitToByte(*(curpos) * (*_g++)); curpos++;
                            *(curpos) = LimitToByte(*(curpos) * (*_r++)); curpos++; 
                        }
                    }
                }
            }
            catch
            {
                fixed (byte* pData = data)
                {
                    for (int i = 0; i < 255 * width; i += 4)
                        *(pData + i) = (byte)(i % width);
                }
            }
        }
        public static unsafe void CorrectImage_viaCorrectionMatrix_byIndex_Mono(double[,,] res, ref dynamic pframe)
        {     
            byte* curpos;
            int IMISS = 0;
            byte[,,] data = pframe.Data;
            int height = pframe.Height;
            int width = pframe.MIplImage.widthStep; //pframe.Width
            int WH = width * height; 
            try
            {
                fixed (double* _res = res)
                {
                    fixed (byte* pData = data)
                    {
                        curpos = pData;
                        double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                        for (int i = 0; i < height * width; i++)
                        { *(curpos++) = (byte)(*(curpos) * (*_g++)); /*++_g;*/IMISS++; }
                    }
                }
            }
            catch
            {
                fixed (byte* pData = data)
                {
                    for (int i = 0; i < 255 * width; i+=4)
                        *(pData + i) = (byte)(i % width);
                }
            }
            //  double[] b32 = new double[3]; b32[0] = res[0, 1000, 1]; b32[1] = res[1, 1000, 1]; b32[2] = res[2, 1000, 1];
        }
        public static unsafe void CorrectionMatrix_AddImage(ref double[,,] res, ref dynamic pframe)
        {
            byte* curpos;
            byte[,,] data = pframe.Data;
            int height = pframe.Height;
            int width =/* pframe.MIplImage.widthStep;*/ pframe.Width;
            int WH = width * height;
            try
            {
                fixed (double* _res = res)
                {
                    fixed (byte* pData = data)
                    {
                        curpos = pData;
                        double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                        for (int i = 0; i < WH; i++)
                        {
                            *_b += *(curpos++); _b++;
                            *_g += *(curpos++); _g++;
                            *_r += *(curpos++); _r++;
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public static unsafe void CorrectionMatrix_AddImage(ref double[,,] res, ref Mat pframe)
        {
            byte* curpos;
            byte[,,] data = pframe.ToImage<Bgr, Byte>().Data;
            int height = pframe.Height;
            int width =  pframe.Width;
            int WH = width * height;
            try
            {
                fixed (double* _res = res)
                {
                    fixed (byte* pData = data)
                    {
                        curpos = pData;
                        double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                        for (int i = 0; i < WH; i++)
                        {
                            *_b += *(curpos++); _b++;
                            *_g += *(curpos++); _g++;
                            *_r += *(curpos++); _r++;
                        }
                    }
                }
            }
            catch
            {

            }
        }
        /*public static unsafe void CorrectionMatrix_AddImage(ref Mat result, Mat pframe)
        {
            result = result + pframe;
            byte* curpos;
            byte[,,] data = pframe.Data;
            int height = pframe.Height;
            int width = pframe.Width;
            int WH = width * height;
            try
            {
                fixed (double* _res = res)
                {
                    fixed (byte* pData = data)
                    {
                        curpos = pData;
                        double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                        for (int i = 0; i < WH; i++)
                        {
                            *_b += *(curpos++); _b++;
                            *_g += *(curpos++); _g++;
                            *_r += *(curpos++); _r++;
                        }
                    }
                }
            }
            catch
            {

            }
        }*/
        public static unsafe double[,,] CorrectionMatrix_fromImage(string Path)
        {

            Mat data = new Emgu.CV.Image<Bgr,Byte>(Path).Mat;
            double[,,] result = new double[3, data.Height, data.Width];
            InitializeMatrix(0,ref result, data.NumberOfChannels, data.Height, data.Width);
            WhiteBalance.CorrectionMatrix_AddImage(ref result, ref data);
            WhiteBalance.CorrectionMatrix_NormalizeByValue(ref result, data.Width, data.Height,255);
            return result;
        }
        public static unsafe double[,,] CorrectionMatrix_fromMatFile(string Path)
        {
            Mat source = new Mat(Path, Emgu.CV.CvEnum.ImreadModes.AnyColor);
            double[,,] result = new double[3, source.Height, source.Width];
            WhiteBalance.Convert_Mat2DoubleMass(out result, source);
            return result;
        }
        public static unsafe void CorrectionMatrix_AverageFromImages(ref double[,,] res, int NumOfIMG, int height, int width)
        {
            int WH = width * height;
            try
            {
                fixed (double* _res = res)
                {
                    double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                    for (int i = 0; i < WH; i++)
                    {
                        *_b /= NumOfIMG; _b++;
                        *_g /= NumOfIMG; _g++;
                        *_r /= NumOfIMG; _r++;
                    }
                }
            }
            catch
            {

            }
        }
        public static unsafe void CorrectionMatrix_FromNormilizedMatrix_Fastest(ref double[,,] res,double CPower,int width,int height)
        {
            int  WH = width * height;
            double sred = 0.0;
            double Maximum = 0, CurMax = 0;
            try
            {
                double* curpos;
                fixed (double* _res = res)
                {
                    double RevCPower = 1 - CPower;
                    double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                    for (int h = 0; h < height; h++)
                    {
                        curpos = /*startpix + h * bd.Stride*/_res;
                        for (int w = 0; w < width; w++)
                        {
                            sred = (((*_b) + (*_g) + (*_r)) / 3.0);
                            sred = TripleMin(*_b, *_g, *_r); //31082020. Сделано, как временное решение для того, чтобы избежать использования 
                                                             //в сравнении в далее применяемой функции LimitToByte. Сравнение сильно замедляло
                            *_b = RevCPower + CPower * (sred / (*_b + 1));  // Самая упрощенная интерпритация выражения
                            *_g = RevCPower + CPower * (sred / (*_g + 1)); //(sred / (*_b+1)) + (1-(sred / (*_b+1)))*(1-CPower)
                            *_r = RevCPower + CPower * (sred / (*_r + 1));
                           
                         /*      CurMax = TripleMax(_b, _g, _r);
                            if (CurMax > Maximum)
                                Maximum = CurMax;*/
                            ++_b; ++_g; ++_r;
                        }
                    }
                //  if (Maximum > 3) Maximum = 1.1;
                     /* for (int h = 0; h < height; h++)
                      {
                          for (int w = 0; w < width; w++)
                          {
                              res[0, h, w] /= Maximum;
                              res[1, h, w] /= Maximum;
                              res[2, h, w] /= Maximum;
                          }
                      }*/
                }
            }
            finally
            {
               // bmp.UnlockBits(bd);
            }
            //           double[] b32 = new double[3]; b32[0] = res[0, 0, 0]; b32[1] = res[1, 0, 0]; b32[2] = res[2, 0,0];
        }
        public static unsafe void CorrectionMatrix_NormalizeByValue(ref double[,,] res, int width, int height, double val)
        {
            int WH = width * height;
            double sred = 0.0;
            double Maximum = 0, CurMax = 0;
            try
            {
                double* curpos;
                fixed (double* _res = res)
                {
                    double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                    for (int h = 0; h < height; h++)
                    {
                        curpos = /*startpix + h * bd.Stride*/_res;
                        for (int w = 0; w < width; w++)
                        {
                            *_b = (*_b) / (double)val;
                            *_g = (*_g) / (double)val;
                            *_r = (*_r) / (double)val;

                            ++_b; ++_g; ++_r;
                        }
                    }
                }
            }
            finally
            {
            }
        }

        public static unsafe void CorrectImage_viaCorrectionMatrix(double[,,] res, ref dynamic pframe)
        {
            int width = pframe.Width, height = pframe.Height, WH = width * height;
            /*  BitmapData bd = pframe.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite,
                  PixelFormat.Format24bppRgb);*/
            try
            {
                fixed (double* _res = res)
                {
                    double* _r = _res, _g = _res + WH, _b = _res + 2 * WH;
                    for (int h = 0; h < height; h++)
                    {
                        for (int w = 0; w < width; w++)
                        {
                            pframe.Data[w, h, 2] *= (*_b); ++_b;
                            pframe.Data[w, h, 1] *= (*_g); ++_g;
                            pframe.Data[w, h, 0] *= (*_r); ++_r;
                        }
                    }
                }
            }
            finally
            {

            }
            //  double[] b32 = new double[3]; b32[0] = res[0, 1000, 1]; b32[1] = res[1, 1000, 1]; b32[2] = res[2, 1000, 1];
        }

    }
}

using System;
//using OSGeo.GDAL;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;


namespace Stereo_Vision
{
    public class WhiteBalance
    {

        private double percentForBalance = 0.6;

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
            if (value < 0)  return 0; 
            else return ((value > 255) ? (byte)255 : (byte)value);
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
        public static string CompareMassives_special(Bitmap bmp, double[,,] m1, double[,,] m2)
        {
            string res = "true";
            int width = bmp.Width, height = bmp.Height;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    for (int k = 0; k < 3; k++)
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
        public static unsafe void CorrectImage_viaCorrectionMatrix_Color(double[,,] res, ref Image<Bgr, byte> pframe)
        {
            byte* curpos;
            int IMISS = 0;
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
                        double* _r = _res, _g = _res + WH, _b = _res + 2*WH;
                        for (int i = 0; i < WH; i++)
                        {
                            *(curpos) = LimitToByte(*(curpos) * (*_b++)); curpos++; IMISS++;
                            *(curpos) = LimitToByte(*(curpos) * (*_g++)); curpos++; IMISS++;
                            *(curpos) = LimitToByte(*(curpos) * (*_r++)); curpos++; IMISS++;
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
        public static unsafe void CorrectionMatrix_Normalize(ref double[,,] res, int NumOfIMG, int height, int width)
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
       /* public static unsafe void ImageEdit_Mono(ref Image<Gray, byte> pframe)
        {
            var data = pframe.Data;
           // pframe.SetRandUniform(new MCvScalar(), new MCvScalar(255));
             int stride = pframe.MIplImage.widthStep;
            int H = pframe.Height;
             fixed (byte* pData = data)
             {
                 for (int i = 0; i < H * stride; i+=2) 
                     *(pData + i) = (byte)(i % stride);
             }
        }*/
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
        public static void Convert_CorM2BMP(double [,,] CM,ref Bitmap pBMP)
        {
            int W = pBMP.Width, H = pBMP.Height;
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    try
                    {
                        pBMP.SetPixel(i, j, Color.FromArgb(LimitToByte(255*CM[i, j, 0]),
                                                           LimitToByte(255*CM[i, j, 1]),
                                                            LimitToByte(255*CM[i, j, 2])));

                    }
                    catch (Exception e)
                    {
                        pBMP.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }            
        }
    }
}

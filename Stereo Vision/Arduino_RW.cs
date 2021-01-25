using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LattePanda.Firmata;
using System.ComponentModel;

namespace Stereo_Vision
{
    class Arduino_RW : IDisposable
    {
        //main things
        Arduino Panduino;
        bool Measuring_Completed = true;

        float _Voltage_critical_measured = 0;
        float TimeLeft_critical_percents = 0;
        float _Voltage_measured_previous = 4.482f;
        float? _Voltage_measured = 4.482f;
        float? Voltage_measured
        {
            set
            {
                // var 
                if(value.Equals(null))
                {
                    Log("Value is equal to NULL");
                    _Voltage_measured = _Voltage_measured_previous;
                }
                else
                {
                //    Log("Value is equal to " + value.ToString());
                    _Voltage_measured_previous = (float)_Voltage_measured;
                    _Voltage_measured = value;
                }

                var TL = Gained_voltage_2_timeleft((float)_Voltage_measured);
                Log("Timeleft (minutes):" + TL.ToString());
                var TL_p = TimeLeft_2_Percents(TL);
              //  Log("Timeleft %:" + TL_p.ToString());
                ChargeLevel_onUpdated(TL_p);

                if (value < _Voltage_critical_measured)
                {
                    ChargeLevel_OnCriticalLevel(TL_p);
                }
            }
            get
            {
                // this is done because _Voltage_measure can be null because of some errors.
                return _Voltage_measured.Equals(null)? _Voltage_measured_previous : (float)_Voltage_measured;
            }
        }

        //curves
        //Real voltage values of battery. V(t) - this is V
        static float[] Real_Voltage_values = { 12.45f, 12.05f, 11.95f, 11.81f, 11.64f, 11.45f, 11.26f, 11.09f, 10.94f, 10.79f,
              10.66f, 10.47f, 10.21f, 9.68f, 8.91f, 8.63f, 8.3f, 8.17f};
        //Nearest coef identical to real voltage devider
        static float C_Real2Gained = 0.36f;
        //This is from math: Real_Voltage_values * Real2Gained_coef = Gained_Voltage_values_1
        static float[] Gained_Voltage_values_1 = { 4.482f, 4.338f, 4.302f, 4.2516f, 4.1904f, 4.122f, 4.0536f, 3.9924f, 3.9384f,
            3.8844f, 3.8376f, 3.7692f, 3.6756f, 3.4848f, 3.2076f, 3.1068f, 2.988f, 2.9412f };

        // V(t) - this is t                                                                                  //fgfffffffffgfgjkjhfkj sasha durak i loh i ne umeet kodit`
        static float[] Times_minutes = { 0, 5f, 10f, 20f, 30f, 40f, 52f, 62f, 72f, 81f, 88f, 101f, 120f, 145f, 160f, 161f, 162f, 162.5f };
        //This is max(t)-t
        static float[] Times_left_minutes = { 162.5f, 157.5f, 152.5f, 142.5f, 132.5f, 122.5f, 110.5f, 100.5f, 90.5f, 81.5f, 74.5f,61.5f,
            42.5f, 17.5f, 2.5f, 1.5f, 0.5f, 0f };

        //Percents is calculated from timeleft, because it's linear in contrast to voltage, that is just close to linear
        //Coef to linear convert Timeleft to %
        static float C_TimeLeft2Percents = 0.615f; //  это 1/1.625 = 1/(162.5/100) , перевод в проценты по времени
        //This  is result of t*TimeLeft2Percents
        static float[] Percentage_left = {100f, 90.7f, 88.3f, 85.0f, 81.1f, 76.6f, 72.2f, 68.2f, 64.7f, 61.2f, 58.2f, 53.7f, 47.7f, 35.3f,
            17.3f, 10.7f, 3.0f, 0f };//проценты по аккуму
        //Number of points
        static int points = Gained_Voltage_values_1.Count();

        //threads
        BackgroundWorker BGW_Thread = new BackgroundWorker();

        //events
        public delegate void ChargeLevel(int percentage);
        public event ChargeLevel ChargeLevel_onUpdated;

        public delegate void ChargeLevelCritical(int percentage);
        public event ChargeLevelCritical ChargeLevel_OnCriticalLevel;

        public delegate void ChargeLevel_Message(string Message);
        public event ChargeLevel_Message ChargeLevel_NewMessage;


        public Arduino_RW(float pTimeLeft_critical_percents, float Initial_percents)
        {        
            Log("\nStarted!");
            Log("\nInit Arduino...");
            Panduino = new Arduino();
            TimeLeft_critical_percents = pTimeLeft_critical_percents;
            _Voltage_critical_measured = Convert_TimePercent_toVoltage(pTimeLeft_critical_percents);
            _Voltage_measured = 4.482f; //Convert_TimePercent_toVoltage(Initial_percents);
            Panduino.pinMode(0, Arduino.ANALOG);
            BGW_Thread.DoWork += new DoWorkEventHandler(this.BGW_Thread_DoWork);
            BGW_Thread.RunWorkerCompleted += BGW_Thread_RunWorkerCompleted;
            BGW_Thread.WorkerSupportsCancellation = true;
            BGW_Thread.RunWorkerAsync();
        }

        private void BGW_Thread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Measuring_Completed = true;
        }

        ~Arduino_RW()
        {
            this.Dispose();
        }

        public virtual void Dispose()
        {
            BGW_Thread.CancelAsync();
            while (!Measuring_Completed || BGW_Thread.IsBusy)
            {
                System.Threading.Thread.Sleep(200);
                System.Windows.Forms.Application.DoEvents();   //waiting for closing
            }
            Panduino.Close();
            GC.SuppressFinalize(this);
        }

        private void BGW_Thread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Random a = new Random();
            while (true)
            {
                Measuring_Completed = false;
                if (Panduino.isOpen() && !BGW_Thread.CancellationPending)
                {
                    Voltage_measured = Measure_Voltage(false, ref worker, Panduino, Log);
                 //  Voltage_measured = (float)(3.48 + a.NextDouble());
                   // System.Threading.Thread.Sleep(500);
                }
                else
                {
                    Log("\n Failed to open Arduino...");
                }
                Measuring_Completed = true;
                if (BGW_Thread.CancellationPending)
                    break;
            }
            Measuring_Completed = true; //let it be here, just for case
        }

        
        public void Log(string pMes)
        {
            ChargeLevel_NewMessage?.Invoke(pMes);
        }

        public static float Gained_voltage_2_timeleft(float pGained_voltage)
        {
            float result = 0;
            //Обнаруживаем, к какому отрезку линейности принадлежит наше напряжение
            int i = 0, MinIndex = 0, MaxIndex = points - 1;
            for (i = 0; i < points; i++)
            {
                float ad = Real_Voltage_values[i] * C_Real2Gained;
                if (Real_Voltage_values[i] * C_Real2Gained - 0.001 <= pGained_voltage)
                { MinIndex = i - 1; MaxIndex = i; break; }
            }
            if (MinIndex < 0) return 162.5f;
            if ((MinIndex == 0) && (MaxIndex == points - 1)) return 0;

            result = Interpolate_Y(Times_left_minutes[MinIndex], Times_left_minutes[MaxIndex],
                Real_Voltage_values[MinIndex] * C_Real2Gained, Real_Voltage_values[MaxIndex] * C_Real2Gained, pGained_voltage);
            return result;
        }

        public static int TimeLeft_2_Percents(float pTimeLeft) //Переводит время в процент от максимального времени жизни
        {
            return ((int)Math.Round(pTimeLeft * C_TimeLeft2Percents));
        }

        public static float Percents_2_Timeleft(int pPercents) //Переводит процент от максимального времени жизни в время 
        {
            return ((float)pPercents / C_TimeLeft2Percents);
        }

        private static float Interpolate_Y(float maxY, float minY,float maxX, float minX, float currentX )
        {
            float res = -1.0f;
            if (currentX > maxX) return maxY;
            else if (currentX < minX) return minY;
            else
            {
                res = ((currentX - minX) * (maxY - minY) / (maxX - minX)) + minY;
            }
            if (res < 0) return -1;
            else return res;
        }
        private float Convert_TimePercent_toVoltage(float TimeLeft_percents)
        {
            return 0.0f;
        }

        private static float? Measure_Voltage(bool p_isDebug,ref BackgroundWorker BGW, Arduino p_arduino, Action<string> pLog = null)
        {
            bool cancelled = BGW.CancellationPending;
            float? end_val = null;
            var endval2 = 0.0f;

            bool NeedLogging = p_isDebug && (pLog != null);
            List<float> vol_mass = new List<float>();

            for (int i = 0; i < 10; i++)
            {
              //  if (NeedLogging) pLog("Reading from pin " + 0 + "...");
                int Value = p_arduino.analogRead(0);//Read the state of pin 0
                                                     // Console.WriteLine(Value);
                                                     // Console.WriteLine("Value=" + Value);
                if (Value != 0) vol_mass.Add(Value);
               // if (NeedLogging) pLog("Voltage Value=" + ((Value * 5.00f) / 1023).ToString() + " v. ");
                System.Threading.Thread.Sleep(500);
                if (BGW.CancellationPending) return null;               
            }
            for (int i = 0; i < vol_mass.Count(); i++)
            {
                endval2 += vol_mass[i];
            }
            if (!endval2.Equals(null)) end_val = endval2;
            if (NeedLogging) pLog("Measured value " + end_val.ToString());

            if (BGW.CancellationPending) return null;
            if (end_val.Equals(null)) return null;
            if (float.IsNaN((float)end_val)) return null;

            end_val /= vol_mass.Count();
            end_val = ((float)((float)((end_val / 1023.00f) * 5))) / 1.00f;

            if (NeedLogging) pLog("Measured voltage: " + ((float.IsNaN((float)end_val)) ? "?" : end_val.ToString()) + " v");
            if (NeedLogging) pLog("Real voltage: " + ((float.IsNaN((float)end_val)) ? "?" : (end_val / 0.36f).ToString()) + " v");
            return end_val;
        }

        [Obsolete]
        public static float GetChargeLevel_Voltage(ref System.ComponentModel.BackgroundWorker ppWorker,bool isDebug,ref bool pp_isArdclosed)
        {
            if (!isDebug)
            {
                try
                {
                    List<float> vol_mass = new List<float>();
                    // Console.WriteLine("\nReinit Arduino...");
                    
                    Arduino p_arduino;
                    try { p_arduino = new Arduino(); pp_isArdclosed = false; }
                    catch { p_arduino = null; pp_isArdclosed = true; }
                    Check_2CloseThisArd(ref ppWorker, ref p_arduino, ref pp_isArdclosed);
                    for (int i = 0; i < 30; i++)
                    {
                        Check_2CloseThisArd(ref ppWorker, ref p_arduino,ref pp_isArdclosed);
                        // Console.WriteLine("Reading from pin " + 0 + "...");
                        int Value = p_arduino.analogRead(0);//Read the state of pin 0
                                                            // Console.WriteLine(Value);
                                                            // Console.WriteLine("Value=" + Value);
                        if (Value != 0) vol_mass.Add(Value);
                        // Console.WriteLine("Voltage Value=" + ((Value * 5.00f) / 1023).ToString() +" v. ");
                        p_arduino.callAnalogPinUpdated(0, 1);
                        System.Threading.Thread.Sleep(1000);
                        Check_2CloseThisArd(ref ppWorker, ref p_arduino,ref pp_isArdclosed);
                    }
                    p_arduino.StopListen();
                    p_arduino.Close();
                    pp_isArdclosed = true;
                    float end_val = 0;
                    for (int i = 0; i < vol_mass.Count(); i++)
                    {
                        end_val += vol_mass[i];
                    }
                    end_val /= vol_mass.Count();
                    end_val = end_val * 0.0048876f;//аналог ((end_val / 1023.00f) * 5);
                                                   // end_val = ((end_val / 1023.00f) * 5);
                    end_val = 4.5f;
                    // p_arduino.callAnalogPinUpdated(0, 1);
                   
                    return end_val;
                }
                catch { return -1f; }
            }
            else
            {
                bool stop = false;
                pp_isArdclosed = false;
                for (int i = 0; i < 5; i++)
                {
                    if (ppWorker.CancellationPending == true)
                    {
                        stop =   true;
                        pp_isArdclosed = true;
                    }

                 //   System.Threading.Thread.Sleep(1000);
                    if (ppWorker.CancellationPending == true)
                    {
                        stop =   true;
                        pp_isArdclosed = true;
                    }
                    pp_isArdclosed = true;
                }
                return ((float)(new Random().Next(350,500)))/100.0f;
            }

        }

        private static void Check_2CloseThisArd(ref System.ComponentModel.BackgroundWorker pppWorker, ref Arduino ppArduino,ref bool ppp_isArdClosed)
        {
            if ((pppWorker.CancellationPending == true)&&(ppArduino!=null))
            {
                ppArduino.StopListen();
                ppArduino.Close();
                ppp_isArdClosed = true;
            }
        }
        public static void ToogleCharge_Level(ref System.Drawing.Bitmap pBMP_Charge,ref string pText_to_write, int pPercents)
        {
            pText_to_write = "N%";
            if (pPercents > 79)
            {
                pBMP_Charge = new System.Drawing.Bitmap(MainWindow.BMP2set_chargelev_100_80);
            }
            else if ((pPercents <= 79) && (pPercents > 59))
            {
                pBMP_Charge = new System.Drawing.Bitmap(MainWindow.BMP2set_chargelev_80_60);
            }
            else if ((pPercents <= 59) && (pPercents > 39))
            {
                pBMP_Charge = new System.Drawing.Bitmap(MainWindow.BMP2set_chargelev_60_40);
            }
            else if ((pPercents <= 39) && (pPercents > 20))
            {
                pBMP_Charge = new System.Drawing.Bitmap(MainWindow.BMP2set_chargelev_40_20);
            }
            else
            {
                pBMP_Charge = new System.Drawing.Bitmap(MainWindow.BMP2set_chargelev_20_0);
            }
            pText_to_write = pPercents.ToString()+"%";
        }
    }
}

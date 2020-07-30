using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using LattePanda.Firmata;

namespace ConsoleApplication1
{
    class Program
    {
        // static Arduino p_arduino = new Arduino();
        //this code is just for Arduino itself
        /*float voltage;
        void setup()
        {
            Serial.begin(9600);
            while (!Serial)
            {

            }
        }
        void loop()
        {
            //do smth
          //  voltage++;
           // Serial.println(voltage);
            delay(1000);
        }*/

        static void Main(string[] args)
        {
            //p_arduino.pinMode(0, Arduino.PWM);
            // SomeLEDTest_digital(ref p_arduino);
            //        SomeLEDTest_analog(ref p_arduino);
            ///Start_monitoring(ref p_arduino);

            bool isdown = false;

            while (true)
            {
                List<float> vol_mass = new List<float>();
                Console.WriteLine("\nReinit Arduino...");
                Arduino p_arduino2 = new Arduino();
                if (!p_arduino2.isOpen())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("Reading from pin " + 0 + "...");
                        int Value = p_arduino2.analogRead(0);//Read the state of pin 0
                                                             // Console.WriteLine(Value);
                                                             // Console.WriteLine("Value=" + Value);
                        if (Value != 0) vol_mass.Add(Value);
                         Console.WriteLine("Voltage Value=" + ((Value * 5.00f) / 1023).ToString() +" v. ");
                        p_arduino2.callAnalogPinUpdated(0, 1);
                        Thread.Sleep(1000);
                    }
                    float end_val = 0;
                    for (int i = 0; i < vol_mass.Count(); i++)
                    {
                        end_val += vol_mass[i];
                    }
                    end_val /= vol_mass.Count();
                    end_val = ((float)((float)((end_val / 1023.00f) * 5))) / 1.00f;
                    Console.WriteLine("Measured voltage (2 signs) : " + end_val.ToString()+" v");
                    Console.Write("\nThen real voltage is " + (end_val / 0.36f).ToString() + " v");
                    p_arduino2.StopListen();
                    p_arduino2.callAnalogPinUpdated(0, 1);
                    p_arduino2.Close();
                }
                else
                { //try again}

                }

            }
        }
        private static void Start_monitoring(ref Arduino arduino)
        {
            int pin_is = 1;
            //arduino.pinMode(13,Arduino.PWM);
            Console.WriteLine("Reading from pin "+ pin_is);
            int Value = arduino.analogRead(pin_is);//Read the state of pin 0
            Console.WriteLine(Value);
          
            arduino.analogPinUpdated += Arduino_analogPinUpdated;//Add Event Listeners and call it when the analog input update.

        }
        private static void Arduino_analogPinUpdated(int pin, int value)
        {
            if (pin == 1)
            {
                Console.WriteLine("Pin:"+pin);
                Console.WriteLine("Value="+value);
                Console.WriteLine("Voltage Value=" + ((value*5.00f)/1023).ToString());
            }
        }


    
        static void SomeLEDTest_digital(ref Arduino arduino)
        {
            arduino.pinMode(13, Arduino.OUTPUT);//Set the digital pin 13 as output
            while (true)
            {
                // ==== set the led on or off
                arduino.digitalWrite(13, Arduino.HIGH);//set the LED　on
                Thread.Sleep(200);//delay a seconds
                arduino.digitalWrite(13, Arduino.LOW);//set the LED　off
                Thread.Sleep(200);//delay a seconds
            }
        }
        static void SomeLEDTest_analog(ref Arduino arduino)
        {
            int pinis = 13;
            arduino.pinMode(pinis, Arduino.PWM);//Set the digital pin 13 as output
                                             // ==== set the led on or off
            int s4et = 0;
            while(true)
            {
                for(int i =0;i<256;i+=15)
                {
                    arduino.analogWrite(pinis, i);
                    s4et++;
                    Console.WriteLine("New move. COUNT OF COMMANDS IS " + s4et);
                    Thread.Sleep(0);
                }
                for(int i = 255;i>-1;i-=15)
                {
                    arduino.analogWrite(pinis, i);
                    s4et++;
                    Console.WriteLine("New move. COUNT OF COMMANDS IS " + s4et);
                    Thread.Sleep(0);
                }
                Console.WriteLine("New cycle. COUNT OF COMMANDS IS " + s4et);
            }
                //set the LED　on
             //   Thread.Sleep(200);//delay a seconds
                    
        }
    }
}

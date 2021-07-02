/*
 * Firmata is a generic protocol for communicating with microcontrollers
 * from software on a host computer. It is intended to work with
 * any host computer software package.
 *
 * To download a host software package, please clink on the following link
 * to open the download page in your default browser.
 *
 * http://firmata.org/wiki/Download
 */

/* Supports as many analog inputs and analog PWM outputs as possible.
 *
 * This example code is in the public domain.
 */
#include <Firmata.h>

byte analogPin = 0;
unsigned long currentMillis;     // store the current value from millis()
unsigned long previousMillis;    // for comparison with currentMillis
unsigned int Delay_ms = 100;
void analogWriteCallback(byte pin, int value)
{    
        analogWrite(PIN_TO_PWM(13), value);
}

void setup()
{
    Firmata.setFirmwareVersion(0, 1);
    Firmata.attach(ANALOG_MESSAGE, analogWriteCallback);
    Firmata.begin(57600);
    pinMode(PIN_TO_DIGITAL(13), OUTPUT);
}

void loop()
{
    while(Firmata.available()) {
        Firmata.processInput();
    }
    // do one analogRead per loop, so if PC is sending a lot of
    // analog write messages, we will only delay 1 analogRead
    //Firmata.sendAnalog(0, analogRead(0)); 
    
    //24/05/2021 test_2 for read stability. Result: read - ? need more tests. Writing - nice
    currentMillis = millis();
    if(currentMillis - previousMillis > Delay_ms) {  
          previousMillis += Delay_ms;                   // run this every 20mss
          Firmata.sendAnalog(0, analogRead(0));    
    }
  
    //24/05/2021 test_1 for read stability. Result: read - ? Writing - laggy
  //  Firmata.sendAnalog(analogPin, analogRead(analogPin)); 
  //  analogPin = analogPin + 1;
  //  if (analogPin >= TOTAL_ANALOG_PINS) analogPin = 0;
    
       //24/05/2021 test_2 for read stability. Result: read - some shit. Writing - laggy
   // Firmata.sendAnalog(0, analogRead(0)); 
}

